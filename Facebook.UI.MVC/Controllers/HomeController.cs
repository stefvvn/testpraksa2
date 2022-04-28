using System;
using Facebook.Business;
using Facebook.Entities;
using Facebook.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Web;


namespace Facebook.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([Bind("email,password")] LoginModel accountUserInfoEntities)
        {
            AccountUserInfoBsn bsn = new AccountUserInfoBsn();
            AccountUserInfoEntities user = bsn.GetUserByEmail(accountUserInfoEntities.email);
            CookieOptions cookieOptions = new CookieOptions();
            HttpContext.Response.Cookies.Append("email", accountUserInfoEntities.email, cookieOptions);
            HttpContext.Response.Cookies.Append("userID", user.UserIdNumber.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("firstName", user.FirstName.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("lastName", user.LastName.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("userName", user.UserName.ToString(), cookieOptions);
            Response.Redirect("https://localhost:7029/PostEntities");
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("User.UserIdNumber,User.UserName,User.FirstName,User.LastName,User.EmailAddress,User.City,User.Gender,User.DateOfBirth,User.ProfileDescription,User.DateMade")] AccountUserInfoEntities accountUserInfoEntities)
        //{
        //    AccountUserInfoBsn bsn = new AccountUserInfoBsn();
        //    bsn.InsertUser(accountUserInfoEntities);
        //    return View("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserIdNumber,UserName,FirstName,LastName,EmailAddress,City,Gender,DateOfBirth,ProfileDescription,DateMade")] AccountUserInfoEntities accountUserInfoEntities)
        {
            AccountUserInfoBsn bsn = new AccountUserInfoBsn();
            bsn.InsertUser(accountUserInfoEntities);

            CookieOptions cookieOptions = new CookieOptions();
            HttpContext.Response.Cookies.Append("email", accountUserInfoEntities.EmailAddress, cookieOptions);
            HttpContext.Response.Cookies.Append("userID", accountUserInfoEntities.UserIdNumber.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("firstName", accountUserInfoEntities.FirstName.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("lastName", accountUserInfoEntities.LastName.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("userName", accountUserInfoEntities.UserName.ToString(), cookieOptions);
            Response.Redirect("https://localhost:7029/PostEntities");
            return View("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}