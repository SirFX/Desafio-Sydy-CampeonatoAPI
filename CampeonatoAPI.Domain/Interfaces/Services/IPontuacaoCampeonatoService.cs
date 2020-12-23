using CampeonatoAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoAPI.Domain.Interfaces.Services
{
    public interface IPontuacaoCampeonatoService
    {
        Task<PontuacaoCampeonatoEntity> Get(Guid id);
        Task<IEnumerable<PontuacaoCampeonatoEntity>> GetAll();
        Task<PontuacaoCampeonatoEntity> Post(PontuacaoCampeonatoEntity entity);
        Task<PontuacaoCampeonatoEntity> Put(PontuacaoCampeonatoEntity entity);
        Task<bool> Delete(Guid id);
    }
}
