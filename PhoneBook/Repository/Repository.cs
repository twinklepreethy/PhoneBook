using Dapper;
using Dapper.Contrib.Extensions;
using PhoneBook.Context;
using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using System.Data;
using static Dapper.SqlMapper;

namespace PhoneBook.Repository
{
    public class Repository<T> : IRepository<T> where T : TEntity
    {
        private readonly DapperContext _context;

        public Repository(DapperContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            try
            {
                using var connection = await _context .CreateConnection();
                var identity = await connection.InsertAsync<T>(entity);

                return identity != -1
                    ? entity
                    : default;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex?.InnerException?.Message ?? ex.Message} \r\n" +
                                            $"at {typeof(IRepository<T>).Name} \r\n" +
                                            $"on method: {nameof(Add)} \r\n", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAll(string query, object parameters = null)
        {
            try
            {
                using var connection = await _context.CreateConnection();
                return connection.Query<T>(query, parameters).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex?.InnerException?.Message ?? ex.Message} \r\n" +
                                         $"at {typeof(IRepository<T>).Name} \r\n" +
                                         $"on method: {nameof(GetAll)} \r\n", ex);
            }
        }

        public virtual async Task<T> Get(string query, object parameters = null)
        {
            try
            {
                using var connection = await _context.CreateConnection();
                return connection.QueryFirstOrDefault<T>(query, parameters);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex?.InnerException?.Message ?? ex.Message} \r\n" +
                                         $"at {typeof(IRepository<T>).Name} \r\n" +
                                         $"on method: {nameof(Get)} \r\n", ex);
            }
        }

        public virtual async Task<bool> Delete(T entity)
        {
            try
            {
                using var connection = await _context.CreateConnection();
                return await connection.DeleteAsync<T>(entity);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex?.InnerException?.Message ?? ex.Message} \r\n" +
                                         $"at {typeof(IRepository<T>).Name} \r\n" +
                                         $"on method: {nameof(Get)} \r\n", ex);
            }
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                using var connection = await _context.CreateConnection();
                return await connection.UpdateAsync<T>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex?.InnerException?.Message ?? ex.Message} \r\n" +
                                            $"at {typeof(IRepository<T>).Name} \r\n" +
                                            $"on method: {nameof(Update)} \r\n", ex);
            }
        }
    }
}
