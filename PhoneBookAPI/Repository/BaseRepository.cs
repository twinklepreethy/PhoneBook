using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Context;

namespace PhoneBookAPI.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TEntity
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            if(entity != null)
            {
                _context.Remove<T>(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Add(T entity)
        {
            _context.Add<T>(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update<T>(entity);

            await _context.SaveChangesAsync();
        }
    }
}
