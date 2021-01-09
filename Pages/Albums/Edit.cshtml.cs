using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaida_Sabina_Proiect.Data;
using Vaida_Sabina_Proiect.Models;

namespace Vaida_Sabina_Proiect.Pages.Albums
{
    public class EditModel : AlbumCategoriesPageModel
    {
        private readonly Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext _context;

        public EditModel(Vaida_Sabina_Proiect.Data.Vaida_Sabina_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; }

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Album
                .Include(b => b.RecordLabel)
                .Include(b => b.AlbumCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Album == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Album);
            ViewData["RecordLabelID"] = new SelectList(_context.Set<RecordLabel>(), "ID", "RecordLabelName");

            return Page();
        }
        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumToUpdate = await _context.Album
                .Include(i => i.RecordLabel)
                .Include(i => i.AlbumCategories)
                    .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (albumToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Album>(
                albumToUpdate,
                "Album",
                i => i.Name, i=> i.Singer, i => i.NumberOfSongs, i => i.Price, i => i.ReleaseDate, i => i.RecordLabel))
            {
                UpdateAlbumCategories(_context, selectedCategories, albumToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateAlbumCategories(_context, selectedCategories, albumToUpdate);
            PopulateAssignedCategoryData(_context, albumToUpdate);
            return Page();
        }


        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.ID == id);
        }
    }
}
