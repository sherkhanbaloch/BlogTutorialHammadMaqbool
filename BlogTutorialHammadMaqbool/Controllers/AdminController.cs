using BlogTutorialHammadMaqbool.Data;
using BlogTutorialHammadMaqbool.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogTutorialHammadMaqbool.Controllers
{
    public class AdminController : Controller
    {
        AppDbContext db;

        public AdminController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Post myPost)
        {
            db.Tbl_Post.Add(myPost);
            db.SaveChanges();
            return View();
        }
    }
}
