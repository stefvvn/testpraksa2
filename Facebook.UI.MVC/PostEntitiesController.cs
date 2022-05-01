﻿#nullable disable
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
            AccountUserInfoBsn userbsn = new AccountUserInfoBsn();
            List<AccountUserInfoEntities> users = userbsn.GetUserList();

            PostBsn postbsn = new PostBsn();
            List<PostEntities> posts = postbsn.GetPostList();

            var joinedModels = (from p in posts
                                join u in users on p.UserId equals u.UserIdNumber
                                select new FeedModel()
                                {
                                    PostId = p.PostId,
                                    UserId = u.UserIdNumber,
                                    Content = p.Content,
                                    DateMade = p.DateMade,
                                    Title = p.Title,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName
                                }).ToList();

            return View(joinedModels);    

            //return View(posts);
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
        [ValidateAntiForgeryToken]
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
