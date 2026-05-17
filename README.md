# **IndustrialSystem API**

A modular, scalable **.NET 8** backend designed for managing industrial work orders.  
The solution follows a clean architecture approach with clear separation between **API**, **Core**, and **Infrastructure** layers.

---

## 🚀 Features

- **RESTful API** built with ASP.NET Core  
- **Entity Framework Core** with migrations  
- **Clean Architecture** (API → Core → Infrastructure)  
- **Work Order Management** (CRUD operations)  
- **DTOs, Services, Validators** for clean separation  
- **Configuration via appsettings.json**  
- **Dependency Injection** throughout the solution  

---

## 🏗️ Solution Architecture

```
IndustrialSystem
│
├── IndustrialSystem.API
│   ├── Controllers
│   ├── DTOs
│   ├── Services
│   ├── Validators
│   └── appsettings.json
│
├── IndustrialSystem.Core
│   └── Entities (e.g., WorkOrder.cs)
│
└── IndustrialSystem.Infrastructure
    ├── Data
    ├── Migrations
    └── EF Core setup
```

---

## 📦 Technologies Used

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server / SQLite** (depending on your config)
- **FluentValidation**
- **Dependency Injection**
- **GitHub Actions (optional CI)**

---

## ⚙️ Getting Started

### 1️⃣ Clone the repository

```bash
git clone https://github.com/sandrajos/IndustrialSystem.API.git
cd IndustrialSystem
```

### 2️⃣ Restore dependencies

```bash
dotnet restore
```

### 3️⃣ Apply migrations

```bash
dotnet ef database update --project IndustrialSystem.Infrastructure
```

### 4️⃣ Run the API

```bash
dotnet run --project IndustrialSystem.API
```

The API will start on:

```
https://localhost:5001
http://localhost:5000
```

---

## 📚 API Endpoints (Example)

### **Work Orders**

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/workorders` | Get all work orders |
| GET | `/api/workorders/{id}` | Get a single work order |
| POST | `/api/workorders` | Create a new work order |
| PUT | `/api/workorders/{id}` | Update an existing work order |
| DELETE | `/api/workorders/{id}` | Delete a work order |

---

## 🧩 Project Structure Explained

### **API Layer**  
Handles HTTP requests, controllers, DTOs, validation, and service orchestration.

### **Core Layer**  
Contains business entities and domain logic.

### **Infrastructure Layer**  
Implements EF Core, database context, migrations, and repository logic.

---

## 🧪 Running Tests (if added later)

```bash
dotnet test
```

---

## 🛠️ Development Workflow

1. Create a feature branch  
2. Commit changes with meaningful messages  
3. Push and open a pull request  
4. Wait for review and merge  

---

## 🤝 Contributing

Contributions are welcome!  
Please open an issue or submit a pull request.

---

## 📄 License

This project is licensed under the MIT License.

