using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pr.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {

    }
}