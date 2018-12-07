using System;
namespace AuthenticationService.BusinessLayer.Entities.Applications
{
	/// <summary>
	/// This class defines an application which can be authorized.
	/// </summary>
	public class Application : Entity
	{
		public Guid ID { get; private set; }
		public string Name { get; private set; }
	}
}
