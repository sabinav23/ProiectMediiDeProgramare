using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vaida_Sabina_Proiect.Data;

namespace Vaida_Sabina_Proiect.Models
{
    public class AlbumCategoriesPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Vaida_Sabina_ProiectContext context, Album album)
        {
            var allCategories = context.Category;
            var albumCategories = new HashSet<int>(album.AlbumCategories.Select(c => c.AlbumID));
            this.AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = albumCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateAlbumCategories(Vaida_Sabina_ProiectContext context, string[] selectedCategories, Album albumToUpdate)
        {
            if (selectedCategories == null)
            {
                albumToUpdate.AlbumCategories = new List<AlbumCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var albumCategories = new HashSet<int>(albumToUpdate.AlbumCategories.Select(c => c.Category.ID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!albumCategories.Contains(cat.ID))
                    {
                        albumToUpdate.AlbumCategories.Add(
                            new AlbumCategory
                            {
                                AlbumID = albumToUpdate.ID,
                                CategoryID = cat.ID
                            });
                    }
                }
                else
                {
                    if (albumCategories.Contains(cat.ID))
                    {
                        AlbumCategory courseToRemove = albumToUpdate
                                                            .AlbumCategories
                                                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
