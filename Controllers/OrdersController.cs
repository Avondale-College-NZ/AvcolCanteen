using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvcolCanteen.Areas.Identity.Data;
using AvcolCanteen.Models;
using static NuGet.Packaging.PackagingConstants;
using Microsoft.AspNetCore.Authorization;

namespace AvcolCanteen.Controllers
{
    [Authorize(Roles = "Admin")] // Requires user to be in role of admin

    public class OrdersController : Controller
    {
        private readonly AvcolCanteenContext _context;

        public OrdersController(AvcolCanteenContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string searchString)
        {
            // Search Functionality

            // Start by selecting all orders
            var orders = _context.Orders.Include(o => o.AvcolCanteenUser).AsQueryable();

            // Apply search filter if searchString is provided
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.AvcolCanteenUser.UserName.Contains(searchString));
            }

            // Pass the filtered list to the view
            return View(await orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.AvcolCanteenUser)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["AvcolCanteenUserID"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,AvcolCanteenUserID,Date")] Orders orders)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AvcolCanteenUserID"] = new SelectList(_context.Users, "Id", "UserName", orders.AvcolCanteenUserID);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["AvcolCanteenUserID"] = new SelectList(_context.Users, "Id", "UserName", orders.AvcolCanteenUserID);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,AvcolCanteenUserID,Date")] Orders orders)
        {
            if (id != orders.OrderID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderID))
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
            ViewData["AvcolCanteenUserID"] = new SelectList(_context.Users, "Id", "Id", orders.AvcolCanteenUserID);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.AvcolCanteenUser)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'AvcolCanteenContext.Orders'  is null.");
            }
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
          return (_context.Orders?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
