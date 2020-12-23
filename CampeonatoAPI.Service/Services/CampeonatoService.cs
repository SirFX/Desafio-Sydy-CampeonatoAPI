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
    public class CampeonatoService : ICampeonatoService
    {
        private readonly IRepository<CampeonatoEntity> _repository;
        private readonly ITimeService _timeService;
        private readonly IPartidaService _partidaService;
        private readonly IPontuacaoCampeonatoService _pontuacaoCampeonatoService;

        public CampeonatoService(
            IRepository<CampeonatoEntity> repository, 
            ITimeService timeService, 
            IPartidaService partidaService, 
            IPontuacaoCampeonatoService pontuacaoCampeonatoService)
        {
            _repository = repository;
            _timeService = timeService;
            _partidaService = partidaService;
            _pontuacaoCampeonatoService = pontuacaoCampeonatoService;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }       

        public async Task<CampeonatoEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<CampeonatoEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<CampeonatoEntity> Post(CampeonatoEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<CampeonatoEntity> Put(CampeonatoEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<CampeonatoEntity> GerarCampeonato()
        {
            var campeonato = new CampeonatoEntity();
            var times = await _timeService.GetAll();
            List<PartidaEntity> partidas = new List<PartidaEntity>();

            foreach (var timeA in times)
            {
                foreach (var timeB in times)
                {
                    if (timeA != timeB && !partidas.Any(x => x.TimeA == timeB && x.TimeB == timeA))
                    {
                        var partida = new PartidaEntity
                        {
                            TimeA = timeA,
                            TimeB = timeB
                        };

                        Random rnd = new Random();
                        partida.GolsA = rnd.Next(0, 3);
                        partida.GolsB = rnd.Next(0, 3);

                        partidas.Add(partida);
                    }
                }
            }

            List<PontuacaoCampeonatoEntity> pontuacoesCampeonatoEntities = new List<PontuacaoCampeonatoEntity>();

            foreach (var time in times)
            {
                var PontuacaoCampeonato = new PontuacaoCampeonatoEntity();
                PontuacaoCampeonato.Time = time;
                pontuacoesCampeonatoEntities.Add(PontuacaoCampeonato);
            }

            foreach (var partida in partidas)
            {

                    
                if (partida.GolsA > partida.GolsB)
                {
                    var time = pontuacoesCampeonatoEntities.Find(x => x.Time == partida.TimeA);

                    time.PontuacaoTime += 3;
                }
                else if (partida.GolsA < partida.GolsB)
                {
                    var time = pontuacoesCampeonatoEntities.Find(x => x.Time == partida.TimeB);

                    time.PontuacaoTime += 3;
                }
                else
                {
                    var time = pontuacoesCampeonatoEntities.Find(x => x.Time == partida.TimeB);
                    time.PontuacaoTime += 1;

                    time = pontuacoesCampeonatoEntities.Find(x => x.Time == partida.TimeA);
                    time.PontuacaoTime += 1;
                }
            }

            var classificacao = pontuacoesCampeonatoEntities.OrderByDescending(x => x.PontuacaoTime);

            campeonato.Partidas = partidas;
            campeonato.Campeao = classificacao.ElementAt(0).Time;
            campeonato.Vici = classificacao.ElementAt(1).Time;
            campeonato.Terceiro = classificacao.ElementAt(2).Time;
            return campeonato;
        }
    }
}
