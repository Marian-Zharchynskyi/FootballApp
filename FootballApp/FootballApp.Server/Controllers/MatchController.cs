using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IRepository<Match, Guid> _matchRepository;

        public MatchController(IRepository<Match, Guid> matchRepository)
        {
            _matchRepository = matchRepository;
        }

        // GET: api/Match
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var matches = await _matchRepository.GetAllAsync();
            return Ok(matches);
        }

        // GET: api/Match/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }

        // POST: api/Match
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Match match)
        {
            if (ModelState.IsValid)
            {
                match.Id = Guid.NewGuid();
                await _matchRepository.CreateAsync(match);
                return CreatedAtAction(nameof(Get), new { id = match.Id }, match);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Match/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _matchRepository.UpdateAsync(match);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Match/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            await _matchRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
