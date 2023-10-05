using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSS.Infrastructure.FluentAPIs;
public class ProposalServiceConfiguration : IEntityTypeConfiguration<ProposalService>
{
    public void Configure(EntityTypeBuilder<ProposalService> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Proposal)
            .WithMany(x => x.ProposalServices).HasForeignKey(x => x.ProposalId);
        builder.HasOne(x => x.Service)
                .WithMany(x => x.ProposalServices)
                .HasForeignKey(x => x.ServiceId);
    }
}