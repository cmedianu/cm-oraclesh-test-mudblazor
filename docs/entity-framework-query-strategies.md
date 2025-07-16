## 🔍 Comparing EF Core Query Strategies — Performance, Tracking, and Query Shape Control

This table compares the most common Entity Framework Core data access patterns, with a focus on performance, tracking behavior, and control over selected data.

| Query Strategy Feature / Concern                | `.Include()` + Entity Tracking | `.ProjectTo<DTO>()` (AutoMapper Projection) | Bare LINQ Query (`AsNoTracking`, no `Include`) |
|------------------------------------------------|-------------------------------|---------------------------------------------|------------------------------------------------|
| 🔄 Tracking Enabled by Default?                | ✅ Yes                        | ⚠️ No (but must add `AsNoTracking`)         | ✅ No — default is `AsNoTracking`               |
| 🧠 Change Tracking Overhead                    | ⚠️ High                      | ✅ Low with `AsNoTracking`                  | ✅ Minimal                                     |
| 🧮 Control over selected columns               | ❌ None (fetches full entity + navs) | ✅ Full (AutoMapper decides)      | ✅ Full (you write exact query)               |
| ⚡ Query Performance on Large Tables           | ❌ Poor (overfetch risk)      | ✅ Good — tight SQL projection              | ✅ Best — manual control                       |
| 🔌 Navigation loading                          | ✅ Auto via `.Include()`      | ⚠️ Partial via AutoMapper config           | ❌ Manual joins only                          |
| 📐 Suitable for DTOs / API responses           | ❌ No                         | ✅ Yes                                      | ✅ Yes                                         |
| 🧩 Supports calculated/mapped fields           | ❌ No                         | ⚠️ Some — no method calls                  | ✅ Yes                                         |
| 🧱 Readability / Maintainability               | ✅ Simple (small graphs)      | ✅ Concise with config                      | ⚠️ Can become messy at scale                  |
| 🛡️ Safety for long-term maintainability       | ❌ Risky (hidden joins, overfetch) | ✅ Safe, declarative mappings       | ✅ Safe, low-level control                     |
| 🧪 Ideal Use Case                              | Modify entity + children      | DTO queries at scale                        | Raw read-only reports, microservices          |

---

### 📝 Code Examples

#### 1. `.Include()` + Entity Tracking
```csharp
var customers = await context.Customers
    .Include(c => c.Country)
    .Where(c => c.Country.Name == "USA")
    .ToListAsync();
// AutoMapper used separately: return mapper.Map<List<CustomerDto>>(customers);
```

#### 2. `.ProjectTo<DTO>()` (AutoMapper Projection)
```csharp
var customerDtos = await context.Customers
    .AsNoTracking()
    .Where(c => c.Country.Name == "USA")
    .ProjectTo<CustomerDto>(mapper.ConfigurationProvider)
    .ToListAsync();
```

#### 3. Bare LINQ Query with Manual DTO Creation
```csharp
var customerDtos = await context.Customers
    .AsNoTracking()
    .Where(c => c.Country.Name == "USA")
    .Select(c => new CustomerDto 
    { 
        Id = c.Id, 
        Name = c.Name, 
        CountryName = c.Country.Name 
    })
    .ToListAsync();
```

---

### ✅ TL;DR Recommendations

- **Use `.ProjectTo<DTO>()`** as the default for most apps:
    - Cleanest syntax
    - Great performance with `.AsNoTracking()`
    - Declarative mappings, little duplication

- **Use `.Include()` only when:**
    - You're modifying entities and need EF to track relationships
    - You're binding directly to the EF model in simple admin forms
    - You're okay with overfetching and know the domain size is small

- **Use bare LINQ with manual DTO creation** when:
    - You need full control over the query shape
    - You want to map derived/calculated fields
    - You're writing highly optimized, low-level queries
    - AutoMapper gets in the way or you want minimal abstraction

---

### ⚠️ Common Pitfalls

- **N+1 Queries**: Watch out when accessing navigation properties in loops without proper includes
- **Missing AsNoTracking()**: Forgetting this on read-only queries adds unnecessary tracking overhead

### 🔀 Split Queries

When loading multiple related collections, consider `.AsSplitQuery()` to avoid data duplication from joins:
```csharp
var customers = await context.Customers
    .Include(c => c.Orders)
    .Include(c => c.Addresses)
    .AsSplitQuery()  // Executes separate queries instead of one large join
    .ToListAsync();
```

---
