using System;
using System.Linq;
using System.Web.Mvc;
using Transbank.Webpay.Oneclick;

namespace transbanksdkdotnetrestexample.Controllers
{
    public class OneclickMallController : Controller
    {
        public ActionResult InscriptionStart()
        {
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var returnUrl = urlHelper.Action("InscriptionFinish", "OneclickMall", null, Request.Url.Scheme);
            var userName = RandomString(10);
            var email = $"{RandomString(5)}@{RandomString(5)}.com";

            ViewBag.UserName = userName;
            ViewBag.Email = email;
            ViewBag.ReturnUrl = returnUrl;

            var response = Inscription.Start(userName, email, returnUrl);
            ViewBag.Result = response;
            
            ViewBag.Action = response.Url;
            ViewBag.Token = response.Token;
            
            return View();
        }
        
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public ActionResult InscriptionFinish()
        {
            throw new NotImplementedException();
        }
    }
}