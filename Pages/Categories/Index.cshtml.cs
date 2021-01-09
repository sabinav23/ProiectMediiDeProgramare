using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vaida_Sabina_Proiect.Data;
using Vaida_Sabina_Proiect.Models;

namespace Vaida_Sabina_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext _context;

        public IndexModel(Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext context)
        {
            _context = context;
        }

        public IList<AlbumCategory> AlbumCategory { get;set; }

        public async Task OnGetAsync()
        {
            AlbumCategory = await _context.AlbumCategory
                .Include(a => a.Album)
                .Include(a => a.Category).ToListAsync();
        }
    }
}
