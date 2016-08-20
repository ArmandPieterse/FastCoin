using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.EntityHelper
{
    public class EmailEntityHelper
    {
        #region CreateEmail
        public void CreateEmailEntry(string subject, string body, string emailType,string from,string to)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                DateTime dateTimeNow = DateTime.Now;
                context.tbl_Email.Add(
                    new tbl_Email {
                        pk_tbl_Email = Guid.NewGuid(),
                        tbl_Email_Subject = subject,
                        tbl_Email_Body = body,
                        tbl_Email_Type = emailType,
                        tbl_Email_From = from,
                        tbl_Email_To = to,
                        tbl_Email_DateCreated = dateTimeNow,
                        tbl_Email_DateLastModified = dateTimeNow                        
                    }    
                );
                context.SaveChanges();
            }
        }
        #endregion

        #region Modify Emails
        public void UpdateEmailEntry(tbl_Email email)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                DateTime dateTimeNow = DateTime.Now;
                context.tbl_Email.Single(x => x.pk_tbl_Email == email.pk_tbl_Email).tbl_Email_Body = email.tbl_Email_Body;
                context.tbl_Email.Single(x => x.pk_tbl_Email == email.pk_tbl_Email).tbl_Email_From = email.tbl_Email_From;
                context.tbl_Email.Single(x => x.pk_tbl_Email == email.pk_tbl_Email).tbl_Email_DateLastModified = dateTimeNow;
                context.tbl_Email.Single(x => x.pk_tbl_Email == email.pk_tbl_Email).tbl_Email_To = email.tbl_Email_To;
                context.tbl_Email.Single(x => x.pk_tbl_Email == email.pk_tbl_Email).tbl_Email_Subject = email.tbl_Email_Subject;
                context.tbl_Email.Single(x => x.pk_tbl_Email == email.pk_tbl_Email).tbl_Email_Type = email.tbl_Email_Type;
                context.Entry(context.tbl_Email.Single(x => x.pk_tbl_Email == email.pk_tbl_Email)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region GetEmails
        public static List<tbl_Email> GetAllEmailList()
        {

            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var emailList = (from emails in context.tbl_Email    
                                 orderby emails.tbl_Email_DateCreated                             
                                 select emails).ToList();

                return emailList; 
            }
        }

        public static IQueryable<tbl_Email> GetAllEmailQueryable()
        {

            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var emailList = (from emails in context.tbl_Email
                                 orderby emails.tbl_Email_DateCreated
                                 select emails).AsQueryable();

                return emailList;
            }
        }

        public static List<tbl_Email> GetEmailsByType(string type)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var emailList = (from emails in context.tbl_Email
                                 where emails.tbl_Email_Type == type
                                 orderby emails.tbl_Email_DateCreated
                                 select emails).ToList();

                return emailList;
            }
        }

        public static List<tbl_Email> GetEmailsToEmailAddressByType(string emailAddress,string type)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var emailList = (from emails in context.tbl_Email
                                 where emails.tbl_Email_To == emailAddress
                                 && emails.tbl_Email_Type == type
                                 orderby emails.tbl_Email_DateCreated
                                 select emails).ToList();

                return emailList;
            }
        }

        public static List<tbl_Email> GetEmailsFromEmailAddressByType(string emailAddress, string type)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                var emailList = (from emails in context.tbl_Email
                                 where emails.tbl_Email_From == emailAddress
                                 && emails.tbl_Email_Type == type
                                 orderby emails.tbl_Email_DateCreated
                                 select emails).ToList();

                return emailList;
            }
        }
        #endregion

        #region Delete Email
        public bool DeleteEmail(Guid PrimaryKey)
        {
            try
            {
                using (FastCoinTraderContext context = new FastCoinTraderContext())
                {
                    var emailToDelete = (from email in context.tbl_Email
                                         where email.pk_tbl_Email == PrimaryKey
                                         select email).FirstOrDefault();

                    if (emailToDelete != null)
                    {                       
                        context.tbl_Email.Remove(emailToDelete);
                        context.SaveChanges();
                        return true;
                    }
                    //if there is no matching email to delete.
                    return false;
                }
                    
            }
            catch
            {
                return false;
            }
        }
        #endregion


    }
}
