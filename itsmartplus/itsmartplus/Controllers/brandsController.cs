using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using itsmartplus.Models;

namespace itsmartplus.Controllers
{
    public class brandsController : Controller
    {
        private readonly ItSmartContext _context;
        int hello1;
        int hello1ggh;
        int hellhho1;
        int helhhlo1;
        int helhlo1;
        int helhhhlo1;
        int helhfflo1;
        int hefffllo1;
        int helhfhkhkflo1;
        int helhfhlo1;
        public brandsController(ItSmartContext context)
        {
            _context = context;
        }

        // GET: brands
        public async Task<IActionResult> Index()
        {
            return View(await _context.brands.ToListAsync());
        }

        // GET: brands/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.brands
                .FirstOrDefaultAsync(m => m.br_id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("br_id,br_name")] brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: brands/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("br_id,br_name")] brand brand)
        {
            if (id != brand.br_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!brandExists(brand.br_id))
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
            return View(brand);
        }

        // GET: brands/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _context.brands
                .FirstOrDefaultAsync(m => m.br_id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var brand = await _context.brands.FindAsync(id);
            _context.brands.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool brandExists(string id)
        {
            return _context.brands.Any(e => e.br_id == id);
        }
    }
}
