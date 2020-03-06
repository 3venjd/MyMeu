using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MEU.web.Data;
using MEU.web.Data.Entities;

namespace MEU.web.Controllers
{
    public class VesselTypesController : Controller
    {
        private readonly DataContext _context;

        public VesselTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: VesselTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VesselTypes.ToListAsync());
        }

        // GET: VesselTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vesselType = await _context.VesselTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vesselType == null)
            {
                return NotFound();
            }

            return View(vesselType);
        }

        // GET: VesselTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type_Vessel")] VesselType vesselType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vesselType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vesselType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vesselType = await _context.VesselTypes.FindAsync(id);
            if (vesselType == null)
            {
                return NotFound();
            }
            return View(vesselType);
        }

        // POST: VesselTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type_Vessel")] VesselType vesselType)
        {
            if (id != vesselType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vesselType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VesselTypeExists(vesselType.Id))
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
            return View(vesselType);
        }

        public async Task<IActionResult> DeleteVesselType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vesselType = await _context.VesselTypes
                .Include(c => c.Vessels)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (vesselType == null)
            {
                return NotFound();
            }

            if (vesselType.Vessels.Count != 0 )
            {
                ModelState.AddModelError(string.Empty, "you Can´t delete this, because it has data asociate");
                return RedirectToAction($"Index");
            }

            _context.VesselTypes.Remove(vesselType);
            await _context.SaveChangesAsync();
            return RedirectToAction($"Index");
        }

        private bool VesselTypeExists(int id)
        {
            return _context.VesselTypes.Any(e => e.Id == id);
        }
    }
}
