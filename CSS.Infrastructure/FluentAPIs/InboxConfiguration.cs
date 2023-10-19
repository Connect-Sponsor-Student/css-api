using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSS.Infrastructure.FluentAPIs
{
    public class InboxConfiguration : IEntityTypeConfiguration<Inbox>
    {
        public void Configure(EntityTypeBuilder<Inbox> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Messages)
                .WithOne(x => x.Inbox)
                .HasForeignKey(x => x.InboxId);
            builder.HasMany(x => x.Participants)
                .WithOne(x => x.Inbox)
                .HasForeignKey(x => x.InboxId);
        }
    }
}
