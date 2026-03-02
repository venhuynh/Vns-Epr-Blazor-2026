using Microsoft.AspNetCore.Identity;

namespace Vns_Epr_Blazor_2026.Web.Data;

/// <summary>
/// Application user — tương tự ApplicationUser trong XAF.
/// Kế thừa IdentityUser thay vì PermissionPolicyUser.
/// </summary>
public class ApplicationUser : IdentityUser
{
    /// <summary>Họ tên đầy đủ</summary>
    public string? FullName { get; set; }

    /// <summary>Ảnh đại diện</summary>
    public string? AvatarUrl { get; set; }

    /// <summary>Buộc đổi mật khẩu lần đầu đăng nhập (ref XAF ChangePasswordOnFirstLogon)</summary>
    public bool ChangePasswordOnFirstLogon { get; set; }

    /// <summary>Liên kết nhân viên (triển khai sau)</summary>
    public Guid? EmployeeId { get; set; }

    /// <summary>Ngày tạo</summary>
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    /// <summary>Ngày sửa đổi cuối</summary>
    public DateTime? ModifiedDate { get; set; }
}
