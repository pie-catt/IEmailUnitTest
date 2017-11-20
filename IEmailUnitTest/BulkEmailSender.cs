using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEmailUnitTest
{
    public class BulkEmailSender

    {
        private readonly IEmailSender _emailSender;
        private readonly string _footer;

        public BulkEmailSender(IEmailSender emailSender, string footer)
        {
            this._emailSender = emailSender;
            this._footer = footer;
        }

        public void SendEmail(List<string> adresses, string body)
        {
            if (adresses == null)
                throw new ArgumentNullException("adresses");
            if (body == null)
                throw new ArgumentNullException("body");
            foreach (var a in adresses)
            {
                if (!this._emailSender.SendEmail(a, body + this._footer))
                    throw new Exception("Cannot send mail");
            }
        }


        static void Main()
        {


        }

    }
}
