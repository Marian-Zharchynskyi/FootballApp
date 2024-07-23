using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IRepository<Player, Guid> _playerRepository;

        public PlayerController(IRepository<Player, Guid> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerRepository.GetAllAsync();
            return Ok(players);
        }

        // GET: api/Player/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var player = await _playerRepository.GetAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        // POST: api/Player
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player player)
        {
            if (ModelState.IsValid)
            {
                player.Id = Guid.NewGuid();
                await _playerRepository.CreateAsync(player);
                return CreatedAtAction(nameof(Get), new { id = player.Id }, player);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Player/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _playerRepository.UpdateAsync(player);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var player = await _playerRepository.GetAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            await _playerRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
