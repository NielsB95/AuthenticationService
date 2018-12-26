using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.BusinessLayer.Entities.Dashboard
{
    public interface IDashboardRepository : IRepository
    {
        Task<IList<DateValuePair>> GetUsersFromLastDays(int days);

        Task<IList<DateValuePair>> GetUserActivityLastDays(int days);

        Task<IList<DateValuePair>> GetFailedAuthenticationActivityLastDays(int days);

        Task<IList<DateValuePair>> GetSuccesfulAuthenticationActivityLastDays(int days);
    }
}
