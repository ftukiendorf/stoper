STOPER — jak uruchomić aplikację
================================

Wymagania
---------
- System Windows
- .NET 9 (jeśli uruchamiasz ze źródeł). Gotowy plik .exe w folderze publikacji
  nie wymaga osobnego instalowania zestawu SDK, o ile użyjesz wersji samodzielnej
  (patrz niżej).

Sposób 1 — najprostszy (ze źródeł)
----------------------------------
1. Otwórz folder projektu (ten, w którym leży plik Stoper.csproj).
2. W Eksploratorze plików kliknij dwukrotnie plik uruchom.bat
   ALBO w terminalu, będąc w folderze projektu, wpisz:

   dotnet run --project Stoper.csproj

Sposób 2 — gotowy program .exe
------------------------------
Po zbudowaniu projektu plik znajdziesz tutaj:

  bin\Release\net9.0-windows\Stoper.exe

Kliknij dwukrotnie Stoper.exe. Nie korzystaj z wiersza poleceń jako interfejsu
aplikacji — okno graficzne otworzy się samo.

Żeby zbudować wersję Release:

  dotnet build -c Release

Obsługa
-------
- Start  — zeruje czas i uruchamia stoper od nowa.
- Pauza / Wznów — zatrzymuje pomiar albo wznawia go od ostatniego momentu.
- Flaga  — zapisuje aktualny znacznik czasu na liście poniżej.

Tytuł okna: Stoper
Język interfejsu: polski
