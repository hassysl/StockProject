using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired(true);

            builder.Property(x => x.Surname).HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired(true);

            builder.Property(x => x.Username).HasMaxLength(50);
            builder.Property(x => x.Username).IsRequired(true);

            builder.Property(x => x.Password).HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired(true);

           
        }
    }
}
