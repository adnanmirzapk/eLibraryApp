using eLibraryData.BusinessLogic;
using eLibraryUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace eLibraryUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;

        public AccountController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Users user)
        {
            var userData = UserBizLogic.GetAllUsers();
            var userFound = userData.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

            if(userFound != null)
            {
                _httpContext.HttpContext.Session.SetString("userName", userFound.UserName);
                return RedirectToAction("index", "Home");
            }
            else
            {
                TempData["WrongCredentials"] = "userName or password is not correct.";
                return View();
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            _httpContext.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
