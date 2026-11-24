# TOFIX

Findings from a code scan on 2026-10-04.

## Medium

- `src/DesignPatterns/DesignPatterns.csproj:16` - `<NoWarn>` suppresses nine warnings project-wide, mostly nullable ones (`CS8600`, `CS8602`, `CS8603`, `CS8618`, `CS8625`) plus `CS0169` and `CA1416`; the comment above it admits it is a blanket switch. Fix the code, or use inline `#pragma warning disable` only where a demo shows the problem on purpose.
- `src/DesignPatterns/DesignPatterns.csproj:20` - `Microsoft.Data.SqlClient` is referenced but no source file uses it (only `System.Data.OleDb` is used, in `templatemethod.cs:5`). Remove the package reference.
- `doc/coding_style.txt:9` - says "Opening braces on the same line as the statement", which contradicts the Microsoft C# conventions the file claims to summarise (Allman, braces on their own line) and the repo's own code (e.g. `src/MultiEntryPoint/Program1.cs:4`). Correct it.
- `GlobalSuppressions.cs:4` - a placeholder `SuppressMessage("Category", "CheckId")` with the comment "doesnt work"; it sits at the repo root, outside every `.csproj`, so it is never compiled. Delete it.

## Low

- `Directory.Build.props:3` - holds only commented-out settings (`TreatWarningsAsErrors`, `WarningsAsErrors`); either turn `TreatWarningsAsErrors` on or delete the file.
- `scripts/dotnet_build.py:3` - the docstring (and the comment at `rsconstruct.toml:42`) describes the script as reproducing "the Makefile", which no longer exists; describe the command directly.
- `to_integrate/exercises/banking/exercise/Program.cs:1` - `to_integrate/` is in no project and not in `demos-cs.sln`, so it is never compiled; give the banking exercise and its solution a `.csproj` in the solution, or delete it.
