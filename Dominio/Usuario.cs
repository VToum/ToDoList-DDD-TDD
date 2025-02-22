using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public List<Tarefa> _tarefas;

        public Usuario(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            _tarefas = new List<Tarefa>();
        }

        public List<Tarefa> ObterTarefas()
        {
            return _tarefas;
        }
    }
}
