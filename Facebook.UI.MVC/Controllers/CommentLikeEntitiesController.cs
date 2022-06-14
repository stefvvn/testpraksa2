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

namespace Facebook.UI.MVC.Controllers
{
    public class CommentLikeEntitiesController : Controller
    {
        private readonly FacebookUIMVCContext _context;

        public CommentLikeEntitiesController(FacebookUIMVCContext context)
        {
            _context = context;
        }

        // GET: CommentLikeEntities
        public async Task<IActionResult> Index()
        {
            var facebookUIMVCContext = _context.CommentLikeEntities.Include(c => c.Comment).Include(c => c.User);
            return View(await facebookUIMVCContext.ToListAsync());
        }

        [HttpDelete]
        [IgnoreAntiforgeryToken]
        public IActionResult ToggleCommentLikeDelete(int userId, int commentId)
        {
            CommentLikesBsn like = new CommentLikesBsn();
            like.ToggleCommentLikeDelete(userId, commentId);
            return Redirect("https://localhost:7029/PostEntities");
        }

        // GET: CommentLikeEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CommentLikeEntities == null)
            {
                return NotFound();
            }

            var commentLikeEntities = await _context.CommentLikeEntities
                .Include(c => c.Comment)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentLikeId == id);
            if (commentLikeEntities == null)
            {
                return NotFound();
            }

            return View(commentLikeEntities);
        }

        // GET: CommentLikeEntities/Create
        public IActionResult Create()
        {
            ViewData["CommentId"] = new SelectList(_context.CommentEntities, "CommentId", "Content");
            ViewData["UserId"] = new SelectList(_context.AccountUserInfoEntities, "UserIdNumber", "City");
            return View();
        }

        // POST: CommentLikeEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("CommentLikeId,CommentId,UserId,CommentLikeStatus")] CommentLikeEntities commentLikeEntities)
        {
            CommentLikesBsn commentlike = new CommentLikesBsn();
            return View(commentlike.InsertCommentLike(commentLikeEntities));
        }

        // GET: CommentLikeEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CommentLikeEntities == null)
            {
                return NotFound();
            }

            var commentLikeEntities = await _context.CommentLikeEntities.FindAsync(id);
            if (commentLikeEntities == null)
            {
                return NotFound();
            }
            ViewData["CommentId"] = new SelectList(_context.CommentEntities, "CommentId", "Content", commentLikeEntities.CommentId);
            ViewData["UserId"] = new SelectList(_context.AccountUserInfoEntities, "UserIdNumber", "City", commentLikeEntities.UserId);
            return View(commentLikeEntities);
        }

        // POST: CommentLikeEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentLikeId,CommentId,UserId,CommentLikeStatus")] CommentLikeEntities commentLikeEntities)
        {
            if (id != commentLikeEntities.CommentLikeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentLikeEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentLikeEntitiesExists(commentLikeEntities.CommentLikeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentId"] = new SelectList(_context.CommentEntities, "CommentId", "Content", commentLikeEntities.CommentId);
            ViewData["UserId"] = new SelectList(_context.AccountUserInfoEntities, "UserIdNumber", "City", commentLikeEntities.UserId);
            return View(commentLikeEntities);
        }

        // GET: CommentLikeEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CommentLikeEntities == null)
            {
                return NotFound();
            }

            var commentLikeEntities = await _context.CommentLikeEntities
                .Include(c => c.Comment)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentLikeId == id);
            if (commentLikeEntities == null)
            {
                return NotFound();
            }

            return View(commentLikeEntities);
        }

        // POST: CommentLikeEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CommentLikeEntities == null)
            {
                return Problem("Entity set 'FacebookUIMVCContext.CommentLikeEntities'  is null.");
            }
            var commentLikeEntities = await _context.CommentLikeEntities.FindAsync(id);
            if (commentLikeEntities != null)
            {
                _context.CommentLikeEntities.Remove(commentLikeEntities);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentLikeEntitiesExists(int id)
        {
          return (_context.CommentLikeEntities?.Any(e => e.CommentLikeId == id)).GetValueOrDefault();
        }
    }
}
