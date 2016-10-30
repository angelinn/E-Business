using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace VacationReservations.App_Code.DataAccess
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
    }
}