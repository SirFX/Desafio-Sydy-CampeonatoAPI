using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.Domain.Interfaces.Repository;
using CampeonatoAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoAPI.Service.Services
{
    public class PontuacaoCampeonatoService : IPontuacaoCampeonatoService
    {
        private readonly IRepository<PontuacaoCampeonatoEntity> _repository;

        public PontuacaoCampeonatoService(IRepository<PontuacaoCampeonatoEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }

        public async Task<PontuacaoCampeonatoEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<PontuacaoCampeonatoEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<PontuacaoCampeonatoEntity> Post(PontuacaoCampeonatoEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<PontuacaoCampeonatoEntity> Put(PontuacaoCampeonatoEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
