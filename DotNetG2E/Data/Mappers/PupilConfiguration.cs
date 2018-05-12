using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Mappers
{
	public class PupilConfiguration : IEntityTypeConfiguration<Pupil>
	{
		public void Configure(EntityTypeBuilder<Pupil> builder)
		{
			builder.ToTable("Pupil");

			builder.HasKey(t => t.PupilId);

		}
	}
}
