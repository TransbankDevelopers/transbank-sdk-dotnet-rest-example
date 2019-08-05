using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transbank.Webpay.Oneclick;
using Transbank.Webpay.Common;

namespace transbanksdkdotnetrestexample.Controllers
{
    public class OneclickController : Controller
    {
        public string UserName = "Pepito Continuum";
        public string Email = "pepito@continuum.co";

        public ActionResult InscriptionStart()
        {
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var ResponseURL = urlHelper.Action("InscriptionFinish", "Oneclick", null, Request.Url.Scheme);
            var result = Inscription.Start(UserName, Email, ResponseURL);

            ViewBag.UserName = UserName;
            ViewBag.Email = Email;
            ViewBag.ResponseURL = ResponseURL;

            ViewBag.Result = result;

            ViewBag.Action = result.Url;
            ViewBag.Token = result.Token;

            return View();
        }

        [HttpPost]
        public ActionResult InscriptionFinish()
        {
            var token = Request.Form["TBK_TOKEN"];
            var result = Inscription.Finish(token);


            ViewBag.Token = token;
            ViewBag.Result = result;
            ViewBag.SaveToken = token;

            ViewBag.TbkUser = result.TbkUser;

            return View();
        }

        [HttpPost]
        public ActionResult InscriptionDelete()
        {
            string TbkUser = Request.Form["TbkUser"];

            try
            {
                Inscription.Delete(UserName, TbkUser);
                ViewBag.Result = "Success";
            }
            catch (Exception e)
            {
                ViewBag.Result = e.Message;
            }

            ViewBag.UserName = UserName;
            ViewBag.TbkUser = TbkUser;
            
            return View();
        }

        [HttpPost]
        public ActionResult TransactionAuthorize()
        {
            string TbkUser = Request.Form["TbkUser"];

            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var ResponseURL = urlHelper.Action("TransactionAuthorizeFinish", "Oneclick", null, Request.Url.Scheme);

            ViewBag.BuyOrder = "OC"+ new Random(1000);

            ViewBag.CommerceA = Oneclick.CommerceCode[1];
            ViewBag.CommerceABuyOrder = "OCA" + new Random(1000);
            ViewBag.CommerceAAmmount = 2500;

            ViewBag.CommerceB = Oneclick.CommerceCode[1];
            ViewBag.CommerceBBuyOrder = "OCB" + new Random(1000);
            ViewBag.CommerceBAmmount = 500;

            PaymentRequest comerceA = new PaymentRequest(ViewBag.CommerceA, ViewBag.CommerceABuyOrder, ViewBag.CommerceAAmmount);
            PaymentRequest comerceB = new PaymentRequest(ViewBag.CommerceB, ViewBag.CommerceBBuyOrder, ViewBag.CommerceBAmmount);

            var result = MallTransaction.Authorize(UserName, TbkUser, ViewBag.BuyOrder, new List<PaymentRequest> { comerceA, comerceB });

            ViewBag.Result = result.toString();

            return View();
        }
    }
}
