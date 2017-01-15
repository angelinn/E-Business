using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using VacationReservations.Common;

namespace VacationReservations.DataAccess
{
    public class CommerceLibOrderInfo
    {
        public int OrderID;
        public string DateCreated;
        public string DateShipped;
        public string Comments;
        public int Status;
        public string AuthCode;
        public string Reference;
        public MembershipUser Customer;
        public ProfileBase CustomerProfile;
        public SecureCard CreditCard;
        public double TotalCost;
        public string OrderAsString;
        public string CustomerAddressAsString;
        public List<CommerceLibOrderDetailInfo> OrderDetails;
        public CommerceLibOrderInfo(DataRow orderRow)
        {
            OrderID = Int32.Parse(orderRow["OrderID"].ToString());
            DateCreated = orderRow["DateCreated"].ToString();
            DateShipped = orderRow["DateShipped"].ToString();
            Comments = orderRow["Comments"].ToString();
            Status = Int32.Parse(orderRow["Status"].ToString());
            AuthCode = orderRow["AuthCode"].ToString();
            Reference = orderRow["Reference"].ToString();
            Customer = Membership.GetUser(
            new Guid(orderRow["CustomerID"].ToString()));
            CustomerProfile = ProfileBase.Create(Customer.UserName);
            CreditCard = new SecureCard(CustomerProfile["CreditCard"] as string);
            OrderDetails =
            CommerceLibAccess.GetOrderDetails(
            orderRow["OrderID"].ToString());
            // set info properties
            Refresh();
        }

        public void Refresh()
        {
            // calculate total cost and set data
            StringBuilder sb = new StringBuilder();
            TotalCost = 0.0;    
            foreach (CommerceLibOrderDetailInfo item in OrderDetails)
            {
                sb.AppendLine(item.ItemAsString);
                TotalCost += item.Subtotal;
            }
            sb.AppendLine();
            sb.Append("Общо лв: ");
            sb.Append(TotalCost.ToString());
            OrderAsString = sb.ToString();
            // get customer address string
            sb = new StringBuilder();
            sb.AppendLine(Customer.UserName);
            sb.AppendLine((string)CustomerProfile["Address1"]);
            if ((string)CustomerProfile["Address2"] != "")
            {
                sb.AppendLine((string)CustomerProfile["Address2"]);
            }
            sb.AppendLine((string)CustomerProfile["City"]);
            sb.AppendLine((string)CustomerProfile["Region"]);
            sb.AppendLine((string)CustomerProfile["PostalCode"]);
            sb.AppendLine((string)CustomerProfile["Country"]);
            CustomerAddressAsString = sb.ToString();
        }
    }
}
