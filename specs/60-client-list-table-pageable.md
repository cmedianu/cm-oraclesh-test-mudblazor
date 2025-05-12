# 60 - Make Client List Table Pageable

## Goal
Ensure the Clients list/search table (`/clients`, `ClientSearch.razor`) is fully pageable, following MudBlazor and project best practices for server-side paging, sorting, and filtering, **using MudDataGrid and MudDataGridPager**.

## Background
- The project requires all large tables to use windowed (paged) queries, never loading all records at once.
- The current implementation uses `<MudTable>` with `ServerData`, `TotalItems`, and `pageSizeOptions`, and the paging logic is handled in `ClientService.GetClientsAsync`.
- There is no shared `PagedTable.razor` component; paging is implemented directly in the page.
- **This task requires migrating the client list table from MudTable to MudDataGrid, and using MudDataGridPager for paging controls.**

## Requirements

1. **Paging Controls (MudDataGridPager)**
   - The table must use `<MudDataGrid>` for displaying client data.
   - The table must display a pager (`MudDataGridPager`) at the bottom, allowing users to navigate between pages.
   - The pager must support these page size options: 10, 20, 50, 100
   - The default page size should be 20.
   - The pager must show the current page, total pages, and total item count (customize `InfoFormat` if needed for clarity).

2. **Server-Side Paging**
   - All paging, sorting, and filtering must be performed server-side via `ClientService.GetClientsAsync`.
   - The UI must never load all records at once.
   - The table must update its contents and pager state in response to user actions (page change, page size change, sort, filter).
   - Use the `ServerData` property of MudDataGrid to implement server-side operations.

3. **User Experience**
   - Paging controls must be always visible at the bottom of the table.
   - The table must indicate loading state when fetching new pages.
   - If there are no results, display a friendly empty state message.
   - The paging experience should be consistent with MudBlazor best practices (see `ai_docs/MudBlazor_DataGrid_Reference.md`).

4. **Testing & Validation**
   - Validate that the table never loads more than one page of data at a time.
   - Confirm that changing page size, sorting, or filters triggers a new server request and updates the table and pager.
   - Confirm that the pager displays correct information for first, last, and middle pages.

## References
- [MudBlazor DataGrid Reference](../ai_docs/MudBlazor_DataGrid_Reference.md)
- [MudBlazor DataGridPager Reference](../ai_docs/MudBlazor_DataGridPager_Reference.md)
- [30-client-search-and-edit.md](./30-client-search-and-edit.md)

## Out of Scope
- Styling changes beyond pager visibility and clarity

---

**Do not implement this specification until explicitly requested.** 