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

namespace Proiect_hotel.Pages.Preturi
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
      public Pret Pret { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pret == null)
            {
                return NotFound();
            }

            var pret = await _context.Pret
               .Include(p => p.Camere)
               .FirstOrDefaultAsync(m => m.ID == id);

            if (pret == null)
            {
                return NotFound();
            }
            else 
            {
                Pret = pret;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pret == null)
            {
                return NotFound();
            }
            var pret = await _context.Pret.FindAsync(id);

            if (pret != null)
            {
                Pret = pret;
                _context.Pret.Remove(Pret);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
