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

namespace Proiect_hotel.Pages.Reviews
{
    [Authorize]

    public class CreateModel : PageModel
    {
        
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public CreateModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Rate"] = new SelectList(Enum.GetValues(typeof(Rate)).Cast<Rate>());
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
            
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          
          if (!ModelState.IsValid || _context.Review == null || Review == null)
            {
                return Page();
            }
            var userEmail = User.Identity.Name;
            var client = await _context.Client.FirstOrDefaultAsync(c => c.Email == userEmail);

            if (client != null)
            {
                
                Review.ClientID = client.ID;
                _context.Review.Add(Review);
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
