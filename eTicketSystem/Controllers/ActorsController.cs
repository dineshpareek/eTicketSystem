using eTicketSystem.Data;
using eTicketSystem.Data.Interface;
using eTicketSystem.Models;
using eTicketSystem.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace eTicketSystem.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService service)
        {
            _actorService = service;
        }
        public async Task<IActionResult> Index()
        {
            var actors = _actorService.GetAll("", "", "", "", "", 1);
            return View(actors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ProfilePic,Info")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorService.GetByIdAsync(id);
            if (id == null)
            {
                return View("Empty");

            }
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorService.GetByIdAsync(id);
            if (actorDetails == null) return View("404");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProfilePic,Info")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorService.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            await _actorService.DeleteAsync(id);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _actorService.GetByIdAsync(id);
            if (actorDetails == null) return View("404");

            await _actorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
