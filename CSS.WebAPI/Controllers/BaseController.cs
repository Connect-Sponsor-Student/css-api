using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace CSS.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ODataController
{

}