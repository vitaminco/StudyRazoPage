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
        public ActionResult OnPost()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }
            //khai báo biến sử lý data
            RazorPageDbContext db = new();

            user.Role = UserRole.ROLECUSTOMER;
            user.BlockedTo = null;

            db.AppUsers.Add(user);
            db.SaveChanges();
            return Page();
        }
    }
}
