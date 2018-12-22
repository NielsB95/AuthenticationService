using AuthenticationService.BusinessLayer.Entities.Users;

namespace AuthenticationService.Api.Models
{
    public class AuthenticationModel
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
