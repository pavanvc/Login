using Login.Models;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class LoginController : Controller
    { 
        // GET: /Login
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View(); // Displays the login form
        }

        // POST: /Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Call the ADO.NET service to authenticate
                var user = _userRepository.AuthenticateUser(model.Username, model.Password);

                if (user != null)
                {
                    // Authentication Successful: Set session data
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Role", user.Role);

                    // Redirect to a protected page
                    return RedirectToAction("ProtectedPage", "Home");
                }

                // Authentication Failed
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View("Index", model);
            }

            return View("Index", model);
        }

        // GET: /Login/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
