using eTicketSystem.Data;
using eTicketSystem.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicketSystem.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ETicketDBContext _context=null;
        public ProducerController(ETicketDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data= _context.Producers.AsQueryable().GetPaged(1, 10);
            return View(data);
        }
    }
}
