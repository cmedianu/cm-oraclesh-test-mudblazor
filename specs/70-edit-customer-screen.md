# 70 - Edit Customer Screen (ClientEdit.razor)

## Overview
Implement the full Edit Customer Screen for the SH.CUSTOMERS table, replacing the stub in `ClientEdit.razor` with a complete, functional form. This screen should allow editing all relevant customer fields, perform validation, and persist changes to the database. It should also support creating a new customer (when the URL is `/clients/edit/new`).

## Requirements

### 1. UI & Form
- Replace the placeholder in `ClientEdit.razor` with a MudBlazor form.
- Display all editable fields for a customer:
  - First Name (`CustFirstName`)
  - Last Name (`CustLastName`)
  - Gender (`CustGender`)
  - Year of Birth (`CustYearOfBirth`)
  - Marital Status (`CustMaritalStatus`)
  - City (`CustCity`)
  - State/Province (`CustStateProvince`)
  - Country (`CountryId` or dropdown by name)
  - Email (`CustEmail`)
  - Main Phone Number (`CustMainPhoneNumber`)
- Use MudBlazor components for all inputs (dropdowns, text fields, etc.).
- For dropdowns (Gender, Marital Status, Country, State/Province), use distinct values from the database (with TODO comments indicating that they will be later replaced with code tables). They should be fully implemented using select distinct via EF.
- Show validation errors inline using MudBlazor validation components.
- Show Save and Cancel buttons.

### 2. Data Loading & Saving
- On page load, if editing, load the customer by ID and populate the form.
- If creating, initialize an empty form.
- On Save:
  - Validate the form using `ClientValidator` (FluentValidation).
  - If valid, update or insert the customer in the database via `ClientService`.
  - Show a success message and navigate back to the search page.
  - If errors, display them inline.
- On Cancel, navigate back to the search page without saving.

### 3. Validation
- Use `ClientValidator` for server-side validation. 
- Specify validation rules using annotations on the DTO.
- Add client-side validation rules for required fields, email format, and reasonable value ranges (e.g., year of birth).

### 4. Routing
- Support both `/clients/edit/{id}` (edit) and `/clients/edit/new` (create) routes.
- If an invalid ID is provided, show an error message.

### 5. File Structure
- All logic and components should remain in `/Features/Client/`.
- Update or extend `ClientService.cs`, `ClientDto.cs`, `ClientValidator.cs`, and `ClientProfile.cs` as needed.

### 6. Deliverables
- `/Features/Client/ClientEdit.razor` (full implementation)
- Updates to `/Features/Client/ClientService.cs`, `ClientDto.cs`, `ClientValidator.cs`, `ClientProfile.cs` as needed
- Any new helper files/components required for dropdowns or validation

### 7. Notes
- Follow the vertical slice and feature folder conventions from `project.md`.
- Use MudBlazor best practices for form layout and UX.
- Ensure navigation and error handling are user-friendly.
- Add TODO comments for any dropdowns or features that require future enhancement (e.g., dynamic dropdowns from DB).

- when done implementing ALL OF THE ABOVE clean and build, to see if all good.
---

*This minispec extends the stub in 30-client-search-and-edit.md, implementing the full edit/create functionality for customers as described in the master project spec.* 