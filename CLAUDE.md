# PCBuilder: project rules

Global coding standards (C#, TypeScript, access to secrets) live in the user's global CLAUDE.md and always apply. This file adds only project-specific rules.

## Stack and layout

- Backend (.NET 10): `Domain` (entities, constants, repository interfaces) ← `Application` (services, DTOs, AutoMapper, compatibility rules) ← `Infrastructure` (EF Core 10 / SQL Server, repositories, migrations, `Seed/seed.sql`) ← `WebAPI` (controllers, `Program.cs`, `ExceptionHandling`, `Security`).
- Frontend: `WebUI` (Angular 22, NgModules, TypeScript 6, ng-bootstrap, ngx-toastr, Node 24).
- Local task notes live in `.tasks/` (git-ignored). Check there before starting a staged task.

## Commands

- Backend build: `dotnet build WebAPI/API.csproj` (if DLLs are locked by a running API/VS, add `-o <scratch dir>`).
- Frontend (in `WebUI`): `npx ng build` (prod and `--configuration development`), `npx tsc -p tsconfig.spec.json --noEmit`.
- Migrations: create only (`dotnet ef migrations add <Name> --project Infrastructure --startup-project WebAPI`). The user runs `database update` and `seed.sql`.
- Never run the application (`dotnet run`, `ng serve`, `ng test`).

## Backend rules

- Flow: Controller → Service → Repository. Persist through `ISaveData.Save()`; map with AutoMapper; controllers hold no business logic.
- Errors: throw `NotFoundException` / `ForbiddenException` (or the compatibility exception); `GlobalExceptionHandler` turns them into ProblemDetails. Do not return ad-hoc error objects.
- Authorization is deny-by-default (`FallbackPolicy` requires an authenticated user). Use `Policies.AdminOrAbove` / `Policies.HeadAdminOnly` and `Roles` constants; `[AllowAnonymous]` only when explicitly required. Ownership checks use `ICurrentUser` (users touch only their own computers; Admin+ may touch any).
- Components (CPU, GPU, RAM, ...) are managed by Admin+; regular users build computers from them via the `ComputerController` configurator endpoints.
- Compatibility of a computer build is enforced server-side in one place: `Application/Service/Compatibility` (`ComputerCompatibilityValidator`, `CompatibilityRules`, `CompatibilityRuleNames`). Put new rules there, not in services, repositories or the frontend. Units: power in W, GPU length and case dimensions in mm.
- DTOs carry DataAnnotations validation. Soft delete (`IsDeleted`) is applied through query filters; dates are UTC.
- DELETE routes have the form `delete/{id}`. When a route changes, update the matching `WebUI/src/app/core/service/*.service.ts` in the same change.
- `PowerSupply.standard` holds the PSU form factor (`CaseSize` names, SFX maps to ITX); the efficiency class belongs in the description.

## Database and seed

- `Infrastructure/Seed/seed.sql` must stay in sync with the schema (migration snapshot) and every seeded computer must pass the compatibility rules. Update it whenever columns or semantics change, and check column names statically against the snapshot.

## Frontend rules

- NgModules with `standalone: false` and `changeDetection: Eager` (do not convert to standalone/OnPush unless asked). Constructor injection in classes; `inject()` only in functional guards/interceptors/initializers.
- Session state lives in `AuthStore` (signals), initialized at startup; route access through `authGuard` / `adminGuard` / `guestGuard`; 401/403 handled by `errorInterceptor`. Frontend access rules are UX only, the backend is authoritative.
- API calls use relative URLs (`/api/`, dev proxy in `proxy.conf.json`) so the session cookie works without CORS or `withCredentials`.
- Navigate with `routerLink` / `Router`, never `href` to internal routes. No `console.*` and no `document.cookie` access in application code.
- Show server errors with `getProblemMessage` (`shared/utils/problem-details.ts`). Compatibility rules are not duplicated on the frontend beyond UX hints.
- Templates: no function calls in `{{ }}` except reading signals.

## Workflow

- Work on the current branch; commit or push only when asked.
- Do not edit or read `appsettings*.json`, `.env*`, `secrets*.json`; ask the user for configuration values (connection string key: `ConnectionStrings:PCBuilder`).
- Report what could not be verified (running the app is off limits), and give the user manual test steps instead.
