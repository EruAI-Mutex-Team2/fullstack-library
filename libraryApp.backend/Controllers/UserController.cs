using libraryApp.backend.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace libraryApp.backend.Controllers
{
    public class UserController : Controller
    {
        private static List<user> users = new List<user>();

        public IActionResult Index()
        {
            return View(users);
        }

        public IActionResult KullaniciBilgi(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(user newUser)
        {
            if (ModelState.IsValid)
            {
                users.Add(newUser);
                return RedirectToAction(nameof(Index));
            }
            return View(newUser);
        }

        public IActionResult Edit(int id)
        {

            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, user guncelledUser)
        {
            if (ModelState.IsValid)
            {
                var user = users.Find(u => u.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Isim = guncelledUser.Isim;
                user.SoyIsim = guncelledUser.SoyIsim;
                user.Email = guncelledUser.Email;
                user.Password = guncelledUser.Password;
                user.RollId = guncelledUser.RollId;

                return RedirectToAction(nameof(Index));
            }
            return View(guncelledUser);
        }

        public IActionResult Delete(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}