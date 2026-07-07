# 🍽️ Restaurant Project — Hướng Dẫn Cài Đặt

Dự án backend API cho hệ thống quản lý nhà hàng, xây dựng theo kiến trúc **Clean Architecture** với **.NET 10**, sử dụng **PostgreSQL** làm cơ sở dữ liệu.

---

## 📋 Yêu Cầu Hệ Thống

Trước khi bắt đầu, hãy đảm bảo máy bạn đã cài đặt:

| Công cụ | Phiên bản tối thiểu | Link tải |
|---|---|---|
| .NET SDK | 10.0+ | https://dotnet.microsoft.com/download |
| PostgreSQL | 14+ | https://www.postgresql.org/download |
| Git | bất kỳ | https://git-scm.com |

---

## 🚀 Các Bước Cài Đặt

### Bước 1 — Clone Dự Án

```bash
git clone <repository-url>
cd RestaurantProject0008
```

---

### Bước 2 — Cấu Hình File `.env`

> ⚠️ **Quan trọng:** Phải điền đầy đủ file `.env` trước khi chạy migration hoặc khởi động ứng dụng.

Copy file mẫu và chỉnh sửa:

```bash
# Windows (PowerShell)
Copy-Item .env.example .env

# Hoặc Linux/macOS
cp .env.example .env
```

Mở file `.env` và điền các giá trị sau:

```env
NODE_ENV=Development

# ─── Cloudinary (lưu trữ hình ảnh) ─────────────────────────────────────────
# Đăng ký tài khoản miễn phí tại: https://cloudinary.com
CLOUDINARY__CLOUDNAME=<cloud-name-của-bạn>
CLOUDINARY__APIKEY=<api-key-của-bạn>
CLOUDINARY__APISECRET=<api-secret-của-bạn>
CLOUDINARY__FOLDER=<tên-thư-mục-lưu-ảnh>

# ─── Chuỗi kết nối PostgreSQL ────────────────────────────────────────────────
# Định dạng: Host=localhost;Port=5432;Database=<tên-db>;Username=<user>;Password=<pass>
ConnectionStrings__MyConnectString=Host=localhost;Port=5432;Database=RestaurantDB;Username=postgres;Password=your_password

# ─── JWT Authentication ──────────────────────────────────────────────────────
# Khuyến nghị: chuỗi ngẫu nhiên tối thiểu 32 ký tự
JwtSettings__SecretKey=your-very-secret-key-at-least-32-characters

# ─── Email (Gmail SMTP) ──────────────────────────────────────────────────────
# Hướng dẫn lấy App Password: https://support.google.com/accounts/answer/185833
EmailSettings__SenderEmail=youremail@gmail.com
EmailSettings__AppPassword=your-gmail-app-password

# ─── URL ─────────────────────────────────────────────────────────────────────
WebAPI__BaseUrl=https://localhost:7001
WebClientUrl=http://localhost:3000
```

#### 📌 Ghi chú chi tiết từng mục

<details>
<summary><strong>🔌 ConnectionStrings__MyConnectString</strong></summary>

Định dạng chuỗi kết nối PostgreSQL (Npgsql):

```
Host=localhost;Port=5432;Database=RestaurantDB;Username=postgres;Password=YourPassword123
```

- `Host` — địa chỉ server PostgreSQL (thường là `localhost`)
- `Port` — cổng mặc định là `5432`
- `Database` — tên database sẽ được tạo
- `Username` / `Password` — thông tin đăng nhập PostgreSQL

</details>

<details>
<summary><strong>🔑 JwtSettings__SecretKey</strong></summary>

Đây là khóa bí mật để ký JWT token. Yêu cầu:
- Tối thiểu **32 ký tự**
- Không được chia sẻ công khai

Tạo nhanh bằng PowerShell:
```powershell
[System.Convert]::ToBase64String([System.Security.Cryptography.RandomNumberGenerator]::GetBytes(32))
```

</details>

<details>
<summary><strong>📧 EmailSettings (Gmail App Password)</strong></summary>

1. Bật **2-Step Verification** trên tài khoản Google
2. Truy cập: https://myaccount.google.com/apppasswords
3. Tạo App Password cho ứng dụng "Mail"
4. Điền mật khẩu 16 ký tự vào `EmailSettings__AppPassword`

</details>

<details>
<summary><strong>☁️ Cloudinary</strong></summary>

1. Đăng ký tại https://cloudinary.com (miễn phí)
2. Vào **Dashboard** → sao chép `Cloud Name`, `API Key`, `API Secret`
3. `CLOUDINARY__FOLDER` — tên thư mục lưu ảnh trong Cloudinary (ví dụ: `restaurant-images`)

</details>

---

### Bước 3 — Tạo Database PostgreSQL

Mở **psql** hoặc **pgAdmin**, chạy lệnh tạo database:

```sql
CREATE DATABASE "RestaurantDB";
```

> **Lưu ý:** Tên database phải khớp với giá trị `Database=` trong `ConnectionStrings__MyConnectString`.

---

### Bước 4 — Cài Đặt EF Core Tools

Nếu chưa cài đặt **dotnet-ef**, chạy lệnh sau:

```bash
dotnet tool install --global dotnet-ef
```

Kiểm tra đã cài thành công:

```bash
dotnet ef --version
```

---

### Bước 5 — Chạy Migration (Tạo Schema Database)

Điều hướng đến thư mục API và chạy lệnh update database:

```bash
# Từ thư mục gốc của dự án
dotnet ef database update \
  --project src/External/Restaurant.Persistence \
  --startup-project src/Restaurant.API
```

**Hoặc dùng Package Manager Console** (trong Visual Studio):

```powershell
# Đặt Default project là: Restaurant.Persistence
Update-Database -StartupProject Restaurant.API
```

> ✅ Nếu thành công, EF Core sẽ tạo toàn bộ bảng trong database theo các file trong thư mục `Migrations/`.

---

### Bước 6 — Chạy Ứng Dụng

```bash
cd src/Restaurant.API
dotnet run
```

Ứng dụng sẽ khởi động và Swagger UI có thể truy cập tại:

```
https://localhost:7001/swagger
```

---

## 🏗️ Cấu Trúc Dự Án

```
RestaurantProject0008/
├── src/
│   ├── Core/
│   │   ├── Restaurant.Domain/          # Entities, Enums, Domain Events
│   │   └── Restaurant.Application/     # Use Cases, DTOs, Interfaces
│   ├── External/
│   │   ├── Restaurant.Persistence/     # EF Core, DbContext, Repositories, Migrations
│   │   └── Restaurant.Infrastructure/  # Email, Cloudinary, External Services
│   └── Restaurant.API/                 # Controllers, Program.cs, Middleware
├── .env.example                        # Mẫu file cấu hình
├── .env                                # ⚠️ File cấu hình thực (KHÔNG commit lên Git)
└── RestaurantProject0008.slnx
```

---

## 🛠️ Các Lệnh Migration Thường Dùng

```bash
# Tạo migration mới
dotnet ef migrations add <TenMigration> \
  --project src/External/Restaurant.Persistence \
  --startup-project src/Restaurant.API

# Áp dụng migration vào database
dotnet ef database update \
  --project src/External/Restaurant.Persistence \
  --startup-project src/Restaurant.API

# Xem danh sách migrations
dotnet ef migrations list \
  --project src/External/Restaurant.Persistence \
  --startup-project src/Restaurant.API

# Rollback về migration trước
dotnet ef database update <TenMigrationTruoc> \
  --project src/External/Restaurant.Persistence \
  --startup-project src/Restaurant.API

# Xóa migration cuối (chưa apply)
dotnet ef migrations remove \
  --project src/External/Restaurant.Persistence \
  --startup-project src/Restaurant.API
```

---

## ❓ Xử Lý Lỗi Thường Gặp

| Lỗi | Nguyên nhân | Cách xử lý |
|---|---|---|
| `Connection refused` | PostgreSQL chưa chạy | Khởi động dịch vụ PostgreSQL |
| `password authentication failed` | Sai username/password | Kiểm tra lại `ConnectionStrings` trong `.env` |
| `database does not exist` | Chưa tạo database | Chạy lại `CREATE DATABASE` ở Bước 3 |
| `dotnet-ef not found` | Chưa cài EF Tools | Chạy lại lệnh ở Bước 4 |
| `No migrations found` | Sai `--project` path | Kiểm tra lại đường dẫn project |

---

## 🔒 Bảo Mật

- File `.env` đã được thêm vào `.gitignore` — **KHÔNG** commit file này lên repository
- Sử dụng `.env.example` làm template chia sẻ với team
- Không để lộ `JwtSettings__SecretKey` hay `AppPassword` trong mã nguồn
