using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace libraryApp.backend.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IuserRepository _userRepo;
        private readonly IrolRepository _rolRepo;
        private readonly IConfiguration _configuration;

        public AccountController(IuserRepository userRepo, IrolRepository rolRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _rolRepo = rolRepo;
            _configuration = configuration;

        }
        [HttpGet("girisYap")]
        public async Task<IActionResult> girisYap(girisYapdto girisdto)
        {
            var user = await _userRepo.users.Include(u => u.rol).FirstOrDefaultAsync(u => u.Email == girisdto.Email);
            if (user == null) return NotFound(new { message = "Kullanıcı bulunamadı." });
            if (!BCrypt.Net.BCrypt.Verify(girisdto.Password, user.Password)) return StatusCode(401, new { message = "Şifre doğru değil." });

            userdto dto = new userdto
            {
                Id = user.Id,
                rolId = user.RollId,
                rolIsmi = user.rol.RolIsmi,
                Isim = user.Isim,
                SoyIsim = user.SoyIsim,
                Email = user.Email,
            };
            string token = GenerateJWT(user);
            return Ok(new
            {
                userdto = dto,
                token = token,
            });


        }
        private string GenerateJWT(user us)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim("rolIsmi",us.rol.RolIsmi),
                ]),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);




        }

        [HttpPost("KayitOl")]
        public async Task<IActionResult> KayitOl(kayitOldto kayitdto)
        {
            if (_userRepo.users.Any(u => u.Email == kayitOldto.Email)) return BadRequest("Email zaten kayıtlı.");

            await _userRepo.AdduserAsync(new user
            {
                Isim = kayitOldto.Isim,
                SoyIsim = kayitOldto.SoyIsim,
                Email = kayitOldto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(kayitOldto.Password),
            });
            return Ok(new { message = "Kayıt gerçekleşti" });
        }
    }
}