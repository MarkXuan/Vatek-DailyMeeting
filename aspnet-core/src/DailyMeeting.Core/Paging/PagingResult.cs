using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMeeting.Paging
{
    public class PagingResult<T>
    {
        public long TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}
