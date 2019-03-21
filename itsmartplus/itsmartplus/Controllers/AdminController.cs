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
    public class AdminController : Controller
    {
	
        private readonly ItSmartContext _context;
        public AdminController(ItSmartContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.admintables.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admintable = await _context.admintables
                .FirstOrDefaultAsync(m => m.ad_id == id);
            if (admintable == null)
            {
                return NotFound();
            }

            return View(admintable);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ad_id,ad_pass,ad_name,ad_lastname")] admintable admintable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admintable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admintable);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admintable = await _context.admintables.FindAsync(id);
            if (admintable == null)
            {
                return NotFound();
            }
            return View(admintable);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ad_id,ad_pass,ad_name,ad_lastname")] admintable admintable)
        {
            if (id != admintable.ad_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admintable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!admintableExists(admintable.ad_id))
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
            return View(admintable);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admintable = await _context.admintables
                .FirstOrDefaultAsync(m => m.ad_id == id);
            if (admintable == null)
            {
                return NotFound();
            }

            return View(admintable);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var admintable = await _context.admintables.FindAsync(id);
            _context.admintables.Remove(admintable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool admintableExists(string id)
        {
            return _context.admintables.Any(e => e.ad_id == id);
        }
    }
}
