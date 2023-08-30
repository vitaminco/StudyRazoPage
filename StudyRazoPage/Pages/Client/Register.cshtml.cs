using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyRazoPage.Common;
using StudyRazoPage.Models;

namespace StudyRazoPage.Pages.Client
{
    public class RegisterModel : PageModel
    {
        //liên kết dữ liệu trên giao diện
        [BindProperty]     
        public AppUser user { get; set; }
        //get hiển thị data
        public void OnGet()
        {

        }
        //post thêm and xóa data (Nhấn nút đk thì nó sẽ chạy vào đây)
        public ActionResult OnPost([FromServices] RazorPageDbContext db)
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }
            //chuẩn hóa username và email 
            user.Username = user.Username.ToLower().Trim();
            user.Email = user.Email.ToLower().Trim();
            //check username và email đã tồn tại chưa
            var exists = db.AppUsers.Any(u => u.Email == user.Email || u.Username == user.Username);
            if(exists)
            {
                ModelState.AddModelError("", "Email hoặc tên đăng nhập đã được sử dụng!");
                return Page();
            }
            //hash mật khẩu
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            //khai báo biến sử lý data

            user.Role = UserRole.ROLECUSTOMER;
            user.BlockedTo = null;

            db.AppUsers.Add(user);
            db.SaveChanges();
            return Page();
        }
    }
}
