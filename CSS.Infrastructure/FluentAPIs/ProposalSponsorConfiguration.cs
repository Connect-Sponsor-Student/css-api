using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSS.Infrastructure.FluentAPIs
{
    public class ProposalSponsorConfiguration : IEntityTypeConfiguration<ProposalSponsor>
    {
        public void Configure(EntityTypeBuilder<ProposalSponsor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Sponsor)
                .WithMany(x => x.ProposalSponsors)
                .HasForeignKey(x => x.SponsorId);
            builder.HasOne(x => x.Proposal)
                .WithMany(x => x.ProposalSponsors)
                .HasForeignKey(x => x.ProposalId);
        }
    }
}
