using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IRepository<Team, Guid> _teamRepository;

        public TeamController(IRepository<Team, Guid> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var team = await _teamRepository.GetAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        // POST: api/Team
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            if (ModelState.IsValid)
            {
                team.Id = Guid.NewGuid();
                await _teamRepository.CreateAsync(team);
                return CreatedAtAction(nameof(Get), new { id = team.Id }, team);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _teamRepository.UpdateAsync(team);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var team = await _teamRepository.GetAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            await _teamRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
