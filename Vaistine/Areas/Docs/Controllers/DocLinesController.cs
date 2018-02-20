using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaistine.Areas.Docs.Models;
using Vaistine.Data;

namespace Vaistine.Areas.Docs.Controllers
{
    [Area("Docs")]
    public class DocLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Docs/DocLines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DocLines.Include(d => d.DocHead).Include(d => d.Good);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Docs/DocLines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docLine = await _context.DocLines
                .Include(d => d.DocHead)
                .Include(d => d.Good)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (docLine == null)
            {
                return NotFound();
            }

            return View(docLine);
        }

        // GET: Docs/DocLines/Create
        public IActionResult Create()
        {
            ViewData["DocHeadId"] = new SelectList(_context.Docs, "Id", "Id");
            ViewData["GoodId"] = new SelectList(_context.Goods, "Id", "Id");
            return View();
        }

        // POST: Docs/DocLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodId,DocHeadId,Price,Quantity,Id")] DocLine docLine)
        {
            if (ModelState.IsValid)
            {
                docLine.Id = Guid.NewGuid();
                _context.Add(docLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocHeadId"] = new SelectList(_context.Docs, "Id", "Id", docLine.DocHeadId);
            ViewData["GoodId"] = new SelectList(_context.Goods, "Id", "Id", docLine.GoodId);
            return View(docLine);
        }

        // GET: Docs/DocLines/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docLine = await _context.DocLines.SingleOrDefaultAsync(m => m.Id == id);
            if (docLine == null)
            {
                return NotFound();
            }
            ViewData["DocHeadId"] = new SelectList(_context.Docs, "Id", "Id", docLine.DocHeadId);
            ViewData["GoodId"] = new SelectList(_context.Goods, "Id", "Id", docLine.GoodId);
            return View(docLine);
        }

        // POST: Docs/DocLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GoodId,DocHeadId,Price,Quantity,Id")] DocLine docLine)
        {
            if (id != docLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocLineExists(docLine.Id))
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
            ViewData["DocHeadId"] = new SelectList(_context.Docs, "Id", "Id", docLine.DocHeadId);
            ViewData["GoodId"] = new SelectList(_context.Goods, "Id", "Id", docLine.GoodId);
            return View(docLine);
        }

        // GET: Docs/DocLines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docLine = await _context.DocLines
                .Include(d => d.DocHead)
                .Include(d => d.Good)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (docLine == null)
            {
                return NotFound();
            }

            return View(docLine);
        }

        // POST: Docs/DocLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var docLine = await _context.DocLines.SingleOrDefaultAsync(m => m.Id == id);
            _context.DocLines.Remove(docLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocLineExists(Guid id)
        {
            return _context.DocLines.Any(e => e.Id == id);
        }
    }
}
