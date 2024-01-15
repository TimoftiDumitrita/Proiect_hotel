using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Rezervari_camera
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public DeleteModel(Proiect_hotel.Data.Proiect_hotelContext context)
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

            var rezervare_camera = await _context.Rezervare_camera.FirstOrDefaultAsync(m => m.CameraID == id);

            if (rezervare_camera == null)
            {
                return NotFound();
            }
            else 
            {
                Rezervare_camera = rezervare_camera;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rezervare_camera == null)
            {
                return NotFound();
            }

            var rezervare_camera = await _context.Rezervare_camera.FirstOrDefaultAsync(m => m.CameraID == id);

            if (rezervare_camera == null)
            {
                return NotFound();
            }

            try
            {
                _context.Rezervare_camera.Remove(rezervare_camera);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                // Log or handle the exception appropriately
                return RedirectToPage("/Error");
            }
        }
    }
}
