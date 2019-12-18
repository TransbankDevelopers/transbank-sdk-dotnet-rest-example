using System;
using System.Web.Mvc;

namespace transbanksdkdotnetrestexample.Controllers
{
    public class PatpassByWebpayController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Commit()
        {
            return View();
        }

        public ActionResult RequestStatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Status()
        {
            return View();
        }

    }
}