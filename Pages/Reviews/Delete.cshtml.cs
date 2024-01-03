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

namespace Proiect_hotel.Pages.Reviews
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public DeleteModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FirstOrDefaultAsync(m => m.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            var userEmail = User.Identity.Name;
            var client = await _context.Client.FirstOrDefaultAsync(c => c.Email == userEmail);

            if (client == null || review.ClientID != client.ID)
            {
               
                return Forbid();
            }

            Review = review;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);

            if (review != null)
            {
                var userEmail = User.Identity.Name;
                var client = await _context.Client.FirstOrDefaultAsync(c => c.Email == userEmail);

                if (client == null || (review.ClientID != client.ID && !User.IsInRole("Admin")))
                {
                   
                    return Forbid();
                }

                Review = review;
                _context.Review.Remove(Review);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
