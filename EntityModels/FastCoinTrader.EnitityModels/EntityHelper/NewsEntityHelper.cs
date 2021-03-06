﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastCoinTrader.EnitityModels.API.Models;

namespace FastCoinTrader.EnitityModels.EntityHelper
{
    public class NewsEntityHelper
    {
        static public string CreateNewsEntry(string title,string paragraph,string link,int panelNumber)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var newsEntries = GetNewsEntries();
                if (newsEntries.Count > panelNumber)
                {
                    int index = panelNumber;
                    newsEntries.ElementAt(index).tbl_News_Paragraph = paragraph;
                    newsEntries.ElementAt(index).tbl_News_Title = title;
                    newsEntries.ElementAt(index).tbl_News_VideoLink = link;
                    context.Entry(newsEntries.ElementAt(index)).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    var newsEntry = new tbl_News
                    {
                        pk_tbl_News = Guid.NewGuid(),
                        tbl_News_Paragraph = paragraph,
                        tbl_News_DateCreated = DateTime.Now,
                        tbl_News_Title = title,
                        tbl_News_VideoLink = link
                    };

                    context.tbl_News.Add(newsEntry);
                }
               
                context.SaveChanges();
                return "success";
            }
            //return "failed";
        }

        static public List<tbl_News> GetNewsEntries()
        {

            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var newsEntries = (from n in context.tbl_News
                                   orderby n.tbl_News_DateCreated ascending
                                   select n).ToList();

                return newsEntries;
            }
        }

    }
}
