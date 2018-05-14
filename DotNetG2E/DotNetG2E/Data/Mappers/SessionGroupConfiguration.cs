using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Mappers
{
	public class SessionGroupConfiguration : IEntityTypeConfiguration<Session_Group>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Session_Group> builder)
		{
			builder.ToTable("SessionGroup");
			builder.HasKey(t => t.SessionCode);
			builder.Property(t => t.GroupId)
				.IsRequired();
			builder.Property(t => t.SessionCode)
				.IsRequired();

			//builder.HasMany(t => t.Sessions)
			//	.WithOne()
			//	.IsRequired()
			//	//.HasForeignKey(t => t.SessionCode)
			//	.OnDelete(DeleteBehavior.Restrict);

			//builder.HasMany(t => t.Groups)
			//	.WithOne()
			//	.IsRequired()
			//	//.HasForeignKey(t => t.GroupId)
			//	.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
