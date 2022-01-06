using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DailyMeeting.EntityFrameworkCore
{
    public static class DailyMeetingDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DailyMeetingDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DailyMeetingDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
