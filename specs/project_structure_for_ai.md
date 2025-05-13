# CM-SH-MudBlazor Project Structure

## Overview
This is a C# Blazor project using MudBlazor component library with Entity Framework Core and Oracle database connectivity.

## Directory Structure

```
/projects/cm-sh-mudblazor/
├── Components/                # Blazor components
│   ├── App.razor              # Main application component
│   ├── Routes.razor           # Routing configuration
│   ├── _Imports.razor         # Razor imports
│   ├── Layout/                # Layout components
│   │   ├── MainLayout.razor   # Main page layout
│   │   └── NavMenu.razor      # Navigation menu
│   ├── Pages/                 # Page components
│   │   ├── Counter.razor      # Example counter page
│   │   ├── Error.razor        # Error page
│   │   └── Home.razor         # Home page
│   ├── Services/              # Component services
│   └── Shared/                # Shared components
│       └── CustomErrorBoundary.razor
│
├── Data/                      # Data access
│   ├── Context/               # EF Core DbContext
│   │   └── AppDbContext.cs    # Database context
│   └── Entities/              # Entity models
│       ├── Country.cs         # Country entity
│       ├── Customer.cs        # Customer entity
│       └── Sale.cs            # Sale entity
│
├── Features/                  # Feature-based organization
│   ├── Client/                # Client feature
│   │   ├── ClientDto.cs       # Data transfer object
│   │   ├── ClientEdit.razor   # Edit component
│   │   ├── ClientProfile.cs   # AutoMapper profile
│   │   ├── ClientSearch.razor # Search component
│   │   ├── ClientService.cs   # Business logic service
│   │   └── ClientValidator.cs # Validation
│   └── Shared/                # Shared features
│
├── Program.cs                 # Application entry point & configuration
├── appsettings.json           # Application settings
├── appsettings.Development.json # Development settings
│
├── Tests/                     # Test project
│
├── wwwroot/                   # Static web assets
│
└── cm-sh-mudblazor.csproj     # Project file with dependencies
```
