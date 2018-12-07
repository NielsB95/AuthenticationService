using System;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.BusinessLayer.Entities.Permissions
{
	public class Permission : Entity
	{
		public Guid ID { get; set; }

		[Required]
		public string Name { get; set; }
	}
}