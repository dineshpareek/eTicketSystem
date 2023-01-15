using eTicketSystem.Data.BaseRepo;
using eTicketSystem.Models;
using eTicketSystem.Models.Common;

namespace eTicketSystem.Data.Interface
{
    public interface IMovieService:IBaseRepo<Movie>
    {
        PagedResult<Movie> GetAll(string sortField, string currentSortField, string currentSortOrder, string currentFilter, string SearchString = "", int pageNo = 1);
    }
}
