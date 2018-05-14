using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetG2E.Data.Mappers;
using DotNetG2E.Models;
using DotNetG2E.Models.Domain;

namespace DotNetG2E.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
        public DbSet<Leerkracht> Leerkrachten { get; set; }
		public DbSet<Leerling> Leerlingen { get; set; }

		public DbSet<Sessie> Sessies { get; set; }

		public DbSet<Group> Groups { get; set; }
		public DbSet<Actie> Acties { get; set; }
		public DbSet<BoB> BoBs { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<Modifier> Modifiers { get; set; }
		public DbSet<Pupil> Pupils { get; set; }
		public DbSet<Session_Group> Session_Group { get; set; }
		public DbSet<BoB_Action> BoB_Action { get; set; }
		public DbSet<BoB_Exercise> BoB_Exercise { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			
			builder.ApplyConfiguration(new LeerkrachtConfiguration());
			builder.ApplyConfiguration(new SessieConfiguration());
			builder.ApplyConfiguration(new GroupConfiguration());
			builder.ApplyConfiguration(new LeerlingConfiguration());
			builder.ApplyConfiguration(new ActieConfiguration());
			builder.ApplyConfiguration(new ExerciseConfiguration());
			builder.ApplyConfiguration(new BoBConfiguration());
			builder.ApplyConfiguration(new ModifierConfiguration());
			builder.ApplyConfiguration(new PupilConfiguration());
			builder.ApplyConfiguration(new BoBActieConfiguration());
			builder.ApplyConfiguration(new BoBExerciseConfiguration());
			builder.ApplyConfiguration(new SessionGroupConfiguration());

			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);
		}
    }
}
