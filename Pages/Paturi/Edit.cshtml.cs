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

namespace Proiect_hotel.Pages.Paturi
{
    public class EditModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public EditModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pat Pat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pat == null)
            {
                return NotFound();
            }

            var pat =  await _context.Pat.FirstOrDefaultAsync(m => m.ID == id);
            if (pat == null)
            {
                return NotFound();
            }
            Pat = pat;
           ViewData["CameraID"] = new SelectList(_context.Camera, "ID", "NumarCamera");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
         public List<SelectListItem> CameraOptions { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pat == null)
            {
                return NotFound();
            }

            var pat = await _context.Pat.FirstOrDefaultAsync(m => m.ID == id);
            if (pat == null)
            {
                return NotFound();
            }
            Pat = pat;


            ViewData["CameraID"] = new SelectList(_context.Camera, "ID", "NumarCamera");


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatExists(Pat.ID))
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

        private bool PatExists(int id)
        {
          return (_context.Pat?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
