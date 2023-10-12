using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSS.Infrastructure.FluentAPIs;
public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
{
    public void Configure(EntityTypeBuilder<Investment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Proposal)
                .WithMany(x => x.Investments)
                .HasForeignKey(x => x.ProposalId);
        builder.HasOne(x => x.Sponsor)
                .WithMany(x => x.Investments) 
                .HasForeignKey(x => x.SponsorId);
    }
}