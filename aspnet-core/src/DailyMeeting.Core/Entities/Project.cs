using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyMeeting.Constants.Enum.StatusEnum;

namespace DailyMeeting.Entities
{
    public class Project : FullAuditedEntity<long>
    {
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectType ProjectType { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }
}
