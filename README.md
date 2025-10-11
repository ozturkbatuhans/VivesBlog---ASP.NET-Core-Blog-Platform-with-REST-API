# VivesBlog---ASP.NET-Core-Blog-Platform-with-REST-API

A full-stack blog management system built with ASP.NET Core, featuring a clean REST API architecture, custom SDK, and modern web practices.

## Project Overview

This project demonstrates a complete transformation of a monolithic MVC application into a modern, API-driven architecture. The application manages blog articles and authors with full CRUD operations, implementing industry-standard patterns and best practices.

## Architecture

The project follows a layered architecture pattern:
      ┌─────────────────────────────────────────┐
      │         VivesBlog.UI.Presentation       │  ← MVC Web Application
      └────────────────┬────────────────────────┘
      │ HTTP Requests
      ↓
      ┌─────────────────────────────────────────┐
      │           VivesBlog.Sdk                 │  ← SDK Library
      └────────────────┬────────────────────────┘
      │ HTTP Client
      ↓
      ┌─────────────────────────────────────────┐
      │           VivesBlog.Api                 │  ← REST API
      └────────────────┬────────────────────────┘
      │
      ┌────────────────┴────────────────────────┐
      │        VivesBlog.Services               │  ← Business Logic
      └────────────────┬────────────────────────┘
      │
      ┌────────────────┴────────────────────────┐
      │        VivesBlog.Repository             │  ← Data Access
      └────────────────┬────────────────────────┘
      │
      ┌────────────────┴────────────────────────┐
      │        VivesBlog.Model                  │  ← Domain Models & DTOs
      └─────────────────────────────────────────┘

## Features

### Core Functionality
-  **Article Management**: Create, read, update, and delete blog articles
-  **Author Management**: Manage blog authors and their profiles
-  **Full CRUD Operations**: Complete data management capabilities
-  **Responsive UI**: Bootstrap-based modern interface

### Technical Highlights
- **REST API**: Clean RESTful endpoints following HTTP standards
- **DTO Pattern**: Data Transfer Objects for API communication
- **Result Pattern**: Structured error handling with `GenericServiceResult<T>`
- **Custom SDK**: Reusable client library for API consumption
- **Swagger/OpenAPI**: Interactive API documentation
- **In-Memory Database**: Entity Framework Core with seed data

##  Getting Started

### Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 or VS Code
- Git


### Installation
1. **Clone the repository**
  ```
   git clone https://github.com/yourusername/VivesBlog.git
   cd VivesBlog
   dotnet restore
```

2. **Configure startup projects**
```
Set both VivesBlog.Api and VivesBlog.UI.Presentation as startup projects

Right-click Solution → Configure Startup Projects... → Multiple Startup Projects
```

3. Run the application

```
dotnet run --project VivesBlog.Api
dotnet run --project VivesBlog.UI.Presentation
The application will start at:

🧩 API → https://localhost:7218/swagger (Swagger UI)

💻 Web UI → https://localhost:7196
```
## Project Structure

    VivesBlog/
    ├── VivesBlog.Api/                  # REST API project
    │   ├── Controllers/                # API controllers
    │   └── Program.cs                  # API configuration
    ├── VivesBlog.Model/                # Domain models and DTOs
    │   ├── Article.cs
    │   ├── Person.cs
    │   ├── Dto/
    │   └── ServiceResult/
    ├── VivesBlog.Repository/           # Data access layer
    │   └── VivesBlogDbContext.cs
    ├── VivesBlog.Services/             # Business logic layer
    │   ├── ArticleService.cs
    │   └── PersonService.cs
    ├── VivesBlog.Sdk/                  # SDK library
    │   ├── VivesBlogApiClient.cs
    │   └── ServiceCollectionExtensions.cs
    └── VivesBlog.UI.Presentation/      # MVC web application
        ├── Controllers/
        ├── Views/
        └── Program.cs
