using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.Utilities.TokenUtilities;
using CSS.Application.ViewModels.LoginModels;
using CSS.Application.ViewModels.UserModels;
using CSS.Domains.Entities;
using Microsoft.Extensions.Options;

namespace CSS.Application.Services;
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly JwtOptions _jwtOptions;
    public UserService(IMapper mapper, IUnitOfWork unitOfWork, IOptions<JwtOptions> options)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _jwtOptions = options.Value;
    }
    public async Task<UserViewModel> CreateAsync(UserCreateModel model)
    {
        var user = _mapper.Map<User>(model);
        var isDup = (await _unitOfWork.UserRepository.GetAllAsync()).Any(x => x.Email == model.Email);
        if (isDup) throw new Exception($"Duplicate Email: {model.Email}");
        await _unitOfWork.UserRepository.AddAsync(user);
        user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
        return await _unitOfWork.SaveChangesAsync()
            ? _mapper.Map<UserViewModel>(await _unitOfWork.UserRepository.GetByIdAsync(user.Id, x => x.Role))
            : throw new Exception($"Save Changes Failed!");
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(id) ?? throw new Exception($"Not found User with Id: {id}");
        _unitOfWork.UserRepository.SoftRemove(user);
        return await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        => _mapper.Map<IEnumerable<UserViewModel>>(await _unitOfWork.UserRepository.GetAllAsync());

    public async Task<UserViewModel> GetByIdAsync(Guid id)
        => _mapper.Map<UserViewModel>(await _unitOfWork.UserRepository.GetByIdAsync(id, x => x.Role));

    public async Task<LoginReponseModel> LoginAsync(LoginRequestModel model)
    {
        var user = await _unitOfWork.UserRepository.FindByField(x => x.Email == model.Email, x => x.Role) ?? throw new Exception($"Not Found User with Email: {model.Email}");
        var verify = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
        if (verify)
        {
            return new LoginReponseModel
            {
                User = _mapper.Map<UserViewModel>(user),
                Token = user.GenerateToken(_jwtOptions)
            };
        }
        else throw new Exception($"Wrong Email Or Password");

    }

    public async Task<UserViewModel> UpdateAsync(UserUpdateModel model)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(model.Id) ?? throw new Exception($"Not Found user with Id: {model.Id}");
        _mapper.Map(model, user);
        _unitOfWork.UserRepository.Update(user);
        return await _unitOfWork.SaveChangesAsync() ?
            _mapper.Map<UserViewModel>(await _unitOfWork.UserRepository.GetByIdAsync(user.Id, x => x.Role))
            : throw new Exception("Save Changes Failed!");

    }
}