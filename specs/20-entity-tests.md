# 20 - Entity Tests: Selects and Foreign Key Relationships

## Goal
Establish a robust set of tests for the foundational entities (`Customer`, `Sale`, `Country`) to ensure correct mapping, navigation, and foreign key relationships in the data layer.

## Requirements

1. **Basic Select Tests**
   - For each entity (`Customer`, `Sale`, `Country`), implement at least one test that inserts and selects a record and deletes the record it just inserted, verifying that the entity can be persisted and retrieved as expected.
   - The Entity should be easy for the test to recognize, so cleanup can be performed.

2. **Foreign Key Relationship Tests**
   - For each navigation property and foreign key relationship:
     - Insert related entities (e.g., a `Customer` with a `Country`, a `Sale` with a `Customer`).
     - Select the parent and include the child collection (e.g., select a `Customer` and include their `Sales`).
     - Select the child and include the parent (e.g., select a `Sale` and include its `Customer`).
     - Assert that navigation properties are correctly populated.

3. **Test Setup**
   - Use EF Core's InMemory provider for tests.
   - Tests should be self-contained and not depend on external state.

4. **Create additional tests, in a separate file that selects (does not update,or delete) from the oracle database
   - Use the datasource already configured in secrets called OracleSH


## Deliverables
- Unit tests in `Data/Context/InMemoryAppDbContextTests.cs` (or a similar location if refactored).
- Unit tests in `Data/Context/OracleAppDbContextTests.cs` (or a similar location if refactored).
- Tests must cover all entities and their relationships as described above.

## Notes
- Tests should be clear, minimal, and focused on verifying EF Core mapping and navigation, not business logic.
- Use xUnit for test implementation.
- Wait for developer feedback and validation before proceeding to the next step. 
