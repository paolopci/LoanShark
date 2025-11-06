# Repository Guidelines

## Project Structure & Module Organization
MortgageCalculator.sln anchors the solution; `MortgageCalculator.csproj` hosts the Blazor WebAssembly app targeting .NET 8 with nullable context enabled. UI components belong in `Components/` and should be split by feature (for example, `Components/Calculator/LoanForm.razor`). `App.razor` defines routing and shared layout. Static assets such as CSS, icons, and service-worker files live under `wwwroot/`. Keep configuration files like `.gitignore` and `Properties/launchSettings.json` aligned with local environment needs, and leave build outputs (`bin/`, `obj/`) untouched in version control.

## Build, Test, and Development Commands
`dotnet restore` syncs NuGet packages after cloning or when SDK versions change. Use `dotnet build MortgageCalculator.csproj` for a CI-equivalent compilation. Run `dotnet watch run --project MortgageCalculator.csproj` to launch the development server with hot reload. When preparing production artifacts, `dotnet publish -c Release` emits optimized files to `bin/Release/net8.0/publish`.

## Coding Style & Naming Conventions
Adhere to .NET conventions: 4-space indentation, PascalCase for public types and methods, camelCase for parameters and locals, and suffix Blazor components with `.razor`. Nullable references are enforced; declare optional values with `?` and guard access clearly. Align namespaces with folder structure, and organize using directives with implicit usings left enabled. Run `dotnet format` before submitting changes to auto-apply the repository style.

## Testing Guidelines
A dedicated test project is not yet present; add one next to the solution root as `MortgageCalculator.Tests` via `dotnet new xunit`. Mirror component namespaces with a `.Tests` suffix and name files `{Target}Tests.cs`. Execute the suite with `dotnet test`. For UI behavior, consider `bunit` component tests and cover every mortgage calculation branch prior to merging.

## Commit & Pull Request Guidelines
Existing history uses concise summaries (for example, `Inizializza repository...`). Continue with imperative, English commit subjects under 72 characters and isolate logical changes per commit. Pull requests must include a clear overview, testing notes (`dotnet test`, manual browser steps), screenshots for visual updates, and references to related issues or tickets. Request at least one review before merging into main.