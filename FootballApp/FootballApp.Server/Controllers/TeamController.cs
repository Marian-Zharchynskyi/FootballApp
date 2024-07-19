using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    public class TeamController : Controller
    {
        private readonly IRepository<Team, Guid> _teamRepository;

        public TeamController(IRepository<Team, Guid> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var teams = await _teamRepository.GetAllAsync();
            return View(teams);
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var team = await _teamRepository.GetAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Coach,Founded,Stadium")] Team team)
        {
            if (ModelState.IsValid)
            {
                team.Id = Guid.NewGuid();
                await _teamRepository.CreateAsync(team);
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var team = await _teamRepository.GetAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Coach,Founded,Stadium")] Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _teamRepository.UpdateAsync(team);
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var team = await _teamRepository.GetAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _teamRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
