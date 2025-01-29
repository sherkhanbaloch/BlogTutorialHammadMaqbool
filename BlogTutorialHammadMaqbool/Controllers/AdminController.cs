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

        public IActionResult AllPosts()
        {
            var allPosts = db.Tbl_Post;
            return View(allPosts);
        }

        public IActionResult DeletePost(int Id)
        {
            var PostToDelete = db.Tbl_Post.Find(Id);

            if (PostToDelete != null)
            {
                db.Remove(PostToDelete);
                db.SaveChanges();
            }

            return RedirectToAction("AllPosts", "Admin");
        }
    }
}
