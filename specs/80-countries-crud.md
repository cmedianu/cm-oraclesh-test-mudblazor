# 80 - Countries CRUD Feature Slice

## Goal
Implement a full CRUD (Create, Read, Update, Delete) feature slice for the `COUNTRIES` table from the Oracle SH schema, following the vertical slice architecture and conventions established in the project.

## Requirements

1. **Feature Folder**
   - Create a new folder: `/Features/Country/`

2. **Data Transfer Object (DTO)**
   - `CountryDto.cs`: Define a DTO for the Country entity, mapping all relevant fields.

3. **AutoMapper Profile**
   - `CountryProfile.cs`: Configure AutoMapper mappings between the Country entity and the DTO.

4. **Validation**
   - `CountryValidator.cs`: Implement FluentValidation rules for the Country DTO. Start with minimal validation (e.g., required fields).

5. **Service Layer**
   - `CountryService.cs`: Implement business logic for CRUD operations on countries, using the existing `AppDbContext`.

6. **UI Pages**
   - `CountrySearch.razor`:
     - List countries in a pageable, sortable MudBlazor DataGrid or Table.
     - Add search/filter functionality (e.g., by country name or region).
     - Provide navigation to the edit/create page.
   - `CountryEdit.razor`:
     - Form for creating and editing a country.
     - Include validation and save/cancel actions.
     - Support both creating a new country and editing an existing one.
     - Provide delete functionality with confirmation dialog.

7. **Navigation**
   - Add a sidebar navigation link to the Countries feature.

8. **Testing**
   - Add or update tests to cover the new CRUD operations for countries, following the patterns in `20-entity-tests.md`.

## Constraints
- Follow the vertical slice and feature folder conventions.
- Use MudBlazor components for UI.
- Use windowed paging for large tables (no full record loading).
- No repository pattern unless already used for similar features.
- No migrations or boilerplate unless explicitly required.

## Deliverables
- `/Features/Country/CountryDto.cs`
- `/Features/Country/CountryProfile.cs`
- `/Features/Country/CountryValidator.cs`
- `/Features/Country/CountryService.cs`
- `/Features/Country/CountrySearch.razor`
- `/Features/Country/CountryEdit.razor`
- Navigation update for Countries
- Tests for CRUD operations

---

At the end of the implementation:
- The project should be clean built and all compile errors fixed.
- Any missing NuGet packages should be installed. 