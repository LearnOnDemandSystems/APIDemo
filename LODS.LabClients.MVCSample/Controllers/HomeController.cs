using System.Web.Mvc;

namespace LODS.LabClients.MVCSample.Controllers {
    public class HomeController : Controller {
        [Authorize]
        public ActionResult Index() {
            return View();
        }

        [Authorize]
        public ActionResult About() {
            ViewBag.Message = "About the sample application.";

            return View();
        }

        [Authorize]
        public ActionResult Contact() {
            ViewBag.Message = "Contact Learn on Demand Systems.";

            return View();
        }

    }
}