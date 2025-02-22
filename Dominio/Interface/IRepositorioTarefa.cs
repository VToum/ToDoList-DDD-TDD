using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public interface IRepositorioTarefa
    {
        Task AdicionarAsync(Tarefa tarefa);
        Task AtualizarAsync(Tarefa tarefa);
        Task<Tarefa> ObterPorIdAsync(Guid id);
        Task RemoverAsync(Guid id);
        Task<int> ContarAsync();
        Task<List<Tarefa>> ListarAsync();
    }
}
