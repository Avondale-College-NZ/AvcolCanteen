using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvcolCanteen.Areas.Identity.Data;
using AvcolCanteen.Models;

namespace AvcolCanteen.Controllers
{
    public class ImageModelsController : Controller
    {
        private readonly AvcolCanteenContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageModelsController(AvcolCanteenContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: ImageModels
        public async Task<IActionResult> Index()
        {
              return _context.ImageModel != null ? 
                          View(await _context.ImageModel.ToListAsync()) :
                          Problem("Entity set 'AvcolCanteenContext.ImageModel'  is null.");
        }

        // GET: ImageModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImageModel == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // GET: ImageModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImageModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageID,Title,ImageFile")] ImageModel imageModel)
        {
            if (!ModelState.IsValid)
            {
                //Save image to wwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }


                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

        // GET: ImageModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImageModel == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }
            return View(imageModel);
        }

        // POST: ImageModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageID,Title,ImageName")] ImageModel imageModel)
        {
            if (id != imageModel.ImageID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(imageModel.ImageID))
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
            return View(imageModel);
        }

        // GET: ImageModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImageModel == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: ImageModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImageModel == null)
            {
                return Problem("Entity set 'AvcolCanteenContext.ImageModel' is null.");
            }
            var imageModel = await _context.ImageModel.FindAsync(id);

            if (imageModel == null)
            {
                return NotFound();
            }

            // Delete image from wwwroot/Images
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", imageModel.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            // Remove the record
            _context.ImageModel.Remove(imageModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool ImageModelExists(int id)
        {
          return (_context.ImageModel?.Any(e => e.ImageID == id)).GetValueOrDefault();
        }
    }
}
