using Microsoft.EntityFrameworkCore;
using UnitOfWorkPractise.Context;
using UnitOfWorkPractise.Interface;

namespace UnitOfWorkPractise.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly MemorandumDbContext _context;
        public DbSet<T> table = null;
        public GenericRepository(MemorandumDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public T Add(T entity)
        {
            var result = table.Add(entity);
            return result.Entity;
        }

        public bool Delete(int id)
        {
            var result = table.Find(id);
            if(result == null)
            {
                throw new Exception("Data not found");
            }
            else
            {
                table.Remove(result);
                return true;
            }
        }

        public List<T> GetAll()
        {
            var result = table.ToList();
            return result;
        }

        public T GetById(int id)
        {
            var result = table.Find(id);
            return result;
        }

        public T Update(T entity, int id)
        {
            var result = table.Update(entity);
            return result.Entity;
        }
    }
}
