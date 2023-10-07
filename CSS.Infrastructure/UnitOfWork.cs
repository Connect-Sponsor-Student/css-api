using CSS.Application;
using CSS.Application.Repositories;
using CSS.Infrastructure.Data;
using CSS.Infrastructure.Repositories;

namespace CSS.Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    private readonly IAdminRepository _adminRepository;
    private readonly IFeedBackRepository _feedBackRepository;
    private readonly IPaymentRepository payment;
    private readonly IProposalRepository proposalRepository;
    private readonly IProposalServiceRespository proposalServiceRespository;
    private readonly IProposalSponsorRepository proposalSponsorRepository;
    private readonly IRoleRepository roleRepository;
    private readonly IServiceRepository serviceRepository;
    private readonly ISponsorRepository sponsorRepository;
    private readonly IStudentRepository studentRepository;
    private readonly IUserRepository userRepository;
    public UnitOfWork(AppDbContext dbContext, IAdminRepository adminRepository, IFeedBackRepository feedBackRepositor
    , IPaymentRepository paymentRepository, IProposalRepository proposalRepository, IProposalServiceRespository proposalServiceRespository
    , IProposalSponsorRepository proposalSponsorRepository, IRoleRepository roleRepository, IServiceRepository serviceRepository
    , ISponsorRepository sponsorRepository, IStudentRepository studentRepository, IUserRepository userRepository)
    {
        _appDbContext = dbContext;
        _adminRepository = adminRepository;
        _feedBackRepository = feedBackRepositor;
        payment = paymentRepository;
        this.proposalRepository = proposalRepository;
        this.proposalServiceRespository = proposalServiceRespository;
        this.proposalSponsorRepository = proposalSponsorRepository;
        this.roleRepository = roleRepository;
        this.serviceRepository = serviceRepository;
        this.sponsorRepository = sponsorRepository;
        this.studentRepository = studentRepository;
        this.userRepository = userRepository;



    }
    public IAdminRepository AdminRepository => _adminRepository;

    public IFeedBackRepository FeedBackRepository => _feedBackRepository;

    public IPaymentRepository PaymentRepository => payment;

    public IProposalRepository ProposalRepository => proposalRepository;

    public IProposalServiceRespository ProposalServiceRespository => proposalServiceRespository;

    public IProposalSponsorRepository ProposalSponsorRepository => proposalSponsorRepository;

    public IRoleRepository RoleRepository => roleRepository;

    public IServiceRepository ServiceRepository => serviceRepository;

    public ISponsorRepository SponsorRepository => sponsorRepository;

    public IStudentRepository StudentRepository => studentRepository;

    public IUserRepository UserRepository => userRepository;

    public async Task<bool> SaveChangesAsync()
        => await _appDbContext.SaveChangesAsync() > 0;
}