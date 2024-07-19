using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.AspNetCore.Mvc;

namespace FootballApp.Server.Controllers
{
    public class TransferController : Controller
    {
        private readonly IRepository<Transfer, Guid> _transferRepository;

        public TransferController(IRepository<Transfer, Guid> transferRepository)
        {
            _transferRepository = transferRepository;
        }

        // GET: Transfer
        public async Task<IActionResult> Index()
        {
            var transfers = await _transferRepository.GetAllAsync();
            return View(transfers);
        }

        // GET: Transfer/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var transfer = await _transferRepository.GetAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }
            return View(transfer);
        }

        // GET: Transfer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transfer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,FromTeamId,ToTeamId,TransferDate,TransferFee")] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                transfer.Id = Guid.NewGuid();
                await _transferRepository.CreateAsync(transfer);
                return RedirectToAction(nameof(Index));
            }
            return View(transfer);
        }

        // GET: Transfer/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var transfer = await _transferRepository.GetAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }
            return View(transfer);
        }

        // POST: Transfer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PlayerId,FromTeamId,ToTeamId,TransferDate,TransferFee")] Transfer transfer)
        {
            if (id != transfer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _transferRepository.UpdateAsync(transfer);
                return RedirectToAction(nameof(Index));
            }
            return View(transfer);
        }

        // GET: Transfer/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var transfer = await _transferRepository.GetAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }
            return View(transfer);
        }

        // POST: Transfer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _transferRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
