using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacationReservations.DataAccess;

namespace VacationReservations.Common.Orders
{
    public static class OrderProcessorMailer
    {
        public static void MailAdmin(int orderID, string subject, string message, int sourceStage)
        {
            // Send mail to administrator
            string to = VacationReservationsConfiguration.ErrorLogEmail;
            string from = VacationReservationsConfiguration.OrderProcessorEmail;
            string body = "Message: " + message
            + "\nSource: " + sourceStage.ToString()
            + "\nOrder ID: " + orderID.ToString();
            Utilities.SendMail(from, to, subject, body);
        }
    }
}