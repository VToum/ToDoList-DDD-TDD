using Dominio.@enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public StatusTarefa Status { get; set; }
        public StatusPrioridade Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConcluido { get; set; } // Alterado para nullable

        // Construtor
        public Tarefa(Guid id, string nome, DateTime dataCriacao, DateTime? dataConcluido = null)
        {
            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            DataCriacao = dataCriacao;
            DataConcluido = dataConcluido;
            Status = StatusTarefa.Pendente;
            Prioridade = StatusPrioridade.Baixo;
        }
    }
}
