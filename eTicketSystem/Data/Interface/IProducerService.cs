using eTicketSystem.Data.BaseRepo;
using eTicketSystem.Models;
using eTicketSystem.Models.Common;

namespace eTicketSystem.Data.Interface
{
    public interface IProducerService : IBaseRepo<Producer>
    {
        PagedResult<Producer> GetAll(string sortField, string currentSortField, string currentSortOrder, string currentFilter, string SearchString = "", int pageNo = 1);
        //Task<Actor> GetByIdAsync(int Id);
        //Task AddAsync(Actor actor);
        //Task<Actor> UpdateAsync(int id,Actor actor);
        //Task DeleteAsync(int id);
    }
}
