using System;
using System.Web.Mvc;
using Transbank.Webpay.WebpayPlus;

namespace transbanksdkdotnetrestexample.Controllers
{
    public class WebpayPlusController : Controller
    {
        public ActionResult NormalCreate()
        {
            var random = new Random();
            var buyOrder = random.Next(999999999).ToString();
            var sessionId = random.Next(999999999).ToString();
            var amount = random.Next(1000, 999999);
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var returnUrl = urlHelper.Action("NormalReturn", "WebpayPlus", null, Request.Url.Scheme);
            var result = Transaction.Create(buyOrder, sessionId, amount, returnUrl);

            ViewBag.BuyOrder = buyOrder;
            ViewBag.SessionId = sessionId;
            ViewBag.Amount = amount;
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Result = result;
            ViewBag.Action = result.Url;
            ViewBag.Token = result.Token;
            return View();
        }

        [HttpPost]
        public ActionResult NormalReturn()
        {
            var token = Request.Form["token_ws"];
            var result = Transaction.Commit(token);

            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);

            ViewBag.Token = token;
            ViewBag.Action = urlHelper.Action("ExecuteRefund", "WebpayPlus", null, Request.Url.Scheme);
            ViewBag.Result = result;
            ViewBag.SaveToken = token;

            return View();
        }

        public ActionResult NormalRefund()
        {
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteRefund", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteRefund()
        {
            var token = Request.Form["token_ws"];
            var refundAmount = 500;
            var result = Transaction.Refund(token, refundAmount);

            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteStatus", "WebpayPlus", null, Request.Url.Scheme);

            ViewBag.Token = token;
            ViewBag.Amount = refundAmount;
            ViewBag.Result = result;

            return View();
        }

        public ActionResult NormalStatus()
        {
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteStatus", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteStatus()
        {
            var token = Request.Form["token_ws"];
            var result = Transaction.Status(token);

            ViewBag.Result = result;

            return View();
        }
    }
}
