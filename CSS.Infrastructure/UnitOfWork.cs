using CSS.Application;
using CSS.Application.Repositories;
using CSS.Infrastructure.Data;

namespace CSS.Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    private readonly IAdminRepository _adminRepository;
    private readonly IFeedBackRepository _feedBackRepository;
    private readonly IPaymentRepository payment;
    private readonly IProposalRepository proposalRepository;
    private readonly IProposalSupportRespository proposalSupportRespository;
    private readonly IProposalSponsorRepository proposalSponsorRepository;
    private readonly IRoleRepository roleRepository;
    private readonly ISupportTypeRepository supportTypeRepository;
    private readonly ISponsorRepository sponsorRepository;
    private readonly IStudentRepository studentRepository;
    private readonly IUserRepository userRepository;
    private readonly IProposalFileRepository _proposalFileRepository;
    private readonly IInvestmentRepository _investmentRepository;
    public UnitOfWork(AppDbContext dbContext, IAdminRepository adminRepository, IFeedBackRepository feedBackRepositor
    , IPaymentRepository paymentRepository, IProposalRepository proposalRepository, IProposalSupportRespository proposalSupportRespository
    , IProposalSponsorRepository proposalSponsorRepository, IRoleRepository roleRepository, ISupportTypeRepository supportTypeRepository
    , ISponsorRepository sponsorRepository, IStudentRepository studentRepository, IUserRepository userRepository, IProposalFileRepository proposalFileRepository
    , IInvestmentRepository invesmentRepository)
    {
        _appDbContext = dbContext;
        _adminRepository = adminRepository;
        _feedBackRepository = feedBackRepositor;
        _investmentRepository = invesmentRepository;
        payment = paymentRepository;
        this.proposalRepository = proposalRepository;
        this.proposalSupportRespository = proposalSupportRespository;
        this.proposalSponsorRepository = proposalSponsorRepository;
        this.roleRepository = roleRepository;
        this.supportTypeRepository = supportTypeRepository;
        this.sponsorRepository = sponsorRepository;
        this.studentRepository = studentRepository;
        this.userRepository = userRepository;
        _proposalFileRepository = proposalFileRepository;



    }
    public IAdminRepository AdminRepository => _adminRepository;

    public IFeedBackRepository FeedBackRepository => _feedBackRepository;

    public IPaymentRepository PaymentRepository => payment;

    public IProposalRepository ProposalRepository => proposalRepository;

    public IProposalSupportRespository ProposalSupportRespository => proposalSupportRespository;

    public IProposalSponsorRepository ProposalSponsorRepository => proposalSponsorRepository;

    public IRoleRepository RoleRepository => roleRepository;

    public ISupportTypeRepository SupportTypeRepository => supportTypeRepository;

    public ISponsorRepository SponsorRepository => sponsorRepository;

    public IStudentRepository StudentRepository => studentRepository;

    public IUserRepository UserRepository => userRepository;
    public IProposalFileRepository ProposalFileRepository => _proposalFileRepository;
    public IInvestmentRepository InvestmentRepository  => _investmentRepository;

    public async Task<bool> SaveChangesAsync()
        => await _appDbContext.SaveChangesAsync() > 0;
}