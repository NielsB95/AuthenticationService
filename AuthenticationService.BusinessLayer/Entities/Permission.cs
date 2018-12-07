using System;

namespace AuthenticationService.BusinessLayer.Entities
{
    public class Permission
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
    }
}