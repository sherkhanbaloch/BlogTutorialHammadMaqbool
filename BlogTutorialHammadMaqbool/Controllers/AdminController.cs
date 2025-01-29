using BlogTutorialHammadMaqbool.Data;
using BlogTutorialHammadMaqbool.Models;
using BlogTutorialHammadMaqbool.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BlogTutorialHammadMaqbool.Controllers
{
    public class AdminController : Controller
    {
        AppDbContext db;
        IWebHostEnvironment evn;

        public AdminController(AppDbContext _db, IWebHostEnvironment _evn)
        {
            db = _db;
            evn = _evn;
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
        public IActionResult AddPost(PostVM myPost)
        {
            if (ModelState.IsValid)
            {
                string ImageName = myPost.Image.FileName.ToString();
                var FolderPath = Path.Combine(evn.WebRootPath, "images", ImageName); // webroot/images
                // var CompletePath = Path.Combine(FolderPath, ImageName);  webroot/images/abc.jpg
                myPost.Image.CopyTo(new FileStream(FolderPath, FileMode.Create));

                Post post = new Post();
                post.Title = myPost.Title;
                post.SubTitle = myPost.SubTitle;
                post.Content = myPost.Content;
                post.Date = myPost.Date;
                post.Image = ImageName;
                post.Slug = myPost.Slug;

                db.Tbl_Post.Add(post);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

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

        public IActionResult UpdatePost(int Id)
        {
            var PostToUpdate = db.Tbl_Post.Find(Id);

            return View(PostToUpdate);
        }

        [HttpPost]
        public IActionResult UpdatePost(Post post)
        {
            db.Tbl_Post.Update(post);
            db.SaveChanges();

            return RedirectToAction("AllPosts", "Admin");
        }
    }
}
