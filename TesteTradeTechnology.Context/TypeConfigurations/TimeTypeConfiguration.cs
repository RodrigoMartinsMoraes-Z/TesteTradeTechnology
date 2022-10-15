using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteTradeTechnology.Domain.Times;

namespace TesteTradeTechnology.Context.TypeConfigurations
{
    public class TimeTypeConfiguration : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasData(new Time
            {
                Id = 1,
                Nome = "Time1"
            });
            builder.HasData(new Time
            {
                Id = 2,
                Nome = "Time2"
            });
            builder.HasData(new Time
            {
                Id = 3,
                Nome = "Time3"
            });
            builder.HasData(new Time
            {
                Id = 4,
                Nome = "Time4"
            });
            builder.HasData(new Time
            {
                Id = 5,
                Nome = "Time5"
            });
            builder.HasData(new Time
            {
                Id = 6,
                Nome = "Time6"
            });
            builder.HasData(new Time
            {
                Id = 7,
                Nome = "Time7"
            });
            builder.HasData(new Time
            {
                Id = 8,
                Nome = "Time8"
            });
        }
    }
}
