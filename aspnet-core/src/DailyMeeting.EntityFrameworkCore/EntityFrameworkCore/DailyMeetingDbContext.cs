using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DailyMeeting.Authorization.Roles;
using DailyMeeting.Authorization.Users;
using DailyMeeting.MultiTenancy;
using DailyMeeting.Entities;

namespace DailyMeeting.EntityFrameworkCore
{
    public class DailyMeetingDbContext : AbpZeroDbContext<Tenant, Role, User, DailyMeetingDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Daily> Dailies { get; set; }

        public DailyMeetingDbContext(DbContextOptions<DailyMeetingDbContext> options)
            : base(options)
        {
        }
    }
}
