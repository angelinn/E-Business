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
    public struct TaxInfo
    {
        public int TaxID;
        public string TaxType;
        public double TaxPercentage;
    }
    /// <summary>
    /// Wraps shipping data
    /// </summary>
    public struct ShippingInfo
    {
        public int ShippingID;
        public string ShippingType;
        public double ShippingCost;
        public int ShippingRegionId;
    }
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
        public ShippingInfo Shipping;
        public TaxInfo Tax;

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
            // Get Shipping Data
            if (orderRow["ShippingID"] != DBNull.Value
            && orderRow["ShippingType"] != DBNull.Value
            && orderRow["ShippingCost"] != DBNull.Value)
            {
                Shipping.ShippingID =
                Int32.Parse(orderRow["ShippingID"].ToString());
                Shipping.ShippingType = orderRow["ShippingType"].ToString();
                Shipping.ShippingCost =
                double.Parse(orderRow["ShippingCost"].ToString());
            }
            else
            {
                Shipping.ShippingID = -1;
            }
            // Get Tax Data
            if (orderRow["TaxID"] != DBNull.Value
            && orderRow["TaxType"] != DBNull.Value
            && orderRow["TaxPercentage"] != DBNull.Value)
            {
                Tax.TaxID = Int32.Parse(orderRow["TaxID"].ToString());
                Tax.TaxType = orderRow["TaxType"].ToString();
                Tax.TaxPercentage =
                double.Parse(orderRow["TaxPercentage"].ToString());
            }
            else
            {
                Tax.TaxID = -1;
            }
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
            // Add shipping cost
            if (Shipping.ShippingID != -1)
            {
                sb.AppendLine(", Доставка: " + Shipping.ShippingType);
                TotalCost += Shipping.ShippingCost;
            }
            // Add tax
            if (Tax.TaxID != -1 && Tax.TaxPercentage != 0.0)
            {
                double taxAmount = Math.Round(TotalCost * Tax.TaxPercentage,
                MidpointRounding.AwayFromZero) / 100.0;
                sb.AppendLine($"{Tax.TaxType}, {taxAmount.ToString()} лв.");
                TotalCost += taxAmount;
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
