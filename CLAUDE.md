# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build Commands

```bash
# Build the project
dotnet build

# Run the application
dotnet run

# Run tests
dotnet test

# Clean build artifacts
dotnet clean

# Restore NuGet packages
dotnet restore
```

## Architecture Overview

This is a **Blazor Server** application using **feature-based architecture** with Oracle database backend.

### Key Patterns
- **Feature-based organization**: `/Features` directory contains business features (Client, Country), each with DTOs, Services, Validators, and Razor components
- **Service layer pattern**: Business logic in feature-specific services (`ClientService`, `CountryService`) registered in DI
- **IDbContextFactory pattern**: Thread-safe database operations using `IDbContextFactory<AppDbContext>`
- **DTO pattern with AutoMapper**: Clean separation between entities and presentation layer

### Technology Stack
- **.NET 9.0** with Blazor Server
- **MudBlazor 8.x** for UI components
- **Entity Framework Core 9.0** with Oracle provider
- **FluentValidation 12.0** for form validation
- **AutoMapper 14.0** for object mapping
- **Serilog** for structured logging
- **xUnit** for testing

### Directory Structure
- `/Components`: Core Blazor infrastructure (Layout, shared components)
- `/Features`: Business features with all related code in one folder
- `/Data`: Entity Framework context and entity models
- `/specs`: Project specifications and task documentation
- `/Tests`: Unit and integration tests

### Database
- **Oracle Database** with Entity Framework Core
- Uses `IDbContextFactory<AppDbContext>` for context management
- Entities: Customer, Country, Sale with proper relationships
- Oracle SQL compatibility mode enabled

### Key Services
- **ClientService**: Customer CRUD operations
- **CountryService**: Country reference data management
- Services use async/await patterns with cancellation tokens

### Validation
- **FluentValidation** integrated with Blazor forms
- Feature-specific validators (e.g., `ClientValidator`)
- **Blazored.FluentValidation** for Blazor integration

### UI Components
- **MudBlazor** component library with Material Design
- Dark/light theme support
- Responsive layout with navigation menu
- Form components with validation integration
- Data grids with filtering, sorting, pagination

## Development Workflow

### Task Management
- Tasks documented in `/specs` directory
- Master specification in `/specs/project.md`
- Mini-specifications numbered (10, 20, 30...) for individual tasks
- Always ensure clean compilation after implementation

### Feature Development
When adding new features:
1. Create feature folder in `/Features`
2. Add DTO, Service, Validator, AutoMapper Profile
3. Register service in `Program.cs`
4. Create Razor components for UI
5. Add tests in `/Tests`

### Database Changes
- Use Entity Framework migrations for schema changes
- Update context factory registration if needed
- Ensure Oracle SQL compatibility settings

### Testing
- Use xUnit framework
- In-memory database provider available for unit tests
- Test services using `IDbContextFactory` pattern