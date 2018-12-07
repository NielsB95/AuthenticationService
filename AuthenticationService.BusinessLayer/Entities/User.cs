using System;
using System.Collections.Generic;
using System.Security;

namespace AuthenticationService.BusinessLayer.Entities
{
    public class User
    {
        public Guid ID { get; internal set; }

        public string Firstname { get; internal set; }
        public string Lastname { get; internal set; }

        public string Username { get; internal set; }
        public SecureString Password { get; internal set; }

        /// <summary>
        /// The role this user has accross all the applications.
        /// </summary>
        /// <value>The role.</value>
        public Role Role { get; internal set; }

        /// <summary>
        /// A list of applications this user is authorized for.
        /// </summary>
        /// <value>The applications.</value>
        public IList<Application> Applications { get; internal set; }
    }
}
