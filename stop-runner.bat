@echo off
echo Stopping runner...
cd /d c:\Users\Admin\source\Workspaces\2026\Vns-Epr-Blazor-2026
docker compose -f docker-compose.runner.yml down
echo Runner stopped.
pause
