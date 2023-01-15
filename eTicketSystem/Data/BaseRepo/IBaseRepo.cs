using eTicketSystem.Models.Common;
using System.Linq.Expressions;

namespace eTicketSystem.Data.BaseRepo
{
    public interface IBaseRepo<T> where T : class, IBaseEntity,new()
    {
        //PagedResult<T> GetAll(string sortField, string currentSortField, string currentSortOrder, string currentFilter, string SearchString = "", int pageNo = 1);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] Includes);
        Task<T> GetByIdAsync(int Id);
        Task AddAsync(T data);
        Task UpdateAsync(int id, T data);
        Task DeleteAsync(int id);
    }
}
