using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DailyMeeting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeeting.APIs.Dailies.Dto
{
    [AutoMapTo(typeof(Daily))]
    public class DailyDto : EntityDto<long>
    {
        public long ProjectId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
