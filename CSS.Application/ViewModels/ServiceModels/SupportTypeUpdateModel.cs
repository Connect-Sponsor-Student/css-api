using System.ComponentModel.Design;
namespace CSS.Application.ViewModels.ServiceModels;
public class SupportTypeUpdateModel : SupportTypeCreateModel
{
    public Guid Id {get ;set;} = default!;
}