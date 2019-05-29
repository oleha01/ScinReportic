using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScinReport.Models;
using Microsoft.AspNetCore.Identity;
using ScinReport.Models.Repositories;

namespace ScinReport.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //public IRepository Repository = SimpleRepository.SharedRepository;
        public PublicationsController(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
        }

        //For test
        private IPublicationRepositories repository;
        public PublicationsController(IPublicationRepositories repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.publications);
        public IActionResult Publication_func()
        {

            return View();
        }
        // GET: Publications
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Publications.Include(p => p.Type);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Publications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var publication = await _context.Publications
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // GET: Publications/Create
        public async  Task<IActionResult> Create()
        {
            ViewData["TypeId"] = new SelectList(_context.Work_Enums, "Id", "Name");
            ViewBag.Users = new SelectList(_context.Users , "Id","Name"+"SurName");
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,Date,Status")] Publication publication, params int[] selectedLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publication);
                await _context.SaveChangesAsync();
                var work_user = new Work_User { WorkId=publication.Id, UserId = int.Parse(_userManager.GetUserId(User))};
                _context.Work_Users.Add(work_user);
                foreach(var el in selectedLists)
                {
                    var use = _context.Users.FirstOrDefault(p => p.Id == el.ToString());
                    if (use!=null)
                    {
                        var work_user1 = new Work_User { WorkId = publication.Id, UserId = int.Parse(use.Id) };
                        _context.Work_Users.Add(work_user1);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["TypeId"] = new SelectList(_context.Work_Enums, "Id", "Id", publication.TypeId);
            return View(publication);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publications.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.Work_Enums, "Id", "Id", publication.TypeId);
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,Date,Status")] Publication publication)
        {
            if (id != publication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationExists(publication.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.Work_Enums, "Id", "Id", publication.TypeId);
            return View(publication);
        }

        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publications
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publications.FindAsync(id);
            _context.Publications.Remove(publication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationExists(int id)
        {
            return _context.Publications.Any(e => e.Id == id);
        }
    }
}
