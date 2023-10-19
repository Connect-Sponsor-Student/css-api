using CSS.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSS.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Role> Role { get; set; } = default!;
    public DbSet<Admin> Admin { get; set; } = default!;
    public DbSet<User> User { get; set; } = default!;
    public DbSet<Student> Student { get; set; } = default!;
    public DbSet<Proposal> Proposal { get; set; } = default!;
    public DbSet<Payment> Payment { get; set; } = default!;
    public DbSet<SupportType> Service { get; set; } = default!;
    public DbSet<ProposalSupport> ProposalService { get; set; } = default!;
    public DbSet<Sponsor> Sponsor { get; set; } = default!;
    public DbSet<FeedBack> FeedBack { get; set; } = default!;
    public DbSet<ProposalSponsor> ProposalSponsor { get; set; } = default!;
    public DbSet<ProposalFile> ProposalFile { get; set; } = default!;
    public DbSet<Investment> Investment { get; set; } = default!;
    public DbSet<Inbox> Inboxes { get; set; } = default!;
    public DbSet<InboxParticipant> InboxParticipants { get; set; } = default!;
    public DbSet<Message> Messages { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Role>().HasData
        (
             new Role { RoleName = "Admin" }
            , new Role { RoleName = "Student" }
            , new Role { RoleName = "Sponsor" }
        );
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

    }
}