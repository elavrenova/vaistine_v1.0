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
    public class GoodCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Goods/GoodCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Categories.Include(g => g.Parent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Goods/GoodCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodCategory = await _context.Categories
                .Include(g => g.Parent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (goodCategory == null)
            {
                return NotFound();
            }

            return View(goodCategory);
        }

        // GET: Goods/GoodCategories/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Goods/GoodCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,Descr,Id")] GoodCategory goodCategory)
        {
            if (ModelState.IsValid)
            {
                goodCategory.Id = Guid.NewGuid();
                _context.Add(goodCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Id", goodCategory.ParentId);
            return View(goodCategory);
        }

        // GET: Goods/GoodCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodCategory = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);
            if (goodCategory == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Id", goodCategory.ParentId);
            return View(goodCategory);
        }

        // POST: Goods/GoodCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ParentId,Descr,Id")] GoodCategory goodCategory)
        {
            if (id != goodCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodCategoryExists(goodCategory.Id))
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
            ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Id", goodCategory.ParentId);
            return View(goodCategory);
        }

        // GET: Goods/GoodCategories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodCategory = await _context.Categories
                .Include(g => g.Parent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (goodCategory == null)
            {
                return NotFound();
            }

            return View(goodCategory);
        }

        // POST: Goods/GoodCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var goodCategory = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);
            _context.Categories.Remove(goodCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodCategoryExists(Guid id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
