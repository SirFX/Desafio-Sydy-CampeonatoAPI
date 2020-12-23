using CampeonatoAPI.Data.Context;
using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.Domain.Interfaces.Repository;
using CampeonatoAPI.Domain.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoAPI.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }
        public async Task<int> Count()
        {
            return await FindAll().CountAsync();
        }

        public async Task<bool> DeletAsync(Guid id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id) && p.isDeleted.Equals(false));

            if (result == null)
                return false;

            result.isDeleted = true;

            await UpdateAsync(result);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public System.Linq.IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            item.CreateAt = DateTime.UtcNow;
            _dataset.Add(item);

            item.UpdateAt = null;
            item.isDeleted = false;

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await FindAll().Where(x => x.isDeleted != true).ToListAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id) && p.isDeleted.Equals(false));

            if (result == null)
            {
                return null;
            }

            item.UpdateAt = DateTime.UtcNow;
            item.CreateAt = result.CreateAt;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<List<T>> GetPaginate(ParametersPage pageParameters)
        {
            return await FindAll()
                .Where(x => x.isDeleted != true)
                .OrderByDescending(on => on.CreateAt)
                .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                .Take(pageParameters.PageSize)
                .ToListAsync();
        }
    }
}
