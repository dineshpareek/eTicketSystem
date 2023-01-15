using eTicketSystem.Data;
using eTicketSystem.Data.Interface;
using eTicketSystem.Models;
using eTicketSystem.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicketSystem.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _service=null;
        public ProducerController(IProducerService serv)
        {
            _service = serv;
        }
        
        public async Task<IActionResult> Index()
        {
            var actors = _service.GetAll("", "", "", "", "", 1);
            return View(actors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePic,Name,Info")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (id == null)
            {
                return View("Empty");

            }
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("404");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePic,Name,Info")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var actorDetails = await _service.GetByIdAsync(id);
        //    if (actorDetails == null) return View("404");

        //    await _service.DeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
