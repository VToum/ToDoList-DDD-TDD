using Dominio.@enum;
using Dominio.Interface;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly IServicoTarefa _tarefaServico;

        public TarefaController(IServicoTarefa tarefaServico)
        {
            _tarefaServico = tarefaServico;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDescricao(Guid id)
        {
            var tarefa = await _tarefaServico.ObterTarefaPorIdAsync(id);

            if (tarefa == null)
            {
                return NotFound("Tarefa não encontrada.");
            }

            var descricao = await _tarefaServico.ObterDescricaoAsync(id);
            return Ok(descricao);
        }

        [HttpPut("AtualizarNome/{id}")]
        public async Task<IActionResult> AtualizarNome(Guid id, [FromBody] string novoNome)
        {
            if (string.IsNullOrEmpty(novoNome))
            {
                return BadRequest("O novo nome não pode ser vazio.");
            }

            try
            {
                await _tarefaServico.AtualizarNomeAsync(id, novoNome);
                return Ok("Nome da tarefa atualizado com sucesso.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Tarefa não encontrada.");
            }
        }

        [HttpPut("AtualizarStatus/{id}")]
        public async Task<IActionResult> AtualizarStatus(Guid id, [FromBody] StatusTarefa novoStatus)
        {
            try
            {
                await _tarefaServico.AtualizarStatusAsync(id, novoStatus);
                return Ok("Status da tarefa atualizado com sucesso.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Tarefa não encontrada.");
            }
        }

        [HttpPut("MarcarPrioridade/{id}")]
        public async Task<IActionResult> MarcarPrioridade(Guid id, [FromBody] StatusPrioridade novaPrioridade)
        {
            try
            {
                await _tarefaServico.MarcarPrioridadeAsync(id, novaPrioridade);
                return Ok("Prioridade da tarefa atualizada com sucesso.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Tarefa não encontrada.");
            }
        }

        [HttpPost("MarcarComoConcluida/{id}")]
        public async Task<IActionResult> MarcarComoConcluida(Guid id)
        {
            try
            {
                await _tarefaServico.MarcarComoConcluidoAsync(id);
                return Ok("Tarefa marcada como concluída.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Tarefa não encontrada.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa([FromBody] Tarefa novaTarefa)
        {
            if (novaTarefa == null)
            {
                return BadRequest("Dados inválidos.");
            }

            await _tarefaServico.AdicionarTarefaAsync(novaTarefa);
            return CreatedAtAction(nameof(ObterDescricao), new { id = novaTarefa.Id }, novaTarefa);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTarefas()
        {
            var tarefas = await _tarefaServico.ListarTarefasAsync();
            return Ok(tarefas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverTarefa(Guid id)
        {
            var resultado = await _tarefaServico.RemoverTarefaAsync(id);
            if (resultado)
            {
                return Ok("Tarefa removida com sucesso.");
            }
            else
            {
                return NotFound("Tarefa não encontrada.");
            }
        }
    }
}
