using CRUDMVCproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMVCproject.Controllers
{
    public class LoginController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            string cookie = Request.Cookies["usertype"];
            if(cookie == "admin@gmail.com")
            {
                return RedirectToAction("home", "Home");
            }
            return View();
        }

        [Route("/CheckLogin")]
        public IActionResult CheckLogin(Login login)   
        {
            if (login.Email == "admin@gmail.com" && login.Password == "1234")
            {
                Response.Cookies.Append("usertype", "admin@gmail.com");
              
            }
            TempData["status"] = "Login Failed";
            return RedirectToAction("index");
        }

        [Route("/logout")]
        public IActionResult delete()
        {
            Response.Cookies.Delete("email");
            return RedirectToAction("index");

        }
    }
}
