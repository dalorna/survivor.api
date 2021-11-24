using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using survivor.api.Manager.Contract;
using survivor.api.Model;
using System;

namespace survivor.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseSQLController<UserSurvivorModel, Guid, IUserManager>
    {
        public UserController(IUserManager manager, ILogger<UserController> logger, TelemetryClient telemetry) : base(manager, logger, telemetry)
        {
        }
    }
}
