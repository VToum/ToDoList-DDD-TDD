🚀 ToDoList-DDD-TDD: API de Gerenciamento de Tarefas com Domain-Driven Design (DDD)

Uma API RESTful robusta para gerenciamento de tarefas, desenvolvida em .NET (C#) com foco em Domain-Driven Design (DDD). Este projeto demonstra minha capacidade de modelar domínios complexos, seguindo boas práticas de arquitetura e código limpo, com preparação para testes automatizados (TDD) e integração futura com um frontend.

✨ Funcionalidades Principais
Modelagem de Domínio com DDD:

Entidades (ex: Tarefa, Usuario), Agregados (ex: ListaDeTarefas), Objetos de Valor (ex: PrazoFinal, Prioridade) e Serviços de Domínio para regras complexas.

Separação clara em camadas: Domínio, Aplicação, Infraestrutura e API.

API RESTful em .NET 8:

Endpoints para CRUD de tarefas, com validações de negócio (ex: prazos não podem ser retroativos).

Integração com SQL Server via Entity Framework Core.

Pronto para TDD:

Estrutura preparada para testes unitários e de integração (xUnit/NUnit), a serem implementados.

🛠️ Tecnologias Utilizadas
Backend	Banco de Dados	Versionamento
.NET 8 (C#)	SQL Server	Git & GitHub
ASP.NET Core Web API	Entity Framework Core	
🎯 Habilidades Destacadas
✅ Domain-Driven Design (DDD): Modelagem de entidades, agregados e objetos de valor para representar o domínio de forma fiel.
✅ Arquitetura em Camadas: Separação clara entre lógica de negócio, aplicação e infraestrutura.
✅ Entity Framework Core: Configuração de migrations, repositórios e mapeamento ORM.
✅ Preparação para TDD: Estrutura modular para facilitar a implementação futura de testes.

📂 Estrutura do Projeto
Copy
ToDoList-DDD-TDD/  
├── 📁 API/               # Camada de apresentação (Controllers, Middlewares)  
├── 📁 Application/       # Casos de uso e serviços da aplicação  
├── 📁 Domain/            # Regras de negócio (Entidades, Serviços de Domínio)  
└── 📁 Infrastructure/    # Implementação de repositórios, EF Core e SQL Server  
⚙️ Configuração do Ambiente
Clone o repositório:

bash
Copy
git clone https://github.com/VToum/ToDoList-DDD-TDD.git  
Configure o Banco de Dados:

Altere a connection string em API/appsettings.json.

Execute as migrations do EF Core:

bash
Copy
dotnet ef database update  
Execute a API:

bash
Copy
cd API  
dotnet run  
🔜 Próximos Passos (Planejados)
Implementar testes unitários e de integração com xUnit/NUnit.

Desenvolver um frontend em Angular para interação com a API.

Adicionar autenticação JWT e autorização por roles.

💡 Por Que Este Projeto?
Foco em DDD: Ideal para demonstrar habilidades em modelagem de domínios e arquitetura limpa.

Escalabilidade: Estrutura pronta para evoluir com novas funcionalidades e testes.

Documentação Clara: Código organizado e README detalhado para facilitar a revisão técnica.

Abrir uma issue para discutir ideias.

Contribuir com um PR seguindo as boas práticas do projeto.

"Transformando requisitos de negócio em código estruturado e preparado para o futuro!" 🌱
