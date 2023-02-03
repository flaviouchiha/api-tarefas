using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using TaskApi.Models;
using TaskApi.Models.DTO;
using TaskApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskApi.Controllers
{
    [Produces("text/json")]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly string MensagemDeErro = "Ocorreu um erro inesparado";

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public IActionResult Todos()
        {
            try
            {
                var result = _tarefaService.ObterTodos();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagemDeErro);
            }
        }

        [HttpGet("{codigo}")]
        public IActionResult ObterPorCodigo(int codigo)
        {
            try
            {
                var result = _tarefaService.ObterPorCodigo(codigo);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagemDeErro);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] TarefaAdicionarDto tarefa)
        {
            try
            {
                var result = await _tarefaService.Adicionar(tarefa);

                return StatusCode(201, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Editar([FromBody] Tarefa tarefa)
        {
            try
            {
                await _tarefaService.Editar(tarefa);

                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagemDeErro);
            }
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Deletar(int codigo)
        {
            try
            {
                await _tarefaService.Deletar(codigo);

                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagemDeErro);
            }
        }
    }
}
