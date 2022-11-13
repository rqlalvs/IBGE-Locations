using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locations.Context;
using Locations.DTO;

namespace Locations.Controllers
{
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Location
        public async Task<IActionResult> Index()
        {
              return View(await _context.Location.ToListAsync());
        }

        // GET: Location/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }

            var locationDTO = await _context.Location
                .FirstOrDefaultAsync(m => m.ID == id);
            if (locationDTO == null)
            {
                return NotFound();
            }

            return View(locationDTO);
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Sigla,Nome")] LocationDTO locationDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationDTO);
        }

        // GET: Location/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }

            var locationDTO = await _context.Location.FindAsync(id);
            if (locationDTO == null)
            {
                return NotFound();
            }
            return View(locationDTO);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Sigla,Nome")] LocationDTO locationDTO)
        {
            if (id != locationDTO.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationDTOExists(locationDTO.ID))
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
            return View(locationDTO);
        }

        // GET: Location/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }

            var locationDTO = await _context.Location
                .FirstOrDefaultAsync(m => m.ID == id);
            if (locationDTO == null)
            {
                return NotFound();
            }

            return View(locationDTO);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Location == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Location'  is null.");
            }
            var locationDTO = await _context.Location.FindAsync(id);
            if (locationDTO != null)
            {
                _context.Location.Remove(locationDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationDTOExists(int id)
        {
          return _context.Location.Any(e => e.ID == id);
        }
    }
}
