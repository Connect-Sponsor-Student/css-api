using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSS.Infrastructure.FluentAPIs;
public class ProposalServiceConfiguration : IEntityTypeConfiguration<ProposalSupport>
{
    public void Configure(EntityTypeBuilder<ProposalSupport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Proposal)
            .WithMany(x => x.ProposalSupports).HasForeignKey(x => x.ProposalId);
        builder.HasOne(x => x.SupportType)
                .WithMany(x => x.ProposalSupports)
                .HasForeignKey(x => x.SupportTypeId);
    }
}