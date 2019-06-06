using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScinReport.Models;
using Microsoft.AspNetCore.Identity;
using ScinReport.ViewModels;

namespace ScinReport.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public PublicationsController(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Publication_func()
        {

            return View();
        }
        // GET: Publications
        public async Task<IActionResult> Index()
        {
            string usId = _userManager.GetUserId(User);
            List<Publication> litForSearch = new List<Publication>();
            List<string> userWork = new List<string>();
            if ((await _userManager.GetUsersInRoleAsync("admin")).FirstOrDefault(p => p.Id == _userManager.GetUserId(User)) != null)
            {
                litForSearch = _context.Publications.Include(p => p.Type).ToList();
                foreach(var el in litForSearch)
                {
                   if(_context.Work_Users.FirstOrDefault(p => p.PublicationId == el.Id)!= null)
                        {
                        var userWhoDoneThisPublicftion = _context.Work_Users.Include(p=>p.User).First(p => p.PublicationId == el.Id).User;
                        userWork.Add(userWhoDoneThisPublicftion.Email);
                    }
                    else
                    {
                        userWork.Add("");
                    }
                }
            }
            else
            {
                var work_user = _context.Work_Users.Include(p => p.User).Include(p => p.Publication).Include(p => p.Publication.Type).Where(p => p.User.Id == usId || p.Publication.IfShared==true);
                foreach (var el in work_user)
                {
                    litForSearch.Add(el.Publication);
                    userWork.Add(el.User.Email);
                }

            }
            ViewBag.userWhoDoneThisPublication = userWork;
            ViewBag.thisUser = (await _userManager.GetUserAsync(User)).Email;
            return View(litForSearch);
        }
        public RedirectToActionResult Share(int id)
        {
            _context.Publications.Find(id).IfShared = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public RedirectToActionResult NoShare(int id)
        {
            _context.Publications.Find(id).IfShared = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Zvit(DateTime date1,DateTime date2,string textcheckbox)
        {
            ViewBag.date1 = date1;
            ViewBag.date2 = date2;
            ViewBag.textcheckbox = textcheckbox;
            List<Publication> applicationContext;
            DateTime def = new DateTime();
            string usId = _userManager.GetUserId(User);
            List<Publication> litForSearch = new List<Publication>();
           
                var work_user = _context.Work_Users.Include(p => p.User).Include(p => p.Publication).Include(p => p.Publication.Type).Where(p => p.User.Id == usId);
                foreach (var el in work_user)
                {
                    litForSearch.Add(el.Publication);
                }
            
            if (date2.Year != def.Year)
                applicationContext = litForSearch.Where(p =>p.Date > date1 && p.Date < date2).OrderByDescending(p => p.Date).ToList();
            else
                applicationContext = litForSearch.Where(p => p.Date > date1).OrderByDescending(p => p.Date).ToList();
            var list = applicationContext;
            List<Publication> publications = new List<Publication>();
            ViewBag.Teacher = await _userManager.GetUserAsync(User);
            ViewBag.publication = publications;
            List<PublicationViewModel> forTable = new List<PublicationViewModel>();
            foreach(var el in _context.Work_Enums)
            {
                forTable.Add(new PublicationViewModel { Name = el.Name });
            }
            foreach(var el in list)
            {
               
                forTable.First(p => p.Name == el.Type.Name).CountAll++;
            }
     
            ViewBag.ForTable = forTable;
            for(int i=0;i<textcheckbox.Length;i++)
            {
                if (textcheckbox[i] == '1')
                    publications.Add(list[i]);
            }
            foreach (var el in publications)
            { 
                forTable.First(p => p.Name == el.Type.Name).CountInTime++;
            }
           
            ViewBag.list = publications;
            return View();
        }
        public async Task<ActionResult> CreateZvit([Bind("t1,t2,t3,t4,t5,t6,t7,t8,t9,t10")]Zvit zvit,string textcheckbox, DateTime date1, DateTime date2)
        {
            List<Publication> applicationContext;
            DateTime def = new DateTime();
            string usId = _userManager.GetUserId(User);
            List<Publication> litForSearch = new List<Publication>();

            var work_user = _context.Work_Users.Include(p => p.User).Include(p => p.Publication).Include(p => p.Publication.Type).Where(p => p.User.Id == usId);
            foreach (var el in work_user)
            {
                litForSearch.Add(el.Publication);
            }

            if (date2.Year != def.Year)
                applicationContext = litForSearch.Where(p => p.Date > date1 && p.Date < date2).OrderByDescending(p => p.Date).ToList();
            else
                applicationContext = litForSearch.Where(p => p.Date > date1).OrderByDescending(p => p.Date).ToList();
            var list = applicationContext;
            List<Publication> publications = new List<Publication>();
            ViewBag.Teacher = await _userManager.GetUserAsync(User);
            ViewBag.publication = publications;
            List<PublicationViewModel> forTable = new List<PublicationViewModel>();
            foreach (var el in _context.Work_Enums)
            {
                forTable.Add(new PublicationViewModel { Name = el.Name });
            }
            foreach (var el in list)
            {

                forTable.First(p => p.Name == el.Type.Name).CountAll++;
            }

            ViewBag.ForTable = forTable;
            for (int i = 0; i < textcheckbox.Length; i++)
            {
                if (textcheckbox[i] == '1')
                    publications.Add(list[i]);
            }
            foreach (var el in publications)
            {
                forTable.First(p => p.Name == el.Type.Name).CountInTime++;
            }
            ViewBag.zvit = zvit;
            ViewBag.list = publications;
            ViewBag.Teacher = await _userManager.GetUserAsync(User);
            return View(zvit);
        }
        public async Task<IActionResult> Date(DateTime date1, DateTime date2)
        {
            List<Publication> applicationContext;
            DateTime def = new DateTime();
            string usId = _userManager.GetUserId(User);
            List<Publication> litForSearch = new List<Publication>();
            List<string> userWork = new List<string>();
            if ((await _userManager.GetUsersInRoleAsync("admin")).FirstOrDefault(p => p.Id == _userManager.GetUserId(User)) != null)
            {
                litForSearch = _context.Publications.Include(p => p.Type).ToList();
                foreach (var el in litForSearch)
                {
                    if (_context.Work_Users.FirstOrDefault(p => p.PublicationId == el.Id) != null)
                    {
                        var userWhoDoneThisPublicftion = _context.Work_Users.Include(p => p.User).First(p => p.PublicationId == el.Id).User;
                        userWork.Add(userWhoDoneThisPublicftion.Email);
                    }
                    else
                    {
                        userWork.Add("");
                    }
                }
                
            }
            else
            {
                var work_user = _context.Work_Users.Include(p => p.User).Include(p => p.Publication).Include(p => p.Publication.Type).Where(p => p.User.Id == usId);
                foreach (var el in work_user)
                {
                    litForSearch.Add(el.Publication);
                    userWork.Add(el.User.Email);
                }
            }
            ViewBag.userWhoDoneThisPublication = userWork;
            if (date2.Year != def.Year)
                applicationContext = litForSearch.Where(p => p.Date > date1 && p.Date < date2).OrderByDescending(p => p.Date).ToList();
            else
                applicationContext = litForSearch.Where(p => p.Date > date1).OrderByDescending(p => p.Date).ToList();
            var list = applicationContext;
            ViewBag.date1 = date1;
            ViewBag.date2 = date2;
            return View("Index", applicationContext);
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
            //ViewBag.Users = new SelectList(_context.Users , "Id","Name"+"SurName");
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,Date,Text")] Publication publication, params int[] selectedLists)
        {
            if (ModelState.IsValid)
            {
                publication.IfShared = false;
                _context.Add(publication);
                await _context.SaveChangesAsync();
                //   var work_user = new Work_User { WorkId=publication.Id, UserId = int.Parse(_userManager.GetUserId(User))};
                //   _context.Work_Users.Add(work_user);
                var use = _userManager.GetUserId(User);
                    if (use!=null)
                    {
                        var work_user1 = new Work_User { PublicationId = publication.Id, UserId = use};
                        _context.Work_Users.Add(work_user1);
                        await _context.SaveChangesAsync();
                    }
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["TypeId"] = new SelectList(_context.Work_Enums, "Id", "Name", publication.TypeId);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,Date,Text")] Publication publication)
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
