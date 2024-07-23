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
        public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber = 1, int pageSize = 10)
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

        // GET: ProductsUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var ProductsUser = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (ProductsUser == null)
            {
                return NotFound();
            }

            return View(ProductsUser);
        }

        // GET: ProductsUser/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: ProductsUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Price,SpecialPrice,CategoryID,Stock,Special,ImageFile,ImageName")] Products Products)
        {
            if (!ModelState.IsValid)
            {
                //Save image to wwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(Products.ImageFile.FileName);
                string extension = Path.GetExtension(Products.ImageFile.FileName);
                Products.ImageName = fileName = fileName + DateTime.Now.ToString("yyhhmm") + extension;
                string path = Path.Combine(wwwRootPath + "/UploadedImg/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Products.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(Products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", Products.CategoryID);
            return View(Products);
        }

        // GET: ProductsUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var ProductsUser = await _context.Products.FindAsync(id);
            if (ProductsUser == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", ProductsUser.CategoryID);
            return View(ProductsUser);
        }

        // POST: ProductsUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Price,SpecialPrice,CategoryID,Stock,Special,ImageFile,ImageName")] Products Products)
        {
            if (id != Products.ProductID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                //Save image to wwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(Products.ImageFile.FileName);
                string extension = Path.GetExtension(Products.ImageFile.FileName);
                Products.ImageName = fileName = fileName + DateTime.Now.ToString("yyhhmm") + extension;
                string path = Path.Combine(wwwRootPath + "/UploadedImg/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Products.ImageFile.CopyToAsync(fileStream);
                }
                try
                {
                    _context.Update(Products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsUserExists(Products.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", Products.CategoryID);
            return View(Products);
        }

        // GET: ProductsUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var ProductsUser = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (ProductsUser == null)
            {
                return NotFound();
            }

            return View(ProductsUser);
        }

        // POST: ProductsUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Delete image from wwwroot/Images
            if (_context.Products == null)
            {
                return Problem("Entity set 'AvcolCanteenContext.ProductsUser'  is null.");
            }
            var ProductsUser = await _context.Products.FindAsync(id);
            if (ProductsUser != null)
            {
                _context.Products.Remove(ProductsUser);
            }
            //delete image from wwroot/uploadedimg
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "UploadedImg", ProductsUser.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            //delete the record
            _context.Products.Remove(ProductsUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsUserExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
