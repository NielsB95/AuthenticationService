using System;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using AuthenticationService.BusinessLayer.Entities.Users;

namespace AuthenticationService.Security
{
	public interface IAuthenticationLogger
	{
		Task CreateLog(User user, Guid applicationCode, bool succesful = true);
	}

	public class AuthenticationLogger : IAuthenticationLogger
	{
		private readonly IAuthenticationLogRepository authenticationLogRepository;
		private readonly IApplicationRepository applicationRepository;

		public AuthenticationLogger(IAuthenticationLogRepository authenticationLogRepository, IApplicationRepository applicationRepository)
		{
			this.authenticationLogRepository = authenticationLogRepository;
			this.applicationRepository = applicationRepository;
		}

		public async Task CreateLog(User user, Guid applicationCode, bool succesful = true)
		{
			var application = await this.applicationRepository.GetByApplicationCode(applicationCode);
			await authenticationLogRepository.Add(new AuthenticationLog()
			{
				CreatedAt = DateTime.Now,
				User = user,
				Successful = succesful,
				ApplicationID = application.ID
			});
		}
	}
}
