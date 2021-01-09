using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaida_Sabina_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<AlbumCategory> AlbumCategories { get; set; }
    }
}
