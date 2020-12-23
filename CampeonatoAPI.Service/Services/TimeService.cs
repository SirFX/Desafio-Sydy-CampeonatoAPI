using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.Domain.Interfaces.Repository;
using CampeonatoAPI.Domain.Interfaces.Services;
using CampeonatoAPI.Domain.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoAPI.Service.Services
{
    public class TimeService : ITimeService
    {
        private readonly IRepository<TimeEntity> _repository;

        public TimeService(IRepository<TimeEntity> repository)
        {
            _repository = repository;
        }
        public async Task<int> Count()
        {
            return await _repository.Count();
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }

        public async Task<List<TimeEntity>> FindAll(string nome)
        {
            return await _repository.FindAll().Where(x => x.Nome == nome).ToListAsync();
        }

        public async Task<TimeEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<TimeEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<TimeEntity> Post(TimeEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<TimeEntity> Put(TimeEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<List<TimeEntity>> GetTimes(ParametersPage pageParameters)
        {
            return await _repository.GetPaginate(pageParameters);
        }
    }
}
