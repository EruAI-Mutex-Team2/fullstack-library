using libraryApp.backend.Dtos;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using libraryApp.backend.Repository.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace libraryApp.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitapController : ControllerBase
    {
        private readonly IkitapRepository _kitapRepo;
        private readonly IsayfaRepository _sayfaRepo;
        private readonly IkitapOduncRepository _kitapOduncRepo;
        private readonly IuserRepository _userRepo;
        private readonly ImesajRepository _mesajRepo;
        private readonly IkitapYayinTalebiRepository _kitapYayinTalebiRepo;

        public KitapController(IkitapRepository kitapRepo, IkitapOduncRepository kitapOduncRepo, IuserRepository userRepo, IkitapYayinTalebiRepository kitapYayinTalebiRepository, IsayfaRepository sayfaRepository, ImesajRepository mesajRepository)
        {
            _kitapRepo = kitapRepo;
            _kitapOduncRepo = kitapOduncRepo;
            _userRepo = userRepo;
            _kitapYayinTalebiRepo = kitapYayinTalebiRepository;
            _sayfaRepo = sayfaRepository;
            _mesajRepo = mesajRepository;
        }


        [HttpGet("kitapYayinlamaİstekleri")] //getbookpublishrequests
        public async Task<IActionResult> kitapYayinlamaİstekleri()
        {
            var kitapYayinlamaİstekleri = await _kitapYayinTalebiRepo.kitapYayinTalepleri.Where(kyt => kyt.BeklemedeMi).Include(kyt => kyt.kitap).ThenInclude(k => k.kitapYazarlari).ThenInclude(ky => ky.user).OrderBy(kyt => kyt.TalepTarihi).ToListAsync();
            return Ok(kitapYayinlamaİstekleri.Select(kyt => new kitapYayinTalepleridto
            {
                kitapYazarlari = kyt.kitap.kitapYazarlari.Select(ky => ky.user.Isim).ToList(),
                kitapIsmi = kyt.kitap.Isim,
                kitapId = kyt.KitapId,
                Id = kyt.Id,
                talepTarihi = kyt.TalepTarihi,
            }));
        }


        [HttpPost("yayinlamaIstegiAt")] //yazarın kitap yayınlama isteği atması
        public async Task<IActionResult> yayinlamaIstegiAt([FromBody] int kitapId)
        {
            var kitap = await _kitapRepo.GetkitapByIdAsync(kitapId);
            if (kitap == null) return NotFound(new { Message = "Kitap bulunamadı." });
            if (kitap.KitapYayinlandiMi) return BadRequest(new { Message = "Kitabın zaten yayınlandı." });
            if (_kitapYayinTalebiRepo.kitapYayinTalepleri.Any(kyt => kyt.BeklemedeMi && kyt.KitapId == kitapId))
                return BadRequest(new { Message = "Aktif isteğin var." });

            await _kitapYayinTalebiRepo.AddkitapYayinTalebiAsync(new kitapYayinTalebi()
            {
                KitapId = kitapId,
                BeklemedeMi = true,
                TalepTarihi = DateTime.UtcNow,
            });
            return Ok(new { Message = "İstek gönderildi." });
        }


        [HttpGet("kitapArama")] //getbooksbyname

        public async Task<IActionResult> kitapArama([FromQuery] string? kitapIsmi)
        {
            var kitaplar = await _kitapRepo.kitaplar.Where(k => k.Isim.Contains(kitapIsmi ?? "") && k.KitapYayinlandiMi).Take(20).Include(k => k.kitapOduncIstekleri).Select(k => new kitapdto
            {
                Id = k.Id,
                kitapIsmi = k.Isim,
                kitapYazarlari = k.kitapYazarlari.Select(ky => ky.user.Isim).ToList(),
                oduncAlindiMi = k.kitapOduncIstekleri.Any(koi => koi.KitapId == k.Id && koi.BeklemedeMi == false && koi.OnaylandiMi && koi.DondurulduMu),
                yayinlanmaTarihi = k.YayinlanmaTarihi,
            }).ToListAsync();
            return Ok(kitaplar);
        }
        [HttpGet("kitapOduncIstekleri")] //kitap ödünç istekleri

        public async Task<IActionResult> kitapOduncIstekleri()
        {

            var kitapOduncIstekleridto = await _kitapOduncRepo.kitapOduncler.Where(ko => !ko.OnaylandiMi).Include(ko => ko.kitap).Include(ko => ko.user).OrderBy(ko => ko.TalepTarihi).Select(ko => new kitapOduncIstekleridto
            {
                Id = ko.Id,
                isteyenKisiIsmi = ko.user.Isim + " " + ko.user.SoyIsim,
                talepTarihi = ko.TalepTarihi,
                donusTarihi = ko.DonusTarihi,
            }).ToListAsync();

            return Ok(kitapOduncIstekleridto);
        }


        [HttpPost("kitapOlustur")] //yazarın daha yayınlanmamış kitap oluşturması

        public async Task<IActionResult> kitapOlustur([FromBody] int yazarId)
        {
            if (!_userRepo.users.Any(u => u.Id == yazarId)) return NotFound(new { Message = "Yazar bulunamadı." });
            await _kitapRepo.AddkitapAsync(new kitap
            {
                KitapYayinlandiMi = false,
                YayinlanmaTarihi = DateTime.MinValue,
                kitapYazarlari = [
                    new kitapYazari(){
                        UserId = yazarId,
                    }
                ]
            });
            return Ok(new { Message = "Kitap oluşturuldu" });
        }

        [HttpGet("oduncAlinanKitaplariGetir")]
        public async Task<IActionResult> oduncAlinanKitaplariGetir([FromRoute] int oduncAlanId)
        {
            if (!_userRepo.users.Any(u => u.Id == oduncAlanId)) return NotFound();

            var kitapoduncler = await _kitapOduncRepo.kitapOduncler.Where(ko => ko.UserId == oduncAlanId && ko.DondurulduMu == false && ko.OnaylandiMi == true).Include(ko => ko.kitap).ThenInclude(k => k.kitapYazarlari).ThenInclude(ky => ky.user).ToListAsync();
            var kitapdtos = kitapoduncler.Select(b => new kitapdto
            {
                Id = b.KitapId,
                kitapIsmi = b.kitap.Isim,
                yayinlanmaTarihi = b.kitap.YayinlanmaTarihi,
                kitapYazarlari = b.kitap.kitapYazarlari.Select(ky => ky.user.Isim).ToList(),
            });

            return Ok(kitapdtos);
        }

        [HttpGet("yazarinKitaplariniGetir")]

        public async Task<IActionResult> yazarinKitaplariniGetir([FromRoute] int yazarId)
        {
            var kitaplar = await _kitapRepo.kitaplar.Include(k => k.kitapYazarlari).Where(k => k.kitapYazarlari.Any(ky => ky.UserId == yazarId)).ToListAsync();

            var kitapdtos = kitaplar.Select(b => new kitapdto
            {
                Id = b.Id,
                kitapIsmi = b.Isim,
                yayinlanmaTarihi = b.YayinlanmaTarihi,
            });

            return Ok(kitapdtos);

        }

        [HttpPost("sayfaEkle")]
        public async Task<IActionResult> sayfaEkle([FromBody] sayfa sf)
        {
            if (!_kitapRepo.kitaplar.Any(k => k.Id == sf.KitapId)) return NotFound();
            await _sayfaRepo.AddsayfaAsync(new sayfa
            {
                Icerik = sf.Icerik,
                SayfaNo = sf.SayfaNo,
                KitapId = sf.KitapId,
            });
            return Ok();
        }

        [HttpPut("yayinlamaIstegineCevapVer")]
        public async Task<IActionResult> yayinlamaIstegineCevapVer([FromBody] yayinlamaIstegidto yayinIstekDto)
        {
            var yayinlamaIstegi = await _kitapYayinTalebiRepo.kitapYayinTalepleri.FirstOrDefaultAsync(kyt => kyt.Id == yayinIstekDto.yayinIstekId);
            if (yayinlamaIstegi == null) return NotFound();

            yayinlamaIstegi.OnaylandiMi = yayinIstekDto.OnaylandiMi;
            yayinlamaIstegi.BeklemedeMi = false;
            await _kitapYayinTalebiRepo.UpdatekitapYayinTalebiAsync(yayinlamaIstegi);
            return Ok();
        }

        [HttpPut("kitapIadeEt")]
        public async Task<IActionResult> kitapIadeEt([FromBody] int kitapId)
        {
            var kitapOdunc = await _kitapOduncRepo.kitapOduncler.FirstOrDefaultAsync(ko => ko.KitapId == kitapId && ko.DondurulduMu == false && ko.OnaylandiMi);

            if (kitapOdunc == null) return NotFound();

            kitapOdunc.DondurulduMu = true;
            await _kitapOduncRepo.UpdatekitapOduncAsync(kitapOdunc);
            return Ok();
        }

        [HttpGet("kitapOku")]
        public async Task<IActionResult> kitapOku([FromRoute] int kitapId)
        {
            kitap? kitapp = await _kitapRepo.kitaplar.Include(k => k.sayfalar).FirstOrDefaultAsync(k => k.Id == kitapId);

            if (kitapp == null) return NotFound();

            kitapOkudto okudto = new kitapOkudto
            {
                sayfalar = kitapp.sayfalar,
                kitapIsmi = kitapp.Isim,
            };

            return Ok(okudto);
        }

        [HttpPost("kitapOduncTalepEt")]
        public async Task<IActionResult> kitapOduncTalepEt([FromBody] kitapOduncTalebidto oduncTalebidto)
        {
            if (_kitapOduncRepo.kitapOduncler.Any(ko => !ko.DondurulduMu && ko.OnaylandiMi)) return BadRequest();

            kitapOdunc kodunc = new kitapOdunc
            {
                BeklemedeMi = true,
                OnaylandiMi = false,
                DondurulduMu = false,
                TalepTarihi = DateTime.Now,
                DonusTarihi = DateTime.Now.AddDays(14),
                KitapId = oduncTalebidto.kitapId,
                UserId = oduncTalebidto.isteyenId,
            };
            await _kitapOduncRepo.AddkitapOduncAsync(kodunc);
            return Ok();
        }

        [HttpPut("gorevliOduncCevapVer")]
        public async Task<IActionResult> gorevliOduncCevapVer([FromBody] oduncCevapdto oduncdto)
        {
            kitapOdunc odunc = await _kitapOduncRepo.GetkitapOduncByIdAsync(oduncdto.oduncIstegiId);
            if (_kitapOduncRepo == null) return NotFound();

            odunc.BeklemedeMi = false;
            odunc.OnaylandiMi = oduncdto.OnaylandiMi;
            await _kitapOduncRepo.UpdatekitapOduncAsync(odunc);

            return Ok();
        }
    }



}

