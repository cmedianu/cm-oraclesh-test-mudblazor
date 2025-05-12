# MudBlazor DataGrid Component Reference

MudBlazor DataGrid is a powerful component for displaying data in a tabular format with advanced features. This reference provides essential information for implementing and customizing DataGrid in your Blazor applications.

## Basic Usage

```csharp
<MudDataGrid Items="@items" T="YourModelType">
    <Columns>
        <PropertyColumn Property="x => x.PropertyName" Title="Column Title" />
        <!-- Additional columns -->
    </Columns>
</MudDataGrid>
```

## Core Properties

| Property | Type | Description |
|----------|------|-------------|
| `Items` | `IEnumerable<T>` | Data source for the grid |
| `T` | Generic Type | The type of items displayed in the grid |
| `Height` | `string` | Sets the height of the grid (e.g., "600px") |
| `FixedHeader` | `bool` | Keeps the header fixed when scrolling |
| `Filterable` | `bool` | Enables filtering functionality |
| `FilterMode` | `DataGridFilterMode` | Sets the filtering mode (e.g., ColumnFilterMenu) |
| `Groupable` | `bool` | Enables grouping functionality |
| `SortMode` | `SortMode` | Controls the sorting behavior |
| `Dense` | `bool` | Makes the grid more compact |
| `RowsPerPage` | `int` | Number of rows per page |
| `ServerData` | `Func<GridState<T>, Task<GridData<T>>>` | For server-side operations |

## Column Types

### PropertyColumn
For displaying and editing properties directly mapped to model properties.

```csharp
<PropertyColumn Property="x => x.Name" Title="Name" />
```

Properties:
- `Property`: Expression pointing to the model property
- `Title`: Column header text
- `IsEditable`: Whether the column can be edited
- `CellStyle`: CSS styles for cells in this column
- `Format`: Optional format string for value display
- `Sortable`: Enable/disable sorting for this column
- `Filterable`: Enable/disable filtering for this column

### TemplateColumn
For custom cell rendering and editing.

```csharp
<TemplateColumn Title="Custom Column">
    <CellTemplate>
        <MudText>@context.Item.SomeProperty</MudText>
    </CellTemplate>
    <EditTemplate>
        <MudTextField @bind-Value="@context.Item.SomeProperty" />
    </EditTemplate>
</TemplateColumn>
```

Properties:
- `Title`: Column header text
- `CellClass`: CSS classes for cells
- `CellStyle`: CSS styles for cells
- `IsEditable`: Whether the column can be edited

## Column Layout and Sizing

Controlling column width:

```csharp
<ColGroup>
    <col style="width: 60px;" />
    <col style="width: 60%;" />
    <col />
</ColGroup>
```

## Server-Side Operations

To handle large datasets efficiently, use the ServerData property:

```csharp
<MudDataGrid ServerData="@LoadServerData" RowsPerPage="10" T="YourModel">
    <Columns>
        <!-- Columns definition -->
    </Columns>
</MudDataGrid>

@code {
    private async Task<GridData<YourModel>> LoadServerData(GridState<YourModel> state)
    {
        // Implement pagination, sorting, filtering
        // Return a GridData object with items and total count
        return new GridData<YourModel> { 
            Items = pagedData, 
            TotalItems = totalCount 
        };
    }
}
```

## Filtering

```csharp
<MudDataGrid Filterable="true" FilterMode="DataGridFilterMode.ColumnFilterMenu">
    <!-- Content -->
</MudDataGrid>
```

## Pagination

```csharp
<MudDataGrid RowsPerPage="25">
    <PagerContent>
        <MudStack Row="true" Justify="Justify.Center" AlignItems="AlignItems.Center">
            <!-- Custom pager content -->
        </MudStack>
    </PagerContent>
</MudDataGrid>
```

## Handling Row Events

```csharp
<MudDataGrid RowClick="@RowClickEvent">
    <!-- Content -->
</MudDataGrid>

@code {
    private void RowClickEvent(DataGridRowClickEventArgs<YourModel> args)
    {
        // Handle row click
        var item = args.Item;
    }
}
```

## Custom Toolbar

```csharp
<MudDataGrid>
    <ToolBarContent>
        <MudText Typo="Typo.h6">Your Table Title</MudText>
        <MudSpacer />
        <MudTextField T="string" ValueChanged="@OnSearch" 
                     Placeholder="Search" Adornment="Adornment.Start" 
                     AdornmentIcon="@Icons.Material.Filled.Search" IconSize="Size.Medium" />
    </ToolBarContent>
    <!-- Rest of grid definition -->
</MudDataGrid>
```

## Styling and Customization

- Use `Class` and `Style` properties for grid-level styling
- Use `HeaderClass`, `CellClass`, etc. for specific element styling
- Control column width with `<ColGroup>` and `<col>` elements
- Use `Dense` property for more compact display

## Working with Nested Objects

When displaying properties from nested objects:

```csharp
<PropertyColumn Property="x => x.NestedObject.Property" Title="Nested Property" />
```

## Performance Considerations

- For large datasets, always use the `ServerData` property to implement server-side pagination
- Set appropriate `RowsPerPage` values to limit data transfer
- Consider using virtualization for very large datasets

## Events

- `RowClick`: Triggered when a row is clicked
- `SelectedItemsChanged`: Triggered when selection changes
- `CommittedItemChanges`: Triggered when edits are committed
- `CellContext`: For context menu or custom operations on cells

## Additional Resources

For more advanced usage scenarios, refer to the MudBlazor GitHub repository and community discussions.
