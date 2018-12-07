using AuthenticationService.BusinessLayer.Entities.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.BusinessLayer.Entities.Roles
{
	public class Role : Entity
	{
		public Guid ID { get; set; }

		[Required]
		public string Name { get; set; }
		public IList<Permission> Permissions { get; set; }
	}
}
