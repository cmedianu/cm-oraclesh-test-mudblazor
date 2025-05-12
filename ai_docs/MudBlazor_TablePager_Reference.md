# MudBlazor TablePager Component Reference

MudTablePager is a component used for adding pagination functionality to MudTable components. It provides controls for navigating between pages and configuring page size options.

## Basic Usage

```csharp
<MudTable Items="@items" T="YourModelType">
    <!-- Table content -->
    <PagerContent>
        <MudTablePager />
    </PagerContent>
</MudTable>
```

## Core Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `PageSizeOptions` | `int[]` | `new int[] {10, 25, 50, 100}` | Available options for rows per page |
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
<MudTablePager PageSizeOptions="new int[] {5, 10, 20, 50, 100}" />
```

To include an option to show all items, use `int.MaxValue` in the PageSizeOptions array:

```csharp
<MudTablePager PageSizeOptions="new int[] {10, 25, 50, int.MaxValue}" />
```

## Localizing the Pager

You can customize text labels:

```csharp
<MudTablePager 
    RowsPerPageString="Items per page"
    InfoFormat="Page {page} of {pages} ({first_item}-{last_item} of {all_items})"
    AllItemsText="Show all" />
```

## Appearance and Layout

### Horizontal Alignment

Control the position of elements within the pager:

```csharp
<MudTablePager HorizontalAlignment="HorizontalAlignment.Center" />
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
<MudTablePager 
    HideRowsPerPage="false" 
    HidePageNumber="false" 
    HidePagination="false" />
```

## RTL Support

The pager automatically adjusts button order and layout in right-to-left (RTL) environments when the parent MudTable has RightToLeft set to true.

## Events

The MudTablePager interacts with its parent MudTable through a cascading parameter reference, so you typically don't need to handle pager events directly.

## Server-Side Pagination

When using MudTablePager with server-side pagination:

```csharp
<MudTable ServerData="@(new Func<TableState, Task<TableData<YourModel>>>(GetServerData))" 
         RowsPerPage="10">
    <!-- Table content -->
    <PagerContent>
        <MudTablePager PageSizeOptions="new int[] {5, 10, 25, 50}" />
    </PagerContent>
</MudTable>

@code {
    private async Task<TableData<YourModel>> GetServerData(TableState state)
    {
        // Implement server-side paging logic
        // Return TableData with items and total count
        return new TableData<YourModel> { 
            Items = pagedData,
            TotalItems = totalCount 
        };
    }
}
```

## Styling

You can apply custom styling using the standard MudBlazor styling properties:

```csharp
<MudTablePager 
    Class="your-custom-class"
    Style="your-custom-style" />
```

## Placement Options

By default, the PagerContent is rendered at the bottom of the table. To change this, you can:

1. Implement custom table layout using MudTable's templating features
2. Use multiple MudTablePager components (both top and bottom) if needed

## Best Practices

1. Set appropriate PageSizeOptions based on expected data volume
2. For large datasets, use server-side pagination for better performance
3. Customize the InfoFormat to provide clear pagination context to users
4. Consider user experience when setting default page size (RowsPerPage on MudTable)

## Related Components

- MudTable: The parent component that hosts the pager
- MudSelect: Used internally for the page size dropdown
- MudIconButton: Used for pagination navigation buttons
