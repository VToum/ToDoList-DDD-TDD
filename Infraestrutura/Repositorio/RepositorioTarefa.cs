using Dominio;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioTarefa : IRepositorioTarefa
    {
        private readonly TarefaDbContext _contexto;

        public RepositorioTarefa(TarefaDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarAsync(Tarefa tarefa)
        {
            await _contexto.Tarefas.AddAsync(tarefa);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            _contexto.Tarefas.Update(tarefa);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Tarefa> ObterPorIdAsync(Guid id)
        {
            return await _contexto.Tarefas.FindAsync(id);
        }

        public async Task RemoverAsync(Guid id)
        {
            var tarefa = await ObterPorIdAsync(id);
            if (tarefa != null)
            {
                _contexto.Tarefas.Remove(tarefa);
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _contexto.Tarefas.CountAsync();
        }

        public async Task<List<Tarefa>> ListarAsync()
        {
            return await _contexto.Tarefas.ToListAsync();
        }
    }
}
