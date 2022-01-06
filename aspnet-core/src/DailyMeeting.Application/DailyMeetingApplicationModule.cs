using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DailyMeeting.Authorization;

namespace DailyMeeting
{
    [DependsOn(
        typeof(DailyMeetingCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DailyMeetingApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DailyMeetingAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DailyMeetingApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
