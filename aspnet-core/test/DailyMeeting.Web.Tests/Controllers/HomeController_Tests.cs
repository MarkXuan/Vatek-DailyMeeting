using System.Threading.Tasks;
using DailyMeeting.Models.TokenAuth;
using DailyMeeting.Web.Controllers;
using Shouldly;
using Xunit;

namespace DailyMeeting.Web.Tests.Controllers
{
    public class HomeController_Tests: DailyMeetingWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}