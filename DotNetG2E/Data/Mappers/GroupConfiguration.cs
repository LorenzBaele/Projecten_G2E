﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
	public class GroupConfiguration : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
		{
			builder.ToTable("Group");
			builder.HasKey(t => t.GroupId);

			builder.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(255);
			//builder.Property(t => t.Pupils)
			//	.IsRequired();

			builder.HasMany(t => t.Pupils)
				.WithOne()
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);


		}
	}
}
