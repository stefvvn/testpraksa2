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
    public class AccountUserInfoEntitiesController : Controller
    {
        private readonly FacebookUIMVCContext _context;

        public AccountUserInfoEntitiesController(FacebookUIMVCContext context)
        {
            _context = context;
        }

        // GET: AccountUserInfoEntities
        public async Task<IActionResult> Index()
        {
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            return View(user.GetUserList());
        }

        // GET: AccountUserInfoEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            return View(user.GetUserByID(id.Value));
        }

        // GET: AccountUserInfoEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountUserInfoEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserIdNumber,UserName,FirstName,LastName,EmailAddress,City,Gender,DateOfBirth,ProfileDescription,DateMade")] AccountUserInfoEntities accountUserInfoEntities)
        {
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            return View(user.InsertUser(accountUserInfoEntities));

            //if (ModelState.IsValid)
            //{
            //    _context.Add(accountUserInfoEntities);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(accountUserInfoEntities);
        }

        // GET: AccountUserInfoEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            return View(user.GetUserByID(id.Value));
        }

        // POST: AccountUserInfoEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserIdNumber,UserName,FirstName,LastName,EmailAddress,City,Gender,DateOfBirth,ProfileDescription,DateMade")] AccountUserInfoEntities accountUserInfoEntities)
        {
            if (id != accountUserInfoEntities.UserIdNumber)
            {
                return NotFound();
            }
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            return View(user.UpdateUserAccountInfo(accountUserInfoEntities));

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(accountUserInfoEntities);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!AccountUserInfoEntitiesExists(accountUserInfoEntities.UserIdNumber))
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
            //return View(accountUserInfoEntities);
        }

        // GET: AccountUserInfoEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            return View(user.GetUserByID(id.Value));

            //var accountUserInfoEntities = await _context.AccountUserInfoEntities
            //    .FirstOrDefaultAsync(m => m.UserIdNumber == id);
            //if (accountUserInfoEntities == null)
            //{
            //    return NotFound();
            //}
            //return View(accountUserInfoEntities);
        }

        // POST: AccountUserInfoEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            View(user.DeleteUserByID(id.Value));
            return RedirectToAction(nameof(Index));

            //var accountUserInfoEntities = await _context.AccountUserInfoEntities.FindAsync(id);
            //_context.AccountUserInfoEntities.Remove(accountUserInfoEntities);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool AccountUserInfoEntitiesExists(int id)
        {
            return _context.AccountUserInfoEntities.Any(e => e.UserIdNumber == id);
        }
    }
}
