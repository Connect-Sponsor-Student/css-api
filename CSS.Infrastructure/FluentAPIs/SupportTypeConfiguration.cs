using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSS.Infrastructure.FluentAPIs;
public class SupportTypeConfiguration : IEntityTypeConfiguration<SupportType>
{
    public void Configure(EntityTypeBuilder<SupportType> builder)
    {
        builder.HasKey(x => x.Id);
    }
}