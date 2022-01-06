using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeeting.Constants.Enum
{
    public class StatusEnum
    {
        public enum ProjectStatus
        {
            Active,
            Deactive
        }
        public enum ProjectType
        {
            TimeAndMaterials,
            FixedFee,
            NoneBillable,
            ODC
        }
        public enum ProjectUserType
        {
            Member,
            PM
        }
    }
}
