using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IRepository<Player, Guid> _playerRepository;

        public PlayerController(IRepository<Player, Guid> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var players = await _playerRepository.GetAllAsync();
            return View(players);
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var player = await _playerRepository.GetAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,BirthDate,Position,TeamId,MarketValue")] Player player)
        {
            if (ModelState.IsValid)
            {
                player.Id = Guid.NewGuid();
                await _playerRepository.CreateAsync(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var player = await _playerRepository.GetAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,BirthDate,Position,TeamId,MarketValue")] Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _playerRepository.UpdateAsync(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var player = await _playerRepository.GetAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _playerRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
