using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScinReport.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ScinReport.Controllers
{
    [Authorize(Roles ="admin")]
    public class WorkEnumsController : Controller
    {
        private readonly ApplicationContext _context;

        public WorkEnumsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: WorkEnums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Work_Enums.ToListAsync());
        }

        // GET: WorkEnums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workEnum = await _context.Work_Enums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workEnum == null)
            {
                return NotFound();
            }

            return View(workEnum);
        }

        // GET: WorkEnums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkEnums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] WorkEnum workEnum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workEnum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workEnum);
        }

        // GET: WorkEnums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workEnum = await _context.Work_Enums.FindAsync(id);
            if (workEnum == null)
            {
                return NotFound();
            }
            return View(workEnum);
        }

        // POST: WorkEnums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] WorkEnum workEnum)
        {
            if (id != workEnum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workEnum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkEnumExists(workEnum.Id))
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
            return View(workEnum);
        }

        // GET: WorkEnums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workEnum = await _context.Work_Enums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workEnum == null)
            {
                return NotFound();
            }

            return View(workEnum);
        }

        // POST: WorkEnums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workEnum = await _context.Work_Enums.FindAsync(id);
            _context.Work_Enums.Remove(workEnum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkEnumExists(int id)
        {
            return _context.Work_Enums.Any(e => e.Id == id);
        }
    }
}
