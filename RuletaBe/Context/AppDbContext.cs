using Microsoft.EntityFrameworkCore;
using RuletaBe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaBe.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<RULETA> RULETA { get; set; }
        public DbSet<ESTADOS> ESTADOS { get; set; }
        public DbSet<JUGADOR> JUGADOR { get; set; }
        public DbSet<JUGADORES_PARTIDAS> JUGADORES_PARTIDAS { get; set; }
        public DbSet<PARTIDA> PARTIDA { get; set; }

    }
}
