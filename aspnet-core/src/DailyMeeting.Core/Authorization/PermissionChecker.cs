using Abp.Authorization;
using DailyMeeting.Authorization.Roles;
using DailyMeeting.Authorization.Users;

namespace DailyMeeting.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
