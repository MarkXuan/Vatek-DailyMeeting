using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DailyMeeting.Configuration;

namespace DailyMeeting.Web.Host.Startup
{
    [DependsOn(
       typeof(DailyMeetingWebCoreModule))]
    public class DailyMeetingWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DailyMeetingWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DailyMeetingWebHostModule).GetAssembly());
        }
    }
}
