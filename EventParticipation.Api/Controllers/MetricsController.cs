using Microsoft.AspNetCore.Mvc;
using EventParticipation.Api.Services;

namespace EventParticipation.Api.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricsController : ControllerBase
    {
        private readonly MetricService _metrics;

        public MetricsController(MetricService metrics)
        {
            _metrics = metrics;
        }

        [HttpGet("country-participation")]
        public async Task<IActionResult> GetCountryParticipation()
        {
            var result = await _metrics.GetCountryParticipationCountAsync();
            return Ok(result);
        }

        [HttpGet("event-participation-reach")]
        public async Task<IActionResult> GetEventParticipationReach()
        {
            var result = await _metrics.GetEventParticipationReachAsync();
            return Ok(result);
        }
    }
}
