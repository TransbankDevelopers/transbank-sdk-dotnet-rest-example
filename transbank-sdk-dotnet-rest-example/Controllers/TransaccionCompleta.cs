using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Transbank.Common;
using Transbank.Webpay.TransaccionCompleta;

namespace transbanksdkdotnetrestexample.Controllers
{
    public class TransaccionCompleta : Controller
    {

        public ActionResult Create()
        {
            var random = new Random();

            var buy_order = random.Next(999999999).ToString();
            var session_id = random.Next(9999999).ToString();
            var amount = random.Next(1000, 999999);
            var cvv = 123;
            var card_number = "4239000000000000";
            var card_expiration_date = "22/10";
            
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var returnUrl = urlHelper.Action("Create", "TransaccionCompleta", null, Request.Url.Scheme);

            var result = FullTransaction.Create(
                buyOrder: buy_order,
                sessionId: session_id,
                amount: amount,
                cvv: cvv,
                cardNumber: card_number,
                cardExpirationDate: card_expiration_date);

            ViewBag.ReturlUrl = returnUrl;
            ViewBag.Token = result.Token;
            ViewBag.Result = result;

            ViewBag.BuyOrder = buy_order;
            ViewBag.SessionId = session_id;
            ViewBag.Amount = amount;
            ViewBag.Cvv = cvv;
            ViewBag.CardNumber = card_number;
            ViewBag.CardExpirationDate = card_expiration_date;

            return View();
        }
        
    }
}