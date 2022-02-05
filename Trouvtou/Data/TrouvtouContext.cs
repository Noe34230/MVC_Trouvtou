using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trouvtou.Models;

    public class TrouvtouContext : DbContext
    {
        public TrouvtouContext (DbContextOptions<TrouvtouContext> options)
            : base(options)
        {
        }

        public DbSet<Trouvtou.Models.Objet> Objet { get; set; }

        public DbSet<Trouvtou.Models.Rangement> Rangement { get; set; }



    }
