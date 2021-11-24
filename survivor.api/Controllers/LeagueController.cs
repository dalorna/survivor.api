using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace survivor.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        [HttpGet]
        public string GetLeagueName()
        {
            return "My League";
        }
    }
}
