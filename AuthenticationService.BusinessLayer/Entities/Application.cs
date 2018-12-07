using System;
namespace AuthenticationService.BusinessLayer.Entities
{
    /// <summary>
    /// This class defines an application which can be authorized.
    /// </summary>
    public class Application
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
    }
}
