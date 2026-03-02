@echo off
echo ==========================================
echo   VNS ERP Blazor — Database Migration
echo ==========================================
echo.

REM 1. Start PostgreSQL container if stopped
echo [1/4] Starting PostgreSQL...
docker start vnserp-db 2>nul || docker start vns-postgres 2>nul
timeout /t 3 /nobreak >nul

REM 2. Create initial migration (skip if already exists)
echo [2/4] Creating migration...
cd /d c:\Users\Admin\source\Workspaces\2026\Vns-Epr-Blazor-2026
dotnet ef migrations add InitialIdentity --project Vns-Epr-Blazor-2026\Vns-Epr-Blazor-2026.Web\Vns-Epr-Blazor-2026.Web.csproj --context ApplicationDbContext

REM 3. Apply migration to database
echo [3/4] Applying migration...
dotnet ef database update --project Vns-Epr-Blazor-2026\Vns-Epr-Blazor-2026.Web\Vns-Epr-Blazor-2026.Web.csproj --context ApplicationDbContext

REM 4. Done
echo.
echo [4/4] Done!
echo ==========================================
echo   Database: VnsErpBlazor2026
echo   Host: localhost:5432
echo   User: vnsuser
echo ==========================================
pause
