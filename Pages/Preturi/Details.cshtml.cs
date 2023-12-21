using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Preturi
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public DetailsModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

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
    }
}
