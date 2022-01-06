using Abp.Application.Services.Dto;

namespace DailyMeeting.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

