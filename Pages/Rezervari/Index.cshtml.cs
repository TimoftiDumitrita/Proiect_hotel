using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Rezervari
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public IndexModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

        public IList<Rezervare> Rezervare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rezervare != null)
            {
                Rezervare = await _context.Rezervare
                .Include(r => r.Client).ToListAsync();
            }
        }
    }
}
