using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Mappers
{
	public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
	{
		public void Configure(EntityTypeBuilder<Progress> builder)
		{
			builder.ToTable("Progress");

			builder.HasKey(t => t.GroupId);

			builder.Property(t => t.TotalExercisesNumber)
				.IsRequired();
			builder.Property(t => t.SolvedExercisesNumber)
				.IsRequired();
		}
	}
}
