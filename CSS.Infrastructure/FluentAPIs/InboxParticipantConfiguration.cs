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
    public class InboxParticipantConfiguration : IEntityTypeConfiguration<InboxParticipant>
    {
        public void Configure(EntityTypeBuilder<InboxParticipant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.InboxParticipants)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Inbox)
                .WithMany(x => x.Participants)
                .HasForeignKey(x => x.InboxId);
        }
    }
}
