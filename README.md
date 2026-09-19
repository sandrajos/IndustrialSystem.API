# IndustrialSystem API
[![.NET CI](https://github.com/sandrajos/IndustrialSystem.API/actions/workflows/main.yml/badge.svg)](https://github.com/sandrajos/IndustrialSystem.API/actions/workflows/main.yml)

A modular .NET 8 backend for managing industrial work orders, built with ASP.NET Core, Entity Framework Core, SQL Server, and a layered architecture.

The project demonstrates REST API development, separation of concerns, dependency injection, validation, automated testing, and CI/CD with GitHub Actions.

## 🚀 Features

- RESTful API with ASP.NET Core
- Work Order CRUD operations
- Clean layered architecture
- Entity Framework Core
- SQL Server integration
- DTO-based API contracts
- Service layer for business operations
- FluentValidation
- Dependency Injection
- Automated xUnit controller tests
- Moq-based service mocking
- GitHub Actions CI
- Configuration through `appsettings.json`

## 🏗️ Architecture

```text
IndustrialSystem.API
│
├── IndustrialSystem.API
│   ├── Controllers
│   ├── DTOs
│   ├── Services
│   ├── Validators
│   └── Program.cs
│
├── IndustrialSystem.Core
│   └── WorkOrder.cs
│
├── IndustrialSystem.Infrastructure
│   ├── Data
│   ├── Migrations
│   └── EF Core configuration
│
└── tests
    └── IndustrialSystem.Tests
        └── WorkOrdersControllerTests.cs
