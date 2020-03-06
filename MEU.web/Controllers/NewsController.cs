using MEU.web.Data;
using MEU.web.Data.Entities;
using MEU.web.Helpers;
using MEU.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEU.web.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public NewsController(DataContext context, IConverterHelper converterHelper, IImageHelper imageHelper)
        {
            _datacontext = context;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        public IActionResult Index()
        {
            return View(_datacontext.News);
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNew(New news)
        {
            if (ModelState.IsValid)
            {
                _datacontext.Add(news);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        public async Task<IActionResult> EditNew(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _datacontext.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNew(int? id, New news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _datacontext.Update(news);
                    await _datacontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var valcomp = _datacontext.News.FindAsync(id);
                    if (valcomp == null)
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
            return View(news);
        }

        public async Task<IActionResult> DeleteNew(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _datacontext.News
                .Include(c => c.NewImages)

                .FirstOrDefaultAsync(p => p.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            if (news.NewImages.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction(nameof(Index));
            }

            _datacontext.News.Remove(news);
            await _datacontext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> NewImagetList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voy = await _datacontext.News
                .Include(a => a.NewImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voy == null)
            {
                return NotFound();
            }

            return View(voy);
        }

        public async Task<IActionResult> AddNewImage(int? id)
        {
            var news = await _datacontext.News.FindAsync(id);

            if (id == null || news == null)
            {
                return NotFound();
            }

            var model = new NewsImageViewModel
            {
                New_id = news.Id,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewImage(NewsImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var newimg = new NewImage
                {

                    ImageUrl = path,
                    New = await _datacontext.News.FindAsync(model.Id)
                };
                _datacontext.NewImages.Add(newimg);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"NewImagetList/{model.New_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditNewImage(int? id)
        {
            var newimg = await _datacontext.NewImages
                .Include(s => s.New)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || newimg == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToNewImageViewModel(newimg);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNewImage(NewsImageViewModel model)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var newimg = await _converterHelper.ToNewImageAsync(model,path,false);
                _datacontext.NewImages.Update(newimg);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"NewImagetList/{model.New_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteNewImage(int? id)
        {
            var newsimg = await _datacontext.NewImages
                .Include(n => n.New)
                .FirstOrDefaultAsync(ni => ni.Id == id.Value);

            if (id == null || newsimg == null)
            { 
                return NotFound();
            }

            _datacontext.NewImages.Remove(newsimg);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"{nameof(NewImagetList)}/{newsimg.New.Id}");
        }

    }
}