using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastCoinTrader.EnitityModels.EntityHelper;
using FastCoinTrader.EnitityModels;
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
        public ActionResult SaveNewsEntry(string title,string paragraph,string videoLink,int panelNumber)
        {
            string message = NewsEntityHelper.CreateNewsEntry(title, paragraph,videoLink,panelNumber);
            return Json(new { Message = message});
        }

        public List<tbl_News> GetNewsEntries()
        {
            return NewsEntityHelper.GetNewsEntries();
        }

        
    }
}