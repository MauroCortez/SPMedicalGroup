using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmed.Interfaces;
using senai_spmed.Repositories;
using senai_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace senai_spmed.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialdadesController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialdadesController()
        {
            _especialidadeRepository = new EspecialidadeRepoasitory();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_especialidadeRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idEspecialdade}")]
        public IActionResult BuscarPorId(int idEspecialdade)
        {
            try
            {
                return Ok(_especialidadeRepository.BuscarPorId(idEspecialdade));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Especialidade novaEspecialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(novaEspecialidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idEspecialdade}")]
        public IActionResult Atualizar(int idEspecialdade, Especialidade especialidadeAtualizada)
        {
            try
            {
                _especialidadeRepository.Atualizar(idEspecialdade, especialidadeAtualizada);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idEspecialdade}")]
        public IActionResult Deletar(int idEspecialdade)
        {
            try
            {
                _especialidadeRepository.Deletar(idEspecialdade);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
