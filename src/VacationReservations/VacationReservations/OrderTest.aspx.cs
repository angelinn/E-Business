using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                CommerceLibOrderInfo orderInfo = CommerceLibAccess.GetOrder(
                orderIDBox.Text);
                resultLabel.Text = "Поръчката е намерена.";
                addressLabel.Text = orderInfo.CustomerAddressAsString.Replace(
                "\n", "<br />");
                creditCardLabel.Text = orderInfo.CreditCard.CardNumberX;
                orderLabel.Text =
                orderInfo.OrderAsString.Replace("\n", "<br />");
            }
            catch (Exception ex)
            {
                resultLabel.Text = "Не е намерена такава поръчка или е в стар формат.";
                addressLabel.Text = "";
                creditCardLabel.Text = "";
                orderLabel.Text = "";
            }
        }
    }
}