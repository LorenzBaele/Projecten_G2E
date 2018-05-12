using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetG2E.Data.Mappers
{
    public class LeerkrachtConfiguration : IEntityTypeConfiguration<Leerkracht>
    {
        public void Configure(EntityTypeBuilder<Leerkracht> builder)
        {
            //Table name
            builder.ToTable("Leerkracht");

            //Primary Key
            builder.HasKey(b => b.LeerkrachtsNummer);

			//Properties
			builder.Property(b => b.Email)
				.IsRequired()
				.HasMaxLength(255);
			builder.Property(b => b.Surname)
				.IsRequired()
				.HasMaxLength(255);
			builder.Property(b => b.UserName)
				.IsRequired()
				.HasMaxLength(255);
			
			//Associaties

			
            

        }
    }
}