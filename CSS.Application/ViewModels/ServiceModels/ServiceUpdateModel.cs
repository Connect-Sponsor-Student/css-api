using System.ComponentModel.Design;
namespace CSS.Application.ViewModels.ServiceModels;
public class ServiceUpdateModel : ServiceCreateModel
{
    public Guid Id {get ;set;} = default!;
}