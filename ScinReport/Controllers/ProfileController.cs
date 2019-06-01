using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ScinReport.ViewModels;
using ScinReport.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ScinReport.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ProfileController(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.SignInManager = _signInManager;
            return View();
        }
        public async Task<IActionResult> EditProfile(string id)
        {

            var publication = _context.Users.First(p=>p.Id==id);
            if (publication == null)
            {
                return NotFound();
            }
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(string id, [Bind("SurName,,Name,Patronymic,Position,Year_of_birth,Year_of_graduation,Year_of_Protection,,Academic_status,Year_of_Assignment,Degree")] User user)
        {
            if (ModelState.IsValid)
            {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private bool ProfileExists(int id)
        {
            return _context.Users.Any(e => e.Id==id.ToString());
        }


    }
}