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
            PostBsn post = new PostBsn();
            return View(post.GetPostList());
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,UserId,Content,DateMade,Title")] PostEntities postEntities)
        {
            PostBsn post = new PostBsn();
            return View(post.InsertPost(postEntities));

            //if (ModelState.IsValid)
            //{
            //    _context.Add(postEntities);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(postEntities);
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

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(postEntities);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!PostEntitiesExists(postEntities.PostId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(postEntities);
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

            //var postEntities = await _context.PostEntities
            //    .FirstOrDefaultAsync(m => m.PostId == id);
            //if (postEntities == null)
            //{
            //    return NotFound();
            //}
            //return View(postEntities);

        }

        // POST: PostEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            PostBsn post = new PostBsn();
            View(post.DeletePostByID(id.Value));
            return RedirectToAction(nameof(Index));

            //var postEntities = await _context.PostEntities.FindAsync(id);
            //_context.PostEntities.Remove(postEntities);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

        }

        private bool PostEntitiesExists(int id)
        {
            return _context.PostEntities.Any(e => e.PostId == id);
        }
    }
}
