using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_DbFirstApproch.Models;

namespace EF_DbFirstApproch.Controllers
{
    public class StocksController : Controller
    {
        private readonly BikeStoresContext _context;

        public StocksController(BikeStoresContext context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var bikeStoresContext = _context.Stocks.Include(s => s.Product).Include(s => s.Store);
            return View(await bikeStoresContext.ToListAsync());
        }

        // GET: Stocks/Details
        public async Task<IActionResult> Details(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks
                .Include(s => s.Product)
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.StoreId == storeId && m.ProductId == productId);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Stocks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,ProductId,Quantity")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", stock.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", stock.StoreId);
            return View(stock);
        }

        // GET: Stocks/Edit
        public async Task<IActionResult> Edit(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks
                .FirstOrDefaultAsync(m => m.StoreId == storeId && m.ProductId == productId);
            if (stock == null)
            {
                return NotFound();
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", stock.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", stock.StoreId);
            return View(stock);
        }

        // POST: Stocks/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int storeId, int productId, [Bind("StoreId,ProductId,Quantity")] Stock stock)
        {
            if (storeId != stock.StoreId || productId != stock.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.StoreId, stock.ProductId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", stock.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", stock.StoreId);
            return View(stock);
        }

        // GET: Stocks/Delete
        public async Task<IActionResult> Delete(int? storeId, int? productId)
        {
            if (storeId == null || productId == null)
            {
                return NotFound();
            }

            var stock = await _context.Stocks
                .Include(s => s.Product)
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.StoreId == storeId && m.ProductId == productId);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int storeId, int productId)
        {
            var stock = await _context.Stocks
                .FirstOrDefaultAsync(m => m.StoreId == storeId && m.ProductId == productId);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int storeId, int productId)
        {
            return _context.Stocks.Any(e => e.StoreId == storeId && e.ProductId == productId);
        }
    }
}
