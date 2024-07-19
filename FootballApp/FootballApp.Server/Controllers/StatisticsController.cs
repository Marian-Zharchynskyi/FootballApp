using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IRepository<Statistics, Guid> _statisticsRepository;

        public StatisticsController(IRepository<Statistics, Guid> statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        // GET: Statistics
        public async Task<IActionResult> Index()
        {
            var statistics = await _statisticsRepository.GetAllAsync();
            return View(statistics);
        }

        // GET: Statistics/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var statistics = await _statisticsRepository.GetAsync(id);
            if (statistics == null)
            {
                return NotFound();
            }
            return View(statistics);
        }

        // GET: Statistics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statistics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,MatchId,Goals,Assists,YellowCards,RedCards,MinutesPlayed")] Statistics statistics)
        {
            if (ModelState.IsValid)
            {
                statistics.Id = Guid.NewGuid();
                await _statisticsRepository.CreateAsync(statistics);
                return RedirectToAction(nameof(Index));
            }
            return View(statistics);
        }

        // GET: Statistics/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var statistics = await _statisticsRepository.GetAsync(id);
            if (statistics == null)
            {
                return NotFound();
            }
            return View(statistics);
        }

        // POST: Statistics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PlayerId,MatchId,Goals,Assists,YellowCards,RedCards,MinutesPlayed")] Statistics statistics)
        {
            if (id != statistics.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _statisticsRepository.UpdateAsync(statistics);
                return RedirectToAction(nameof(Index));
            }
            return View(statistics);
        }

        // GET: Statistics/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var statistics = await _statisticsRepository.GetAsync(id);
            if (statistics == null)
            {
                return NotFound();
            }
            return View(statistics);
        }

        // POST: Statistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _statisticsRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
