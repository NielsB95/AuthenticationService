using AuthenticationService.BusinessLayer.Entities.Permissions;
using System;
using System.Collections.Generic;

namespace AuthenticationService.BusinessLayer.Entities.Roles
{
	public class Role : Entity
	{
		public Guid ID { get; private set; }
		public string Name { get; private set; }
		public IList<Permission> Permissions { get; private set; }
	}
}
