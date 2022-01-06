using System.Threading.Tasks;
using Abp.Application.Services;
using DailyMeeting.Authorization.Accounts.Dto;

namespace DailyMeeting.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
