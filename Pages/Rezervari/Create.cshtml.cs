using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Rezervari
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
        public Rezervare Rezervare { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Rezervare == null || Rezervare == null)
            {
                return Page();
            }

            var userEmail = User.Identity.Name;
            var client = await _context.Client.FirstOrDefaultAsync(c => c.Email == userEmail);

            if (client != null)
            {
                Rezervare.ClientID = client.ID;

                TimeSpan diferentaInZile = Rezervare.Data_end - Rezervare.Data_start;
                Rezervare.Pret_total = (int)Math.Ceiling(diferentaInZile.TotalDays) * 200;

                _context.Rezervare.Add(Rezervare);
                await _context.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Client not found.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

