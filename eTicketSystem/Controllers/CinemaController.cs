using eTicketSystem.Data;
using eTicketSystem.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicketSystem.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ETicketDBContext _context = null;
        public CinemaController(ETicketDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data =  _context.Cinemas.GetPaged(2, 10);
            return View(data);
        }
    }
}
