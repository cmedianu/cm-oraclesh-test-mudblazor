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

The application follows a **feature-based architecture** where related functionality is grouped together rather than separated by technical layers. Each feature contains its own DTOs, services, validators, and Razor components.

Key patterns:
- Service layer for business logic
- Repository pattern via Entity Framework
- DTO pattern with AutoMapper
- Component-based UI with MudBlazor
- Dependency injection throughout

## Features

Currently implements basic CRUD operations for:
- **Customers** - Customer management with search and edit capabilities
- **Countries** - Reference data management

Future experiments may include additional Sales History entities and advanced UI patterns.