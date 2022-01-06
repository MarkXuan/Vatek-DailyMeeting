﻿using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace DailyMeeting.Authorization
{
    public class DailyMeetingAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Customers, L("Customers"));
            context.CreatePermission(PermissionNames.Pages_Projects, L("Projects"));
            context.CreatePermission(PermissionNames.Pages_Dailies, L("Dailies"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DailyMeetingConsts.LocalizationSourceName);
        }
    }
}
