using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastCoinTrader.EnitityModels;
using FastCoinTrader.EnitityModels.EntityHelper;


namespace FastCoinTrader.Controllers
{
    public class FAQController : Controller
    {
        // GET: FAQ
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveFAQEntry(string title, string content, string panelNumber)
        {
            string message =  FAQEntityHelper.CreateFAQEntry(title, content, int.Parse(panelNumber));
            return Json(new { Message = message });
            //return Json("");
        }
    }
}