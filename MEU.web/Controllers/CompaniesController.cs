using MEU.web.Data;
using MEU.web.Data.Entities;
using MEU.web.Helpers;
using MEU.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MEU.web.Controllers
{

    [Authorize(Roles ="Manager")]
    public class CompaniesController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public CompaniesController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper,IConverterHelper converterHelper,IImageHelper imageHelper)
        {
            _datacontext = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        public IActionResult Index()
        {
            return View(_datacontext.Companies
                .Include(c => c.Clients)
                .Include(v => v.Voys)
                .ThenInclude(s => s.Statuses)
                .Include(v => v.Voys)
                .ThenInclude(v => v.Vessel)
                );
        }

        public IActionResult Create_Company()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_Company(Company company)
        {
            if (ModelState.IsValid)
            {
                _datacontext.Add(company);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        public async Task<IActionResult> EditCompany(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _datacontext.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCompany(int? id, Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _datacontext.Update(company);
                    await _datacontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var valcomp = _datacontext.Companies.FindAsync(id);
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
            return View(company);
        }

        public async Task<IActionResult> DeleteCompany(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _datacontext.Companies
                .Include(c => c.Clients)
                .Include(v => v.Voys)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            if (company.Clients.Count !=0 || company.Voys.Count !=0)
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction(nameof(Index));
            }

            _datacontext.Companies.Remove(company);
            await _datacontext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> ClientList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _datacontext.Companies
                .Include(c => c.Clients)
                .ThenInclude(u => u.User)
                .Include(v => v.Voys)
                .ThenInclude(s => s.Statuses)
                .Include(v => v.Voys)
                .ThenInclude(v => v.Vessel)
                .Include(v => v.Voys)
                .ThenInclude(p => p.Port)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        public async Task<IActionResult> ClientDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _datacontext.Clients
                .Include(u => u.User)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClient(AddUserViewModel model, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var company = await _datacontext.Companies.FindAsync(id);
            if (ModelState.IsValid)
            {
                var user = await CreateClient(model);

                if (user != null)
                {
                    var client = new Client
                    {
                        User = user,
                        Company = company,


                    };
                    _datacontext.Clients.Add(client);//queda en memoria
                    await _datacontext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "User already exists");
            }

            return View(model);
        }

        private async Task<User> CreateClient(AddUserViewModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Username,
                UserName = model.Username,
                Document = model.Document,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userHelper.AddUserAsync(user, model.Password);

            if (result.Succeeded)
            {
                user = await _userHelper.GetUserByEmailAsync(model.Username);
                await _userHelper.AddUserToRoleAsync(user, "Client");
                return user;
            }
            return null;
        }


        public async Task<IActionResult> DeleteClient(int? id)
        {
            var client = await _datacontext.Clients
                .Include(s => s.Company)
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || client == null)
            {
                return NotFound();
            }

            _datacontext.Clients.Remove(client);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"{nameof(ClientList)}/{client.Company.Id}");

        }
        
        public async Task<IActionResult> EditClient(int? id)
        {
            var client = await _datacontext.Clients
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || client == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                Document = client.User.Document,
                FirstName = client.User.FirstName,
                LastName = client.User.LastName,
                PhoneNumber = client.User.PhoneNumber,
                Id = client.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditClient(EditUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var client = await _datacontext.Clients
                .Include(u => u.User)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(p => p.Id == view.Id);

                client.User.Document = view.Document;
                client.User.FirstName = view.FirstName;
                client.User.LastName = view.LastName;
                client.User.PhoneNumber = view.PhoneNumber;

                await _userHelper.UpdateUserAsync(client.User);
                return RedirectToAction($"{nameof(ClientList)}/{client.Company.Id}");
            }

            return View(view);
        }


        public async Task<IActionResult> VoyList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _datacontext.Companies
                .Include(c => c.Clients)
                .ThenInclude(u => u.User)
                .Include(v => v.Voys)
                .ThenInclude(s => s.Statuses)
                .Include(v => v.Voys)
                .ThenInclude(v => v.Vessel)
                .Include(v => v.Voys)
                .ThenInclude(p => p.Port)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        public async Task<IActionResult> AddVoy(int? id)
        {
            var company = await _datacontext.Companies.FindAsync(id);

            if (id == null || company == null)
            {
                return NotFound();
            }

            var model = new VoysViewModel
            {
                Company_id = company.Id,
                Employee_list = _combosHelper.GetComboEmployees(),
                Port_list = _combosHelper.GetComboPorts(),
                Vessel_list = _combosHelper.GetComboVessels(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddVoy(VoysViewModel model)
        {

            if (ModelState.IsValid)
            {
                var voy = await _converterHelper.ToVoyAsync(model,true);
                _datacontext.Voys.Add(voy);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"VoyList/{model.Company_id}");
            }
            model.Employee_list = _combosHelper.GetComboEmployees();
            model.Vessel_list = _combosHelper.GetComboVessels();
            model.Port_list = _combosHelper.GetComboPorts();
            return View(model);
        }


        public async Task<IActionResult> EditVoy(int? id)
        {
            var voy = await _datacontext.Voys
                .Include(e => e.Employee)
                .Include(c => c.Company)
                .Include(p => p.Port)
                .Include(v => v.Vessel)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (id == null || voy == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToVoyViewModel(voy);

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> EditVoy(VoysViewModel model)
        {

            if (ModelState.IsValid)
            {
                var voy = await _converterHelper.ToVoyAsync(model, false);
                _datacontext.Voys.Update(voy);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"VoyList/{model.Company_id}");
            }
            return View(model);
        }


        public async Task<IActionResult> Deletevoy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voy = await _datacontext.Voys
                .Include(c => c.Voyimages)
                .Include(v => v.Statuses)
                .Include(v => v.Opinions)
                .Include(a => a.Company)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (voy == null)
            {
                return NotFound();
            }

            if (voy.Voyimages.Count != 0 || voy.Statuses.Count != 0 || voy.Opinions.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"VoyList/{voy.Company.Id}");
            }

            _datacontext.Voys.Remove(voy);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"VoyList/{voy.Company.Id}");
        }



        public async Task<IActionResult> OpinionList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voy = await _datacontext.Voys
                .Include(c => c.Opinions)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voy == null)
            {
                return NotFound();
            }

            return View(voy);
        }

        public async Task<IActionResult> AddOpinion(int? id)
        {
            var voy = await _datacontext.Voys.FindAsync(id);

            if (id == null || voy == null)
            {
                return NotFound();
            }

            var model = new OpinionViewModel
            {
                Voy_id = voy.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOpinion(OpinionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var opinion = await _converterHelper.ToOpinionAsync(model, true);
                _datacontext.Opinions.Add(opinion);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"OpinionList/{model.Voy_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditOpinion(int? id)
        {
             var opinion = await _datacontext.Opinions
                .Include(c => c.Voy)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (id == null || opinion == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToOpinionViewModel(opinion);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditOpinion(OpinionViewModel model)
        {

            if (ModelState.IsValid)
            {
                var opinion = await _converterHelper.ToOpinionAsync(model, false);
                _datacontext.Opinions.Update(opinion);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"OpinionList/{model.Voy_id}");
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteOpinion(int? id)
        {
            var opinion = await _datacontext.Opinions
                .Include(v => v.Voy)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || opinion == null)
            {
                return NotFound();
            }

            _datacontext.Opinions.Remove(opinion);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"{nameof(OpinionList)}/{opinion.Voy.Id}");

        }



        public async Task<IActionResult> StatusList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voy = await _datacontext.Voys
                .Include(c => c.Statuses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voy == null)
            {
                return NotFound();
            }

            return View(voy);
        }

        public async Task<IActionResult> AddStatus(int? id)
        {
            var voy = await _datacontext.Voys.FindAsync(id);

            if (id == null || voy == null)
            {
                return NotFound();
            }

            var model = new StatusViewModel
            {
                Voy_id = voy.Id,
                
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStatus(StatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = await _converterHelper.ToStatusAsync(model, true);
                _datacontext.Statuses.Add(status);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"StatusList/{model.Voy_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditStatus(int? id)
        {
            var statuses = await _datacontext.Statuses
                .Include(v => v.Voy)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || statuses == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToStatusViewModel(statuses);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStatus(StatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = await _converterHelper.ToStatusAsync(model, false);
                _datacontext.Statuses.Update(status);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"StatusList/{model.Voy_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _datacontext.Statuses
                .Include(c => c.Holds)
                .Include(v => v.Alerts)
                .Include(a => a.Voy)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            if (status.Holds.Count != 0 || status.Alerts.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"StatusList/{status.Voy.Id}");
            }

            _datacontext.Statuses.Remove(status);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"StatusList/{status.Voy.Id}");
        }


        #region Hold
        public async Task<IActionResult> HoldList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voy = await _datacontext.Statuses
                .Include(c => c.Holds)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voy == null)
            {
                return NotFound();
            }

            return View(voy);
        }

        public async Task<IActionResult> AddHold(int? id)
        {
            var status = await _datacontext.Statuses.FindAsync(id);

            if (id == null || status == null)
            {
                return NotFound();
            }

            var model = new HoldViewModel
            {
                Status_id =  status.Id

            };

            return View(model);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHold(HoldViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hold = await _converterHelper.ToHoldAsync(model, true);
                _datacontext.Holds.Add(hold);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"HoldList/{model.Status_id}");
            }

            return View(model);
        }
        
        public async Task<IActionResult> EditHold(int? id)
        {
            var hold = await _datacontext.Holds
                .Include(v => v.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || hold == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToHoldViewModel(hold);

            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHold(HoldViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hold = await _converterHelper.ToHoldAsync(model, false);
                _datacontext.Holds.Update(hold);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"HoldList/{model.Status_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteHold(int? id)
        {
            var hold = await _datacontext.Holds
                .Include(v => v.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || hold == null)
            {
                return NotFound();
            }

            _datacontext.Holds.Remove(hold);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"{nameof(HoldList)}/{hold.Status.Id}");

        }

        #endregion
        public async Task<IActionResult> AlertList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _datacontext.Statuses
                .Include(a => a.Alerts)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        public async Task<IActionResult> AddAlert(int? id)
        {
            var status = await _datacontext.Statuses.FindAsync(id);

            if (id == null || status == null)
            {
                return NotFound();
            }

            var model = new AlertsViewModel
            {
                Status_id = status.Id,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAlert(AlertsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var alert = await _converterHelper.ToAlertAsync(model, true);
                _datacontext.Alerts.Add(alert);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"AlertList/{model.Status_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditAlert(int? id)
        {
            var alert = await _datacontext.Alerts
                .Include(s => s.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || alert == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToAlertViewModel(alert);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAlert(AlertsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = await _converterHelper.ToAlertAsync(model, false);
                _datacontext.Alerts.Update(status);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"AlertList/{model.Status_id}");
            }

            return View(model);
        }


        public async Task<IActionResult> DeleteAlert(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _datacontext.Alerts
                .Include(c => c.AlertImages)
                .Include(s => s.Status)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if (alert == null)
            {
                return NotFound();
            }

            if (alert.AlertImages.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"AlertList/{alert.Status.Id}");
            }

            _datacontext.Alerts.Remove(alert);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"AlertList/{alert.Status.Id}");
        }




        public async Task<IActionResult> AlertImagetList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _datacontext.Alerts
                .Include(a => a.AlertImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        public async Task<IActionResult> AddAlertImage(int? id)
        {
            var alert = await _datacontext.Alerts.FindAsync(id);

            if (id == null || alert == null)
            {
                return NotFound();
            }

            var model = new AlertImageViewModel
            {
                 Alert_id = alert.Id,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAlertImage(AlertImageViewModel model)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var alert = await _converterHelper.ToAlertImageAsync(model,path, true);
                _datacontext.AlertImages.Add(alert);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"AlertImagetList/{model.Alert_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditAlertImage(int? id)
        {
            var alertimg = await _datacontext.AlertImages
                .Include(s => s.Alert)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || alertimg == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToAlertImageViewModel(alertimg);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAlertImage(AlertImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var status = await _converterHelper.ToAlertImageAsync(model,path, false);
                _datacontext.AlertImages.Update(status);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"AlertImagetList/{model.Alert_id}");
            }

            return View(model);
        }


        public async Task<IActionResult> DeleteAlertImage(int? id)
        {
            var alertImage = await _datacontext.AlertImages
                .Include(v => v.Alert)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || alertImage == null)
            {
                return NotFound();
            }

            _datacontext.AlertImages.Remove(alertImage);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"{nameof(AlertImagetList)}/{alertImage.Alert.Id}");

        }


        public async Task<IActionResult> VoyImagetList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voy = await _datacontext.Voys
                .Include(a => a.Voyimages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voy == null)
            {
                return NotFound();
            }

            return View(voy);
        }

        public async Task<IActionResult> AddVoyImage(int? id)
        {
            var voy = await _datacontext.Voys.FindAsync(id);

            if (id == null || voy == null)
            {
                return NotFound();
            }

            var model = new VoyImageViewModel
            {
                Voy_id = voy.Id,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVoyImage(VoyImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var voyimg = await _converterHelper.ToVoyImageAsync(model,path, true);
                _datacontext.Voyimages.Add(voyimg);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"VoyImagetList/{model.Voy_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditVoyImage(int? id)
        {
            var voyimg = await _datacontext.Voyimages
                .Include(s => s.Voy)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || voyimg == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToVoyImageViewModel(voyimg);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVoyImage(VoyImageViewModel model)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var voyimg = await _converterHelper.ToVoyImageAsync(model,path, false);
                _datacontext.Voyimages.Update(voyimg);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction($"VoyImagetList/{model.Voy_id}");
            }

            return View(model);
        }


        public async Task<IActionResult> DeleteVoyImage(int? id)
        {
            var voyimage = await _datacontext.Voyimages
                .Include(v => v.Voy)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || voyimage == null)
            {
                return NotFound();
            }

            _datacontext.Voyimages.Remove(voyimage);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction($"{nameof(VoyImagetList)}/{voyimage.Voy.Id}");

        }
    }
}