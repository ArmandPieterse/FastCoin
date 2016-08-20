using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastCoinTrader.EnitityModels.EntityHelper;
using Newtonsoft.Json;


namespace FastCoinTrader.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveNewsEntry(string title,string paragraph,string videoLink)
        {
            string message = NewsEntityHelper.CreateNewsEntry(title, paragraph,videoLink);
            return Json(new { Message = ""});

        }
    }
}