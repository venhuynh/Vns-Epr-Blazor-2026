@echo off
echo ==========================================
echo   VNS ERP - GitHub Runner (Docker)
echo ==========================================
echo.

cd /d c:\Users\Admin\source\Workspaces\2026\Vns-Epr-Blazor-2026

echo [1/2] Building image...
docker compose -f docker-compose.runner.yml build

echo.
echo [2/2] Starting runner...
docker compose -f docker-compose.runner.yml up -d

echo.
echo ==========================================
echo   Runner started! Check status:
echo   docker logs vns-erp-runner -f
echo ==========================================
pause
