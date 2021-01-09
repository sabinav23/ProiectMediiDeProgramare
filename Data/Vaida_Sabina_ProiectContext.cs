using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vaida_Sabina_Proiect.Models;

namespace Vaida_Sabina_Proiect.Data
{
    public class Vaida_Sabina_ProiectContext : DbContext
    {
        public Vaida_Sabina_ProiectContext (DbContextOptions<Vaida_Sabina_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Vaida_Sabina_Proiect.Models.Album> Album { get; set; }

        public DbSet<Vaida_Sabina_Proiect.Models.RecordLabel> RecordLabel { get; set; }

        public DbSet<Vaida_Sabina_Proiect.Models.AlbumCategory> AlbumCategory { get; set; }

        public DbSet<Vaida_Sabina_Proiect.Models.Category> Category { get; set; }
    }
}
