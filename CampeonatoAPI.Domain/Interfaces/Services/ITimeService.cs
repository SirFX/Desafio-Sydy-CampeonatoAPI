using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoAPI.Domain.Interfaces.Services
{
    public interface ITimeService
    {
        Task<TimeEntity> Get    (Guid id);
        Task<IEnumerable<TimeEntity>> GetAll();
        Task<TimeEntity> Post(TimeEntity entity);
        Task<TimeEntity> Put(TimeEntity entity);
        Task<bool> Delete(Guid id);
        Task<List<TimeEntity>> FindAll(string nome);
        Task<int> Count();
        Task<List<TimeEntity>> GetTimes(ParametersPage pageParameters);
    }
}
