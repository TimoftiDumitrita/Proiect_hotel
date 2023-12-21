using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Rezervari_camera
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public CreateModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CameraID"] = new SelectList(_context.Camera, "ID", "NumarCamera");
            ViewData["RezervareID"] = new SelectList(_context.Rezervare, "ID", "ID"); 

            return Page();
        }

        [BindProperty]
        public Rezervare_camera Rezervare_camera { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rezervare_camera == null || Rezervare_camera == null)
            {
                return Page();
            }

            _context.Rezervare_camera.Add(Rezervare_camera);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
