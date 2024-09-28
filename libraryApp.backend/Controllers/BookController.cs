using libraryApp.backend.Dtos;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using libraryApp.backend.Repository.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace libraryApp.backend.Controllers
{
    public class BookController
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
                    kitapId = kyt.kitap.Id,
                    Id = kyt.Id,
                    talepTarihi = kyt.TalepTarihi,
                }));
            }
           
            
            [HttpPost("istekYayinlama")] //yazarın kitap yayınlama isteği atması
            public async Task<IActionResult> istekYayinlama([FromBody] int kitapId)
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
                    KitapYayinlandiMi= false,
                    YayinlanmaTarihi =  DateTime.MinValue,
                    kitapYazarlari = [
                        new kitapYazari(){
                        UserId = yazarId,
                    }
                    ]
                });
                return Ok(new { Message = "Kitap oluşturuldu" });
            }
          
        }



    }
    }
}

