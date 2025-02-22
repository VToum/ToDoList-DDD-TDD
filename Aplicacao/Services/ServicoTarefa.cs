using Dominio;
using Dominio.@enum;
using Dominio.Interface;
using Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class ServicoTarefa : IServicoTarefa
    {
        private readonly IRepositorioTarefa _repositorioTarefa;

        public ServicoTarefa(IRepositorioTarefa repositorioTarefa)
        {
            _repositorioTarefa = repositorioTarefa;
        }

        public async Task AdicionarTarefaAsync(Tarefa tarefa)
        {
            if (tarefa == null)
            {
                throw new ArgumentNullException(nameof(tarefa), "A tarefa não pode ser nula.");
            }

            tarefa.Id = Guid.NewGuid();
            tarefa.DataCriacao = DateTime.UtcNow;
            tarefa.Status = StatusTarefa.Pendente;

            await _repositorioTarefa.AdicionarAsync(tarefa);
        }

        public async Task AtualizarNomeAsync(Guid tarefaId, string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
            {
                throw new ArgumentException("O novo nome não pode ser vazio ou nulo.", nameof(novoNome));
            }

            var tarefa = await _repositorioTarefa.ObterPorIdAsync(tarefaId);
            if (tarefa == null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada.");
            }

            tarefa.Nome = novoNome;
            await _repositorioTarefa.AtualizarAsync(tarefa);
        }

        public async Task AtualizarStatusAsync(Guid tarefaId, StatusTarefa novoStatus)
        {
            var tarefa = await _repositorioTarefa.ObterPorIdAsync(tarefaId);
            if (tarefa == null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada.");
            }

            if (!Enum.IsDefined(typeof(StatusTarefa), novoStatus))
            {
                throw new ArgumentOutOfRangeException(nameof(novoStatus), "Status inválido.");
            }

            tarefa.Status = novoStatus;

            if (novoStatus == StatusTarefa.Concluido)
            {
                tarefa.DataConcluido = DateTime.UtcNow;
            }

            await _repositorioTarefa.AtualizarAsync(tarefa);
        }

        public async Task<int> ContarTarefasAsync()
        {
            return await _repositorioTarefa.ContarAsync();
        }

        public async Task<List<Tarefa>> ListarTarefasAsync()
        {
            return await _repositorioTarefa.ListarAsync();
        }

        public async Task MarcarComoConcluidoAsync(Guid tarefaId)
        {
            var tarefa = await _repositorioTarefa.ObterPorIdAsync(tarefaId);
            if (tarefa == null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada.");
            }

            if (tarefa.Status != StatusTarefa.Concluido)
            {
                tarefa.Status = StatusTarefa.Concluido;
                tarefa.DataConcluido = DateTime.UtcNow;

                await _repositorioTarefa.AtualizarAsync(tarefa);
            }
        }

        public async Task MarcarPrioridadeAsync(Guid tarefaId, StatusPrioridade novaPrioridade)
        {
            if (!Enum.IsDefined(typeof(StatusPrioridade), novaPrioridade))
            {
                throw new ArgumentOutOfRangeException(nameof(novaPrioridade), "Prioridade inválida.");
            }

            var tarefa = await _repositorioTarefa.ObterPorIdAsync(tarefaId);
            if (tarefa == null)
            {
                throw new KeyNotFoundException("Tarefa não encontrada.");
            }

            tarefa.Prioridade = novaPrioridade;
            await _repositorioTarefa.AtualizarAsync(tarefa);
        }

        public async Task<string> ObterDescricaoAsync(Guid tarefaId)
        {
            var tarefa = await _repositorioTarefa.ObterPorIdAsync(tarefaId);
            if (tarefa == null)
            {
                return "Tarefa não encontrada.";
            }

            return $"ID: {tarefa.Id}\n" +
                   $"Nome: {tarefa.Nome}\n" +
                   $"Status: {tarefa.Status}\n" +
                   $"Prioridade: {tarefa.Prioridade}\n" +
                   $"Data de Criação: {tarefa.DataCriacao}\n" +
                   $"Data de Conclusão: {tarefa.DataConcluido}";
        }

        public async Task<Tarefa> ObterTarefaPorIdAsync(Guid tarefaId)
        {
            return await _repositorioTarefa.ObterPorIdAsync(tarefaId);
        }

        public async Task<bool> RemoverTarefaAsync(Guid tarefaId)
        {
            var tarefa = await _repositorioTarefa.ObterPorIdAsync(tarefaId);
            if (tarefa == null)
            {
                return false;
            }

            await _repositorioTarefa.RemoverAsync(tarefaId);
            return true;
        }
    }
}
