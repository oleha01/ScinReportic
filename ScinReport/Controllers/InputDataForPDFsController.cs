 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScinReport.Models;
using ScinReport.ViewModels;

namespace ScinReport.Controllers
{
    public class InputDataForPDFsController : Controller
    {
        private readonly ApplicationContext _context;

        public InputDataForPDFsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: InputDataForPDFs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataForPDFs.ToListAsync());
        }

        // GET: InputDataForPDFs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inputDataForPDF = await _context.DataForPDFs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inputDataForPDF == null)
            {
                return NotFound();
            }

            return View(inputDataForPDF);
        }
        public IActionResult Generate()
        {
            return View();
        }
        // GET: InputDataForPDFs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InputDataForPDFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Punct1,Punct2,Punct3,Punct4,Punct5,Punct7_1,Punct7_2,Punct8,Punct9,Punct10,IsReady")] InputDataForPDF inputDataForPDF)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inputDataForPDF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inputDataForPDF);
        }

        // GET: InputDataForPDFs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inputDataForPDF = await _context.DataForPDFs.FindAsync(id);
            if (inputDataForPDF == null)
            {
                return NotFound();
            }
            return View(inputDataForPDF);
        }

        // POST: InputDataForPDFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Punct1,Punct2,Punct3,Punct4,Punct5,Punct7_1,Punct7_2,Punct8,Punct9,Punct10,IsReady")] InputDataForPDF inputDataForPDF)
        {
            if (id != inputDataForPDF.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inputDataForPDF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InputDataForPDFExists(inputDataForPDF.Id))
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
            return View(inputDataForPDF);
        }

        // GET: InputDataForPDFs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inputDataForPDF = await _context.DataForPDFs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inputDataForPDF == null)
            {
                return NotFound();
            }

            return View(inputDataForPDF);
        }

        // POST: InputDataForPDFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inputDataForPDF = await _context.DataForPDFs.FindAsync(id);
            _context.DataForPDFs.Remove(inputDataForPDF);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InputDataForPDFExists(int id)
        {
            return _context.DataForPDFs.Any(e => e.Id == id);
        }
    }
}
