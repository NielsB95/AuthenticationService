using System;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.BusinessLayer.Entities.Applications
{
	/// <summary>
	/// This class defines an application which can be authorized.
	/// </summary>
	public class Application : Entity
	{
		public Guid ID { get; private set; }

		[Required]
		public string Name { get; private set; }
	}
}
