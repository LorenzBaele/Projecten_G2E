using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
	public class ActieConfiguration : IEntityTypeConfiguration<Actie>
	{
		public void Configure(EntityTypeBuilder<Actie> builder)
		{
			builder.ToTable("Actie");
			builder.HasKey(t => t.ActieId);

			builder.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(255);

		}
	}
}
