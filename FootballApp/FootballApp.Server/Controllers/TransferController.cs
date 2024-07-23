using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly IRepository<Transfer, Guid> _transferRepository;

        public TransferController(IRepository<Transfer, Guid> transferRepository)
        {
            _transferRepository = transferRepository;
        }

        // GET: api/Transfer
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transfers = await _transferRepository.GetAllAsync();
            return Ok(transfers);
        }

        // GET: api/Transfer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var transfer = await _transferRepository.GetAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }
            return Ok(transfer);
        }

        // POST: api/Transfer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                transfer.Id = Guid.NewGuid();
                await _transferRepository.CreateAsync(transfer);
                return CreatedAtAction(nameof(Get), new { id = transfer.Id }, transfer);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Transfer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Transfer transfer)
        {
            if (id != transfer.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _transferRepository.UpdateAsync(transfer);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Transfer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var transfer = await _transferRepository.GetAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }

            await _transferRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
