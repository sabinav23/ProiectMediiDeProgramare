using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vaida_Sabina_Proiect.Models;

namespace Vaida_Sabina_Proiect.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext _context;

        public IndexModel(Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; }
        public AlbumData AlbumD { get; set; }
        public int AlbumID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            AlbumD = new AlbumData();

            AlbumD.Albums = await _context.Album
            .Include(b => b.RecordLabel)
            .Include(b => b.AlbumCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                AlbumID = id.Value;
                Album album = AlbumD.Albums
                .Where(i => i.ID == id.Value).Single();
                AlbumD.Categories = album.AlbumCategories.Select(s => s.Category);
            }
        }
    }
}
