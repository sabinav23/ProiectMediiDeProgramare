using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vaida_Sabina_Proiect.Data;
using Vaida_Sabina_Proiect.Models;

namespace Vaida_Sabina_Proiect.Pages.Albums
{
    public class DetailsModel : PageModel
    {
        private readonly Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext _context;

        public DetailsModel(Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext context)
        {
            _context = context;
        }

        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Album.FirstOrDefaultAsync(m => m.ID == id);

            if (Album == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
