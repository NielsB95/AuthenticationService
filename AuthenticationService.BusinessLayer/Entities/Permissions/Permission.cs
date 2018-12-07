using System;

namespace AuthenticationService.BusinessLayer.Entities.Permissions
{
	public class Permission : Entity
	{
		public Guid ID { get; private set; }
		public string Name { get; private set; }
	}
}