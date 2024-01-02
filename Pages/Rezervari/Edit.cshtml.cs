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
   
    public class EditModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public EditModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervare
                .Include(r => r.Client)  // Asigurați-vă că se încarcă și informațiile despre client
                .FirstOrDefaultAsync(m => m.ID == id);

            if (rezervare == null)
            {
                return NotFound();
            }

            // Verificați dacă utilizatorul curent este autorul rezervării
            var currentUser = await _context.Client.FirstOrDefaultAsync(c => c.Email == User.Identity.Name);

            if (currentUser == null || rezervare.ClientID != currentUser.ID)
            {
                // Utilizatorul curent nu are permisiunea de a modifica această rezervare
                return Forbid();
            }

            Rezervare = rezervare;
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "ID");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName", Rezervare.ClientID);
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

           
            var rezervareToUpdate = await _context.Rezervare
                .Include(r => r.Client)
                .FirstOrDefaultAsync(m => m.ID == Rezervare.ID);

            
            if (rezervareToUpdate == null)
            {
                return NotFound();
            }

            
            var client = await _context.Client.FirstOrDefaultAsync(c => c.ID == Rezervare.ClientID);

           
            if (client != null)
            {
                
                rezervareToUpdate.Data_start = Rezervare.Data_start;
                rezervareToUpdate.Data_end = Rezervare.Data_end;
                rezervareToUpdate.Pret_total = Rezervare.Pret_total;

                // Setează ClientID în rezervare
                rezervareToUpdate.ClientID = Rezervare.ClientID;

                // Atașează și marchează entitatea ca modificată
                _context.Attach(rezervareToUpdate).State = EntityState.Modified;

                // Salvează modificările în baza de date
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            else
            {
                // Clientul nu a fost găsit, deci întoarce o eroare
                ModelState.AddModelError(string.Empty, "Client not found.");
                return Page();
            }
        }

        private bool RezervareExists(int id)
        {
          return (_context.Rezervare?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
