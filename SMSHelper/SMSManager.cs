using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMSHelper
{
    public class SMSManager
    {
        public void GetSMS(long number)
        {
            try
            {
                var accountSid = "AC582c9a6a588231e2c0354e93ff0c894f";
                var authToken = "e2918113d716e275007b5a7f67bdb60f";
                TwilioClient.Init(accountSid, authToken);


                var recipients = new List<string> { "+91" + number, "+919752503237" };
                var message = "you Enquiry has been completed.....thanks for visiting us!";

                foreach (var recipient in recipients)
                {
                    MessageResource.Create(
                        to: new Twilio.Types.PhoneNumber(recipient),
                        from: new Twilio.Types.PhoneNumber("+19703722478"),
                        body: message
                    );
                }

            }
            catch (Exception exc)
            {

            }
        }
    }
}
