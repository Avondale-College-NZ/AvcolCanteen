using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvcolCanteen.Areas.Identity.Data;
using AvcolCanteen.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AvcolCanteen.Controllers
{
    public class ProductsUserController : Controller
    {
        private readonly AvcolCanteenContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsUserController(AvcolCanteenContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: ProductsUser
        public async Task<IActionResult> Menu(string searchString, string sortOrder, int pageNumber = 1, int pageSize = 10)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AvcolCanteenContext.ProductsUser' is null.");
            }
            // Search Products by name
            var Products = from m in _context.Products select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Products = Products.Where(s => s.Name!.Contains(searchString));
            }
            // Sort functionality
            switch (sortOrder)
            {
                case "name_asc":
                    Products = Products.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    Products = Products.OrderByDescending(s => s.Name);
                    break;
                case "price_asc":
                    Products = Products.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    Products = Products.OrderByDescending(s => s.Price);
                    break;
                default:
                    Products = Products.OrderBy(s => s.Name);
                    break;
            }

            // Get total product count and calculate total pages
            var totalProductsUser = await Products.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalProductsUser / pageSize);

            // Get the ProductsUser for the current page
            var ProductsUserPerPage = await Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = totalPages;
            ViewData["PageSize"] = pageSize;

            return View(ProductsUserPerPage);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId)
        {
            // If user not signed in; redirect not working

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            // Get the current user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Create a new order
            var order = new Orders
            {
                AvcolCanteenUserID = userId,
                Date = DateTime.Now
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Create cart records
            var cartItem = new Cart
            {
                OrderID = order.OrderID,
                ProductID = productId,
                Quantity = 1,
            };
            _context.Cart.Add(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProductsUserExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
