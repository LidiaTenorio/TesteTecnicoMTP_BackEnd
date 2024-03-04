## Nome Projeto
# Teste Tecnico MTP

Projeto para cadastrar, listar, concluir e deletar tarefas.

## Pré-Requisitos
- [.NET Core SDK](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) instalado

## Configuração do Projeto
1. Clonar o Repositório:
   https://github.com/LidiaTenorio/TesteTecnicoMTP_BackEnd.git

## Configurações do Banco de dados
  1. Executar Script do Banco de Dados:
     Abra o SQL Server Management Studio.
     Conecte-se à sua instância do SQL Server.
     Abra e execute o arquivo ScriptEstruturaDB.ipynb localizado na pasta inicial do projeto.

  3. Configurar a String de Conexão do Banco de Dados:
     Abra o arquivo appsettings.json.
     Atualize a ConnectionStrings com os detalhes da sua conexão com o SQL Server. Alterar apenas o Data Source.

    Exemplo: "DefaultConnection": "Data Source=SEUBANCO;Initial Catalog=TesteTecnicoMTP;Integrated Security=True;TrustServerCertificate=True"

