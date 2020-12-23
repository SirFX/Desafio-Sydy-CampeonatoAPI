using AutoMapper;
using CampeonatoAPI.Domain.Entities;
using CampeonatoAPI.Domain.Interfaces.Services;
using CampeonatoAPI.Domain.Parameters;
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
    public class TimeController : Controller
    {
        private readonly ITimeService _service;
        private readonly IMapper _mapper;
        public TimeController(ITimeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: TimesController
        /// <summary>
        /// Obter Times com paginação 
        /// </summary>
        /// <response code = "200">Times obtidos com sucesso!</response>
        [HttpGet]
        public async Task<IActionResult> GetTimes([FromQuery] ParametersPage pageParameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var times = await _service.GetTimes(pageParameters);

                var timesVideModel = _mapper.Map<List<TimeEntity>, List<TimeViewModel>>(times);
                var result = new TimesPageViewModel();
                var qtdPagina = await _service.Count();
                qtdPagina = qtdPagina / pageParameters.PageSize + 1;

                result.Times = timesVideModel;
                result.TamanhoPagina = pageParameters.PageSize;
                result.QtdPagina = qtdPagina;
                result.Pagina = pageParameters.PageSize;

                return Ok(result);

            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: TimesController/Details/5
        // GET: TimesController
        /// <summary>
        /// Obter Time especifico
        /// </summary>
        /// <response code = "200">Time obtido com sucesso!</response>
        [HttpGet]
        [Route("{id}", Name = "GetTime")]
        public async Task<IActionResult> Get(Guid id)
        {           
            try
            {
                var result = await _service.Get(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: TimesController/Create
        // GET: TimesController
        /// <summary>
        /// Adicionar Time 
        /// </summary>
        /// <response code = "200">Times Adicionado com sucesso!</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TimeEntity time)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = await _service.Post(time);
                if (result != null)
                {
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST: TimesController/Create

        /// <summary>
        /// Atualizar Time
        /// </summary>
        /// <response code = "200">Time Atualizado com sucesso!</response>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TimeEntity time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                time.Id = id;
                var result = await _service.Put(time);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Time não existe!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        // GET: TimesController/Delete/5
        /// <summary>
        /// Deletar Time 
        /// </summary>
        /// <response code = "200">Time Deletado com sucesso!</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Delete(id);

                if (result == false)
                {
                    return BadRequest("Time não encontrado");
                }
                else
                {
                    return Ok("Excluído com sucesso");
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
       
    }
}
