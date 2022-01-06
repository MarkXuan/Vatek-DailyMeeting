using DailyMeeting.Debugging;

namespace DailyMeeting
{
    public class DailyMeetingConsts
    {
        public const string LocalizationSourceName = "DailyMeeting";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "c4428cb3205848a7ab8798b666dd84fd";
    }
}
