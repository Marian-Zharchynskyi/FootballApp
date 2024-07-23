using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IRepository<Statistics, Guid> _statisticsRepository;

        public StatisticsController(IRepository<Statistics, Guid> statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        // GET: api/Statistics
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statistics = await _statisticsRepository.GetAllAsync();
            return Ok(statistics);
        }

        // GET: api/Statistics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var statistics = await _statisticsRepository.GetAsync(id);
            if (statistics == null)
            {
                return NotFound();
            }
            return Ok(statistics);
        }

        // POST: api/Statistics
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Statistics statistics)
        {
            if (ModelState.IsValid)
            {
                statistics.Id = Guid.NewGuid();
                await _statisticsRepository.CreateAsync(statistics);
                return CreatedAtAction(nameof(Get), new { id = statistics.Id }, statistics);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Statistics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Statistics statistics)
        {
            if (id != statistics.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _statisticsRepository.UpdateAsync(statistics);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Statistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var statistics = await _statisticsRepository.GetAsync(id);
            if (statistics == null)
            {
                return NotFound();
            }

            await _statisticsRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
