# MudBlazor DataGridPager Component Reference

MudDataGridPager is a component used for adding pagination functionality to MudDataGrid components. It provides controls for navigating between pages and configuring page size options.

## Basic Usage

```csharp
<MudDataGrid Items="@items" T="YourModelType">
    <!-- DataGrid content -->
    <PagerContent>
        <MudDataGridPager T="YourModelType" />
    </PagerContent>
</MudDataGrid>
```

## Core Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `T` | Generic Type | Required | The type of items displayed in the grid |
| `PageSizeOptions` | `int[]` | `new int[] {10, 25, 50, 100}` | Available options for rows per page |
| `Disabled` | `bool` | `false` | When true, disables all pager buttons |
| `RowsPerPageString` | `string` | "Rows per page" | Text displayed for rows per page label |
| `InfoFormat` | `string` | "{first_item}-{last_item} of {all_items}" | Format for displaying pagination information |
| `HideRowsPerPage` | `bool` | `false` | Hides the rows per page selector when true |
| `HidePageNumber` | `bool` | `false` | Hides the page number information when true |
| `HidePagination` | `bool` | `false` | Hides the pagination navigation buttons when true |
| `HorizontalAlignment` | `HorizontalAlignment` | `HorizontalAlignment.Left` | Controls the horizontal alignment of the pager content |
| `AllItemsText` | `string` | "All" | Text displayed when selecting to show all items |

## Placeholders in InfoFormat

The InfoFormat property uses the following placeholders:

- `{first_item}`: The index of the first item on the current page
- `{last_item}`: The index of the last item on the current page
- `{all_items}`: The total number of items
- `{page}`: The current page number
- `{pages}`: The total number of pages

## Customizing Page Size Options

You can specify custom page size options:

```csharp
<MudDataGridPager T="YourModelType" PageSizeOptions="new int[] {5, 10, 20, 50, 100}" />
```

To include an option to show all items, use `int.MaxValue` in the PageSizeOptions array:

```csharp
<MudDataGridPager T="YourModelType" PageSizeOptions="new int[] {10, 25, 50, int.MaxValue}" />
```

## Setting Initial Page Size

To set the initial page size, use the `RowsPerPage` property on the parent MudDataGrid component:

```csharp
<MudDataGrid T="YourModelType" RowsPerPage="25">
    <PagerContent>
        <MudDataGridPager T="YourModelType" PageSizeOptions="new int[] {25, 50, 100}" />
    </PagerContent>
</MudDataGrid>
```

## Localizing the Pager

You can customize text labels:

```csharp
<MudDataGridPager T="YourModelType"
    RowsPerPageString="Items per page"
    InfoFormat="Page {page} of {pages} ({first_item}-{last_item} of {all_items})"
    AllItemsText="Show all" />
```

## Appearance and Layout

### Horizontal Alignment

Control the position of elements within the pager:

```csharp
<MudDataGridPager T="YourModelType" HorizontalAlignment="HorizontalAlignment.Center" />
```

Possible values:
- `HorizontalAlignment.Left`
- `HorizontalAlignment.Center`
- `HorizontalAlignment.Right`
- `HorizontalAlignment.Start`
- `HorizontalAlignment.End`

### Hiding Elements

You can hide different parts of the pager as needed:

```csharp
<MudDataGridPager T="YourModelType"
    HideRowsPerPage="false" 
    HidePageNumber="false" 
    HidePagination="false" />
```

## RTL Support

The pager automatically adjusts button order and layout in right-to-left (RTL) environments when the parent MudDataGrid has RightToLeft set to true.

## Events

The MudDataGridPager interacts with its parent MudDataGrid through a cascading parameter reference, so you typically don't need to handle pager events directly.

## Server-Side Pagination

When using MudDataGridPager with server-side pagination:

```csharp
<MudDataGrid ServerData="@(new Func<GridState<YourModel>, Task<GridData<YourModel>>>(LoadGridData))" 
         T="YourModel">
    <!-- Grid content -->
    <PagerContent>
        <MudDataGridPager T="YourModel" PageSizeOptions="new int[] {5, 10, 25, 50}" />
    </PagerContent>
</MudDataGrid>

@code {
    private async Task<GridData<YourModel>> LoadGridData(GridState<YourModel> state)
    {
        // Implement server-side paging logic
        // Return GridData with items and total count
        return new GridData<YourModel> { 
            Items = pagedData,
            TotalItems = totalCount 
        };
    }
}
```

## Styling

You can apply custom styling using the standard MudBlazor styling properties:

```csharp
<MudDataGridPager T="YourModelType"
    Class="your-custom-class"
    Style="your-custom-style" />
```

## Placement Options

By default, the PagerContent is rendered at the bottom of the grid. Unlike MudTable, there's currently no option to place the pager at the top of the grid through properties.

## Navigation Methods

MudDataGrid exposes navigation methods that can be used to programmatically control pagination:

- `GoToPage(int page)`: Navigates to a specific page number
- `FirstPage()`: Navigates to the first page
- `LastPage()`: Navigates to the last page 
- `NextPage()`: Navigates to the next page
- `PreviousPage()`: Navigates to the previous page

Example:
```csharp
@code {
    private MudDataGrid<YourModel> _dataGrid;
    
    private void NavigateToFirstPage()
    {
        if (_dataGrid != null)
        {
            _dataGrid.CurrentPage = 0; // Sets page to first page
            // Or alternatively:
            // await _dataGrid.GoToPage(0);
        }
    }
}
```

## Best Practices

1. Set appropriate PageSizeOptions based on expected data volume
2. For large datasets, use server-side pagination with ServerData for better performance
3. Customize the InfoFormat to provide clear pagination context to users
4. Consider user experience when setting default page size (RowsPerPage on MudDataGrid)
5. When implementing search functionality, remember to reset the current page (CurrentPage = 0) to avoid showing empty results

## Related Components

- MudDataGrid: The parent component that hosts the pager
- MudSelect: Used internally for the page size dropdown
- MudIconButton: Used for pagination navigation buttons
- MudTablePager: Similar component for MudTable pagination
