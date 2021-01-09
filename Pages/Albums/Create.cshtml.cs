using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vaida_Sabina_Proiect.Data;
using Vaida_Sabina_Proiect.Models;

namespace Vaida_Sabina_Proiect.Pages.Albums
{
    public class CreateModel : AlbumCategoriesPageModel
    {
        private readonly Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext _context;

        public CreateModel(Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RecordLabelID"] = new SelectList(_context.Set<RecordLabel>(), "ID", "RecordLabelName");

            var album = new Album();
            album.AlbumCategories = new List<AlbumCategory>();
            PopulateAssignedCategoryData(_context, album);
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newAlbum = new Album();
            if (selectedCategories != null)
            {
                newAlbum.AlbumCategories = new List<AlbumCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new AlbumCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newAlbum.AlbumCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Album>(
            newAlbum,
            "Album",
            i => i.Name, i => i.Singer,
            i => i.NumberOfSongs, i => i.Price, i => i.ReleaseDate, i => i.RecordLabel, i => i.RecordLabelID))
            {
                _context.Album.Add(newAlbum);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newAlbum);
            return Page();
        }
    }
}
