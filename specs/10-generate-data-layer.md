# 10 - Data Layer: CUSTOMERS, SALES, COUNTRIES

## Goal
Implement the foundational data layer for the application, targeting the Oracle SH schema's `CUSTOMERS`, `SALES`, and `COUNTRIES` tables. This layer will provide entity models and a DbContext for EF Core, enabling CRUD operations and future feature slices.

## Requirements

1. **Entity Classes**
   - Generate C# entity classes for:
     - `Customer` (from SH.CUSTOMERS)
     - `Sale` (from SH.SALES)
     - `Country` (from SH.COUNTRIES)
   - Properties must match the Oracle schema (types, nullability, keys).
   - Add navigation properties where appropriate (e.g., Customer → Sales, Sale → Customer, Customer → Country).

2. **DbContext**
   - Create `AppDbContext` in `Data/Context/`.
   - Add `DbSet<Customer>`, `DbSet<Sale>`, and `DbSet<Country>`.
   - Configure relationships and keys using Fluent API if needed.
   - Use Oracle EF Core provider.

3. **Dependency Injection**
   - Register `AppDbContext` as Scoped in DI (no connection pooling).
   - Don't touch appsettings.json it's good.

4. **Constraints**
   - No repository pattern for Sales (repository pattern may be used for Customer if needed in later steps).
   - No migrations, no boilerplate, no Docker.
   - No full record loading; future queries must support windowed paging.

5. **Location**
   - Place entity classes in `Data/Entities/`.
   - Place context in `Data/Context/`.

## Deliverables
- `Data/Entities/Customer.cs`
- `Data/Entities/Sale.cs`
- `Data/Entities/Country.cs`
- `Data/Context/AppDbContext.cs`
- DI registration in `Program.cs` (code sample)


## Notes
- Use PascalCase for C# properties, matching Oracle columns.
- Use `[Key]`, `[ForeignKey]`, and other EF Core attributes as needed.
- Navigation properties should be virtual for EF Core proxy support.
- Do not implement any business logic or repository methods in this step.
- Wait for developer feedback and validation before proceeding to the next step. 