using System.Runtime.CompilerServices;
using System.Security;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using CSS.Application.Services.Interfaces;
using CSS.Application.Utilities.FireBaseUtilities;
using CSS.Application.ViewModels.ProposalModels;
using CSS.Application.ViewModels.ProposalServiceModels;
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



    public async Task<bool> DeleteAsync(Guid id)
    {
        var prop = await _unitOfWork.ProposalRepository.GetByIdAsync(id) ?? throw new Exception($"--> Error: Not Found Proposal With Id: {id}");
        _unitOfWork.ProposalRepository.SoftRemove(prop);
        var files = await _unitOfWork.ProposalFileRepository.FindListByField(x => x.ProposalId == prop.Id);
        foreach(var file in files)
        {
            await file.Name.RemoveFileAsync();
        }
        _unitOfWork.ProposalFileRepository.SoftRemoveRange(files);
        return await _unitOfWork.SaveChangesAsync();
    }



    public async Task<IEnumerable<ProposalViewModel>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ProposalViewModel>>(await _unitOfWork.ProposalRepository.GetAllAsync(x => x.ProposalFiles));
    }

    public async Task<ProposalViewModel> GetByIdAsync(Guid id)
    {
        var result = await _unitOfWork.ProposalRepository.GetByIdAsync(id, x => x.ProposalFiles) ?? throw new Exception($"--> Error: Could Not Find Proposal with Id: {id}");
        return _mapper.Map<ProposalViewModel>(result);
    }

    public async Task<bool> UpdateAsync(ProposalUpdateModel model)
    {
       var proposal = await _unitOfWork.ProposalRepository.GetByIdAsync(model.Id) ?? throw new Exception($"--> Error: Update Failed! Not Found Proposal with Id: {model.Id}");
       _mapper.Map(model, proposal);
       _unitOfWork.ProposalRepository.Update(proposal);
       return await _unitOfWork.SaveChangesAsync();
       
    }
}