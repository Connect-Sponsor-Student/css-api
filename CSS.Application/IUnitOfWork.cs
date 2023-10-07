using CSS.Application.Repositories;

namespace CSS.Application;
public interface IUnitOfWork
{
    public IAdminRepository AdminRepository { get; }
    public IFeedBackRepository FeedBackRepository { get; }
    public IPaymentRepository PaymentRepository { get; }
    public IProposalRepository ProposalRepository { get; }
    public IProposalServiceRespository ProposalServiceRespository { get; }
    public IProposalSponsorRepository ProposalSponsorRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IServiceRepository ServiceRepository { get; }
    public ISponsorRepository SponsorRepository { get; }
    public IStudentRepository StudentRepository { get; }
    public IUserRepository UserRepository { get; }
    Task<bool> SaveChangesAsync();
}