# MF - My Finance

Projeto de controle de finanças pessoais

O projeto foi desenvolvido para que os usuários dele possam registrar suas receitas e despesas
pondendo realizar a análise de seus gastos e consequentemente um melhor planejamento financeiro. Esta 
aplicação deve permitir que o usuário monte uma espécie de Plano de Contas para categorizar 
todas as Transações realizadas, além de disponibilizar um relatório das transações efetuadas por período.

## 💻 Tecnologias

O projeto utiliza as tecnologias:

- ASP .NET MVC
- SQL Server

## Banco de dados

Para o projeto utilizamos o banco de dados relacional SQL Server, seguindo a modelagem de dados apresentada:

<img src="myfinance-web-netcore\docs\MF_DER.png" alt="DER">

## 💻 Arquitetura

O projeto foi divido em camadas, seguindo boas práticas de arquitetura, conforme desenho:

<img src="myfinance-web-netcore\docs\MF_Arquitetura.png" alt="Arquitetura">

## 💻 Premissas

O projeto ainda não possui estrutura de deploy, neste caso utlizamos uma IDE para sua execução, sendo necessários os requisitos:

- [Git](https://git-scm.com/downloads)
- [VSCode](https://code.visualstudio.com/download)
- [.NET Core SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

- Criação do banco de dados através do script disponível em: [myfynance.sql](myfinance-web-netcore\database\myfynance.sql)


## 💻 Execucao

Para executar o projeto: 
- Navegar até a pasta myfinance-web-netcore/src via terminal (de sua preferência)
- Executar o comando `dotnet run`

## Acessando a aplicação

- HTTPS: https://localhost:7192
- HTTP: http://localhost:5228

## Navegação

- Tela de Plano de Contas

Nessa tela conseguimos criar, alterar, deletar e visualizar os planos de contas, informando uma descrição e o tipo (Receita ou Despesa):

<img src="myfinance-web-netcore\docs\T_PlanoConta.png" alt="Plano de Conta">

- Tela de Transações

Nessa tela conseguimos criar, alterar, deletar e visualizar transações financeiras, informando a data, valor, histórico e selecionando qual o plano de conta relacionado a transação, além de podermos navegar para a tela de relatório:

<img src="myfinance-web-netcore\docs\T_Transacoes.png" alt="Transacao">

- Tela de Relatório

Nessa tela conseguimos gerar um relatório por período, selecionando o intervalo de datas que desejamos pesquisar e clicando em filtrar:

<img src="myfinance-web-netcore\docs\T_Reports.png" alt="Relatorio">

Com o relatório gerado conseguimos em sequência gerar um gráfico clicando em "Gerar Gráfico" comparando as receitas e despesas do período:

<img src="myfinance-web-netcore\docs\T_ReportsChart.png" alt="Grafico">