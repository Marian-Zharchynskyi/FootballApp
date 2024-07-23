using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly IRepository<Tournament, Guid> _tournamentRepository;

        public TournamentController(IRepository<Tournament, Guid> tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        // GET: api/Tournament
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tournaments = await _tournamentRepository.GetAllAsync();
            return Ok(tournaments);
        }

        // GET: api/Tournament/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tournament = await _tournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament);
        }

        // POST: api/Tournament
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                tournament.Id = Guid.NewGuid();
                await _tournamentRepository.CreateAsync(tournament);
                return CreatedAtAction(nameof(Get), new { id = tournament.Id }, tournament);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Tournament/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _tournamentRepository.UpdateAsync(tournament);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Tournament/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tournament = await _tournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            await _tournamentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
