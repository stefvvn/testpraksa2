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

namespace Facebook.UI.MVC.Views
{
    public class CommentEntitiesController : Controller
    {
        private readonly FacebookUIMVCContext _context;

        public CommentEntitiesController(FacebookUIMVCContext context)
        {
            _context = context;
        }

        // GET: CommentEntities
        public async Task<IActionResult> Index()
        {
            CommentBsn comment = new CommentBsn();
            return View(comment.GetCommentList());
        }

        // GET: CommentEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            CommentBsn comment = new CommentBsn();
            return View(comment.GetCommentByID(id.Value));
        }

        // GET: CommentEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommentEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,PostId,UserId,Content,DateMade")] CommentEntities commentEntities)
        {
            CommentBsn comment = new CommentBsn();
            return View(comment.InsertComment(commentEntities));
        }

        // GET: CommentEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentEntities = await _context.CommentEntities.FindAsync(id);
            if (commentEntities == null)
            {
                return NotFound();
            }
            return View(commentEntities);
        }

        // POST: CommentEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,PostId,UserId,Content,DateMade")] CommentEntities commentEntities)
        {
            CommentBsn comment = new CommentBsn();
            return View(comment.UpdateComment(commentEntities));
        }

        // GET: CommentEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            CommentBsn comment = new CommentBsn();
            return View(comment.GetCommentByID(id.Value));
        }

        // POST: CommentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            CommentBsn comment = new CommentBsn();
            View(comment.DeleteCommentByID(id.Value));
            return RedirectToAction(nameof(Index));
        }

        private bool CommentEntitiesExists(int id)
        {
            return _context.CommentEntities.Any(e => e.CommentId == id);
        }
    }
}
