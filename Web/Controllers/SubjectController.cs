using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/subject")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {

    }
}
