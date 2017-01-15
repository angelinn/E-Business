using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.Common.Orders;
using VacationReservations.DataAccess;

namespace VacationReservations
{
    public partial class OrderTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            try
            {
                CommerceLibOrderInfo orderInfo =
                CommerceLibAccess.GetOrder(orderIDBox.Text);
                resultLabel.Text = "Поръчката е намерена.";
                addressLabel.Text =
                orderInfo.CustomerAddressAsString.Replace("\n", "<br />");
                creditCardLabel.Text = orderInfo.CreditCard.CardNumberX;
                orderLabel.Text = orderInfo.OrderAsString.Replace("\n", "<br />");
                processButton.Enabled = true;
                processResultLabel.Text = "";
            }
            catch
            {
                resultLabel.Text = "Не е намерена такава поръчка или е в стар формат.";
                addressLabel.Text = "";
                creditCardLabel.Text = "";
                orderLabel.Text = "";
                processButton.Enabled = false;
            }
        }

        protected void processButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderProcessor processor = new OrderProcessor(orderIDBox.Text);
                processor.Process();
                CommerceLibOrderInfo orderInfo =
                CommerceLibAccess.GetOrder(orderIDBox.Text);
                processResultLabel.Text = "Поръчката е обработена, статус:"
                + orderInfo.Status.ToString();
            }
            catch
            {
                CommerceLibOrderInfo orderInfo =
                CommerceLibAccess.GetOrder(orderIDBox.Text);
                processResultLabel.Text =
                "Има проблем с обработката на поръчката, статус: "
                + orderInfo.Status.ToString();
            }
        }
    }
}