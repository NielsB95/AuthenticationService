using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.Roles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.BusinessLayer.Entities.Users
{
	public class User : Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ID { get; set; }

		[Required]
		public string Firstname { get; set; }

		[Required]
		public string Lastname { get; set; }

		[Required]
		public string Username { get; set; }

		[JsonIgnore]
		[Required]
		public string Password { get; set; }

		[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime CreatedAt { get; set; }

		public string Fullname
		{
			get
			{
				return string.Format("{0} {1}", Firstname, Lastname);
			}
		}

		/// <summary>
		/// The role this user has accross all the applications.
		/// </summary>
		/// <value>The role.</value>
		public virtual Role Role { get; set; }

		/// <summary>
		/// A list of applications this user is authorized for.
		/// </summary>
		/// <value>The applications.</value>
		public virtual IList<ApplicationUser> Applications { get; set; }
	}
}
