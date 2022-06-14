#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("UserIdNumber,UserName,FirstName,LastName,EmailAddress,City,Gender,DateOfBirth,ProfileDescription,DateMade")] AccountUserInfoEntities accountUserInfoEntities)
        {
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            return View(user.InsertUser(accountUserInfoEntities));
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateUser(string UserName, string FirstName, string LastName, string EmailAddress, string City, byte Gender, DateTime DateOfBirth, string ProfileDescription, string ImgPath, IFormFile file)
        {
            AccountUserInfoEntities user = new AccountUserInfoEntities();
            AccountUserInfoBsn userBsn = new AccountUserInfoBsn();
            var fileName = Path.GetFileName(file.FileName);
            var uniqueFileName = Convert.ToString(Guid.NewGuid());
            var fileExtension = Path.GetExtension(fileName);
            var newFileName = String.Concat(uniqueFileName, fileExtension);

            user.UserName = UserName;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.EmailAddress = EmailAddress;
            user.City = City;
            user.Gender = Gender;
            user.DateOfBirth = DateOfBirth;
            user.ProfileDescription = ProfileDescription;
            user.ImgPath = newFileName;
            userBsn.InsertUser(user);

            var lastUser = userBsn.GetLastUser();
            var newUserId = lastUser.UserIdNumber;

            var filepath = (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "img", "user")) + $@"\{newUserId}" + $@"\{newFileName}";
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            userBsn.GetUserByEmail(user.EmailAddress);
            CookieOptions cookieOptions = new CookieOptions();
            HttpContext.Response.Cookies.Append("email", user.EmailAddress, cookieOptions);
            HttpContext.Response.Cookies.Append("userID", user.UserIdNumber.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("firstName", user.FirstName.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("lastName", user.LastName.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("userName", user.UserName.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("imgPath", user.ImgPath.ToString(), cookieOptions);





            return Redirect("https://localhost:7029/PostEntities");
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
        }

        // POST: AccountUserInfoEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            View(user.DeleteUserByID(id.Value));
            return RedirectToAction(nameof(Index));
        }

        private bool AccountUserInfoEntitiesExists(int id)
        {
            return _context.AccountUserInfoEntities.Any(e => e.UserIdNumber == id);
        }
    }
}
