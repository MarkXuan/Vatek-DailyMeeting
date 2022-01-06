using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DailyMeeting.Localization
{
    public static class DailyMeetingLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(DailyMeetingConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DailyMeetingLocalizationConfigurer).GetAssembly(),
                        "DailyMeeting.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
