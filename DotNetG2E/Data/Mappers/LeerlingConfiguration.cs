using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
    public class LeerlingConfiguration : IEntityTypeConfiguration<Leerling>
    {
        public void Configure(EntityTypeBuilder<Leerling> builder)
        {
			builder.ToTable("Leerling");
			builder.HasKey(l => l.LeerlingId);
        }
    }
}
