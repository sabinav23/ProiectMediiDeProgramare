using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaida_Sabina_Proiect.Models
{
    public class RecordLabel
    {
        public int ID { get; set; }
        public string RecordLabelName { get; set; }
        public ICollection<Album> Albums { get; set; }

    }
}
