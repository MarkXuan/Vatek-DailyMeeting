using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DailyMeeting.Controllers
{
    public abstract class DailyMeetingControllerBase: AbpController
    {
        protected DailyMeetingControllerBase()
        {
            LocalizationSourceName = DailyMeetingConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
