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
            List<PostEntities> posts = postbsn.GetPostList();

            AccountUserInfoBsn userbsn = new AccountUserInfoBsn();
            List<AccountUserInfoEntities> users = userbsn.GetUserList();

            PostLikesBsn likesbsn = new PostLikesBsn();
            List<PostLikeEntities> likes = likesbsn.GetPostLikesByUserId(loggedInUser);

            //PostLikesBsn postlikesbsn = new PostLikesBsn();
            //List<PostLikeEntities> postlikes = postlikesbsn.GetPostLikes();

            var joinedModels = (
                from post in posts
                let user = users.Where(x => x.UserIdNumber == post.UserId).FirstOrDefault()
                let like = likes.Where(y => y.UserId == loggedInUser).FirstOrDefault()
                where user != null
                orderby post.PostId descending
                select new FeedModel()
                {
                    PostId = post.PostId,
                    Content = post.Content,
                    DateMade = post.DateMade,
                    Title = post.Title,
                    UserId = user.UserIdNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PostLikeId = like.PostLikeId,
                    PostLikeStatus = like.PostLikeStatus
                }).ToList();


            //var joinedModels = (from post in posts
            //                    join user in users on post.UserId equals user.UserIdNumber
            //                    join like in likes on loggedInUser equals like.UserId where post.UserId == like.UserId
            //                    orderby post.PostId descending
            //                    select new FeedModel()
            //                    {
            //                        PostId = post.PostId,
            //                        Content = post.Content,
            //                        DateMade = post.DateMade,
            //                        Title = post.Title,
            //                        UserId = user.UserIdNumber,
            //                        FirstName = user.FirstName,
            //                        LastName = user.LastName,
            //                        PostLikeId = like.PostLikeId,
            //                        PostLikeStatus = like.PostLikeStatus
            //                    }).ToList();

            foreach (var entity in joinedModels)
            {
                Console.WriteLine("PostId:  " + entity.PostId.ToString());
                Console.WriteLine("PostLikeId:  " + entity.PostLikeId.ToString());
                Console.WriteLine("PostLikeStatus:  " + entity.PostLikeStatus.ToString());
                Console.WriteLine();
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
        public async Task<IActionResult> Create([Bind("PostId,UserId,Content,DateMade,Title")] PostEntities postEntities)
        {
            PostBsn post = new PostBsn();
            return View(post.InsertPost(postEntities));
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public IActionResult CreatePost(int UserID, string Title, string Content)
        {
            PostEntities post = new PostEntities();
            PostBsn postbsn = new PostBsn();

            post.UserId = UserID;
            post.Title = Title;
            post.Content = Content;

            return View(postbsn.InsertPost(post));
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
