using eTicketSystem.Data;
using eTicketSystem.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace eTicketSystem.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ETicketDBContext _context;
        public ActorsController(ETicketDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var actors=_context.Actors.GetPaged(2, 10);
            return View(actors);
        }

    }
}
