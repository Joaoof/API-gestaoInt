# 💰 Gestão Inteligente de Despesas Pessoais — **GestaoInt API**

> Uma solução completa, escalável e segura para controle financeiro pessoal.
> Desenvolvida com **.NET 8**, arquitetura **DDD (Domain-Driven Design)** e **PostgreSQL**.

---

## 🧠 Sobre o Projeto

A **GestaoInt API** é uma aplicação **RESTful** projetada para simplificar o gerenciamento de finanças pessoais.
Ela permite que o usuário registre, categorize e acompanhe suas movimentações financeiras (receitas e despesas) de forma estruturada e segura.

💡 **Principais funcionalidades:**

* Registro de **movimentações financeiras** (receitas/despesas);
* Controle por **categorias**, **descrições** e **datas**;
* **Autenticação JWT** para segurança das rotas;
* **Criptografia de senhas** com BCrypt;
* **Documentação interativa via Swagger**.

---

## ⚙️ Tecnologias e Arquitetura

| **Aspecto**            | **Detalhes**                       |
| ---------------------- | ---------------------------------- |
| 🧩 **Framework**       | .NET 8                             |
| 🧱 **Arquitetura**     | Domain-Driven Design (DDD)         |
| 🌐 **Comunicação**     | RESTful API                        |
| 🗄️ **Banco de Dados** | PostgreSQL (Entity Framework Core) |
| 🔒 **Segurança**       | JWT + BCrypt                       |
| 📘 **Documentação**    | Swagger / OpenAPI                  |

---

## 📦 Pacotes NuGet Principais

| **Pacote**                      | **Função**                                     | **Implementação**                                  |
| ------------------------------- | ---------------------------------------------- | -------------------------------------------------- |
| `AutoMapper`                    | Mapeia entidades ↔ DTOs, reduzindo boilerplate | `GestaoInt.Application/AutoMapper/AutoMapping.cs`  |
| `FluentValidation`              | Valida objetos de requisição de forma fluida   | `MovementValidator.cs`, `RegisterUserValidator.cs` |
| `Microsoft.EntityFrameworkCore` | ORM para integração com PostgreSQL             | Entidades `Users` e `Movements`                    |
| `BCrypt.Net-Next`               | Criptografia e verificação de senhas           | `Infrastructure/Security/BCrypt.cs`                |
| `FluentAssertions`              | Testes de unidade legíveis e expressivos       | Usado em testes de domínio                         |
| `Swashbuckle.AspNetCore`        | Geração da interface Swagger/OpenAPI           | Configurado em `Program.cs`                        |

---

## 🚀 Como Executar o Projeto

### 🧾 Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Docker](https://www.docker.com/) *(opcional)*

---

### ⚙️ Configuração do Banco de Dados

O arquivo `appsettings.Development.json` contém a **string de conexão** padrão:

```json
"ConnectionStrings": {
  "Connection": "Host=localhost;Port=5432;Database=gestao;Username=joao;Password=Senha123;SearchPath=public"
}
```

---

### 🧱 Aplicando as Migrations

```bash
# Instalar o Entity Framework CLI
dotnet tool install --global dotnet-ef

# Aplicar migrations e criar o banco
dotnet ef database update \
  --project src/GestaoInt.Infrastructure/GestaoInt.Infrastructure.csproj \
  --startup-project src/GestaoInt.Api/GestaoInt.Api.csproj
```

---

### ▶️ Execução Local

```bash
cd src/GestaoInt.Api
dotnet run
```

Acesse a API em:

* 🔗 [http://localhost:5031](http://localhost:5031)
* 🔒 [https://localhost:7158](https://localhost:7158)

> 📜 Confira o arquivo `launchSettings.json` para confirmar as portas utilizadas.

---

### 🐳 Execução com Docker

```bash
# Construir a imagem
docker build -t gestaoint-api -f src/GestaoInt.Api/Dockerfile .

# Rodar o contêiner
docker run -d -p 5031:8080 -p 7158:8081 --name gestaoint gestaoint-api
```

---

## 🗺️ Endpoints Principais

A documentação completa está disponível no **Swagger** após a execução da API:

🔗 **[https://localhost:7158/swagger](https://localhost:7158/swagger)**

| **Controlador**      | **Método** | **Rota**             | **Descrição**                                      |
| -------------------- | ---------- | -------------------- | -------------------------------------------------- |
| `UserController`     | `POST`     | `/user-created`      | Criação de novo usuário                            |
| `LoginController`    | `POST`     | `/api/Login`         | Login e geração de token JWT                       |
| `MovementController` | `POST`     | `/movement-register` | Registro de movimentação financeira *(requer JWT)* |

> 🔑 Para endpoints protegidos, adicione o token no header:
>
> ```
> Authorization: Bearer <seu_token_jwt>
> ```

---

## 🧩 Estrutura do Projeto

```
src/
├── GestaoInt.Api/              # Camada de Apresentação (Controllers, Swagger)
├── GestaoInt.Application/      # Casos de uso, validações e AutoMapper
├── GestaoInt.Domain/           # Entidades, Interfaces e Regras de Negócio
├── GestaoInt.Infrastructure/   # Persistência, Contexto EF e Segurança
└── GestaoInt.Tests/            # Testes de unidade
```

---

## 🧠 Conceitos de Arquitetura

O projeto segue princípios de **Domain-Driven Design (DDD)**, priorizando:

* Separação clara de responsabilidades;
* Independência da camada de domínio;
* Testabilidade e manutenção facilitada;
* Comunicação RESTful entre camadas.

---

## 🧪 Testes

Os testes utilizam `xUnit` e `FluentAssertions` para garantir legibilidade e confiabilidade:

```bash
dotnet test
```

---

## 🔒 Segurança

* **Autenticação JWT**: usada para proteger endpoints sensíveis;
* **Criptografia BCrypt**: garante que senhas nunca sejam armazenadas em texto puro;
* **Validações robustas**: implementadas com FluentValidation para entrada de dados segura.

---

## 🧰 Futuras Implementações

* 📊 Dashboard de relatórios financeiros (gráficos e estatísticas)
* 🏷️ Subcategorias e tags de movimentações
* 📆 Exportação de dados (CSV/Excel)
* 🔁 Integração com bancos e PIX

---

## 👨‍💻 Autor

**João**
💼 Desenvolvedor Full Stack • 🚀 Explorador de tecnologia e eficiência
📧 [[joao@email.com](mailto:joaodeus400@gmail.com)]
🔗 [LinkedIn](https://www.linkedin.com/in/jo-aoof/) *(exemplo)*

---

## 🪪 Licença

Este projeto está licenciado sob a **MIT License** — veja o arquivo [LICENSE](LICENSE) para detalhes.
