using eTicketSystem.Data.BaseRepo;
using eTicketSystem.Data.Interface;
using eTicketSystem.Models;
using eTicketSystem.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace eTicketSystem.Data.Services
{
    public class CinemaService : BaseRepo<Cinema>, ICinemaService
    {
        private readonly ETicketDBContext _context;
        public CinemaService(ETicketDBContext eTicketDBContext) : base(eTicketDBContext) //{ }
        {
            _context = eTicketDBContext;
        }

        public PagedResult<Cinema> GetAll(string sortField, string currentSortField, string currentSortOrder, string currentFilter, string SearchString = "", int pageNo = 1)
        {
            var data = _context.Cinemas.AsNoTracking();//.AsQueryable();

            if (SearchString != null)
            {
                pageNo = 1;
            }
            else
            {
                SearchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                data = data.Where(s => s.Name.Contains(SearchString));//.ToList();
            }
            string sortTypeStr = "ASC"; // or DESC
            string SortColumnName = "Age"; // Your column name
            //data = data.OrderBy($"{SortColumnName} {sortTypeStr}");
            return data.GetPaged(pageNo, 10);
        }

       
    }
}
