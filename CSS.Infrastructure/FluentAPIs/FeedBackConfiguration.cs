using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSS.Infrastructure.FluentAPIs
{
    public class FeedBackConfiguration : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Admin)
                .WithMany(x => x.FeedBacks)
                .HasForeignKey(x => x.AdminId);
            builder.HasOne(x => x.Proposal)
                .WithMany(x => x.FeedBacks);

        }
    }
}
