using Microsoft.EntityFrameworkCore;

using TesteTradeTechnology.Context.TypeConfigurations;
using TesteTradeTechnology.CrossCutting.Interfaces.Context;
using TesteTradeTechnology.Domain.Campeonatos;
using TesteTradeTechnology.Domain.Jogos;
using TesteTradeTechnology.Domain.Placares;
using TesteTradeTechnology.Domain.Times;

namespace TesteTradeTechnology.Context
{
    public class MeuCampeonatoContext : DbContext, IMeuCampeonatoContext
    {
        public MeuCampeonatoContext(DbContextOptions<MeuCampeonatoContext> options) : base(options)
        {
        }

        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Placar> Placares { get; set; }
        public DbSet<Time> Times { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CampeonatoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new JogoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlacarTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeTypeConfiguration());
        }
    }
}