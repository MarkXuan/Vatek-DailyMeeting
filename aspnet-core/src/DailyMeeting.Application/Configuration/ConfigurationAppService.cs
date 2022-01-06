using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DailyMeeting.Configuration.Dto;

namespace DailyMeeting.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DailyMeetingAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
