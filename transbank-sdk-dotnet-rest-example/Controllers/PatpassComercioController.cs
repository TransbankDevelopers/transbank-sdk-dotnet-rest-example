using System;
using System.Web.Mvc;
using Transbank.Patpass.PatpassComercio;

namespace transbanksdkdotnetrestexample.Controllers
{
    public class PatpassComercioController : Controller
    {
        public ActionResult Start()
        {
            
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);

            var returnUrl = urlHelper.Action("Start", "PatpassComercio", null, Request.Url.Scheme);

            var random = new Random();

            var url = returnUrl;
            var name = "nombre";
            var f_lastname = "pApellido";
            var s_lastname = "sApellido";
            var rut = "14959787-6";
            var service_id = random.Next(999999999).ToString();
            var final_url = urlHelper.Action("End", "PatpassComercio", null, Request.Url.Scheme);
            var commerce_code = "28299257";
            var max_amount = random.Next(1000, 999999);
            var phone_number = random.Next(999999999).ToString();
            var mobile_number = random.Next(999999999).ToString();
            var patpass_name = "nombre del patpass";
            var person_email = "persona@persona.cl";
            var commerce_email = "comercio@comercio.cl";
            var address = "huerfanos 101";
            var city = "city";
            

            var result = Inscription.Start(
                url,
                name,
                f_lastname,
                s_lastname,
                rut,
                service_id,
                final_url,
                commerce_code,
                max_amount,
                phone_number,
                mobile_number,
                patpass_name,
                person_email,
                commerce_email,
                address,
                city
                );

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Action = result.Url;
            ViewBag.Token = result.Token;
            ViewBag.Result = result;
            
            ViewBag.Url = url;
            ViewBag.Name = name;
            ViewBag.F_Lastname = f_lastname;
            ViewBag.S_Lastname = s_lastname;
            ViewBag.Rut = rut;
            ViewBag.Service_id = service_id;
            ViewBag.Final_url = final_url;
            ViewBag.Commerce_code = commerce_code;
            ViewBag.Max_amount = max_amount;
            ViewBag.Phone_number = phone_number;
            ViewBag.Mobile_number = mobile_number;
            ViewBag.Patpass_name = patpass_name;
            ViewBag.Client_name = person_email;
            ViewBag.Commerce_email = commerce_email;
            ViewBag.Address = address;
            ViewBag.City = city;

            return View();
        }

        [HttpGet]
        public ActionResult Return()
        {
            var token = Request.Form["token_ws"];
            var url = Request.Form["url"];

            ViewBag.Token = token;
            ViewBag.Url = url;

            return View();
        }

        public ActionResult End()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Status()
        {
            var token = Request.Form["token_ws"];
            var result = Inscription.Status(token);
            
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);

            ViewBag.Action = urlHelper.Action("Status", "PatpassComercio", null, Request.Url.Scheme);
            ViewBag.Result = result;

            return View();
        }
    }
}