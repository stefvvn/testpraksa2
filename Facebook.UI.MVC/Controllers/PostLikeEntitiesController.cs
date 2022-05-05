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


namespace Facebook.UI.MVC.Controllers
{
    public class PostLikeEntitiesController : Controller
    {
        private readonly FacebookUIMVCContext _context;

        public PostLikeEntitiesController(FacebookUIMVCContext context)
        {
            _context = context;
        }

        // GET: PostLikeEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostLikeEntities.ToListAsync());
        }

        // GET: PostLikeEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postLikeEntities = await _context.PostLikeEntities
                .FirstOrDefaultAsync(m => m.PostLikeId == id);
            if (postLikeEntities == null)
            {
                return NotFound();
            }

            return View(postLikeEntities);
        }

        // GET: PostLikeEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostLikeEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("PostLikeId,PostId,UserId,PostLikeStatus")] PostLikeEntities postLikeEntities)
        {
            PostLikesBsn postlike = new PostLikesBsn();
            return View(postlike.InsertPostLike(postLikeEntities));
        }

        // GET: PostLikeEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postLikeEntities = await _context.PostLikeEntities.FindAsync(id);
            if (postLikeEntities == null)
            {
                return NotFound();
            }
            return View(postLikeEntities);
        }

        // POST: PostLikeEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostLikeId,PostId,UserId,PostLikeStatus")] PostLikeEntities postLikeEntities)
        {
            if (id != postLikeEntities.PostLikeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postLikeEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostLikeEntitiesExists(postLikeEntities.PostLikeId))
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
            return View(postLikeEntities);
        }

        // GET: PostLikeEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postLikeEntities = await _context.PostLikeEntities
                .FirstOrDefaultAsync(m => m.PostLikeId == id);
            if (postLikeEntities == null)
            {
                return NotFound();
            }

            return View(postLikeEntities);
        }

        // POST: PostLikeEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postLikeEntities = await _context.PostLikeEntities.FindAsync(id);
            _context.PostLikeEntities.Remove(postLikeEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostLikeEntitiesExists(int id)
        {
            return _context.PostLikeEntities.Any(e => e.PostLikeId == id);
        }
    }
}
