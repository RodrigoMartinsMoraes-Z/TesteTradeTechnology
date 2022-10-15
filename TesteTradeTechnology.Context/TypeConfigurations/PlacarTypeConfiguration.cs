using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Domain.Placares;

namespace TesteTradeTechnology.Context.TypeConfigurations
{
    public class PlacarTypeConfiguration : IEntityTypeConfiguration<Placar>
    {
        public void Configure(EntityTypeBuilder<Placar> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.TimeA).WithMany().HasForeignKey(p => p.IdTimeA);
            builder.HasOne(p => p.TimeB).WithMany().HasForeignKey(p => p.IdTimeB);
        }
    }
}
