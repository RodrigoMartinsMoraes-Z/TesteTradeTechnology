using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Domain.Campeonatos;

namespace TesteTradeTechnology.Context.TypeConfigurations
{
    public class CampeonatoTypeConfiguration : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
