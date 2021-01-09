using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vaida_Sabina_Proiect.Models
{
    public class Album
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage= "Nmele Cantaretului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        public string Singer { get; set; }

        [Display(Name = "Number of songs")]
        public int NumberOfSongs { get; set; }
        
        [Range(1, 500)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int RecordLabelID { get; set; }
        public RecordLabel RecordLabel { get; set; }

        public ICollection<AlbumCategory> AlbumCategories { get; set; }
    }
}
