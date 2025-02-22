using Dominio.@enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IServicoTarefa
    {
        Task AdicionarTarefaAsync(Tarefa tarefa);
        Task<bool> RemoverTarefaAsync(Guid tarefaId);
        Task<Tarefa> ObterTarefaPorIdAsync(Guid tarefaId);
        Task<List<Tarefa>> ListarTarefasAsync();
        Task<int> ContarTarefasAsync();
        Task MarcarComoConcluidoAsync(Guid tarefaId);
        Task MarcarPrioridadeAsync(Guid tarefaId, StatusPrioridade novaPrioridade);
        Task AtualizarStatusAsync(Guid tarefaId, StatusTarefa novoStatus);
        Task AtualizarNomeAsync(Guid tarefaId, string novoNome);
        Task<string> ObterDescricaoAsync(Guid tarefaId);

    }
}
