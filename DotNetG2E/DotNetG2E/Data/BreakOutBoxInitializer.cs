using DotNetG2E.Models;
using DotNetG2E.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetG2E.Data
{
    public class BreakOutBoxInitializer
    {
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public BreakOutBoxInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{

			_context = context;
			_userManager = userManager;

		}

		public async Task InitializeData()
		{
			_context.Database.EnsureDeleted();
			if (_context.Database.EnsureCreated())
			{
				//generate some exercises
				//String name, String task, String result, String feedback, String goal, String category, int timeLimit, IEnumerable<int> modifier

				//Exercise testE1 = new Exercise() { Name = "Krachthuis van de cel" };
				//Exercise testE2 = new Exercise() { Name = "Translatie van beweging" };
				//Exercise testE3 = new Exercise() { Name = "Matige vergelijking" };
				//Exercise testE4 = new Exercise() { Name = "Gemakkelijke vergelijking" };

				////generate some actions
				Actie testA = new Actie();

				////generate some bobs
				BoB testB = new BoB();

				////generate some groups
				Group testG = new Group();

				//generate some sessions
				//private Sessie sessie1 = new Sessie("Wiskunde", "Moeilijk", new DateTime(1862, 12, 19), true, true);
				//private Sessie sessie2 = new Sessie("Aardrijkskunde", "Makkelijk", new DateTime(1862, 12, 19), true, true);
				//String name, String desc, DateTime dayStarted, Boolean isDayEducation, Boolean hasFeedback, int sessionCode, boolean isActive, boolean hasStarted
				Sessie testS1 = new Sessie() { Name = "Wiskunde", Desc="Moeilijk", DayStarted= new DateTime(1862, 12, 19) , SessionCode = 123, IsActive = true, HasStarted= false};
				Sessie testS2 = new Sessie() { Name = "Aardrijkskunde", Desc = "Makkelijk", DayStarted = new DateTime(1892, 10, 16), SessionCode = 321, IsActive = false, HasStarted = false };
				Sessie[] sessies = new Sessie[] { testS1, testS2 };
				_context.Sessies.AddRange(sessies);
				//generate a user
				Leerkracht jan = new Leerkracht()
				{
					Surname = "Peeters",
					UserName = "Jan",
					Email = "jan.peeters@hogent.be"
				};

				//Console.WriteLine(jan.Email);
				//Console.ReadKey();

				_context.Leerkrachten.Add(jan);
				ApplicationUser user1 = new ApplicationUser { UserName = jan.Email, Email = jan.Email };
				await _userManager.CreateAsync(user1, "P@ssword1");
				await _userManager.AddClaimAsync(user1, new Claim(ClaimTypes.Role, "Leerkracht"));
				
				_context.SaveChanges();


			}


		}
    }
}
