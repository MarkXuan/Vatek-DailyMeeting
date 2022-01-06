using DailyMeeting.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeeting.APIs.Dailies.Dto
{
    public class GetDailyInput
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long ProjectId { get; set; }
    }
}
