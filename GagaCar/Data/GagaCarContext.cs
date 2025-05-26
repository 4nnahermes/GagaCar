using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GagaCar.Models;

namespace GagaCar.Data
{
    public class GagaCarContext : DbContext
    {
        public GagaCarContext (DbContextOptions<GagaCarContext> options)
            : base(options)
        {
        }

        public DbSet<GagaCar.Models.Carro> Carro { get; set; } = default!;
        public DbSet<GagaCar.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<GagaCar.Models.Vendedor> Vendedor { get; set; } = default!;
        public DbSet<GagaCar.Models.Nota> Nota { get; set; } = default!;
    }
}
