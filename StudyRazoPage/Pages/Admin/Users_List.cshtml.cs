using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyRazoPage.Models;
using X.PagedList;

namespace StudyRazoPage.Pages.Admin
{
    public class Users_ListModel : PageModel
    {
        private readonly RazorPageDbContext _db;
        public IPagedList<AppUser> ListUsers { get; set; }
        public Users_ListModel(RazorPageDbContext db)
        {
            _db = db;
        }
        public void OnGet([FromQuery] int page = 1)
        {
            ListUsers = _db.AppUsers
                .OrderByDescending(x => x.Id).ToList()
                .ToPagedList(page, 3);
        }
    }
}
