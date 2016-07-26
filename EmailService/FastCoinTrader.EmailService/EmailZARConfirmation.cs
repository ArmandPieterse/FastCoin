using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limilabs.Client.IMAP;
using Limilabs.Client.POP3;
using Limilabs.Client.SMTP;
using Limilabs.Mail;
using Limilabs.Mail.MIME;
using Limilabs.Mail.Fluent;
using Limilabs.Mail.Headers;


namespace FastCoinTrader.EmailService
{
    public class EmailZARConfirmation
    {        
        private string EmailAddress { get; set; }
        private string Password { get; set; }
        public EmailZARConfirmation(string emailAddress,string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public List<EmailModel> ReceiveEmails()
        {
            List<EmailModel> emailList = new List<EmailModel>();
            using (Pop3 pop3 = new Pop3())
            {
                pop3.ConnectSSL("pop.gmail.com",995);       // or ConnectSSL for SSL                
                pop3.UseBestLogin(EmailAddress, Password);

                foreach (string uid in pop3.GetAll())
                {
                    IMail email = new MailBuilder()
                        .CreateFromEml(pop3.GetMessageByUID(uid));

                    Console.WriteLine(email.Subject);
                    Console.WriteLine(email.Text);
                    EmailModel tempEmail = new EmailModel { Body = email.Text, Subject = email.Subject };
                    emailList.Add(tempEmail);
                }
                pop3.Close();
            }
            return emailList;
        }

    }

    public class EmailModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }        
    }
}
