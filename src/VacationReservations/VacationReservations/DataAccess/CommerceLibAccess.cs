using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace VacationReservations.DataAccess
{
    /// <summary>
    /// Wraps order detail data
    /// </summary>
    public class CommerceLibOrderDetailInfo
    {
        public int OrderID;
        public int ProductID;
        public string ProductName;
        public int Quantity;
        public double UnitCost;
        public string ItemAsString;
        public double Subtotal
        {
            get
            {
                return Quantity * UnitCost;
            }
        }
        public CommerceLibOrderDetailInfo(DataRow orderDetailRow)
        {
            OrderID = Int32.Parse(orderDetailRow["OrderID"].ToString());
            ProductID = Int32.Parse(orderDetailRow["ProductId"].ToString());
            ProductName = orderDetailRow["ProductName"].ToString();
            Quantity = Int32.Parse(orderDetailRow["Quantity"].ToString());
            UnitCost = Double.Parse(orderDetailRow["UnitCost"].ToString());
            // set info property
            Refresh();
        }
        public void Refresh()
        {
            ItemAsString = Quantity.ToString() + " " + ProductName + ", лв " +
           UnitCost.ToString() + " всяко, общо лв " + Subtotal.ToString();
        }
    }

    public class CommerceLibAccess
    {
        public static List<CommerceLibOrderDetailInfo> GetOrderDetails(string orderId)
        {
            // use existing method for DataTable
            DataTable orderDetailsData = OrdersAccess.GetDetails(orderId);
            // create List<>
            List<CommerceLibOrderDetailInfo> orderDetails =
            new List<CommerceLibOrderDetailInfo>(
            orderDetailsData.Rows.Count);
            foreach (DataRow orderDetail in orderDetailsData.Rows)
            {
                orderDetails.Add(
                new CommerceLibOrderDetailInfo(orderDetail));
            }
            return orderDetails;
        }

        public static CommerceLibOrderInfo GetOrder(string orderID)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CommerceLibOrderGetInfo";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@OrderID";
            param.Value = orderID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // obtain the results
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            DataRow orderRow = table.Rows[0];
            // save the results into an CommerceLibOrderInfo object
            CommerceLibOrderInfo orderInfo =
            new CommerceLibOrderInfo(orderRow);
            return orderInfo;
        }

        public static List<ShippingInfo> GetShippingInfo(int shippingRegionId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CommerceLibShippingGetInfo";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ShippingRegionId";
            param.Value = shippingRegionId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // obtain the results
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            List<ShippingInfo> result = new List<ShippingInfo>();
            foreach (DataRow row in table.Rows)
            {
                ShippingInfo rowData = new ShippingInfo();
                rowData.ShippingID = int.Parse(row["ShippingId"].ToString());
                rowData.ShippingType = row["ShippingType"].ToString();
                rowData.ShippingCost =
                double.Parse(row["ShippingCost"].ToString());
                rowData.ShippingRegionId = shippingRegionId;
                result.Add(rowData);
            }
            return result;
        }
    }

}