# MudBlazor Table Component Reference

MudTable is a powerful component for displaying data in a tabular format. It supports features such as sorting, filtering, pagination, row selection, and more.

## Basic Usage

```csharp
<MudTable Items="@items" T="YourModelType">
    <HeaderContent>
        <MudTh>Column 1</MudTh>
        <MudTh>Column 2</MudTh>
    </HeaderContent>
    <RowTemplate>
        <MudTd DataLabel="Column 1">@context.Property1</MudTd>
        <MudTd DataLabel="Column 2">@context.Property2</MudTd>
    </RowTemplate>
</MudTable>
```

## Core Properties and Features

### Data Source Properties

| Property | Type | Description |
|----------|------|-------------|
| `Items` | `IEnumerable<T>` | Collection of items to display in the table |
| `T` | Generic Type | The type of items displayed in the table |
| `ServerData` | `Func<TableState, Task<TableData<T>>>` | For server-side pagination, sorting, and filtering |
| `CurrentPage` | `int` | Current page index (zero-based) |
| `RowsPerPage` | `int` | Number of rows per page |
| `TotalItems` | `int` | Total number of items |

### Appearance Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Dense` | `bool` | `false` | Makes the table more compact |
| `Hover` | `bool` | `false` | Adds hover effect to rows |
| `Striped` | `bool` | `false` | Adds alternating row colors |
| `Bordered` | `bool` | `false` | Adds borders to cells |
| `Outlined` | `bool` | `false` | Adds an outline around the table |
| `Square` | `bool` | `false` | Makes table corners square instead of rounded |
| `Elevation` | `int` | `1` | Elevation/shadow level |
| `FixedHeader` | `bool` | `false` | Makes header fixed during scroll |
| `FixedFooter` | `bool` | `false` | Makes footer fixed during scroll |
| `Height` | `string` | `null` | Sets the table height (e.g., "400px") |
| `Width` | `string` | `null` | Sets the table width |
| `Class` | `string` | `null` | CSS class for the table |
| `Style` | `string` | `null` | Inline CSS styles for the table |
| `HeaderClass` | `string` | `null` | CSS class for the header |
| `HeaderStyle` | `string` | `null` | Inline CSS styles for the header |
| `RowClass` | `Func<T, int, string>` | `null` | Function that returns CSS class for each row |
| `RowStyle` | `Func<T, int, string>` | `null` | Function that returns inline CSS styles for each row |

### Behavior Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Loading` | `bool` | `false` | Shows loading indicator when true |
| `LoadingProgressColor` | `Color` | `Color.Default` | Color of the loading progress bar |
| `Breakpoint` | `Breakpoint` | `Breakpoint.Xs` | Responsive breakpoint for mobile view |
| `HorizontalScrollbar` | `bool` | `false` | Shows horizontal scrollbar when content exceeds width |
| `RightAlignSmall` | `bool` | `false` | Aligns content to the right on small screens |
| `CommitEditOnValidityChanged` | `bool` | `false` | Commits edits when validity changes |
| `CanCancelEdit` | `bool` | `true` | Allows canceling edits |
| `ReadOnly` | `bool` | `false` | Prevents editing when true |

### Selection Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `MultiSelection` | `bool` | `false` | Enables multi-selection mode |
| `SelectedItem` | `T` | `default` | Currently selected item in single selection mode |
| `SelectedItems` | `HashSet<T>` | `null` | Currently selected items in multi-selection mode |
| `CheckBoxPosition` | `TableCheckBoxPosition` | `TableCheckBoxPosition.Start` | Position of checkboxes in multi-selection mode |
| `SelectionChangedTrigger` | `TableSelectionChangedTrigger` | `TableSelectionChangedTrigger.RowClick` | When selection change is triggered |

### Sorting and Filtering

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `SortLabel` | `string` | `null` | Label for sort dropdown on small screens |
| `Filter` | `Func<T, bool>` | `null` | Function to filter items |
| `SortBy` | `Func<T, object>` | `null` | Function to sort items |
| `SortDirection` | `SortDirection` | `SortDirection.None` | Direction of sorting |
| `SortFunc` | `Comparison<T>` | `null` | Custom comparison function for sorting |

### Grouping Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `GroupBy` | `TableGroupDefinition<T>` | `null` | Definition for grouping rows |
| `GroupHeaderClass` | `string` | `null` | CSS class for group headers |
| `GroupHeaderStyle` | `string` | `null` | Inline CSS styles for group headers |
| `GroupFooterClass` | `string` | `null` | CSS class for group footers |
| `GroupFooterStyle` | `string` | `null` | Inline CSS styles for group footers |

## Template Content

| Property | Type | Description |
|----------|------|-------------|
| `HeaderContent` | `RenderFragment` | Content for table header |
| `RowTemplate` | `RenderFragment` | Template for rendering each row |
| `RowEditingTemplate` | `RenderFragment` | Template for row editing mode |
| `FooterContent` | `RenderFragment` | Content for table footer |
| `ColGroup` | `RenderFragment` | Column group definitions |
| `ToolBarContent` | `RenderFragment` | Content for the toolbar |
| `PagerContent` | `RenderFragment` | Content for the pager |
| `NoRecordsContent` | `RenderFragment` | Content when no records are available |
| `LoadingContent` | `RenderFragment` | Content during loading state |
| `GroupHeaderTemplate` | `RenderFragment<TableGroupData<T>>` | Template for group headers |
| `GroupFooterTemplate` | `RenderFragment<TableGroupData<T>>` | Template for group footers |

## Events

| Event | Type | Description |
|-------|------|-------------|
| `RowClick` | `EventCallback<TableRowClickEventArgs<T>>` | Triggered when a row is clicked |
| `SelectedItemChanged` | `EventCallback<T>` | Triggered when selected item changes |
| `SelectedItemsChanged` | `EventCallback<HashSet<T>>` | Triggered when selected items change |
| `OnRowEditCommit` | `EventCallback<object>` | Triggered when row edits are committed |
| `OnRowEditCancel` | `EventCallback<object>` | Triggered when row edits are canceled |
| `CommittedItemChanges` | `EventCallback<T>` | Triggered when item changes are committed |

## Server-Side Operations

MudTable supports server-side operations for large datasets using the `ServerData` property:

```csharp
<MudTable ServerData="@ServerReload" 
          @ref="table"
          Hover="true"
          FixedHeader="true"
          FixedFooter="true"
          Height="calc(100vh - 200px)">
    <HeaderContent>
        <!-- Header Content -->
    </HeaderContent>
    <RowTemplate>
        <!-- Row Template -->
    </RowTemplate>
    <PagerContent>
        <MudTablePager />
    </PagerContent>
</MudTable>

@code {
    private MudTable<YourModel> table;

    private async Task<TableData<YourModel>> ServerReload(TableState state)
    {
        // Implement server-side logic for paging, sorting, and filtering
        // state.Page contains the current page index
        // state.PageSize contains the page size
        // state.SortLabel contains the current sort column
        // state.SortDirection contains the sort direction

        // Return TableData with items and total count
        return new TableData<YourModel> 
        { 
            Items = pagedData,
            TotalItems = totalCount 
        };
    }
}
```

## Sorting

MudTable supports sorting through the `MudTableSortLabel` component:

```csharp
<MudTable Items="@elements" Hover="true" SortLabel="Sort By">
    <HeaderContent>
        <MudTh>
            <MudTableSortLabel SortBy="@(x => x.Number)">Nr</MudTableSortLabel>
        </MudTh>
        <MudTh>
            <MudTableSortLabel InitialDirection="SortDirection.Ascending" 
                              SortBy="@(x => x.Name)">Name</MudTableSortLabel>
        </MudTh>
    </HeaderContent>
    <RowTemplate>
        <MudTd DataLabel="Nr">@context.Number</MudTd>
        <MudTd DataLabel="Name">@context.Name</MudTd>
    </RowTemplate>
</MudTable>
```

## Filtering

MudTable supports filtering through the `Filter` property:

```csharp
<MudTable Items="@elements" Filter="@FilterFunc">
    <ToolBarContent>
        <MudTextField @bind-Value="searchString" Placeholder="Search"
                     Adornment="Adornment.Start" AdornmentIcon="@Icons.Material.Filled.Search"
                     IconSize="Size.Medium" Class="mt-0"></MudTextField>
    </ToolBarContent>
    <!-- Header and row content -->
</MudTable>

@code {
    private string searchString = "";

    private bool FilterFunc(YourModel element)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        return element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
    }
}
```

## Row Selection

### Single Selection

```csharp
<MudTable Items="@elements" @bind-SelectedItem="selectedItem">
    <!-- Content -->
</MudTable>

@code {
    private YourModel selectedItem = null;
}
```

### Multiple Selection

```csharp
<MudTable Items="@elements" MultiSelection="true" @bind-SelectedItems="selectedItems">
    <!-- Content -->
</MudTable>

@code {
    private HashSet<YourModel> selectedItems = new HashSet<YourModel>();
}
```

## Row Editing

```csharp
<MudTable Items="@elements" CanCancelEdit="true" @bind-SelectedItem="selectedItem">
    <HeaderContent>
        <!-- Header content -->
    </HeaderContent>
    <RowTemplate>
        <!-- Normal row display -->
    </RowTemplate>
    <RowEditingTemplate>
        <!-- Editing mode display -->
    </RowEditingTemplate>
</MudTable>
```

## Column Sizing with ColGroup

```csharp
<MudTable Items="@elements">
    <ColGroup>
        <col style="width: 60px;" />
        <col />
        <col style="width: 60%;" />
        <col style="width: 60px;" />
        <col />
    </ColGroup>
    <!-- Header and row content -->
</MudTable>
```

## Localization

MudTable supports localization through several properties:

```csharp
<MudTablePager 
    InfoFormat="{first_item}-{last_item} de {all_items}" 
    RowsPerPageString="Filas por página:" 
    AllItemsText="Todos" />
```

## Responsive Behavior

MudTable is responsive and adapts to different screen sizes. Use the `Breakpoint` property to control at which breakpoint the table switches to mobile layout:

```csharp
<MudTable Items="@elements" Breakpoint="Breakpoint.Sm">
    <!-- Content -->
</MudTable>
```

In mobile layout, each cell is displayed with its label (specified by the `DataLabel` property):

```csharp
<MudTd DataLabel="Name">@context.Name</MudTd>
```

## Styling Best Practices

1. Use `FixedHeader` and `Height` when displaying large datasets
2. Apply `Dense` for more compact tables with many rows
3. Use `Hover` to improve row identification
4. Use `RowClass` for conditional row styling
5. Customize header appearance with `HeaderClass` and `HeaderStyle`
6. Use `ColGroup` for precise column width control

## Related Components

- MudTh: Table header cell
- MudTd: Table data cell
- MudTableSortLabel: Adds sorting capability to a header
- MudTablePager: Adds pagination functionality
- MudToolBar: Container for toolbar content
