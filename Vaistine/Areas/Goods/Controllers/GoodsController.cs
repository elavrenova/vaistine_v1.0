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
    public class GoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Goods/Goods
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Goods.Include(g => g.Category).Include(g => g.MainComponent).Include(g => g.Unit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Goods/Goods/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .Include(g => g.Category)
                .Include(g => g.MainComponent)
                .Include(g => g.Unit)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Goods/Goods/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Descr");
            ViewData["MainComponentId"] = new SelectList(_context.Components, "Id", "Descr");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Descr");
            return View();
        }

        // POST: Goods/Goods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainComponentId,UnitId,CategoryId,Descr,Id")] Good good)
        {
            if (ModelState.IsValid)
            {
                good.Id = Guid.NewGuid();
                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Descr", good.CategoryId);
            ViewData["MainComponentId"] = new SelectList(_context.Components, "Id", "Descr", good.MainComponentId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Descr", good.UnitId);
            return View(good);
        }

        // GET: Goods/Goods/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.SingleOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Descr", good.CategoryId);
            ViewData["MainComponentId"] = new SelectList(_context.Components, "Id", "Descr", good.MainComponentId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Descr", good.UnitId);
            return View(good);
        }

        // POST: Goods/Goods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MainComponentId,UnitId,CategoryId,Descr,Id")] Good good)
        {
            if (id != good.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Descr", good.CategoryId);
            ViewData["MainComponentId"] = new SelectList(_context.Components, "Id", "Descr", good.MainComponentId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Descr", good.UnitId);
            return View(good);
        }

        // GET: Goods/Goods/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .Include(g => g.Category)
                .Include(g => g.MainComponent)
                .Include(g => g.Unit)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Goods/Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var good = await _context.Goods.SingleOrDefaultAsync(m => m.Id == id);
            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodExists(Guid id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }
    }
}
