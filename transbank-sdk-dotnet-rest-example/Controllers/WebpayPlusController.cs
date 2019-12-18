using System.Web.Mvc;

namespace transbanksdkdotnetrestexample.Controllers
{
    public class WebpayPlusController : Controller
    {
        public ActionResult NormalCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NormalReturn()
        {
            return View();
        }

        public ActionResult NormalRefund()
        {
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteRefund", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteRefund()
        {
            return View();
        }


        public ActionResult NormalStatus()
        {
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteStatus", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteStatus()
        {
            return View();
        }

        public ActionResult DeferredCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeferredReturn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteDeferredCapture()
        {
            return View();
        }

        public ActionResult DeferredRefund()
        {
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteDeferredRefund", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteDeferredRefund()
        {
            return View();
        }

        public ActionResult DeferredStatus()
        {
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteDeferredStatus", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteDeferredStatus()
        {
            return View();
        }

        public ActionResult MallCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MallReturn()
        {
            return View();
        }

        public ActionResult MallRefund()
        {
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteMallRefund", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteMallRefund()
        {
            return View();
        }

        public ActionResult MallStatus()
        {
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteMallStatus", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        public ActionResult ExecuteMallStatus()
        {
            return View();
        }

        public ActionResult MallDeferredCreate()
        {
            return View();
        }
        
        public ActionResult MallDeferredCommit()
        {
            return View();
        }
        
        public ActionResult ExecuteMallDeferredCapture()
        {
            return View();
        }

        public ActionResult ExecuteMallDeferredRefund()
        {
            return View();
        }

        public ActionResult ExecuteMallDeferredStatus()
        {
            return View();
        }
    }
}