using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaistine.Areas.Stores.Models;
using Vaistine.Data;

namespace Vaistine.Areas.Stores.Controllers
{
    [Area("Stores")]
    public class StoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stores/Stores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Stores.Include(s => s.Owner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stores/Stores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .Include(s => s.Owner)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Stores/Stores/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Cags, "Id", "Descr");
            return View();
        }

        // POST: Stores/Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IsAccount,OwnerId,Descr,Id")] Store store)
        {
            if (ModelState.IsValid)
            {
                store.Id = Guid.NewGuid();
                _context.Add(store);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Cags, "Id", "Id", store.OwnerId);
            return View(store);
        }

        // GET: Stores/Stores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores.SingleOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Cags, "Id", "Id", store.OwnerId);
            return View(store);
        }

        // POST: Stores/Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IsAccount,OwnerId,Descr,Id")] Store store)
        {
            if (id != store.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(store);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreExists(store.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Cags, "Id", "Id", store.OwnerId);
            return View(store);
        }

        // GET: Stores/Stores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .Include(s => s.Owner)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Stores/Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var store = await _context.Stores.SingleOrDefaultAsync(m => m.Id == id);
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreExists(Guid id)
        {
            return _context.Stores.Any(e => e.Id == id);
        }
    }
}
