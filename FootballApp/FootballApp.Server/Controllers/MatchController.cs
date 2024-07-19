using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    public class MatchController : Controller
    {
        private readonly IRepository<Match, Guid> _matchRepository;

        public MatchController(IRepository<Match, Guid> matchRepository)
        {
            _matchRepository = matchRepository;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var matches = await _matchRepository.GetAllAsync();
            return View(matches);
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,HomeTeamId,AwayTeamId,TournamentId,Location")] Match match)
        {
            if (ModelState.IsValid)
            {
                match.Id = Guid.NewGuid();
                await _matchRepository.CreateAsync(match);
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // POST: Matches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Date,HomeTeamId,AwayTeamId,TournamentId,Location")] Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _matchRepository.UpdateAsync(match);
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _matchRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
