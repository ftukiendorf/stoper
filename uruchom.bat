@echo off
cd /d "%~dp0"
if exist "bin\Release\net9.0-windows\Stoper.exe" (
  start "" "bin\Release\net9.0-windows\Stoper.exe"
) else (
  start "" dotnet run --project Stoper.csproj -c Release
)
