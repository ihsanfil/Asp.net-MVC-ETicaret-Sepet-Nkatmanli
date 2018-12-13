using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationManager;

        public AccountController(IAuthenticationService authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            User validatedUser = _authenticationManager.Authenticate(user);

            if (validatedUser == null)
            {
                ModelState.AddModelError("Hata", "Kullanıcı adı veya parola hatalı");
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return Redirect(returnUrl);
            }
            return View();
        }
    }

}