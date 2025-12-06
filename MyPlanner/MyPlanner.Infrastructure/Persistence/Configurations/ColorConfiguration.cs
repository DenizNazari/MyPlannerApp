using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlanner.Domain.Entities;


namespace MyPlanner.Infrastructure.Persistence.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Label).HasMaxLength(50);
            builder.Property(c => c.Value).HasMaxLength(50); // Hex kodu (#FFFFFF)
        }
    }
}
