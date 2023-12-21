using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Paturi
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public DetailsModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

      public Pat Pat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pat == null)
            {
                return NotFound();
            }

           
            var pat = await _context.Pat
                .Include(p => p.Camere)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (pat == null)
            {
                return NotFound();
            }

            Pat = pat;
            return Page();
        }
    }
}
