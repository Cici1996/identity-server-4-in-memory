using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Core.Contants;
using Sample.DataAccessLayer.Entities;

namespace Sample.DataAccessLayer.EntityConfigurations
{
    public class MeetingEventConfiguration : IEntityTypeConfiguration<MeetingEvent>
    {
        public void Configure(EntityTypeBuilder<MeetingEvent> builder)
        {
            builder.ToTable("MeetingEvents");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(GlobalContant.DefaultMaxLength);
        }
    }
}