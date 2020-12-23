using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.Domain.Interfaces.Repository;
using CampeonatoAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoAPI.Service.Services
{
    public class PartidaService : IPartidaService
    {
        private readonly IRepository<PartidaEntity> _repository;
        private readonly ITimeService _timeService;
        public PartidaService(IRepository<PartidaEntity> repository, ITimeService timeService)
        {
            _repository = repository;
            _timeService = timeService;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }
        

        public async Task<PartidaEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<PartidaEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<PartidaEntity> Post(PartidaEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<PartidaEntity> Put(PartidaEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
                
    }
}
