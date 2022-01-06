using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DailyMeeting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyMeeting.Constants.Enum.StatusEnum;

namespace DailyMeeting.APIs.Projects.Dto
{
    [AutoMapTo(typeof(Project))]
    public class CreateProjectDto: EntityDto<long>
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectType ProjectType { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public IEnumerable<CreateProjectUserDto> ProjectUsers { get; set; }
    }
}
