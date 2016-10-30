using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using VacationReservations.DataAccess;

namespace VacationReservations.Common
{
    public struct DepartmentDetails
    {
        public string Name;
        public string Description;
    }

    /// <summary>
    /// Wraps category details data
    /// </summary>
    public struct CategoryDetails
    {
        public int DepartmentId;
        public string Name;
        public string Description;
    }

    /// <summary>
    /// Wraps product details data
    /// </summary>
    public struct ProductDetails
    {
        public int ProductID;
        public string Name;
        public string Description;
        public decimal Price;
        public string Thumbnail;
        public string Image;
        public bool PromoFront;
        public bool PromoDept;
    }

    public class Link
    {
        private static string BuildAbsolute(string relativeUri)
        {
            // get current uri
            Uri uri = HttpContext.Current.Request.Url;
            // build absolute path
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/")) app += "/";
            relativeUri = relativeUri.TrimStart('/');
            // return the absolute path
            return HttpUtility.UrlPathEncode(
            String.Format("http://{0}:{1}{2}{3}",
            uri.Host, uri.Port, app, relativeUri));
        }
        // Generate a department URL
        public static string ToDepartment(string departmentId, string page)
        {
            if (page == "1")
                return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}", departmentId));

            return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}&Page={1}", departmentId, page));
        }
        // Generate a department URL for the first page
        public static string ToDepartment(string departmentId)
        {
            return ToDepartment(departmentId, "1");
        }

        // Get category details
        public static CategoryDetails GetCategoryDetails(string categoryId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetCategoryDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CategoryID";
            param.Value = categoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // wrap retrieved data into a CategoryDetails object
            CategoryDetails details = new CategoryDetails();
            if (table.Rows.Count > 0)
            {
                details.DepartmentId = Int32.Parse(table.Rows[0]["DepartmentID"].ToString());
                details.Name = table.Rows[0]["Name"].ToString();
                details.Description = table.Rows[0]["Description"].ToString();
            }
            // return department details
            return details;
        }

        // Get product details
        public static ProductDetails GetProductDetails(string productId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ProductID";
            param.Value = productId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // wrap retrieved data into a ProductDetails object
            ProductDetails details = new ProductDetails();
            if (table.Rows.Count > 0)
            {
                // get the first table row
                DataRow dr = table.Rows[0];
                // get product details
                details.ProductID = int.Parse(productId);
                details.Name = dr["Name"].ToString();
                details.Description = dr["Description"].ToString();
                details.Price = Decimal.Parse(dr["Price"].ToString());
                details.Thumbnail = dr["Thumbnail"].ToString();
                details.Image = dr["Image"].ToString();
                details.PromoFront = bool.Parse(dr["PromoFront"].ToString());
                details.PromoDept =
            bool.Parse(dr["PromoDept"].ToString());
            }
            // return department details
            return details;
        }

        // retrieve the list of categories in a department
        public static DataTable GetCategoriesInDepartment(string departmentId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetCategoriesInDepartment";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentID";
            param.Value = departmentId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static string ToCategory(string departmentId, string categoryId, string
page)
        {
            if (page == "1")
                return BuildAbsolute(String.Format(
               "Catalog.aspx?DepartmentID={0}&CategoryID={1}",
               departmentId, categoryId));
            else
                return BuildAbsolute(String.Format(
               "Catalog.aspx?DepartmentID={0}&CategoryID={1}&Page={2}",
               departmentId, categoryId, page));
        }
        public static string ToCategory(string departmentId, string categoryId)
        {
            return ToCategory(departmentId, categoryId, "1");
        }
        public static string ToProduct(string productId)
        {
            return BuildAbsolute(String.Format("Product.aspx?ProductID={0}", productId));
        }
        public static string ToProductImage(string fileName)
        {
            // build product URL
            return BuildAbsolute("/ProductImages/" + fileName);
        }
    }
}