using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Domain.Campeonatos;
using TesteTradeTechnology.Domain.Jogos;
using TesteTradeTechnology.Domain.Placares;
using TesteTradeTechnology.Domain.Times;

namespace TesteTradeTechnology.CrossCutting.Interfaces.Context
{
    public interface IMeuCampeonatoContext : IDbContext
    {
        public DbSet<Campeonato> Campeonatos { get; }
        public DbSet<Jogo> Jogos { get; }
        public DbSet<Placar> Placares { get; }
        public DbSet<Time> Times { get; }
    }
}
