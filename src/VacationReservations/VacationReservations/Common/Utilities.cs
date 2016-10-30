using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using VacationReservations.DataAccess;

namespace VacationReservations.Common
{
    public static class Utilities
    {
        static Utilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void SendMail(string from, string to, string subject, string body)
        {
            SmtpClient mailClient = new SmtpClient(VacationReservationsConfiguration.MailServer);
            // Set credentials (for SMTP servers that require authentication)
            mailClient.Credentials = new NetworkCredential(VacationReservationsConfiguration.MailUsername,
                                                           VacationReservationsConfiguration.MailPassword);
            // Create the mail message
            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            // Send mail
            mailClient.Send(mailMessage);
        }
        // Send error log mail
        public static void LogError(Exception ex)
        {
            // get the current date and time
            string dateTime = DateTime.Now.ToLongDateString() + ", at "
            + DateTime.Now.ToShortTimeString();
            // stores the error message
            string errorMessage = "Exception generated on " + dateTime;
            // obtain the page that generated the error
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            errorMessage += "\n\n Page location: " + context.Request.RawUrl;
            // build the error message
            errorMessage += "\n\n Message: " + ex.Message;
            errorMessage += "\n\n Source: " + ex.Source;
            errorMessage += "\n\n Method: " + ex.TargetSite;
            errorMessage += "\n\n Stack Trace: \n\n" + ex.StackTrace;
            // send error email in case the option is activated in web.config
            if (VacationReservationsConfiguration.EnableErrorLogEmail)
            {
                string from = VacationReservationsConfiguration.MailFrom;
                string to = VacationReservationsConfiguration.ErrorLogEmail;
                string subject = "BalloonShop Error Report";
                string body = errorMessage;
                SendMail(from, to, subject, body);
            }
        }
    }
}
