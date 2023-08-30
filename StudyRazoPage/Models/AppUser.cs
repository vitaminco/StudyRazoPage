using Microsoft.EntityFrameworkCore;
using StudyRazoPage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace StudyRazoPage.Models
{
    //làm cho giá trị đc nập vào ko trùng nhau
    [Index("Username", IsUnique = true)]
    [Index("Email", IsUnique = true)]
    public class AppUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")] //bên dưới nó sẽ đc cấu hình not null
        [MaxLength(100)] // độ dài của kí tự
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [MaxLength(200)]
        public string Password { get; set; }
        [NotMapped]//ko tạo cột cfmPassword vào trong bảng database
        [Compare("Password",ErrorMessage = "Mật khẩu không khớp")]

        public string Cfm_Password { get; set; }
        public UserRole Role { get; set; } //phan quyen; int ko ? là nó đã not null ròi
        [MaxLength(20)]
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        public string Phone { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string Address { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Email là bắt buộc")]
        public string Email { get; set; }
        public DateTime? BlockedTo { get; set; }
        //? là ko cần not null
    }
}
