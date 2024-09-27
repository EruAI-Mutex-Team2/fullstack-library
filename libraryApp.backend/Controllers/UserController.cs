using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;



namespace libraryApp.backend.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IuserRepository _userRepo;
        private readonly IrolRepository _rolRepo;

        private readonly IcezaRepository _cezaRepo;

        public UserController(IuserRepository userRepo, IrolRepository rolRepo, IcezaRepository cezaRepo)
        {
            _userRepo = userRepo;
            _rolRepo = rolRepo;
            _cezaRepo = cezaRepo;
        }
        [HttpGet("rolleriGetir")]
        public async Task<IActionResult> rolleriGetir()
        {
            var roller = await _rolRepo.roller.ToListAsync();
            return Ok(roller);
        }

        [HttpPut("roluGuncelle")]
        public async Task<IActionResult> rolleriDegistir([FromBody] rolDegistirmedto rolDegistirdto)
        {
            var user = await _userRepo.GetuserByIdAsync(rolDegistirdto.userId);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.RollId = rolDegistirdto.yeniRolId;
                await _userRepo.UpdateuserAsync(user);
                return Ok();
            }
        }
        [HttpGet("rolDegistirilecekUserlariGetir")]
        public async Task<IActionResult> rolUserGetir()
        {
            List<user> userlar = await _userRepo.users.Where(user => user.RollId < 4).Include(user => user.rol).ToListAsync();

            List<rolUserGetirdto> userGetirdtolar = userlar.Select(user => new rolUserGetirdto
            {
                Isım = user.Isim,
                rolIsmi = user.rol.RolIsmi,
                Soyisim = user.SoyIsim,
                userId = user.Id,
            }).ToList();

            return Ok(userGetirdtolar);
        }

        [HttpGet("cezaVerilebilecekUserlariGetir")]
        public async Task<IActionResult> cezaUserGetir([FromRoute] int rolId)
        {
            var users = await _userRepo.users.Where(u => u.RollId < rolId).Include(u => u.rol).ToListAsync();
            var userGetirdtolar = users.Select(u => new rolUserGetirdto
            {
                Isım = u.Isim,
                rolIsmi = u.rol.RolIsmi,
                Soyisim = u.SoyIsim,
                userId = u.Id,

            }).ToList();

            return Ok(userGetirdtolar);
        }

        [HttpPost("cezaVer")]
        public async Task<IActionResult> cezaVer([FromBody] int userId)
        {
            var user = await _userRepo.GetuserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var ceza = new ceza
                {
                    UserId = userId,
                    CezaAktifMi = true,
                    CezaBitisGunu = DateTime.Now.AddDays(14),
                    CezaGunu = DateTime.Now,
                };
                await _cezaRepo.AddcezaAsync(ceza);
                return Ok();
            }

        }

        [HttpPut("cezaKaldir")]
        public async Task<IActionResult> cezaKaldir([FromBody] int userId)
        {
            var cezaKaydi = await _cezaRepo.cezalar.Where(c => c.UserId == userId && c.CezaAktifMi == true).FirstOrDefaultAsync();
            if (cezaKaydi == null)
            {
                return NotFound();
            }
            else
            {
                cezaKaydi.CezaAktifMi = false;
                await _cezaRepo.UpdatecezaAsync(cezaKaydi);
                return Ok();
            }
        }
        [HttpGet("mesajGonderilebilecekUserlarGetir")]
        public async Task<IActionResult> mesajGonderilebilecekUserlarGetir([FromRoute] int rolId)
        {
            //1-user 2-yazar 3-gorevli 4-yonetici 
            var roller = new List<int>();

            if (rolId == 1)
            {
                roller.Add(3);
            }
            else if (rolId == 2)
            {
                roller.Add(3);
                roller.Add(4);
            }
            else if (rolId == 3)
            {
                roller.Add(1);
                roller.Add(2);
                roller.Add(4);
            }
            else if (rolId == 4)
            {
                roller.Add(2);
                roller.Add(3);
            }

            var users = await _userRepo.users.Where(u => roller.Contains(u.RollId)).Include(u => u.rol).ToListAsync();
            var userGetirdtolar = users.Select(u => new rolUserGetirdto
            {
                Isım = u.Isim,
                rolIsmi = u.rol.RolIsmi,
                Soyisim = u.SoyIsim,
                userId = u.Id,

            }).ToList();
            return Ok(userGetirdtolar);


        }







    }

}





