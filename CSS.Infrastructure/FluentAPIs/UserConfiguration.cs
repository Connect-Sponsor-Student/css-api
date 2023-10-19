using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSS.Infrastructure.FluentAPIs;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);

        builder.HasMany(x => x.InboxParticipants)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Messages)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId);

       
    }
}