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
	public class CategoryController : Controller
	{
		//itsmartplus.Models.ItSmartContext __context;
		private readonly ItSmartContext _context;

		public CategoryController(ItSmartContext context)
		{

			_context = context;
		}

		// GET: Category
		public async Task<IActionResult> Index()
		{
			var itSmartContext = _context.categories.Include(b => b.Brand).Include(c => c.Admintable).Include(c => c.Employee).Include(c => c.Type);
			return View(await itSmartContext.ToListAsync());
		}

		// GET: Category/Details/5
		public async Task<IActionResult> Details(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = await _context.categories
				.Include(b=>b.Brand)
				.Include(c => c.Admintable)
				.Include(c => c.Employee)
				.Include(c => c.Type)
				.FirstOrDefaultAsync(m => m.cat_id == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		// GET: Category/Create
		public IActionResult Create()
		{
			category ct = new category();
			//ViewData["ad_id"] = new SelectList(_context.admintables, "ad_id", "ad_id");
			//ViewData["em_id"] = new SelectList(_context.employees, "em_id", "em_id");
			//ViewData["t_id"] = new SelectList(_context.types, "t_id", "t_id");
			ct.EmSelectList = Emselect.emSelectList(_context);
			ct.TypeSelectList = Typeselect.TypeSelectList(_context);
			ct.BrandSelectList = Brandselect.brandSelectList(_context);
			return View(ct);
		}

		// POST: Category/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(category category)
		{
			if (ModelState.IsValid)
			{
				_context.Add(category);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			//ViewData["ad_id"] = new SelectList(_context.admintables, "ad_id", "ad_id", category.ad_id);
			//ViewData["em_id"] = new SelectList(_context.employees, "em_id", "em_id", category.em_id);
			//ViewData["t_id"] = new SelectList(_context.types, "t_id", "t_id", category.t_id);
			category.EmSelectList = Emselect.emSelectList(_context);
			category.TypeSelectList = Typeselect.TypeSelectList(_context);
			category.BrandSelectList = Brandselect.brandSelectList(_context);
			return View(category);
		}

		// GET: Category/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = await _context.categories.FindAsync(id);
			category.TypeSelectList = Typeselect.TypeSelectList(_context);
			category.EmSelectList = Emselect.emSelectList(_context);
			category.BrandSelectList = Brandselect.brandSelectList(_context);
			if (category == null)
			{
				return NotFound();
			}

			//ViewData["ad_id"] = new SelectList(_context.admintables, "ad_id", "ad_id", category.ad_id);
			//ViewData["em_id"] = new SelectList(_context.employees, "em_id", "em_id", category.em_id);
			//ViewData["t_id"] = new SelectList(_context.types, "t_id", "t_id", category.t_id);
			return View(category);
		}

		// POST: Category/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, category category)
		{
			if (id != category.cat_id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(category);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!categoryExists(category.cat_id))
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
			//ViewData["ad_id"] = new SelectList(_context.admintables, "ad_id", "ad_id", category.ad_id);
			//ViewData["em_id"] = new SelectList(_context.employees, "em_id", "em_id", category.em_id);
			//ViewData["t_id"] = new SelectList(_context.types, "t_id", "t_id", category.t_id);
			category.BrandSelectList = Brandselect.brandSelectList(_context);
			category.TypeSelectList = Typeselect.TypeSelectList(_context);
			category.EmSelectList = Emselect.emSelectList(_context);
			return View(category);
		}

		// GET: Category/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = await _context.categories
				.Include(b=>b.Brand)
				.Include(c => c.Admintable)
				.Include(c => c.Employee)
				.Include(c => c.Type)
				.FirstOrDefaultAsync(m => m.cat_id == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		// POST: Category/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			var category = await _context.categories.FindAsync(id);
			_context.categories.Remove(category);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool categoryExists(string id)
		{
			return _context.categories.Any(e => e.cat_id == id);
		}
	}
}
