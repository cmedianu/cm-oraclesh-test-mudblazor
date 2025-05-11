# 30 - Client Search and Edit Pages

## Overview
Implement a feature slice for searching and managing Clients (SH.CUSTOMERS), including:
- A beautiful, paged, sortable, and filterable Client Search Page using MudBlazor's advanced DataGrid ([reference](https://mudblazor.com/components/datagrid#advanced-data-grid)).
- Links from the search results to an Edit Client page (stubbed for now), which will also serve as the Create Client page in the future.
- Friendly URLs, with the Client ID included in the URL for editing.
- Full data layer and LINQ-based querying, fully hooked up to the UI.
- Integrated into the app navigation.

## Requirements

### 1. Directory & File Structure
- Place all files in `/Features/Client/`.
- Pages:
  - `ClientSearch.razor` (search page)
  - `ClientEdit.razor` (edit/create stub)
- Data/logic:
  - `ClientService.cs` (LINQ-based querying, paging, filtering)
  - `ClientDto.cs` (DTO for grid projection)
  - `ClientProfile.cs` (AutoMapper profile)
  - `ClientValidator.cs` (minimal, for future use)

### 2. Data Layer & Querying
- Use the existing `Customer` entity (from `Data/Entities/Customer.cs`).
- Add `ClientDto` for grid projection (only needed columns).
- Implement `ClientService`:
  - Expose methods for paged, filtered, and sorted queries using LINQ over `AppDbContext.Customers`.
  - Support MudBlazor DataGrid's requirements for server-side paging, sorting, and filtering.
  - Use windowed queries (no full table loads).
- Use AutoMapper for entity-to-DTO mapping (`ClientProfile`).

### 3. Search Page (`ClientSearch.razor`)
- Use MudBlazor's advanced DataGrid ([see docs](https://mudblazor.com/components/datagrid#advanced-data-grid)) for a beautiful, responsive table.
- Columns to display (with search/sort notes):
  - **ID** (`CustId`): sortable, not searchable
  - **First Name** (`CustFirstName`): sortable, searchable
  - **Last Name** (`CustLastName`): sortable, searchable
  - **Gender** (`CustGender`): filterable (dropdown), not free-text searchable
  - **Year of Birth** (`CustYearOfBirth`): sortable, filterable (range)
  - **Marital Status** (`CustMaritalStatus`): filterable (dropdown)
  - **City** (`CustCity`): sortable, searchable
  - **State/Province** (`CustStateProvince`): filterable (dropdown)
  - **Country** (`Country.CountryName`): filterable (dropdown, join to Country)
  - **Email** (`CustEmail`): searchable
  - **Phone** (`CustMainPhoneNumber`): not searchable
- Each row should have a link (button or clickable row) to the Edit Client page, using a friendly URL with the Client ID (e.g., `/clients/edit/123`).
- Include a button/link to create a new Client, which routes to the Edit Client page with a special URL (e.g., `/clients/edit/new`).
- Paging, sorting, and filtering should be handled server-side via `ClientService`.
- Use MudBlazor theming for a beautiful, modern look.

### 4. Edit/Create Page (`ClientEdit.razor`)
- Stub out the page for now (no real form or logic yet).
- Should handle both editing (with ID in URL) and creating (with 'new' in URL).
- Display a placeholder message indicating the page is under construction.

### 5. Routing & Navigation
- Use friendly URLs:
  - `/clients` for the search page
  - `/clients/edit/{id}` for editing
  - `/clients/edit/new` for creating
- Add navigation link to sidebar/menu for Clients.

### 6. Deliverables
- `/Features/Client/ClientSearch.razor`
- `/Features/Client/ClientEdit.razor`
- `/Features/Client/ClientService.cs`
- `/Features/Client/ClientDto.cs`
- `/Features/Client/ClientProfile.cs`
- `/Features/Client/ClientValidator.cs`
- Navigation update (sidebar/menu)
- Fully working, beautiful Client table with paging, sorting, filtering, and navigation to edit/create stubs.

### 7. Notes
- Follow the vertical slice and feature folder conventions from `project.md`.
- Ensure navigation is consistent with the rest of the app.
- No actual data layer or form logic for Edit/Create yet—just stubs and navigation.
- Use LINQ for all queries, no raw SQL.
- Use MudBlazor DataGrid advanced features for best UX.

---

*This specification is based on the project goals and conventions outlined in `project.md` and the [MudBlazor DataGrid documentation](https://mudblazor.com/components/datagrid#advanced-data-grid).* 