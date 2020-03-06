using MEU.web.Data;
using MEU.web.Data.Entities;
using MEU.web.Helpers;
using MEU.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MEU.web.Controllers
{
    public class PortsController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public PortsController(DataContext context, IConverterHelper converterHelper,IImageHelper imageHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        // GET: Ports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ports.ToListAsync());
        }

        // GET: Ports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Ports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }

        // GET: Ports/Create
        public async Task<IActionResult> Create(int? id)
        {
            var port = await _context.Ports.FindAsync(id);

            if (id == null || port == null)
            {
                return NotFound();
            }

            var model = new PortViewModel
            {
                Port_id = port.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var port = await _converterHelper.ToPortAsync(model,path,true);
                _context.Ports.Add(port);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Ports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var port = await _context.Ports
                .Include(t => t.Terminals)
                .Include(v => v.Voys)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || port == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToPortViewModel(port);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PortViewModel model)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }

                var port = await _converterHelper.ToPortAsync(model, path,false);
                _context.Ports.Update(port);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Index");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> DeletePort(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Ports
                .Include(c => c.Voys)
                .Include(v => v.Terminals)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (port == null)
            {
                return NotFound();
            }

            if (port.Voys.Count != 0 || port.Terminals.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"Index");
            }

            _context.Ports.Remove(port);
            await _context.SaveChangesAsync();
            return RedirectToAction($"Index");
        }

        public async Task<IActionResult> TerminalsList(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var port = await _context.Ports
                .Include(c => c.Terminals)
                .ThenInclude(l => l.LineUps)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }




        public async Task<IActionResult> AddTerminal(int? id)
        {
            var port = await _context.Ports.FindAsync(id);

            if (id == null || port == null)
            {
                return NotFound();
            }

            var model = new TerminalViewModel
            {
                Port_id = port.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTerminal(TerminalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }


                var terminal = await _converterHelper.ToTerminalAsync(model,path, true);
                _context.Terminals.Add(terminal);
                await _context.SaveChangesAsync();
                return RedirectToAction($"TerminalsList/{model.Port_id}");
            }

            return View(model);
        }


        public async Task<IActionResult> EditTerminal(int? id)
        {
            var terminal = await _context.Terminals
                .Include(p => p.Port)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (id == null || terminal == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToTerminalViewModel(terminal);


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTerminal(TerminalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.ImageFile);
                }


                var terminal = await _converterHelper.ToTerminalAsync(model,path, false);
                _context.Terminals.Update(terminal);
                await _context.SaveChangesAsync();
                return RedirectToAction($"TerminalsList/{model.Port_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteTerminal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminals = await _context.Terminals
                .Include(c => c.LineUps)
                .Include(p => p.Port)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (terminals == null)
            {
                return NotFound();
            }

            if (terminals.LineUps.Count != 0)
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"TerminalList/{terminals.Port.Id}");
            }

            _context.Terminals.Remove(terminals);
            await _context.SaveChangesAsync();
            return RedirectToAction($"TerminalList/{terminals.Port.Id}");
        }


        public async Task<IActionResult> LineUpList(int? id)
        {
            var terminal = await _context.Terminals
                .Include(a => a.LineUps)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (id == null || terminal == null)
            {
                return NotFound();
            }


            return View(terminal);
        }

        public async Task<IActionResult> DetailsLineUp(int? id)
        {
            var lineUp = await _context.LineUps
                .Include(a => a.Terminal)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (id == null || lineUp == null)
            {
                return NotFound();
            }


            return View(lineUp);
        }

        public async Task<IActionResult> AddLineUp(int? id)
        {
            var terminal = await _context.Terminals.FindAsync(id);

            if (id == null || terminal == null)
            {
                return NotFound();
            }

            var model = new LineUpViewModel
            {
                Terminal_id = terminal.Id,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLineUp(LineUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                

                var lineup = await _converterHelper.ToLineUpAsync(model, true);
                _context.LineUps.Add(lineup);
                await _context.SaveChangesAsync();
                return RedirectToAction($"LineUpList/{model.Terminal_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditLineUp(int? id)
        {
            var lineup = await _context.LineUps
                .Include(s => s.Terminal)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || lineup == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToLineUpViewModel(lineup);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLineUp(LineUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lineup = await _converterHelper.ToLineUpAsync(model, false);
                _context.LineUps.Update(lineup);
                await _context.SaveChangesAsync();
                return RedirectToAction($"LineUpList/{model.Terminal_id}");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteLineUp(int? id)
        {
            var lineUp = await _context.LineUps
                .Include(s => s.Terminal)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (id == null || lineUp == null)
            {
                return NotFound();
            }

            _context.LineUps.Remove(lineUp);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(LineUpList)}/{lineUp.Terminal.Id}");

        }


    }
}
