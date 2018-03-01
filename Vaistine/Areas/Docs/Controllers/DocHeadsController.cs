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
    public class DocHeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocHeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Docs/DocHeads
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Docs.Include(d => d.FromCag).Include(d => d.FromStore).Include(d => d.ToCag).Include(d => d.ToStore);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Docs/DocHeads/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docHead = await _context.Docs
                .Include(d => d.FromCag)
                .Include(d => d.FromStore)
                .Include(d => d.ToCag)
                .Include(d => d.ToStore)
                .Include(d => d.DocLines)
                .ThenInclude(l=>l.Good)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (docHead == null)
            {
                return NotFound();
            }

            return View(docHead);
        }

        // GET: Docs/DocHeads/Create
        public IActionResult Create()
        {
            ViewData["FromCagId"] = new SelectList(_context.Cags, "Id", "Descr");
            ViewData["FromStoreId"] = new SelectList(_context.Stores, "Id", "Descr");
            ViewData["ToCagId"] = new SelectList(_context.Cags, "Id", "Descr");
            ViewData["ToStoreId"] = new SelectList(_context.Stores, "Id", "Descr");
            return View();
        }

        // POST: Docs/DocHeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FromStoreId,ToStoreId,FromDate,ToDate,FromCagId,ToCagId,Descr,Id")] DocHead docHead)
        {
            if (ModelState.IsValid)
            {
                docHead.Id = Guid.NewGuid();
                _context.Add(docHead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromCagId"] = new SelectList(_context.Cags, "Id", "Descr", docHead.FromCagId);
            ViewData["FromStoreId"] = new SelectList(_context.Stores, "Id", "Descr", docHead.FromStoreId);
            ViewData["ToCagId"] = new SelectList(_context.Cags, "Id", "Descr", docHead.ToCagId);
            ViewData["ToStoreId"] = new SelectList(_context.Stores, "Id", "Descr", docHead.ToStoreId);
            return View(docHead);
        }

        // GET: Docs/DocHeads/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docHead = await _context.Docs.SingleOrDefaultAsync(m => m.Id == id);
            if (docHead == null)
            {
                return NotFound();
            }
            ViewData["FromCagId"] = new SelectList(_context.Cags, "Id", "Descr", docHead.FromCagId);
            ViewData["FromStoreId"] = new SelectList(_context.Stores, "Id", "Descr", docHead.FromStoreId);
            ViewData["ToCagId"] = new SelectList(_context.Cags, "Id", "Descr", docHead.ToCagId);
            ViewData["ToStoreId"] = new SelectList(_context.Stores, "Id", "Descr", docHead.ToStoreId);
            return View(docHead);
        }

        // POST: Docs/DocHeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FromStoreId,ToStoreId,FromDate,ToDate,FromCagId,ToCagId,Descr,Id")] DocHead docHead)
        {
            if (id != docHead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docHead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocHeadExists(docHead.Id))
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
            ViewData["FromCagId"] = new SelectList(_context.Cags, "Id", "Descr", docHead.FromCagId);
            ViewData["FromStoreId"] = new SelectList(_context.Stores, "Id", "Descr", docHead.FromStoreId);
            ViewData["ToCagId"] = new SelectList(_context.Cags, "Id", "Descr", docHead.ToCagId);
            ViewData["ToStoreId"] = new SelectList(_context.Stores, "Id", "Descr", docHead.ToStoreId);
            return View(docHead);
        }

        // GET: Docs/DocHeads/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docHead = await _context.Docs
                .Include(d => d.FromCag)
                .Include(d => d.FromStore)
                .Include(d => d.ToCag)
                .Include(d => d.ToStore)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (docHead == null)
            {
                return NotFound();
            }

            return View(docHead);
        }

        // POST: Docs/DocHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var docHead = await _context.Docs.SingleOrDefaultAsync(m => m.Id == id);
            _context.Docs.Remove(docHead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocHeadExists(Guid id)
        {
            return _context.Docs.Any(e => e.Id == id);
        }
    }
}
