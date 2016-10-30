using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

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
    }
}