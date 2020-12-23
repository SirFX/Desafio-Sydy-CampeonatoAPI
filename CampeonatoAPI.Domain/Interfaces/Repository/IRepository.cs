using CampeonatoAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CampeonatoAPI.Domain.Parameters;

namespace CampeonatoAPI.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeletAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        IQueryable<T> FindAll();
        Task<int> Count();
        Task<List<T>> GetPaginate(ParametersPage entity);
    }
}
