using Abp.Application.Services.Dto;
using DailyMeeting.Anotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyMeeting.Constants.Enum.StatusEnum;

namespace DailyMeeting.APIs.Projects.Dto
{
    public class ProjectDto : EntityDto<long>
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        [ApplySearchAttribute]
        public string Name { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectType ProjectType { get; set; }
        [ApplySearchAttribute]
        public string Code { get; set; }
        public string Country { get; set; }
        [ApplySearchAttribute]
        public string Description { get; set; }
    }
}
