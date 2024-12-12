using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hulladékszállítás.Models;

    public class HulladekSzallitasContext : DbContext
    {
        public HulladekSzallitasContext (DbContextOptions<HulladekSzallitasContext> options)
            : base(options)
        {
        }

        public DbSet<Hulladékszállítás.Models.Szolgaltatas> Szolgaltatas { get; set; } = default!;

        public DbSet<Hulladékszállítás.Models.Naptar> Naptar { get; set; } = default!;

        public DbSet<Hulladékszállítás.Models.Lakig> Lakig { get; set; } = default!;
    }
