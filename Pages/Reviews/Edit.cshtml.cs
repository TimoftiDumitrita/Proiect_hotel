﻿using System;
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
    public class EditModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public EditModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;
        public SelectList RateList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review =  await _context.Review.FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            Review = review;
            RateList = new SelectList(Enum.GetValues(typeof(Rate)).Cast<Rate>(), Review.Rate);
            Review = await _context.Review.FirstOrDefaultAsync(m => m.Id == id);



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
            if (Review.Client == null)
            {
                ModelState.AddModelError("Review.Client.ID", "Client information is missing.");
                return Page();
            }

            var existingClient = await _context.Client.FindAsync(Review.Client.ID);
            if (existingClient == null)
            {
                ModelState.AddModelError("Review.Client.ID", "Client with the specified ID does not exist.");
                return Page();
            }

            if (Enum.TryParse(typeof(Rate), Request.Form["Review.Rate"], out var rate))
            {
                Review.Rate = (Rate)rate;
            }
            else
            {
                
                ModelState.AddModelError("Review.Rate", "Invalid rate value");
                return Page();
            }

            try
            {
                _context.Entry(Review).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Review = await _context.Review.FirstOrDefaultAsync(m => m.Id == Review.Id);

            return RedirectToPage("./Index");
        }

        private bool ReviewExists(int id)
        {
          return (_context.Review?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
