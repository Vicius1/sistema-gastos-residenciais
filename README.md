# Sistema de Gastos Residenciais

Este é um projeto em **.NET com C#** para gerenciar gastos residenciais, utilizando **banco de dados em memória** com **Entity Framework Core**.

## Funcionalidades

O projeto permite:

-  Cadastro, listagem e exclusão de pessoas  
-  Cadastro e listagem de transações (receitas e despesas)  
-  Listagem de totais (receita, despesa e saldo por pessoa e saldo geral)

## Tecnologias Utilizadas

- .NET 8+
- C#
- Entity Framework Core (com banco de dados em memória)

## Como Configurar e Executar o Projeto

### Pré-requisitos

- .NET 8+ SDK instalado

### Instalação

1. Clone o repositório:

   ```sh
   git clone https://github.com/Vicius1/sistema-gastos-residenciais.git
   cd sistema-gastos-residenciais
   ```

2. Execute a aplicação:
   
       dotnet run

Com isso a aplicação estará disponível em http://localhost:5276/.

## Utilização

### Pessoas

#### Criar uma Pessoa
  - **Endpoint:** `POST /pessoa`
  - **URL completa:** `http://localhost:5276/pessoa`
  - **Modelo de requisição:**
 ```json
  {
    "nome": "Vinícius",
    "idade": 22
  }
 ```

#### Listar Pessoas
  - **Endpoint:** `GET /pessoa`
  - **URL completa:** `http://localhost:5276/pessoa`

#### Deletar uma Pessoa baseado no ID vinculado a ela
  - **Endpoint:** `DELETE /pessoa/:id`
  - **URL completa:** `http://localhost:5276/pessoa/{id}`
  > **Observação:** Ao deletar uma pessoa, todas as suas transações também serão removidas.

### Transações

#### Criar uma Transação
- **Endpoint:** `POST /transacao`
- **URL completa:** `http://localhost:5276/transacao`
- **Modelo de requisição:**
  ```json
  {
    "descricao": "Salário",
    "valor": 1000,
    "tipo": "receita",
    "pessoaId": 1
  }
  ```
> Observação: O campo **"tipo"** deve conter obrigatoriamente o valor **"receita"** ou **"despesa"**.
#### Listar Transações
- **Endpoint:** `GET /transacao`
- **URL completa:** `http://localhost:5276/transacao`

### Totais
#### Consultar totais por pessoa e geral
- **Endpoint:** `GET /total`
- **URL completa:** `http://localhost:5276/total`

## Testando a API
Para testar os endpoints da API, utilize uma ferramenta de requisições HTTP como:

- Postman
- Insomnia
- Ou outras ferramentas que disponibilizam requisições HTTP

Essas ferramentas permitem que você envie requisições GET, POST e DELETE para os endpoints descritos acima e visualize as respostas retornadas pelo servidor.

> **Importante:** Certifique-se de que a aplicação esteja em execução com `dotnet run` antes de enviar as requisições.
