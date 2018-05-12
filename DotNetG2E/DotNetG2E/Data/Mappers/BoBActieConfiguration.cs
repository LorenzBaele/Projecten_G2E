using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Mappers
{
	public class BoBActieConfiguration : IEntityTypeConfiguration<BoB_Action>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BoB_Action> builder)
		{
			builder.ToTable("BobAction");
			builder.HasKey(t => t.BoBId);
			builder.Property(t => t.ActionId)
				.IsRequired();
			builder.Property(t => t.BoBId)
				.IsRequired();


		}
	}
}
