using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuthenticationService.BusinessLayer.Entities.Users;

namespace AuthenticationService.BusinessLayer.Entities.Applications
{
	public class ApplicationUser : Entity
	{
		[Key, ForeignKey(nameof(User))]
		public Guid UserID { get; set; }

		[Key, ForeignKey(nameof(Application))]
		public Guid ApplicationID { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreatedAt { get; set; }

		public virtual User User { get; set; }
		public virtual Application Application { get; set; }
	}
}
