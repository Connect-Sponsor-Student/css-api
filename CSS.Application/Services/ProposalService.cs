using System.Runtime.CompilerServices;
using System.Security;
using AutoMapper;
using CSS.Application.Services.Interfaces;
using CSS.Application.Utilities.FireBaseUtilities;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Domains.Entities;
using CSS.Domains.Enums;
using Microsoft.AspNetCore.Http;

namespace CSS.Application.Services;
public class ProposalService : IProposalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimsService _claimsService;
    public ProposalService(IUnitOfWork unitOfWork, IClaimsService claimsServivce, IMapper mapper)
    {
        _mapper = mapper;
        _claimsService = claimsServivce;
        _unitOfWork = unitOfWork;
    }
    public async Task<ProposalViewModel> CreateAsync(ProposalCreateModel model)
    {

        var proposal = _mapper.Map<Proposal>(model);
        var fileList = new List<ProposalFile>();
        model.Files ??= new List<IFormFile>();
        if (model.Files.Count > 0)
        {
            foreach (var file in model.Files)
            {
                var fireBaseFile = await file.UploadFileAsync();
                if (fireBaseFile is not null)
                {
                    fileList.Add(new ProposalFile
                    {
                        Extension = fireBaseFile.Extension,
                        Name = fireBaseFile.FileName,
                        URL = fireBaseFile.URL,
                        ProposalId = proposal.Id
                    });
                }

            }
            proposal.ProposalFiles = fileList;
        }
        proposal.StudentId = _claimsService.GetCurrentUser;
        await _unitOfWork.ProposalRepository.AddAsync(proposal);
        if(await _unitOfWork.SaveChangesAsync())
            return _mapper.Map<ProposalViewModel>(await _unitOfWork.ProposalRepository.GetByIdAsync(proposal.Id, x => x.ProposalFiles));
        else throw new Exception($"Oh Shjt, Its Exception");
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProposalViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProposalViewModel> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ProposalViewModel> UpdateAsync(ProposalUpdateModel model)
    {
        throw new NotImplementedException();
    }
}