using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Camere
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public IndexModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string WarningMessage { get; private set; }
        public List<Camera> Camera { get; private set; }

        public async Task OnGetAsync()
        {
            IQueryable<Camera> camerasQuery = _context.Camera;

            if (!string.IsNullOrEmpty(SearchString))
            {
                camerasQuery = camerasQuery.Where(c => c.NumarCamera.ToString() == SearchString);
            }

            Camera = await camerasQuery.ToListAsync();

            if (!string.IsNullOrEmpty(SearchString) && !Camera.Any())
            {
                WarningMessage = $"Nu exista camera cu numarul : {SearchString}.";
            }
        }
    }
}
