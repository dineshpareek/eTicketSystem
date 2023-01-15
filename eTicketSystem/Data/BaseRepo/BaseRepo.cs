using eTicketSystem.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTicketSystem.Data.BaseRepo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseEntity, new()
    {
        private readonly ETicketDBContext _context;
        public BaseRepo(ETicketDBContext eTicketDBContext)
        {
            _context = eTicketDBContext;
        }
        public async Task AddAsync(T actor)
        {
            await _context.Set<T>().AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                EntityEntry entityEntry = _context.Update(entity);
                entityEntry.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
        public IEnumerable<T> GetAll(params Expression<Func<T,object>>[] Includes)
        {
            IQueryable<T> query = _context.Set<T>();//.AsQueryable();
            query=Includes.Aggregate(query,(current,Includes)=>current.Include(Includes));
            
            return query.ToList();
        }
        public async Task<T> GetByIdAsync(int Id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == Id);

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Update(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
