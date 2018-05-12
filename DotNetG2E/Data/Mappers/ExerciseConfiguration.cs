using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
	public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
	{
		public void Configure(EntityTypeBuilder<Exercise> builder)
		{
			builder.ToTable("Exercise");
			builder.HasKey(t => t.ExerciseId);

			builder.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(255);
			builder.Property(t => t.Category)
				.IsRequired()
				.HasMaxLength(255);
			builder.Property(t => t.Feedback)
				.IsRequired();
			builder.Property(t => t.Goal)
				.IsRequired()
				.HasMaxLength(255);
			//builder.Property(t => t.Modifiers)
			//	.IsRequired();
			builder.Property(t => t.Result)
				.IsRequired()
				.HasMaxLength(255);
			builder.Property(t => t.Task)
				.IsRequired()
				.HasMaxLength(255);
			builder.Property(t => t.TimeLimit)
				.IsRequired();

			builder.HasMany(t => t.Modifiers)
				.WithOne()
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);







		}
	}
}
