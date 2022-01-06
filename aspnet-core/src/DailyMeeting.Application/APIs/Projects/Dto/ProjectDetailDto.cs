using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeeting.APIs.Projects.Dto
{
    public class ProjectDetailDto : ProjectDto
    {
        public IEnumerable<ProjectUserDto> ProjectUsers { get; set; }
    }
}
