# 40 - Add Serilog Logging

## Overview
Add Serilog logging to the project, as specified in the main project specification (see Tech Stack: .NET 8, EF Core, MudBlazor, Oracle (SH schema), Serilog). Logging should write to the `./logs` directory, with the date included in the log file name. In **Development** mode, logs should also be written to the console. This task will update configuration, dependencies, and startup code to enable robust, file-based and console logging for the application.

## Requirements
- Use [Serilog](https://serilog.net/) as the logging provider for the application.
- Log files must be written to a `./logs` directory at the project root.
- Each log file must include the date in its file name (e.g., `log-2024-05-01.txt`).
- In **Development** mode, logs must be written to both the file and the console.
- In other environments, logs should be written to file only.
- Ensure compatibility with existing logging configuration in `appsettings.json` and `appsettings.Development.json`.
- If the `./logs` directory does not exist, it should be created automatically by Serilog or on application startup.
- Update configuration and code only; do not add any business logic or logging statements to features yet.
- After adding the Serilog NuGet package, run `dotnet outdated -u` to update dependencies as per project standards.

## Steps
1. **Add Serilog NuGet Packages**
   - Add `Serilog.AspNetCore`, `Serilog.Sinks.File`, and `Serilog.Sinks.Console` to the project.
   - Run `dotnet outdated -u` after package installation.

2. **Update appsettings.json and appsettings.Development.json**
   - Add a `Serilog` section to `appsettings.json` to configure file logging to `./logs` with date in the file name.
   - In `appsettings.Development.json`, configure Serilog to log to both file and console.
   - Ensure existing `Logging` section remains for compatibility.

3. **Configure Serilog in Program.cs**
   - Update the application startup to use Serilog as the logging provider.
   - Ensure logs are written to the correct directory and file format.
   - Ensure the `./logs` directory is created if it does not exist.
   - Ensure that in Development mode, logs are also written to the console.

4. **Verify Logging**
   - Confirm that logs are written to `./logs` with the correct date format in the file name.
   - In Development mode, confirm that logs are also output to the console.
   - Ensure no conflicts with existing logging configuration.

## Notes
- Do not implement this specification yet. Await user confirmation before proceeding.
- If logging is not described in the initial project specification, confirm with the user before adding this task (Serilog is already listed in the tech stack). 