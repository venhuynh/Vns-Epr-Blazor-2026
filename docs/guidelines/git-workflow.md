# Git Workflow — VNS ERP 2026

## Branching Strategy: GitHub Flow

Dự án sử dụng **GitHub Flow** — đơn giản, hiệu quả cho team nhỏ-trung.

```
main ─────────────────────────────────────────────►
       \                        /
        └── feature/login ─────┘  (PR + merge)
              \              /
               └── bugfix ──┘
```

### Quy tắc

1. **`main`** luôn ở trạng thái deployable
2. Tạo **feature branch** từ `main` cho mọi thay đổi
3. Commit thường xuyên, push lên remote
4. Tạo **Pull Request** khi sẵn sàng merge
5. Merge vào `main` sau khi review

## Branch Naming

```
feature/[module]-[short-description]
bugfix/[issue-number]-[short-description]
hotfix/[critical-issue]
docs/[what-changed]
refactor/[what-changed]
```

**Ví dụ:**
```
feature/inventory-stock-in-out
bugfix/123-null-reference-audit
hotfix/login-crash
docs/update-setup-guide
refactor/extract-base-service
```

## Commit Message Convention

Sử dụng [Conventional Commits](https://www.conventionalcommits.org/):

```
<type>(<scope>): <description>

[optional body]

[optional footer]
```

### Types

| Type | Mô tả |
|------|--------|
| `feat` | Tính năng mới |
| `fix` | Sửa lỗi |
| `docs` | Thay đổi tài liệu |
| `style` | Format code (không thay đổi logic) |
| `refactor` | Cải thiện code (không thêm feature/fix bug) |
| `test` | Thêm/sửa tests |
| `chore` | Cập nhật build, configs, dependencies |

### Ví dụ

```
feat(inventory): add stock-in voucher generation
fix(audit): resolve NullReferenceException on batch save
docs(setup): update DevExpress NuGet configuration steps
refactor(shared): extract base CRUD service
chore: update DevExpress to 25.2.3
```

## Pull Request Guidelines

1. **Title**: Dùng conventional commit format
2. **Description**: Điền đầy đủ PR template
3. **Size**: Giữ PR nhỏ (<400 lines changed)
4. **Review**: Ít nhất 1 reviewer approve
5. **CI**: Build phải pass trước khi merge
6. **Merge**: Dùng **Squash and merge** cho feature branches

## Workflow Example

```bash
# 1. Cập nhật main
git checkout main
git pull origin main

# 2. Tạo feature branch
git checkout -b feature/inventory-stock-in

# 3. Làm việc, commit thường xuyên
git add .
git commit -m "feat(inventory): add StockIn model and service"

# 4. Push và tạo PR
git push -u origin feature/inventory-stock-in
# → Tạo PR trên GitHub

# 5. Sau khi merge, cleanup
git checkout main
git pull origin main
git branch -d feature/inventory-stock-in
```
