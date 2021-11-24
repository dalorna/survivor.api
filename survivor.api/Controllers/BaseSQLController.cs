using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using survivor.api.Manager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace survivor.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseSQLController<TModel, TKey, TManager> : ControllerBase where TModel : class, IModel<TKey> where TManager : IManager<TModel, TKey>
    {
        protected readonly TManager _manager;
        protected readonly ILogger _logger;
        protected readonly TelemetryClient _telemetry;

        public BaseSQLController(TManager manager, ILogger logger, TelemetryClient telemetry)
        {
            _manager = manager;
            _telemetry = telemetry;
            _logger = logger;
        }

        [HttpGet("{id}/id")]
        public virtual async Task<ActionResult<TModel>> GetModel(TKey id)
        {
            try
            {
                TManager manager = _manager;
                return Ok(await manager.GetModel(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Failed To retrieve Model, LogTrackerId:" + TrackException(ex));
            }
        }

        [HttpGet("models")]
        public virtual async Task<ActionResult<IEnumerable<TModel>>> GetModels()
        {
            try
            {
                TManager manager = _manager;
                return Ok(await manager.GetModels());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed To retrieve Models, LogTrackerId:" + TrackException(ex));
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TModel>> Post(TKey id, [FromBody] TModel model)
        {
            try
            {
                TManager manager = _manager;
                return Ok(await manager.PutModel(id, model));
            }
            catch (Exception ex)
            {
                return BadRequest("Failed To save Model, LogTrackerId:" + TrackException(ex));
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<TModel>> Post([FromBody] TModel model)
        {
            try
            {
                TManager manager = _manager;
                return Ok(await manager.PostModel(model));
            }
            catch (Exception ex)
            {
                return BadRequest("Failed To save Model, LogTrackerId:" + TrackException(ex));
            }
        }

        [HttpPost("models")]
        public virtual async Task<ActionResult<IEnumerable<TModel>>> PostModels([FromBody] IEnumerable<TModel> model)
        {
            try
            {
                TManager manager = _manager;
                return Ok(await manager.PostModels(model));
            }
            catch (Exception ex)
            {
                return BadRequest("Failed To save Model, LogTrackerId:" + TrackException(ex));
            }
        }

        [HttpPatch("{id}")]
        public virtual async Task<ActionResult<TModel>> Patch(TKey id, [FromBody] Dictionary<string, object> patch)
        {
            try
            {
                TManager manager = _manager;
                return Ok(await manager.PatchModel(id, patch));
            }
            catch (Exception ex)
            {
                return BadRequest("Failed To patch Model, LogTrackerId:" + TrackException(ex));
            }
        }

        [HttpDelete("harddelete/{id}")]
        public virtual async Task<ActionResult<bool>> HardDelete(TKey id)
        {
            try
            {
                TManager manager = _manager;
                return Ok(await manager.DeleteModel(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Failed To hard delete Model, LogTrackerId:" + TrackException(ex));
            }
        }

        protected string TrackException(Exception ex)
        {
            string text = Guid.NewGuid().ToString();
            _telemetry.TrackException(ex, new Dictionary<string, string>
            {
                {
                    "LogTrackerId",
                    text
                }
            });
            return text;
        }
    }
}
