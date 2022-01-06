using System.Threading.Tasks;
using DailyMeeting.Configuration.Dto;

namespace DailyMeeting.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
