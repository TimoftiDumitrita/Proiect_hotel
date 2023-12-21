using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_hotel.Data;
using Proiect_hotel.Models;

namespace Proiect_hotel.Pages.Preturi
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_hotel.Data.Proiect_hotelContext _context;

        public CreateModel(Proiect_hotel.Data.Proiect_hotelContext context)
        {
            _context = context;
        }
        public List<SelectListItem> CameraOptions { get; set; }

        public IActionResult OnGet()
        {
            CameraOptions = _context.Camera.Select(a =>
                                   new SelectListItem
                                   {
                                       Value = a.ID.ToString(),
                                       Text = a.NumarCamera.ToString()
                                   }).ToList();
            return Page();
        }

        [BindProperty]
        public Pret Pret { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Pret == null || Pret == null)
            {
                return Page();
            }

            _context.Pret.Add(Pret);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
