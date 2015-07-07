using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using LODS.LabClients.MVCSample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace LODS.LabClients.MVCSample.Controllers {
    [Authorize]
    public class AccountController : Controller {

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl) {

            if (!ModelState.IsValid) {
                return View(model);
            }

            // BUG: just take any old credentials; don't do this!
            // cf. on custom auth if you're curious: http://www.khalidabuhakmeh.com/asp-net-mvc-5-authentication-breakdown-part-deux
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.NameIdentifier, model.Email),
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Bogus Auth"),
            }, DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
            return RedirectToLocal(returnUrl);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}