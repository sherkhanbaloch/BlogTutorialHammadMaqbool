using BlogTutorialHammadMaqbool.Data;
using BlogTutorialHammadMaqbool.Models;
using BlogTutorialHammadMaqbool.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

        public IActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfile(ProfileVM profileVM)
        {
            if (ModelState.IsValid)
            {
                string ImageName = profileVM.Image.FileName.ToString();
                string FolderPath = Path.Combine(evn.WebRootPath, "images");
                string CompletePath = Path.Combine(FolderPath, ImageName);
                profileVM.Image.CopyTo(new FileStream(CompletePath, FileMode.Create));

                Profile profile = new Profile();
                profile.Name = profileVM.Name;
                profile.FatherName = profileVM.FatherName;
                profile.Bio = profileVM.Bio;
                profile.Image = ImageName;
                profile.UserName = profileVM.UserName;
                profile.Password = profileVM.Password;

                db.Tbl_Profile.Add(profile);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var result = db.Tbl_Profile.Where(x => x.UserName.Equals(login.UserName) && x.Password.Equals(login.Password)).FirstOrDefault();

                if (result != null)
                {
                    return RedirectToAction("Index", "Admin");
                }

                ViewData["LoginMessage"] = "Invalid User Name or Password.";
            }
            return View();
        }
    }
}
