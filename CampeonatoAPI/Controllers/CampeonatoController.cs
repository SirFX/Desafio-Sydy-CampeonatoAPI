using AutoMapper;
using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.Domain.Interfaces.Services;
using CampeonatoAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CampeonatoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : Controller
    {
        private readonly ICampeonatoService _service;
        private readonly IMapper _mapper;

        public CampeonatoController(ICampeonatoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: CampeonatoController

        /// <summary>
        /// Gerar campeonato 'Brasileirão'
        /// </summary>
        /// <response code = "200">Campeonato obtido com sucesso!</response>
        [HttpGet]
        public async Task<IActionResult> GetCampeonato()
        {
            try
            {
                var campeonato = await _service.GerarCampeonato();

                var partidas = campeonato.Partidas;
                var partidasVideModel = _mapper.Map<List<PartidaEntity>, List<PartidaViewModel>>(partidas);

                var result = new CampeonatoViewModel();
                result.Nome = "Brasileirão";
                result.Partidas = partidasVideModel;
                result.Campeao = campeonato.Campeao.Nome;
                result.Vice = campeonato.Vici.Nome;
                result.Terceiro = campeonato.Terceiro.Nome;

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Gerar campeonato com nome personalisado
        /// </summary>
        /// <response code = "200">Campeonato obtido com sucesso!</response>
        [HttpGet]
        [Route("{nomeCampeonato}", Name = "GetCampeonato")]
        public async Task<IActionResult> GetCampeonato(string nomeCampeonato)
        {
            try
            {
                var campeonato = await _service.GerarCampeonato();

                var partidas = campeonato.Partidas;
                var partidasVideModel = _mapper.Map<List<PartidaEntity>, List<PartidaViewModel>>(partidas);

                var result = new CampeonatoViewModel();
                result.Nome = nomeCampeonato;
                result.Partidas = partidasVideModel;
                result.Campeao = campeonato.Campeao.Nome;
                result.Vice = campeonato.Vici.Nome;
                result.Terceiro = campeonato.Terceiro.Nome;

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
