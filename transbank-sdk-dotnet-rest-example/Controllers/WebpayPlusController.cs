using System;
using System.Web.Mvc;
using Transbank.Webpay.WebpayPlus;
using Transbank.Webpay.Common;

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

        public ActionResult DeferredCapture()
        {
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            ViewBag.Action = urlHelper.Action("ExecuteCapture", "WebpayPlus", null, Request.Url.Scheme);
            return View();
        }

        public ActionResult DeferredCreate()
        {
            var random = new Random();
            var buyOrder = random.Next(999999999).ToString();
            var sessionId = random.Next(999999999).ToString();
            var amount = random.Next(1000, 999999);
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var returnUrl = urlHelper.Action("DeferredReturn", "WebpayPlus", null, Request.Url.Scheme);
            var result = Transaction.Create(buyOrder, sessionId, amount, returnUrl, new Options(
                "597055555540", "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C",
                WebpayIntegrationType.Test));

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
        public ActionResult DeferredReturn()
        {
            var token = Request.Form["token_ws"];
            var result = Transaction.Commit(token, new Options(
                "597055555540", "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C",
                WebpayIntegrationType.Test));

            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);

            ViewBag.Token = token;
            ViewBag.Action = urlHelper.Action("ExecuteCapture", "WebpayPlus", null, Request.Url.Scheme);
            ViewBag.Result = result;
            ViewBag.SaveToken = token;

            return View();
        }

        [HttpPost]
        public ActionResult ExecuteCapture()
        {
            var token = Request.Form["token_ws"];
            var buyOrder = Request.Form["buy_order"];
            var authorizationCode = Request.Form["authorization_code"];
            var captureAmount = decimal.Parse(Request.Form["capture_amount"]);
            var result = Transaction.Capture(token, buyOrder, authorizationCode, captureAmount, new Options(
                "597055555540", "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C",
                WebpayIntegrationType.Test));

            ViewBag.BuyOrder = buyOrder;
            ViewBag.AuthorizationCode = authorizationCode;
            ViewBag.CaptureAmount = captureAmount;
            ViewBag.Result = result;

            return View();
        }
    }
}
