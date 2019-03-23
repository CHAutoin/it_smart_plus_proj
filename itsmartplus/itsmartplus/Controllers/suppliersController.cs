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
    public class suppliersController : Controller
    {
        private readonly ItSmartContext _context;

        public suppliersController(ItSmartContext context)
        {
            _context = context;
        }

        // GET: suppliers
        public async Task<IActionResult> Index()
        {


            return View(await _context.supplier.ToListAsync());
        }

        // GET: suppliers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.supplier
                .FirstOrDefaultAsync(m => m.supp_id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("supp_id,supp_name,supp_addr,supp_phone,supp_mobile,supp_mail,supp_fax,supp_tin")] supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: suppliers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("supp_id,supp_name,supp_addr,supp_phone,supp_mobile,supp_mail,supp_fax,supp_tin")] supplier supplier)
        {
            if (id != supplier.supp_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!supplierExists(supplier.supp_id))
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
            return View(supplier);
        }

        // GET: suppliers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.supplier
                .FirstOrDefaultAsync(m => m.supp_id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var supplier = await _context.supplier.FindAsync(id);
            _context.supplier.Remove(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool supplierExists(string id)
        {
            return _context.supplier.Any(e => e.supp_id == id);
        }
    }
}
