﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using VacationReservations.Common;

namespace VacationReservations.DataAccess
{
    public static class CatalogAccess
    {
        static CatalogAccess()
        {

        }

        public static DataTable GetDepartments()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetDepartments";
            // execute the stored procedure and return the results
            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

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

        // get department details
        public static DepartmentDetails GetDepartmentDetails(string departmentId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetDepartmentDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentID";
            param.Value = departmentId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // wrap retrieved data into a DepartmentDetails object
            DepartmentDetails details = new DepartmentDetails();
            if (table.Rows.Count > 0)
            {
                details.Name = table.Rows[0]["Name"].ToString();
                details.Description = table.Rows[0]["Description"].ToString();
            }
            // return department details
            return details;
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

        public static DataTable GetProductsOnFrontPromo(string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductsOnFrontPromo";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = VacationReservationsConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = VacationReservationsConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters
          ["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)VacationReservationsConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }

        // retrieve the list of products featured for a department
        public static DataTable GetProductsOnDeptPromo
        (string departmentId, string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductsOnDeptPromo";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentID";
            param.Value = departmentId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = VacationReservationsConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = VacationReservationsConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts /
                           (double)VacationReservationsConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }

        // retrieve the list of products in a category
        public static DataTable GetProductsInCategory
        (string categoryId, string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductsInCategory";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CategoryID";
            param.Value = categoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = VacationReservationsConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";

            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = VacationReservationsConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts /
                           (double)VacationReservationsConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }

        public static DataTable GetProductAttributes(string productId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogGetProductAttributeValues";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ProductID";
            param.Value = productId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and return the results
            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public static DataTable Search(string searchString, string allWords,
    string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "SearchCatalog";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = VacationReservationsConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@AllWords";
            param.Value = allWords.ToUpper() == "TRUE" ? "1" : "0";
            param.DbType = DbType.Byte;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = VacationReservationsConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyResults";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // define the maximum number of words
            int howManyWords = 5;
            // transform search string into array of words
            string[] words = Regex.Split(searchString, "[^a-zA-Zа-яА-Я0-9]+");

            // add the words as stored procedure parameters
            int index = 1;
            for (int i = 0; i <= words.GetUpperBound(0) && index <= howManyWords; i++)
                // ignore short words
                if (words[i].Length > 2)
                {
                    // create the @Word parameters
                    param = comm.CreateParameter();
                    param.ParameterName = "@Word" + index.ToString();
                    param.Value = words[i];
                    param.DbType = DbType.String;
                    comm.Parameters.Add(param);
                    index++;
                }

            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts =
          Int32.Parse(comm.Parameters["@HowManyResults"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts /
                           (double)VacationReservationsConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }

        // Update department details
        public static bool UpdateDepartment(string id, string name, string description)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogUpdateDepartment";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentId";
            param.Value = id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DepartmentName";
            param.Value = name;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DepartmentDescription";
            param.Value = description;
            param.DbType = DbType.String;
            param.Size = 1000;
            comm.Parameters.Add(param);
            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        // Delete department
        public static bool DeleteDepartment(string id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogDeleteDepartment";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentId";
            param.Value = id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure; an error will be thrown by the
            // database if the department has related categories, in which case
            // it is not deleted
            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }
        // Add a new department
        public static bool AddDepartment(string name, string description)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "CatalogAddDepartment";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentName";
            param.Value = name;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DepartmentDescription";
            param.Value = description;
            param.DbType = DbType.String;
            param.Size = 1000;
            comm.Parameters.Add(param);
            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }
    }
}
