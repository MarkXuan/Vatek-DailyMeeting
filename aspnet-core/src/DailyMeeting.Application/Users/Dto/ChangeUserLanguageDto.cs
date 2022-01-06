using System.ComponentModel.DataAnnotations;

namespace DailyMeeting.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}