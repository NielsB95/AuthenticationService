using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.BusinessLayer.Entities.Applications
{
	/// <summary>
	/// This class defines an application which can be authorized.
	/// </summary>
	public class Application : Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ID { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ApplicationCode { get; set; }

		public virtual IList<ApplicationUser> ApplicationUsers { get; set; }
	}
}
