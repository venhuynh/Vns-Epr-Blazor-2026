# 🐳 Self-Hosted GitHub Runner — Hướng Dẫn Sử Dụng

## Yêu cầu
- Docker Desktop đang chạy trên PC

## 🚀 Khởi động Runner

```powershell
cd c:\Users\Admin\source\Workspaces\2026\Vns-Epr-Blazor-2026
docker compose -f docker-compose.runner.yml build
docker compose -f docker-compose.runner.yml up -d
```

> **Lần đầu** build mất ~5-10 phút (tải .NET 10 SDK + GitHub Runner).
> **Các lần sau** chỉ mất vài giây nhờ Docker cache.

## 🔍 Kiểm tra trạng thái

```powershell
# Container đang chạy?
docker ps

# Xem logs realtime
docker logs vns-erp-runner -f

# Kiểm tra trên GitHub
# https://github.com/venhuynh/Vns-Epr-Blazor-2026/settings/actions/runners
```

## 🛑 Dừng Runner

```powershell
docker compose -f docker-compose.runner.yml down
```

## 🔄 Cập nhật Runner Token

Token hết hạn sau 1 giờ. Nếu cần đăng ký lại:

1. Lấy token mới tại: https://github.com/venhuynh/Vns-Epr-Blazor-2026/settings/actions/runners/new
2. Sửa file `.github/runner/.env`:
   ```
   RUNNER_TOKEN=<token_moi>
   ```
3. Chạy lại:
   ```powershell
   docker compose -f docker-compose.runner.yml down
   docker compose -f docker-compose.runner.yml up -d
   ```

## 🗑️ Xóa hoàn toàn

```powershell
docker compose -f docker-compose.runner.yml down -v
docker rmi vns-epr-blazor-2026-github-runner
```

## 📁 Cấu trúc files

| File | Vai trò |
|------|---------|
| `docker-compose.runner.yml` | Quản lý container |
| `.github/runner/Dockerfile.runner` | Image definition (Ubuntu + .NET 10) |
| `.github/runner/start.sh` | Entrypoint (register + run + cleanup) |
| `.github/runner/.env` | Secrets (token, NuGet key) — **không commit!** |
