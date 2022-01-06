using Abp.Domain.Entities.Auditing;
using DailyMeeting.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyMeeting.Constants.Enum.StatusEnum;

namespace DailyMeeting.Entities
{
    public class ProjectUser : FullAuditedEntity<long>
    {
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public long ProjectId { get; set; }
        public ProjectUserType Type { get; set; }
        public bool IsActive { get; set; }
    }
}
