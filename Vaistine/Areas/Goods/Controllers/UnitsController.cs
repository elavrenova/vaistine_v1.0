using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaistine.Areas.Goods.Models;
using Vaistine.Data;

namespace Vaistine.Areas.Goods.Controllers
{
    [Area("Goods")]
    public class UnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Goods/Units
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Units.Include(u => u.BaseUnit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Goods/Units/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .Include(u => u.BaseUnit)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Goods/Units/Create
        public IActionResult Create()
        {
            ViewData["BaseUnitId"] = new SelectList(_context.Units, "Id", "Id");
            return View();
        }

        // POST: Goods/Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaseUnitId,Scale,Descr,Id")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                unit.Id = Guid.NewGuid();
                _context.Add(unit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaseUnitId"] = new SelectList(_context.Units, "Id", "Id", unit.BaseUnitId);
            return View(unit);
        }

        // GET: Goods/Units/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units.SingleOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }
            ViewData["BaseUnitId"] = new SelectList(_context.Units, "Id", "Id", unit.BaseUnitId);
            return View(unit);
        }

        // POST: Goods/Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BaseUnitId,Scale,Descr,Id")] Unit unit)
        {
            if (id != unit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitExists(unit.Id))
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
            ViewData["BaseUnitId"] = new SelectList(_context.Units, "Id", "Id", unit.BaseUnitId);
            return View(unit);
        }

        // GET: Goods/Units/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .Include(u => u.BaseUnit)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Goods/Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unit = await _context.Units.SingleOrDefaultAsync(m => m.Id == id);
            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(Guid id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
    }
}
