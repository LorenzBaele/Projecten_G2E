using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
    public class SessieConfiguration : IEntityTypeConfiguration<Sessie>
    {
        public void Configure(EntityTypeBuilder<Sessie> builder)
        {
            //table & PK

            builder.ToTable("Sessie");
            builder.HasKey(t => t.SessionCode);

            //properties

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(t => t.Desc)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(t => t.IsActive)
                .IsRequired();
			builder.Property(t => t.HasFeedback)
				.IsRequired();
			builder.Property(t => t.IsDayEducation)
				.IsRequired();
            builder.Property(t => t.DayStarted)
                .IsRequired();

			//associations


			builder.HasMany(t => t.Groups)
				.WithOne(t => t.Session)
				.IsRequired()
				//.HasForeignKey(t => t.SessionCode)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(t => t.Box)
				.WithMany()
				.HasForeignKey(t => t.SessionCode)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

		}
    }
}
