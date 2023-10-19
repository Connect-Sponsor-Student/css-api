using CSS.Application.Repositories;

namespace CSS.Application;
public interface IUnitOfWork
{
    public IAdminRepository AdminRepository { get; }
    public IFeedBackRepository FeedBackRepository { get; }
    public IPaymentRepository PaymentRepository { get; }
    public IProposalRepository ProposalRepository { get; }
    public IProposalSupportRespository ProposalSupportRespository { get; }
    public IProposalSponsorRepository ProposalSponsorRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public ISupportTypeRepository SupportTypeRepository { get; }
    public ISponsorRepository SponsorRepository { get; }
    public IStudentRepository StudentRepository { get; }
    public IUserRepository UserRepository { get; }
    public IProposalFileRepository ProposalFileRepository { get; }
    public IInvestmentRepository InvestmentRepository { get; }

    public IMessageRepository MessageRepository { get; }
    public IInboxParticipantRepository InboxParticipantRepository { get; }
    public IInboxRepository InboxRepository { get; }
    Task<bool> SaveChangesAsync();
}