using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Priori.francesco._5h.ECommerce.Models;

    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<Priori.francesco._5h.ECommerce.Models.Componenti> Componenti { get; set; } = default!;

public DbSet<Priori.francesco._5h.ECommerce.Models.Utenti> Utenti { get; set; } = default!;
    }
