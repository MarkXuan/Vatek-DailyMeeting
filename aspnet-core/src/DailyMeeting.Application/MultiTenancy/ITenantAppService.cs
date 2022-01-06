using Abp.Application.Services;
using DailyMeeting.MultiTenancy.Dto;

namespace DailyMeeting.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

