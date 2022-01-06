using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeeting.APIs.Dailies.Dto
{
    public class ProjectDailyDto
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<DailyDetailDto> Details { get; set; }
    }
     
    public class DailyDetailDto
    {
        public long UserId { get; set; }
        public string AvatarPath { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsEdit { get; set; }
    }
}
