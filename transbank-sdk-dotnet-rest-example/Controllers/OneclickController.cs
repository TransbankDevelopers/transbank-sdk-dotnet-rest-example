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
        public ActionResult InscriptionStart()
        {
            var UserName = "Pepito Continuum";
            var Email = "pepito@continuum.co";

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
            ViewBag.SaveTbkUser = result.TransbankUser;

            return View();
        }
    }
}
