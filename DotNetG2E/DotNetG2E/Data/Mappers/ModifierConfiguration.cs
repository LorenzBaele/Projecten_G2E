using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
	public class ModifierConfiguration : IEntityTypeConfiguration<Modifier>
	{
		public void Configure(EntityTypeBuilder<Modifier> builder)
		{
			builder.ToTable("Modifier");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Modifierint)
				.IsRequired();

			
		}
	}
}
