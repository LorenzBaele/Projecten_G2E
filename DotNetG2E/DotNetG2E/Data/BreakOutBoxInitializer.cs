using DotNetG2E.Models;
using DotNetG2E.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
				//generate some exercises w/ modifiers
				//String name, String task, String result, String feedback, String goal, String category, int timeLimit, IEnumerable<int> modifier
				Modifier m1 = new Modifier() { Modifierint = 5 };
				Modifier m2 = new Modifier() { Modifierint = 12 };
				Modifier m3 = new Modifier() { Modifierint = 8 };
				Modifier m4 = new Modifier() { Modifierint = 9 };
				Modifier m5 = new Modifier() { Modifierint = 10 };

				ICollection<Modifier> mfs = new List<Modifier>();

				mfs.Add(m1);
				mfs.Add(m2);
				mfs.Add(m3);
				mfs.Add(m4);
				mfs.Add(m5);

				Exercise testE1 = new Exercise() { Name = "Krachthuis van de cel", Category = "Biologie", Task = "vraag1.pdf", Feedback = "hulp4.pdf", Result = "Mitochondrion", TimeLimit = 80, Goal = "Onderdelen van de cel begrijpen", Modifiers = mfs };
				Exercise testE2 = new Exercise() { Name = "Translatie van beweging", Category = "Fysica", Task = "vergelijking3.pdf", Feedback = "Hulp3.pdf", Result = "Een getal", TimeLimit = 70, Goal = "Begrijpen van de gecompliceerde Fysica", Modifiers = mfs };
				Exercise testE3 = new Exercise() { Name = "Matige vergelijking", Category = "Wiskunde", Task = "vergelijking2.pdf", Feedback = "Hulp2.pdf", Result = "4", TimeLimit = 60, Goal = "Vergelijkingen leren oplossen", Modifiers = mfs };
				Exercise testE4 = new Exercise() { Name = "Gemakkelijke vergelijking", Category = "Wiskunde", Task = "vergelijking1.pdf", Feedback = "Hulp1.pdf", Result = "2", TimeLimit = 50, Goal = "Vergelijkingen leren opstellen", Modifiers = mfs };

				ICollection<Exercise> exList1 = new List<Exercise>();

				exList1.Add(testE1);
				exList1.Add(testE2);

				ICollection<Exercise> exList2 = new List<Exercise>();

				exList2.Add(testE2);
				exList2.Add(testE3);

				ICollection<Exercise> exList3 = new List<Exercise>();

				exList3.Add(testE2);
				exList3.Add(testE3);
				exList3.Add(testE4);

				////generate some actions
				Actie testA1 = new Actie() { Name = "Connect the dots" };
				Actie testA2 = new Actie() { Name = "Open the lunchbox" };
				Actie testA3 = new Actie() { Name = "Find the enveloppe" };
				Actie testA4 = new Actie() { Name = "Pop the balloon" };

				ICollection<Actie> aList1 = new List<Actie>();
				aList1.Add(testA1);

				ICollection<Actie> aList2 = new List<Actie>();
				aList2.Add(testA2);

				ICollection<Actie> aList3 = new List<Actie>();
				aList3.Add(testA3);
				aList3.Add(testA4);

				////generate some accesscodes
				AccesCode testAc1 = new AccesCode() { Code = 1 };
				AccesCode testAc2 = new AccesCode() { Code = 2 };
				AccesCode testAc3 = new AccesCode() { Code = 3 };
				AccesCode testAc4 = new AccesCode() { Code = 4 };

				ICollection<AccesCode> acList1 = new List<AccesCode>();
				acList1.Add(testAc1);
				acList1.Add(testAc2);
				ICollection<AccesCode> acList2 = new List<AccesCode>();
				acList2.Add(testAc2);
				acList2.Add(testAc3);
				ICollection<AccesCode> acList3 = new List<AccesCode>();
				acList3.Add(testAc4);
				acList3.Add(testAc3);

				////generate some bobs
				BoB testB1 = new BoB() { Name = "Biologie", Description = "Inhoud van de cel", AccesCodes = acList1, Actions = aList1, Exercises = exList1 };
				BoB testB2 = new BoB() { Name = "Wiskunde", Description = "Vergelijkingen", AccesCodes = acList3, Actions = aList3, Exercises = exList3 };
				BoB testB3 = new BoB() { Name = "Fysica", Description = "Oefeningen", AccesCodes = acList2, Actions = aList2, Exercises = exList2 };

				//_context.BoBs.Add(testB1);
				//het werkt tot hier, yay!

				////generate some pupils
				Pupil p1 = new Pupil() { Name = "Wannes" };
				Pupil p2 = new Pupil() { Name = "Lorenz" };
				Pupil p3 = new Pupil() { Name = "Arne" };
				Pupil p4 = new Pupil() { Name = "Jef" };
				Pupil p5 = new Pupil() { Name = "Bob" };
				Pupil p6 = new Pupil() { Name = "Jozef" };

				ICollection<Pupil> pList1 = new List<Pupil>();
				pList1.Add(p1);
				pList1.Add(p2);
				pList1.Add(p3);

				ICollection<Pupil> pList2 = new List<Pupil>();
				pList2.Add(p4);
				pList2.Add(p5);
				pList2.Add(p6);

				ICollection<Pupil> pList3 = new List<Pupil>();
				pList3.Add(p6);
				pList3.Add(p4);
				pList3.Add(p1);

				////generate some groups
				Group testG1 = new Group() {  Name = "Groep E1", Pupils = pList1 };
				Group testG2 = new Group() {  Name = "Groep E2", Pupils = pList2 };
				Group testG3 = new Group() {  Name = "Groep E2", Pupils = pList3 };
				//Group[] groups = new Group[] { testG1, testG2 };
				//Group[] groups2 = new Group[] {  testG3 };

				ICollection<Group> gList1 = new List<Group>();
				gList1.Add(testG1);
				gList1.Add(testG2);

				ICollection<Group> gList2 = new List<Group>();
				gList2.Add(testG3);

				//generate some sessions

				Sessie testS1 = new Sessie() { Name = "Wiskunde", Desc = "Moeilijk", DayStarted = new DateTime(1862, 12, 19), IsActive = true, HasStarted = false, HasFeedback = true, IsDayEducation = true, Box = testB1, Groups = gList1 };

				Sessie testS2 = new Sessie() { Name = "Aardrijkskunde", Desc = "Makkelijk", DayStarted = new DateTime(1892, 10, 16), IsActive = false, HasStarted = false, HasFeedback = false, IsDayEducation = true, Box = testB2, Groups = gList2 };

				ICollection<Sessie> sList = new List<Sessie>();
				sList.Add(testS1);
				sList.Add(testS2);

				_context.Sessies.AddRange(sList);

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