using System;
using System.Web.Mvc;
using Transbank.Webpay.TransaccionCompleta;

namespace transbanksdkdotnetrestexample.Controllers
{
    public class TransaccionCompletaController : Controller
    {

        public ActionResult Create()
        {
            var random = new Random();

            var buy_order = random.Next(999999999).ToString();
            var session_id = random.Next(9999999).ToString();
            var amount = random.Next(1000, 999999);
            var cvv = 123;
            var card_number = "4051885600446623";
            var card_expiration_date = "22/10";
            
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var returnUrl = urlHelper.Action("Installments", "TransaccionCompleta", null, Request.Url.Scheme);

            var result = FullTransaction.Create(
                buyOrder: buy_order,
                sessionId: session_id,
                amount: amount,
                cvv: cvv,
                cardNumber: card_number,
                cardExpirationDate: card_expiration_date);

            ViewBag.Action = returnUrl;
            ViewBag.ReturnUrl = returnUrl;
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
        
        [HttpPost]
        public ActionResult Installments()
        {
            var token = Request.Form["token_ws"];
            var installments_number = 10;
            
            var result = FullTransaction.Installments(
                token,
                installments_number);
            
            
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);
            var returnUrl = urlHelper.Action("Installments", "TransaccionCompleta", null, Request.Url.Scheme);


            ViewBag.Action = returnUrl;
            ViewBag.Token = token;
            ViewBag.InstallmentsNumber = installments_number;
            ViewBag.IdQueryInstallmentss = result.IdQueryInstallments;
            ViewBag.Result = result;
            ViewBag.ReturnUrl = returnUrl;

            return View();

        }
        
        
        
        
    }
}