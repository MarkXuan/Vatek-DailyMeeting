using System.Threading.Tasks;
using Abp.Application.Services;
using DailyMeeting.Sessions.Dto;

namespace DailyMeeting.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
