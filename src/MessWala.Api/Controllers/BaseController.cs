using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MessWala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        
    }
}
