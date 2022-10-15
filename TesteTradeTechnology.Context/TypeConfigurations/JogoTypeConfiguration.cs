using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Domain.Jogos;

namespace TesteTradeTechnology.Context.TypeConfigurations
{
    public class JogoTypeConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(j => j.Id);

            builder.HasOne(j => j.Placar).WithOne().HasForeignKey<Jogo>(j => j.IdPlacar);
            builder.HasOne(j => j.Campeonato).WithMany(c => c.Jogos).HasForeignKey(j => j.IdCampeonato);
        }
    }
}
