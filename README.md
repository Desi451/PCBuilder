# PCBuilder

Aplikacja do składania zestawów komputerowych. Administratorzy utrzymują katalog podzespołów (CPU, GPU, RAM, płyty główne, obudowy, zasilacze, dyski), a użytkownicy konfigurują z nich własne komputery. Serwer sprawdza kompatybilność zestawu i nie zapisuje niezgodnych konfiguracji.

## Stack

- Backend: ASP.NET Core (.NET 10), EF Core 10 (SQL Server), ASP.NET Identity, AutoMapper, Swagger (w trybie Development).
- Frontend: Angular 22 (NgModules), TypeScript 6, Bootstrap 5, ng-bootstrap, ngx-toastr.

## Struktura

| Katalog | Zawartość |
| --- | --- |
| `Domain` | encje, stałe (`Roles`, `Policies`), interfejsy repozytoriów |
| `Application` | serwisy, DTO, mapowania, reguły kompatybilności (`Service/Compatibility`) |
| `Infrastructure` | `AppDbContext`, repozytoria, migracje, `Seed/seed.sql` |
| `WebAPI` | kontrolery, `Program.cs`, obsługa wyjątków, `ICurrentUser` |
| `WebUI` | aplikacja Angular |

## Wymagania

- .NET 10 SDK
- SQL Server (np. LocalDB lub Express)
- Node.js 24 i npm

## Uruchomienie

1. **Konfiguracja.** Ustaw connection string w kluczu `ConnectionStrings:PCBuilder` (np. w `WebAPI/appsettings.Development.json` albo przez `dotnet user-secrets`). Opcjonalnie `Cors:AllowedOrigins` (domyślnie `http://localhost:4200` i `https://localhost:7214`).
2. **Baza.** Z katalogu głównego repozytorium:

   ```bash
   dotnet ef database update --project Infrastructure --startup-project WebAPI
   ```

   Następnie wykonaj `Infrastructure/Seed/seed.sql` (dane testowe: podzespoły i przykładowe zestawy).
3. **Backend.** Uruchom projekt `WebAPI` (profil `https`, `https://localhost:7214`; Swagger pod `/swagger`).
4. **Frontend.**

   ```bash
   cd WebUI
   npm install
   npm start
   ```

   Aplikacja jest dostępna pod `http://localhost:4200`. Zapytania `/api` są kierowane przez proxy (`WebUI/proxy.conf.json`) na `https://localhost:7214`, dzięki czemu przeglądarka widzi jeden origin i ciasteczko sesji działa bez CORS.

## Uwierzytelnianie i role

- Logowanie i rejestracja przez ASP.NET Identity (login lub e-mail, unikalny e-mail), sesja w ciasteczku `PCBuilder.Auth` (HttpOnly, 8 h, wydłużana przy aktywności).
- Role: `User`, `Admin`, `HeadAdmin` (HeadAdmin obejmuje uprawnienia Admin).
- Domyślnie każdy endpoint wymaga zalogowania.

| Obszar | Dostęp |
| --- | --- |
| Własne komputery (podgląd, tworzenie, edycja, usuwanie) | zalogowany użytkownik (cudze komputery: tylko Admin+) |
| Katalog podzespołów, marki, serie, interfejsy | Admin+ |
| Zarządzanie użytkownikami | HeadAdmin |

## Kompatybilność zestawu

Walidacja działa na serwerze (`Application/Service/Compatibility`) i zwraca błąd 400 z pełną listą naruszeń. Reguły:

- gniazdo CPU zgodne z płytą główną,
- obsługiwany typ i prędkość RAM, pojemność w limicie płyty i procesora, liczba modułów w limicie slotów,
- format płyty i zasilacza mieści się w obudowie,
- długość karty graficznej plus zapas 20 mm mieści się w głębokości obudowy,
- moc zasilacza ≥ (TDP CPU + TDP GPU + 50 W) × 1,25,
- brak karty graficznej dozwolony tylko dla procesora ze zintegrowaną grafiką (APU),
- liczba dysków SATA i M.2 w limicie slotów płyty, bez duplikatów.

## Budowanie i kontrola

```bash
dotnet build WebAPI/API.csproj
cd WebUI
npx ng build
npx tsc -p tsconfig.spec.json --noEmit
```

Jeśli działająca aplikacja blokuje pliki DLL, dodaj do `dotnet build` opcję `-o <katalog tymczasowy>`.

## Reguły pracy nad projektem

Konwencje kodu i architektury opisuje [CLAUDE.md](CLAUDE.md).
