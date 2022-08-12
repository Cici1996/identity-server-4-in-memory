using Microsoft.EntityFrameworkCore;
using Sample.DataAccessLayer.Entities;
using Sample.DataAccessLayer.EntityConfigurations;

namespace Sample.DataAccessLayer
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions<CoreDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new MeetingEventConfiguration());
        }

        public DbSet<MeetingEvent> MeetingEvents { get; set; }
    }
}