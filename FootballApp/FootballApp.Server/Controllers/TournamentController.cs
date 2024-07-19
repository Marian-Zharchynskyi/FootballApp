using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IRepository<Tournament, Guid> _tournamentRepository;

        public TournamentController(IRepository<Tournament, Guid> tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        // GET: Tournaments
        public async Task<IActionResult> Index()
        {
            var tournaments = await _tournamentRepository.GetAllAsync();
            return View(tournaments);
        }

        // GET: Tournaments/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var tournament = await _tournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // GET: Tournaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tournaments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartDate,EndDate,Sponsor")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                tournament.Id = Guid.NewGuid();
                await _tournamentRepository.CreateAsync(tournament);
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }

        // GET: Tournaments/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var tournament = await _tournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,StartDate,EndDate,Sponsor")] Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _tournamentRepository.UpdateAsync(tournament);
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var tournament = await _tournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _tournamentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
