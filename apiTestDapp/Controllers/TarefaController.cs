using apiTestDapp.MODEL;
using apiTestDapp.SERVICES;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;

namespace apiTestDapp.Controllers
{
    [ApiController]
    public class TarefaController : Controller
    {
        private readonly TarefaService _service;
        public TarefaController(TarefaService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("ListaTarefa")]
        public IActionResult Get()
        {
            var retorno = _service.ListaTarefa();

            return Ok(retorno);
        }

        [HttpPost]
        [Route("Inputar dados")]
        public async Task<IActionResult> AdicionarTarefa([FromBody] TarefaModel tarefa)
        {
            if (tarefa == null || string.IsNullOrEmpty(tarefa.descricao))
            {
                return BadRequest("Dados inválidos.");
            }

            bool sucesso = _service.ColocarTarefa(tarefa);

            if (sucesso)
            {
                return Ok("Tarefa adicionada com sucesso.");
            }
            else
            {
                return StatusCode(500, "Erro ao adicionar a tarefa.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { mensagem = "ID inválido." });
            }

            try
            {
                var resultado = _service.DeletarTarefa(id);
                return Ok(new { mensagem = resultado });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro ao deletar a tarefa.", detalhe = ex.Message });
            }
        }

    }
}