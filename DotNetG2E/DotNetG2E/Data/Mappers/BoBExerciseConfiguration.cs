using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Mappers
{
	public class BoBExerciseConfiguration : IEntityTypeConfiguration<BoB_Exercise>
	{
		public void Configure(EntityTypeBuilder<BoB_Exercise> builder)
		{
			builder.ToTable("BoBExercise");
			builder.HasKey(t => t.BoBId);
			builder.Property(t => t.BoBId)
				.IsRequired(); ;
			builder.Property(t => t.ExerciseId)
				.IsRequired();
		}
	}
}
