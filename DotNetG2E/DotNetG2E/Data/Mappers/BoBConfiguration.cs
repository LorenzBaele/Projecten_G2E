using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
	public class BoBConfiguration : IEntityTypeConfiguration<BoB>
	{
		public void Configure(EntityTypeBuilder<BoB> builder)
		{
			builder.ToTable("BoB");
			builder.HasKey(t => t.BoBId);

			builder.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(255);
			builder.Property(t => t.Description)
				.IsRequired()
				.HasMaxLength(255);

			//builder.Property(t => t.AccesCodes);

			//Associaties
			builder.HasMany(t => t.AccesCodes)
				.WithOne()
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(t => t.Exercises)
				.WithOne()
				.IsRequired()
				//.HasForeignKey(t => t.BoBId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(t => t.Actions)
				.WithOne()
				.IsRequired()
				.HasForeignKey(t => t.BoBId)
				.OnDelete(DeleteBehavior.Cascade);




		}
	}
}
