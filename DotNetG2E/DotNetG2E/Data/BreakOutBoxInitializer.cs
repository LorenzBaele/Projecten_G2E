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
				//Exercise testE = new Exercise();

				////generate some actions
				//Actie testA = new Actie();

				////generate some bobs
				//BoB testB = new BoB();

				////generate some groups
				//Group testG = new Group();

				//generate some sessions
				//Sessie testS = new Sessie();

				//generate a user
				Leerkracht jan = new Leerkracht()
				{
					Surname = "Peeters",
					UserName = "Jan",
					Email = "jan.peeters@hogent.be"
				};

				Console.WriteLine(jan.Email);
				Console.ReadLine();

				_context.Leerkrachten.Add(jan);
				ApplicationUser user1 = new ApplicationUser { UserName = jan.Email, Email = jan.Email };
				await _userManager.CreateAsync(user1, "P@ssword1");
				await _userManager.AddClaimAsync(user1, new Claim(ClaimTypes.Role, "Leerkracht"));
				
				_context.SaveChanges();


			}


		}
    }
}
