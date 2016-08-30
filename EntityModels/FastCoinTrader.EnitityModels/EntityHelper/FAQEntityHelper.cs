using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.EntityHelper
{
    public class FAQEntityHelper
    {
        #region Create/Save
        static public string CreateFAQEntry(string title, string content, int panelNumber)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var faqEntries = GetFAQEntries();
                if (faqEntries.Count > panelNumber)
                {
                    int index = panelNumber;
                    faqEntries.ElementAt(index).tbl_FAQ_Title = title;
                    faqEntries.ElementAt(index).tbl_FAQ_Content = content;
                    context.Entry(faqEntries.ElementAt(index)).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    var faqEntry = new tbl_FAQ
                    {
                        pk_tbl_FAQ = Guid.NewGuid(),
                        tbl_FAQ_Content = content,
                        tbl_FAQ_DateCreated = DateTime.Now,
                        tbl_FAQ_Title = title                      
                    };

                    context.tbl_FAQ.Add(faqEntry);
                }

                context.SaveChanges();
                return "success";
            }
            //return "failed";
        }
        #endregion

        #region GetFAQEntries
        static public List<tbl_FAQ> GetFAQEntries()
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var faqEnties = (from f in context.tbl_FAQ
                                   orderby f.tbl_FAQ_DateCreated ascending
                                   select f).ToList();

                return faqEnties;
            }
        }
        #endregion
    }
}
