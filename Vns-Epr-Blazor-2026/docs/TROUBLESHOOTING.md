# Hướng dẫn Xử lý Lỗi Kết nối PostgreSQL

Tài liệu này ghi lại các vấn đề thường gặp khi thiết lập môi trường database PostgreSQL và cách khắc phục.

## 1. Lỗi Xác thực Passowrd (28P01: password authentication failed)

### Nguyên nhân
- **Xung đột Port 5432:** Máy tính đang chạy PostgreSQL cài trực tiếp (local service) chiếm cổng 5432. Khi ứng dụng kết nối tới `localhost:5432`, nó đâm vào bản local thay vì bản Docker.
- **Volume Docker cũ:** Volume của Docker đã được khởi tạo với password cũ từ trước, không khớp với `appsettings.json`.
- **Ký tự đặc biệt trong Password:** Ký tự `!` hoặc `@` trong password không được đặt trong dấu ngoặc kép trong `docker-compose.yml` dẫn đến sai cấu trúc YAML.

### Cách khắc phục

#### Bước A: Tắt PostgreSQL Local (Windows)
Chạy PowerShell với quyền Administrator:
```powershell
# Dừng service PostgreSQL local
Get-Service -Name *postgres* | Stop-Service -Force -Verbose

# Chỉnh sang Manual để không tự bật khi reset máy
Get-Service -Name *postgres* | Set-Service -StartupType Manual
```

#### Bước B: Reset Docker Container và Volume
Chạy lệnh sau tại thư mục gốc của dự án:
```bash
# Xóa container và quét sạch data/volume cũ
docker compose down -v

# Khởi động lại
docker compose up -d
```

#### Bước C: Kiểm tra kết nối
```bash
docker exec vns-erp-postgres psql -U vns_erp -d VnsErpBlazor -c "SELECT 1;"
```

---

## 2. Lỗi Thiếu bảng (Table not found / Entity framework exception)

### Nguyên nhân
- Sau khi reset volume database rỗng, cấu trúc bảng chưa được tạo lại.

### Cách khắc phục
Chạy migration để cập nhật cấu trúc database:
```bash
dotnet ef database update --project Vns.Erp.Infrastructure --startup-project Vns-Epr-Blazor-2026
```

---

## 3. Cấu hình chuẩn (Best Practices)

- Luôn bao bọc password trong dấu ngoặc kép trong `docker-compose.yml`:
  ```yaml
  POSTGRES_PASSWORD: "VnsErp@2026!"
  ```
- Kiểm tra cổng 5432 có bị chiếm không:
  ```powershell
  Get-NetTCPConnection -LocalPort 5432 -ErrorAction SilentlyContinue
  ```
