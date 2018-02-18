using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaistine.Areas.Cags.Models;
using Vaistine.Data;

namespace Vaistine.Areas.Cags
{
    [Area("Cags")]
    public class CagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cags/Cags
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cags.Include(c => c.Parent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cags/Cags/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cag = await _context.Cags
                .Include(c => c.Parent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cag == null)
            {
                return NotFound();
            }

            return View(cag);
        }

        // GET: Cags/Cags/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Cags, "Id", "Id");
            return View();
        }

        // POST: Cags/Cags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,Descr,Id")] Cag cag)
        {
            if (ModelState.IsValid)
            {
                cag.Id = Guid.NewGuid();
                _context.Add(cag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Cags, "Id", "Id", cag.ParentId);
            return View(cag);
        }

        // GET: Cags/Cags/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cag = await _context.Cags.SingleOrDefaultAsync(m => m.Id == id);
            if (cag == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Cags, "Id", "Id", cag.ParentId);
            return View(cag);
        }

        // POST: Cags/Cags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ParentId,Descr,Id")] Cag cag)
        {
            if (id != cag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CagExists(cag.Id))
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
            ViewData["ParentId"] = new SelectList(_context.Cags, "Id", "Id", cag.ParentId);
            return View(cag);
        }

        // GET: Cags/Cags/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cag = await _context.Cags
                .Include(c => c.Parent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cag == null)
            {
                return NotFound();
            }

            return View(cag);
        }

        // POST: Cags/Cags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cag = await _context.Cags.SingleOrDefaultAsync(m => m.Id == id);
            _context.Cags.Remove(cag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CagExists(Guid id)
        {
            return _context.Cags.Any(e => e.Id == id);
        }
    }
}
