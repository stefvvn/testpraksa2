#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Facebook.Entities;
using Facebook.UI.MVC.Data;
using Facebook.Business;
using Facebook.Data.EntityFramework;
using Microsoft.AspNetCore.Http;
using Facebook.UI.MVC.Models;


namespace Facebook.UI.MVC
{
    public class PostEntitiesController : Controller
    {
        private readonly FacebookUIMVCContext _context;
        public PostEntitiesController(FacebookUIMVCContext context)
        {
            _context = context;
        }

        // GET: PostEntities
        public async Task<IActionResult> Index() 
        {
            int loggedInUser = Convert.ToInt32(HttpContext.Request.Cookies["userID"]);
            PostBsn postbsn = new PostBsn();
            List<PostEntities> joinedModels = postbsn.GetJoinedPostList(loggedInUser);
            foreach (var entity in joinedModels)
            {
                Console.WriteLine("");
                Console.WriteLine("Name: " + entity.User.FirstName.ToString() + " " + entity.User.LastName.ToString());
                Console.WriteLine("PostId: " + entity.PostId.ToString());
                Console.WriteLine("Likes:  " + entity.PostLikes.Count());
            }

            return View(joinedModels);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> InsertPostLike([Bind("PostLikeId, PostId, UserId, PostLikeStatus")] PostLikeEntities postLikeEntities)
        {
            PostLikesBsn post = new PostLikesBsn();
            return View(post.InsertPostLike(postLikeEntities));
        }

        public IActionResult InsertPostLike()
        {
            return View();
        }



        // GET: PostEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PostBsn post = new PostBsn();
            return View(post.GetPostByID(id.Value));
        }

        // GET: PostEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,UserId,Content,DateMade,Title,ImgPath")] PostEntities postEntities)
        {
            PostBsn post = new PostBsn();
            return View(post.InsertPost(postEntities));
        }

        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //[IgnoreAntiforgeryToken]
        //public IActionResult Upload(IFormFile file)
        //{
        //    var fileName = Path.GetFileName(file.FileName);
        //    var uniqueFileName = Convert.ToString(Guid.NewGuid());
        //    var fileExtension = Path.GetExtension(fileName);
        //    //var newFileName = String.Concat(uniqueFileName, fileExtension);
        //    var newFileName = String.Concat(fileName);

        //    var filepath = (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "img")) + $@"\{newFileName}";
        //    using (FileStream fs = System.IO.File.Create(filepath))
        //    {
        //        file.CopyTo(fs);
        //        fs.Flush();
        //    }

        //    return View();
        //}


        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateComment(int UserID, int PostID, string CommentContent, string ImgPath, IFormFile file)
        {
            CommentEntities comment = new CommentEntities();
            CommentBsn commentBsn = new CommentBsn();

            var fileName = Path.GetFileName(file.FileName);
            var uniqueFileName = Convert.ToString(Guid.NewGuid());
            var fileExtension = Path.GetExtension(fileName);
            var newFileName = String.Concat(uniqueFileName, fileExtension);

            comment.UserId = Convert.ToInt32(HttpContext.Request.Cookies["userID"]);
            comment.PostId = 4;
            comment.Content = CommentContent;
            comment.ImgPath = newFileName;
            commentBsn.InsertComment(comment);

            ///////////     LAST ID

            var filepath = (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "img")) + $@"\{newFileName}";
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return Redirect("https://localhost:7029/PostEntities");
        }



        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public IActionResult CreatePost(int UserID, string Title, string PostContent, string ImgPath, IFormFile file)
        {
            PostEntities post = new PostEntities();
            PostBsn postbsn = new PostBsn();

            var fileName = Path.GetFileName(file.FileName);
            var uniqueFileName = Convert.ToString(Guid.NewGuid());
            var fileExtension = Path.GetExtension(fileName);
            var newFileName = String.Concat(uniqueFileName, fileExtension);

            post.UserId = Convert.ToInt32(HttpContext.Request.Cookies["userID"]);
            post.Title = Title;
            post.Content = PostContent;
            post.ImgPath = newFileName;
            postbsn.InsertPost(post);

            ///////////     LAST ID

            var filepath = (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "img")) + $@"\{newFileName}";
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }






            return Redirect("https://localhost:7029/PostEntities");
        }

        // GET: PostEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PostBsn post = new PostBsn();
            return View(post.GetPostByID(id.Value));
        }

        // POST: PostEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,UserId,Content,DateMade,Title")] PostEntities postEntities)
        {
            if (id != postEntities.PostId)
            {
                return NotFound();
            }
            PostBsn post = new PostBsn();
            return View(post.UpdatePost(postEntities));
        }

        // GET: PostEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PostBsn post = new PostBsn();
            return View(post.GetPostByID(id.Value));

        }

        // POST: PostEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            PostBsn post = new PostBsn();
            View(post.DeletePostByID(id.Value));
            return RedirectToAction(nameof(Index));
        }

        private bool PostEntitiesExists(int id)
        {
            return _context.PostEntities.Any(e => e.PostId == id);
        }
    }
}
