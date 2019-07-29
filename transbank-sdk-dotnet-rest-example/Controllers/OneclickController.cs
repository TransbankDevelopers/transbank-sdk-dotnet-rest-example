using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transbank.Webpay.Oneclick;

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
        public ActionResult PaymentAuthorize()
        {
            ViewBag.UserName = UserName;
            //ViewBag.TbkUser = TbkUser;
            ViewBag.BuyOrder = "OC"+ new Random(1000);


            return View();
        }
    }
}
