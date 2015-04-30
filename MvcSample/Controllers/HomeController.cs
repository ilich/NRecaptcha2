using System.Web.Mvc;
using MvcSample.Models;
using NRecaptcha2.Mvc;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Customer();
            return View(model);
        }

        [HttpPost]
        [ValidateRecaptcha2(ErrorMessage = "Captcha is invalid")]
        public ActionResult Index(Customer model)
        {
            if (ModelState.IsValid)
            {
                return View("CustomerCreated", model);
            }
            else
            {
                return View(model);
            }
        }
    }
}