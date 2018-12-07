using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.Roles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security;

namespace AuthenticationService.BusinessLayer.Entities.Users
{
	public class User : Entity
	{
		public Guid ID { get; set; }

		public string Firstname { get; set; }
		public string Lastname { get; set; }

		public string Username { get; set; }

		[JsonIgnore]
		public SecureString Password { get; set; }

		/// <summary>
		/// The role this user has accross all the applications.
		/// </summary>
		/// <value>The role.</value>
		public Role Role { get; set; }

		/// <summary>
		/// A list of applications this user is authorized for.
		/// </summary>
		/// <value>The applications.</value>
		public IList<Application> Applications { get; set; }
	}
}
