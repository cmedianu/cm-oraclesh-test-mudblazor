#!/bin/bash

# Script to scaffold SH schema with CUSTOMERS and SALES tables using dotnet-ef

echo "Scaffolding Oracle SH schema tables for Vertical Slice Architecture"
echo "=================================================================="

# Create directories if they don't exist
mkdir -p Features/Shared/Entities
mkdir -p Data

# Run the scaffolding command for EF Core
dotnet-ef dbcontext scaffold "Name=OracleSH" Oracle.EntityFrameworkCore \
    --context AppDbContext \
    --context-dir Data \
    --context-namespace SH.Data \
    -t CUSTOMERS \
    -t SALES \
    -t COUNTRIES \
    --output-dir Features/Shared/Entities \
    --namespace SH.Features.Shared.Entities \
    --use-database-names \
    --no-pluralize \
    --no-onconfiguring \
    --force

# Check if the scaffolding was successful
if [ $? -eq 0 ]; then
    echo "Scaffolding completed successfully!"
else
    echo "Scaffolding failed. Check the error messages above."
fi