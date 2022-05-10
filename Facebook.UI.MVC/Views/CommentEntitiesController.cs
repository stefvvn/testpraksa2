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
            return View(await _context.CommentEntities.ToListAsync());
        }

        // GET: CommentEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentEntities = await _context.CommentEntities
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (commentEntities == null)
            {
                return NotFound();
            }

            return View(commentEntities);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,PostId,UserId,Content,DateMade")] CommentEntities commentEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commentEntities);
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
            if (id != commentEntities.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentEntitiesExists(commentEntities.CommentId))
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
            return View(commentEntities);
        }

        // GET: CommentEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentEntities = await _context.CommentEntities
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (commentEntities == null)
            {
                return NotFound();
            }

            return View(commentEntities);
        }

        // POST: CommentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentEntities = await _context.CommentEntities.FindAsync(id);
            _context.CommentEntities.Remove(commentEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentEntitiesExists(int id)
        {
            return _context.CommentEntities.Any(e => e.CommentId == id);
        }
    }
}
