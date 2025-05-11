# ✅ Codegen Prompt: Oracle SH Schema - Vertical Slice CRUD App

## 🔍 Purpose

You are generating a **lean, maintainable, feature-sliced** CRUD application on top of the **Oracle SH schema**, starting with the **CUSTOMERS** and **SALES** tables. This prompt will be processed in steps, **one feature slice at a time**, with **incremental implementation** and **feedback checkpoints** between each step.

---

## 🧱 Implementation Flow (Steps)

Generate the application **one step at a time**, in the following **dependency-aware sequence**. After each step, **ask for feedback and wait until the developer confirms success before proceeding**.

### STEP 1: Data Layer for CUSTOMERS  SALES and COUNTRIES tables

- Generate the following:
  - `Customer.cs`  `Sale.cs` and `Country.cs` entity classes from oracle-inspector metadata.
  - `AppDbContext` with proper `DbSet<Customer>` and `DbSet<Sale>`.
  - Auto-registration of `AppDbContext` as **Scoped**, no connection pooling.

🟢 After step 1, prompt the developer to compile and validate before moving on.

---

### STEP 2: Customer Feature Slice

- Create the **Customer** vertical slice:
  - Folder: `/Features/Customer/`
  - Files:
    - `CustomerService.cs` using `IRepository<T>`
    - `CustomerDto.cs`
    - `CustomerValidator.cs` - With minimal implementation, just to prove the concept.
    - `CustomerProfile.cs` (AutoMapper)
    - Pages: `CustomerSearch.razor`, `CustomerEdit.razor`
  - UI:
    - Search screen with paging, sorting, and optional filters.
    - Edit screen with full validation.
  - Dropdowns (if needed) use `SELECT DISTINCT` with `// TODO: Replace...` comment.

🟢 After step 2, prompt for feedback, compilation, and testing.

---

### STEP 3: Sales Feature Slice (No Repository Pattern)

- Create the **Sales** vertical slice:
  - Folder: `/Features/Sales/`
  - Files:
    - `SalesService.cs` (no repository)
    - `SaleDto.cs`
    - `SaleValidator.cs`
    - `SaleProfile.cs`
    - Pages: `SalesList.razor`, `SalesEdit.razor`
  - UI:
    - Master-detail screen from Customer → Sales.
    - Windowed paging with proper relational filtering.
  - Filtering and dropdowns use `SELECT DISTINCT` with TODO markers.

🟢 Prompt for feedback, test compilation before moving on.

---

### STEP 4: Navigation and Shared Infrastructure

- Add MudBlazor navigation:
  - Sidebar with nav links to Customers and Sales.
  - Pages wired via `@page` routes.
- Create shared base components only if needed (e.g., `PagedTable.razor`, `FormLayout.razor`).

🟢 Confirm functionality, style, and routing before proceeding.

---

## 🛠️ Core Principles

- **Tech Stack**: .NET 8, EF Core, MudBlazor, Oracle (SH schema), Serilog
- **No Docker, no migration scripts, no boilerplate unless requested.**
- **No full record loading**: use windowed SQL (e.g., `ROWNUM`, `OFFSET/FETCH`).
- Filtering/sorting only where sensible.
- No use of generic repository for Sales.
- Connection strings go in `appsettings.json` as placeholders.

---

## 🔐 Oracle-Inspector Integration
