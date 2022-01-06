using Abp.Domain.Entities.Auditing;
using DailyMeeting.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeeting.Entities
{
    public class Daily : FullAuditedEntity<long>
    {
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public long ProjectId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; } 
    }
}
