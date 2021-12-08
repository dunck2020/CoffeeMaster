using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeMaster.Models;

namespace CoffeeMaster.Controllers
{
    public class OrderManagerController : Controller
    {
        private readonly CoffeeMasterContext _context;

        public OrderManagerController(CoffeeMasterContext context)
        {
            _context = context;
        }

        // GET: OrderManager
        public async Task<IActionResult> Index()
        {
            var coffeeMasterContext = _context.Orders.Include(o => o.Customer);
            return View(await coffeeMasterContext.ToListAsync());
        }

        // GET: OrderManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderManager = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderManager == null)
            {
                return NotFound();
            }

            return View(orderManager);
        }

        // GET: OrderManager/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        // POST: OrderManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,IsPaid,IsServed")] OrderManager orderManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", orderManager.CustomerId);
            return View(orderManager);
        }

        // GET: OrderManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderManager = await _context.Orders.FindAsync(id);
            if (orderManager == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", orderManager.CustomerId);
            return View(orderManager);
        }

        // POST: OrderManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,IsPaid,IsServed")] OrderManager orderManager)
        {
            if (id != orderManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderManagerExists(orderManager.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", orderManager.CustomerId);
            return View(orderManager);
        }

        // GET: OrderManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderManager = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderManager == null)
            {
                return NotFound();
            }

            return View(orderManager);
        }

        // POST: OrderManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderManager = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orderManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderManagerExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
