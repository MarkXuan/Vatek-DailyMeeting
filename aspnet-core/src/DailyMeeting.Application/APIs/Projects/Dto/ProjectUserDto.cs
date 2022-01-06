using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyMeeting.Constants.Enum.StatusEnum;

namespace DailyMeeting.APIs.Projects.Dto
{
    public class ProjectUserDto : EntityDto<long>
    {
        public long UserId { get; set; }
        public string FullNameUser { get; set; }
        public string AvatarPath { get; set; }
        public long ProjectId { get; set; }
        public ProjectUserType Type { get; set; }
        public bool IsActive { get; set; }
    }
}
