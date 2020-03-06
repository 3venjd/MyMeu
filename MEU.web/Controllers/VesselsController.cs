using MEU.web.Data;
using MEU.web.Data.Entities;
using MEU.web.Helpers;
using MEU.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEU.web.Controllers
{
    public class VesselsController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public VesselsController(DataContext context,
                                IUserHelper userHelper,
                                ICombosHelper combosHelper,
                                IConverterHelper converterHelper,
                                IImageHelper imageHelper
                                )
        {
            _datacontext = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        public IActionResult Index()
        {
            return View(_datacontext.Vessels
            .Include(v => v.VesselType)
            );
        }

        public IActionResult AddVessel()
        {

            var model = new VesselViewModel
            {

                VesselTypes = _combosHelper.GetComboVesselType(),
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddVessel(VesselViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var vesselimg = new Vessel
                {
                    Vessel_Name = model.Vessel_Name,
                    ImageUrl = path,
                    Voys = new List<Voy>() ,
                    VesselType = await _datacontext.VesselTypes.FindAsync(model.VesselTypeId),

                };

                _datacontext.Vessels.Add(vesselimg);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"Index");
            }

            model.VesselTypes = _combosHelper.GetComboVesselType();

            return View(model);
        }

        public async Task<IActionResult> EditVessel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vessel = await _datacontext.Vessels.FindAsync(id);

            if (vessel == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToVesselViewModel(vessel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditVessel(VesselViewModel model)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var vessel = await _converterHelper.ToVesselAsync(model,path, false);
                _datacontext.Vessels.Update(vessel);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"Index");
            }
            else
            {
                return View(model);
            }
            
        }

        public async Task<IActionResult> DeleteVessel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vessel = await _datacontext.Vessels
                .Include(c => c.Voys)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (vessel == null)
            {
                return NotFound();
            }

            if (vessel.Voys.Count != 0 )
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"Index");
            }

            _datacontext.Vessels.Remove(vessel);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"Index");
        }

    }
}