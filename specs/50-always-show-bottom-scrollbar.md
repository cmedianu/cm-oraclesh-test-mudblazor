# 40 - Always Show Bottom Scrollbar on Clients Table Page

## Overview
Improve the user experience on the Clients search page by ensuring the horizontal (bottom) scrollbar for the table is always visible, not just when scrolled to the bottom. This makes it clear to users that the table is horizontally scrollable and improves accessibility, especially for wide tables.

## Requirements
- The horizontal scrollbar for the Clients table must always be visible, even when the table is not scrolled to the bottom.
- The solution should use CSS (preferably via a class or inline style) to set `overflow-x: scroll` (or equivalent) on the table's container.
- The visual appearance should remain clean and consistent with the rest of the MudBlazor UI.
- The change should only affect the Clients table page (`/clients`), not other tables in the app.
- Test in both light and dark modes to ensure the scrollbar is visible and not visually disruptive.

## Implementation Notes
- The most likely place to apply the CSS is the container wrapping the `<MudDataGrid>` in `Features/Client/ClientSearch.razor`.
- If needed, create a new CSS class (e.g., `.always-show-scrollbar`) in the appropriate stylesheet and apply it to the container.
- Avoid global CSS changes that could affect other components.

## Acceptance Criteria
- When visiting `/clients`, the bottom scrollbar is always visible for the table, regardless of scroll position.
- No visual regressions or layout issues are introduced.
- The change is limited in scope to the Clients table page.

---

*This mini-spec is based on the project conventions and user request. See also the [MudBlazor DataGrid documentation](https://mudblazor.com/components/datagrid) for reference.* 