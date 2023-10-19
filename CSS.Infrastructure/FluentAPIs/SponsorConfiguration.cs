using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSS.Infrastructure.FluentAPIs
{
    public class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
    {

        public void Configure(EntityTypeBuilder<Sponsor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
