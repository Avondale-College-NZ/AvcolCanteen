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
    public class ProductsController : Controller
    {
        private readonly AvcolCanteenContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(AvcolCanteenContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1, int pageSize = 10)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AvcolCanteenContext.Products' is null.");
            }
            // Search products by name
            var products = from m in _context.Products select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }
            // Sort functionality
            switch (sortOrder)
            {
                case "name_asc":
                    products = products.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "price_asc":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }

            // Get total product count and calculate total pages
            var totalProducts = await products.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalProducts / pageSize);

            // Get the products for the current page
            var productsPerPage = await products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = totalPages;
            ViewData["PageSize"] = pageSize;

            return View(productsPerPage);
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

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Price,SpecialPrice,CategoryID,Stock,Special,ImageFile,ImageName")] Products products)
        {
            if (!ModelState.IsValid)
            {
                //Save image to wwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(products.ImageFile.FileName);
                string extension = Path.GetExtension(products.ImageFile.FileName);
                products.ImageName = fileName = fileName + DateTime.Now.ToString("yyhhmm") + extension;
                string path = Path.Combine(wwwRootPath + "/UploadedImg/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await products.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", products.CategoryID);
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", products.CategoryID);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Price,SpecialPrice,CategoryID,Stock,Special,ImageFile,ImageName")] Products products)
        {
            if (id != products.ProductID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                //Save image to wwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(products.ImageFile.FileName);
                string extension = Path.GetExtension(products.ImageFile.FileName);
                products.ImageName = fileName = fileName + DateTime.Now.ToString("yyhhmm") + extension;
                string path = Path.Combine(wwwRootPath + "/UploadedImg/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await products.ImageFile.CopyToAsync(fileStream);
                }
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", products.CategoryID);
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete image from wwwroot/Images
            if (_context.Products == null)
            {
                return Problem("Entity set 'AvcolCanteenContext.Products'  is null.");
            }
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                _context.Products.Remove(products);
            }
            //delete image from wwroot/uploadedimg
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "UploadedImg", products.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            //delete the record
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
