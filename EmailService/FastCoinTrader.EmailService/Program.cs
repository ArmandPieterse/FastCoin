using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastCoinTrader.EmailService;
namespace FastCoinTrader.EmailService
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailZARConfirmation emailService = new EmailZARConfirmation("armandpie2@gmail.com","Hakutaku2");
            List<EmailModel> emailList = emailService.ReceiveEmails();
           // Console.ReadLine();
        }
    }
}
