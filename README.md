# CM-OracleSH-Test-MudBlazor

This is an experimental Blazor Server application for exploring modern web architecture patterns using MudBlazor components and Oracle database connectivity.

## Purpose

This application serves as a sandbox for experimenting with:
- **Blazor Server** architecture and components
- **MudBlazor** UI component library and Material Design
- **Feature-based** code organization patterns
- **Entity Framework Core** with Oracle provider
- Modern .NET development practices

## Database Schema

The application uses the Oracle Sales History sample schema for realistic data scenarios. The sample schema can be found at:
https://github.com/oracle-samples/db-sample-schemas/tree/main/sales_history

## Technology Stack

- **.NET 9.0** - Latest .NET framework
- **Blazor Server** - Server-side rendering with real-time updates
- **MudBlazor 8.x** - Material Design component library
- **Entity Framework Core** - ORM with Oracle provider
- **Oracle Database** - Data persistence using Sales History schema
- **FluentValidation** - Form validation
- **AutoMapper** - Object-to-object mapping
- **Serilog** - Structured logging

## Getting Started

1. **Prerequisites**
   - .NET 9.0 SDK
   - Oracle Database with Sales History schema installed
   - Connection string configured in user secrets

2. **Setup**
   ```bash
   dotnet restore
   dotnet user-secrets set "ConnectionStrings:OracleSH" "your-oracle-connection-string"
   ```

3. **Run**
   ```bash
   dotnet run
   ```

## Architecture

The application uses **feature-based architecture** instead of traditional layered architecture. Rather than organizing code by technical layers (Controllers, Services, Repositories), functionality is grouped by business features.

### Feature-Based Organization
Each business feature (Client, Country) is contained within its own folder in `/Features` and includes:
- **DTOs** - Data transfer objects for the feature
- **Services** - Business logic and data operations
- **Validators** - FluentValidation rules
- **Razor Components** - UI components for the feature
- **AutoMapper Profiles** - Object mapping configurations

### Key Patterns
- **IDbContextFactory pattern** - Thread-safe database operations
- **Service layer pattern** - Business logic encapsulation
- **DTO pattern with AutoMapper** - Clean separation between entities and presentation
- **Component-based UI** - MudBlazor Razor components
- **Dependency injection** - Throughout the application

## Features

Currently implements basic CRUD operations for:
- **Customers** - Customer management with search and edit capabilities
- **Countries** - Reference data management

Future experiments may include additional Sales History entities and advanced UI patterns.