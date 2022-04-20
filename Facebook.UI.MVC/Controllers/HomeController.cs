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
            //CookieOptions cookieOptions = new CookieOptions();
            //HttpContext.Response.Cookies.Append("first_request", DateTime.Now.ToString(), cookieOptions);
            //HttpContext.Response.Cookies.Append("user_id", "1");
            //HttpContext.Response.Cookies.Append("user_name", "UserName");
            //HttpContext.Response.Cookies.Append("first_name", "Vuk");
            //HttpContext.Response.Cookies.Append("last_name", "Vasiljević");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserIdNumber,UserName,FirstName,LastName,EmailAddress,City,Gender,DateOfBirth,ProfileDescription,DateMade")] AccountUserInfoEntities accountUserInfoEntities)
        {
            AccountUserInfoBsn user = new AccountUserInfoBsn();
            return View(user.InsertUser(accountUserInfoEntities));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}