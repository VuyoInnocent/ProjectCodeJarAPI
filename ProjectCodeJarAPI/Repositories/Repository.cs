using ProjectCodeJarAPI.Data;
using ProjectCodeJarAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> DeleteAsync()
        {
            //foreach (var coin in _dataContext.Set<T>())
            //{
            //    _dataContext.Remove(coin);
                
            //}
            //await _dataContext.SaveChangesAsync();
            _dataContext.RemoveRange(_dataContext.Set<T>());
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return _dataContext.Set<T>();
        }

        public async Task<bool> SaveAsync(T entity)
        {
            await _dataContext.AddAsync(entity);
            var added = await _dataContext.SaveChangesAsync();

            return added > 0;
        }
    }
}
