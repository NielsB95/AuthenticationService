using AuthenticationService.BusinessLayer.Entities.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.BusinessLayer.Entities.AuthenticationLogs
{
	public class AuthenticationLog : Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public User User { get; set; }

		public bool Successful { get; set; }

		public Guid ApplicationCode { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; }
	}
}
