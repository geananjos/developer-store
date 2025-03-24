# 🛒 Sales System API

Uma API RESTful desenvolvida com **.NET 8**, **PostgreSQL**, **DDD**, **JWT Authentication**

---

## ✅ Funcionalidades

- CRUD de **Produtos**, **Usuários** e **Carrinhos de Compra**
- **Autenticação com JWT**
- **Regras de desconto** aplicadas no domínio
- **Swagger** com documentação de API interativa
- Paginação e ordenação com parâmetros customizados
- **Testes automatizados** com xUnit + Moq
- Arquitetura baseada em **DDD** (Domain-Driven Design)
- **Validações com FluentValidation**

---

## 🧰 Tecnologias Utilizadas

- ASP.NET Core 8
- PostgreSQL + EF Core
- AutoMapper
- MediatR
- FluentValidation
- JWT (Json Web Token)
- xUnit + Moq
- Swagger / Swashbuckle

---

## ⚙️ Requisitos

- [.NET SDK 8+](https://dotnet.microsoft.com/download)
- [PostgreSQL 13+](https://www.postgresql.org/download/)
- (Opcional) Visual Studio 2022+ ou VS Code

---

## 🚀 Como configurar o projeto

### 1. Clone o repositório

```
git clone https://github.com/geananjos/developer-store.git
```

### 2. Crie o banco de dados no PostgreSQL
``Acesse seu terminal ou pgAdmin e crie um banco chamado: sales_db

### 3. Configure o appsettings.json
**Arquivo:** ``src/SalesSystem.API/appsettings.json

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=sales_db;Username=postgres;Password=root"
  },
  "JwtSettings": {
    "Secret": "your_super_secret_key_here_123456789",
    "Issuer": "SalesSystemAPI",
    "Audience": "SalesSystemAPIUsers",
    "ExpiresInHours": 6
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

⚠️ **Altere** `Username` e `Password` **de acordo com sua instalação do PostgreSQL.**

### 4. Crie o banco com Entity Framework
No diretório raiz:

```
dotnet ef database update --project src/SalesSystem.Infrastructure/SalesSystem.Infrastructure.csproj --startup-project src/SalesSystem.API/SalesSystem.API.csproj --context SalesDbContext
```

### 5. Execute o projeto
`` dotnet run --project src/SalesSystem.API/SalesSystem.API.csproj

A API estará disponível em:
🔗 https://localhost:7037/swagger

🔐 ### Autenticação JWT
### 1. Crie um usuário com POST /users
Use o endpoint `/api/users` para cadastrar um novo usuário.

### 2. Faça login com POST /auth/login
```
{
  "username": "seuUsuario",
  "password": "suaSenha"
}
```

### 3. Copie o token da resposta
```
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### 4. Use o token para acessar endpoints protegidos
No Swagger, clique em "Authorize" e insira:

`Bearer <seu_token_aqui>`

## 🧪  Executar os testes
Os testes estão organizados no diretório tests.

`dotnet test tests/SalesSystem.Tests`

---

## 🗂️ Estrutura do Projeto
```
├── src/
│   ├── SalesSystem.API               # Web API
│   ├── SalesSystem.Application       # Camada de Aplicação (Commands, Queries, DTOs)
│   ├── SalesSystem.Domain            # Entidades, Enums, ValueObjects
│   └── SalesSystem.Infrastructure    # EF Core, Repositories, Services
│
├── tests/
│   └── SalesSystem.Tests             # Testes com xUnit + Moq
│
└── README.md
```

## 📌 Notas de Segurança
- As senhas são armazenadas de forma segura com BCrypt
- A autenticação é baseada em JWT Tokens
- Endpoints são protegidos com [Authorize]
- O primeiro usuário pode ser criado sem autenticação (apenas para fins de teste da aplicação)
  Alterar para [AllowAnonymous] o UsersController apenas para criar o primeiro usuário, depois retornar para [Authorize].
