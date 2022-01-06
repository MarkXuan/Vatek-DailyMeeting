using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using DailyMeeting.Authorization.Users;
using DailyMeeting.MultiTenancy;
using DailyMeeting.IoC;
using Abp.Dependency;
using Abp.ObjectMapping;

namespace DailyMeeting
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class DailyMeetingAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        public IWorkScope WorkScope { get; set; }

        protected DailyMeetingAppServiceBase()
        {
            LocalizationSourceName = DailyMeetingConsts.LocalizationSourceName;
            WorkScope = IocManager.Instance.Resolve<IWorkScope>();
            ObjectMapper = IocManager.Instance.Resolve<IObjectMapper>();
            UserManager = IocManager.Instance.Resolve<UserManager>();
            TenantManager = IocManager.Instance.Resolve<TenantManager>();
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
