using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastCoinTrader.EnitityModels.API.Models;

namespace FastCoinTrader.EnitityModels.EntityHelper
{
    public class NewsEntityHelper
    {
        static public string CreateNewsEntry(string title,string paragraph,string link)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var newsEntry = new tbl_News
                {
                    pk_tbl_News = Guid.NewGuid(),
                    tbl_News_Paragraph = paragraph,
                    tbl_News_Title = title,
                    tbl_News_VideoLink = link
                };

                context.tbl_News.Add(newsEntry);
                context.SaveChanges();
                return "success";
            }
            return "failed";
        }

    }
}
