using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Rezervari_camera
{
    public class EditModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public EditModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervare_camera Rezervare_camera { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare_camera == null)
            {
                return NotFound();
            }

            var rezervare_camera =  await _context.Rezervare_camera.FirstOrDefaultAsync(m => m.CameraID == id);
            if (rezervare_camera == null)
            {
                return NotFound();
            }
            Rezervare_camera = rezervare_camera;
           ViewData["CameraID"] = new SelectList(_context.Camera, "ID", "ID");
           ViewData["RezervareID"] = new SelectList(_context.Rezervare, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rezervare_camera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rezervare_cameraExists(Rezervare_camera.CameraID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Rezervare_cameraExists(int? id)
        {
          return (_context.Rezervare_camera?.Any(e => e.CameraID == id)).GetValueOrDefault();
        }
    }
}
