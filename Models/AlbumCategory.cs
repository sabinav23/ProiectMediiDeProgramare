using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaida_Sabina_Proiect.Models
{
    public class AlbumCategory
    {
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
