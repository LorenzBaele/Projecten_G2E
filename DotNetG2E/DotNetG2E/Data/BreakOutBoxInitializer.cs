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
				//generate some exercises w/ modifiers
				//String name, String task, String result, String feedback, String goal, String category, int timeLimit, IEnumerable<int> modifier
				Modifier m1 = new Modifier() { Id = 1, Modifierint = 5 };
				Modifier m2 = new Modifier() { Id = 2, Modifierint = 12 };
				Modifier m3 = new Modifier() { Id = 3, Modifierint = 8 };
				Modifier m4 = new Modifier() { Id = 4, Modifierint = 9 };
				Modifier m5 = new Modifier() { Id = 5, Modifierint = 10 };
				Modifier[] mfs = new Modifier[] { m1, m2, m3, m4, m5 };

				Exercise testE1 = new Exercise() { ExerciseId= 1, Name = "Krachthuis van de cel", Category = "Biologie", Task = "vraag1.pdf", Feedback = "hulp4.pdf", Result = "Mitochondrion", TimeLimit = 80, Goal = "Onderdelen van de cel begrijpen", Modifiers = mfs };
				Exercise testE2 = new Exercise() { ExerciseId = 2, Name = "Translatie van beweging", Category = "Fysica", Task = "vergelijking3.pdf", Feedback = "Hulp3.pdf", Result = "Een getal", TimeLimit = 70, Goal = "Begrijpen van de gecompliceerde Fysica", Modifiers = mfs };
				Exercise testE3 = new Exercise() { ExerciseId = 3, Name = "Matige vergelijking", Category = "Wiskunde", Task = "vergelijking2.pdf", Feedback = "Hulp2.pdf", Result = "4", TimeLimit = 60, Goal = "Vergelijkingen leren oplossen", Modifiers = mfs };
				Exercise testE4 = new Exercise() { ExerciseId = 4, Name = "Gemakkelijke vergelijking", Category = "Wiskunde", Task = "vergelijking1.pdf", Feedback = "Hulp1.pdf", Result = "2", TimeLimit = 50, Goal = "Vergelijkingen leren opstellen", Modifiers = mfs };

				Exercise[] exList1 = new Exercise[] { testE1, testE2 };
				Exercise[] exList2 = new Exercise[] { testE2, testE3 };
				Exercise[] exList3 = new Exercise[] { testE2, testE3, testE4 };

				////generate some actions
				Actie testA1 = new Actie() { ActieId = 1, Name = "Connect the dots" };
				Actie testA2 = new Actie() { ActieId = 2, Name = "Open the lunchbox" };
				Actie testA3 = new Actie() { ActieId = 3, Name = "Find the enveloppe" };
				Actie testA4 = new Actie() { ActieId = 4, Name = "Pop the balloon" };

				Actie[] aList1 = new Actie[] { testA1 };
				Actie[] aList2 = new Actie[] { testA2 };
				Actie[] aList3 = new Actie[] { testA3, testA4 };


				////generate some accesscodes
				AccesCode testAc1 = new AccesCode() { id = 1, Code = 1 };
				AccesCode testAc2 = new AccesCode() { id = 2, Code = 2 };
				AccesCode testAc3 = new AccesCode() { id = 3, Code = 3 };
				AccesCode testAc4 = new AccesCode() { id = 4, Code = 4 };

				AccesCode[] acList1 = new AccesCode[] { testAc1, testAc2 };
				AccesCode[] acList2 = new AccesCode[] { testAc2, testAc3 };
				AccesCode[] acList3 = new AccesCode[] { testAc3, testAc4 };

				////generate some bobs
				BoB testB1 = new BoB() { BoBId = 1, Name="Biologie", Description="Inhoud van de cel", AccesCodes = acList1 , Actions = aList1, Exercises = exList1};
				BoB testB2 = new BoB() { BoBId = 2, Name = "Wiskunde", Description = "Vergelijkingen", AccesCodes = acList3, Actions = aList3, Exercises = exList3 };
				BoB testB3 = new BoB() { BoBId = 3, Name = "Fysica", Description = "Oefeningen", AccesCodes = acList2, Actions = aList2, Exercises = exList2 };

				BoB[] bobs = new BoB[] { testB1, testB2, testB3 };
				//_context.BoBs.Add(testB1);

				////generate some pupils
				Pupil p1 = new Pupil() { PupilId = 1, Name = "Wannes" };
				Pupil p2 = new Pupil() { PupilId = 2, Name = "Lorenz" };
				Pupil p3 = new Pupil() { PupilId = 3, Name = "Arne" };
				Pupil p4 = new Pupil() { PupilId = 4, Name = "Jef" };
				Pupil p5 = new Pupil() { PupilId = 5, Name = "Bob" };
				Pupil p6 = new Pupil() { PupilId = 6, Name = "Jozef" };

				Pupil[] pList1 = new Pupil[] { p1, p2, p3 };
				Pupil[] pList2 = new Pupil[] { p4, p5, p6 };
				Pupil[] pList3 = new Pupil[] { p6, p4, p1 };
				////generate some groups
				Group testG1 = new Group() {  GroupId = 1, Name = "Groep E1", Pupils = pList1 };
				Group testG2 = new Group() { GroupId = 2, Name = "Groep E2", Pupils = pList2 };
				Group testG3 = new Group() { GroupId = 3, Name = "Groep E2", Pupils = pList3 };

				//generate some sessions
				//private Sessie sessie1 = new Sessie("Wiskunde", "Moeilijk", new DateTime(1862, 12, 19), true, true);
				//private Sessie sessie2 = new Sessie("Aardrijkskunde", "Makkelijk", new DateTime(1862, 12, 19), true, true);
				//String name, String desc, DateTime dayStarted, Boolean isDayEducation, Boolean hasFeedback, int sessionCode, boolean isActive, boolean hasStarted
				//int s1 = 123;
				//int s2 = 321;

				//int g1 = 1;
				//int g2 = 2;

				//Session_Group sg1 = new Session_Group() { GroupId = g1, SessionCode = s1 };
				//Session_Group sg2 = new Session_Group() { GroupId = g2, SessionCode = s2 };


				//Sessie testS1 = new Sessie() { Name = "Wiskunde", Desc = "Moeilijk", DayStarted = new DateTime(1862, 12, 19), SessionCode = s1, IsActive = true, HasStarted = false, HasFeedback = true, IsDayEducation = true };

				//testS1.SessionGroup.GroupId = g1;
				//testS1.SessionGroup.SessionCode = s1;

				//Sessie testS2 = new Sessie() { Name = "Aardrijkskunde", Desc = "Makkelijk", DayStarted = new DateTime(1892, 10, 16), SessionCode = s2, IsActive = false, HasStarted = false, HasFeedback = false, IsDayEducation = true };
				//testS2.SessionGroup.GroupId = g2;
				//testS2.SessionGroup.SessionCode = s2;

				//Sessie[] sessies = new Sessie[] { testS1, testS2 };
				//_context.Sessies.AddRange(sessies);


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
