using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using DotNetG2E.Models.Domain;

namespace DotNetG2E.Models.SessieViewModels
{
    public class SessieViewModel
    {
		[Display(Name = "SessionCode")]
		public int SessionCode { get; set; }
		[Display(Name = "Name Session")]
		public String Name { get; private set; }
		[Display(Name = "Description Session")]
		public String Desc { get; private set; }
		[Display(Name = "Date Session")]
		public DateTime DayStarted { get; private set; }
		public Boolean IsDayEducation { get; private set; }
		public Boolean HasFeedback { get; private set; }
		public Group Groups { get; private set; }
		public int BoxId { get; set; }
		[Display(Name = "Session Box")]
		public BoB Box { get; set; }
		public Boolean IsActive { get; set; }

		public SessieViewModel(Sessie sessie)
		{
			SessionCode = sessie.SessionCode;
			Name = sessie.Name;
			Desc = sessie.Desc;
			DayStarted = sessie.DayStarted;
			IsDayEducation = sessie.IsDayEducation;
			HasFeedback = sessie.HasFeedback;
			Groups = sessie.Groups;
			Box = sessie.Box;
			IsActive = sessie.IsActive;


		}
	}
}
