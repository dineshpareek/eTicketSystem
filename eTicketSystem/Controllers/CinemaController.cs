using eTicketSystem.Data;
using eTicketSystem.Data.Interface;
using eTicketSystem.Models;
using eTicketSystem.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicketSystem.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _Service;
        public CinemaController(ICinemaService serv)
        {
            _Service = serv;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = _Service.GetAll("", "", "", "", "", 1);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _Service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var Details = await _Service.GetByIdAsync(id);
            if (Details == null) return View("404");
            return View(Details);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _Service.GetByIdAsync(id);
            if (data == null) return View("404");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _Service.UpdateAsync(id, model);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            await _Service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
