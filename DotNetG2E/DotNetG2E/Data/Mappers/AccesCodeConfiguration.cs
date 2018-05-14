using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
	public class AccesCodeConfiguration : IEntityTypeConfiguration<AccesCode>
	{
		public void Configure(EntityTypeBuilder<AccesCode> builder)
		{
			builder.ToTable("AccesCode");
			builder.HasKey(t => t.id);

			builder.Property(t => t.Code)
				.IsRequired()
				.HasMaxLength(255);

		}
	}
}
