using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.DataAccess;

namespace VacationReservations.UserControls
{
    public partial class CategoriesList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string departmentId = Request.QueryString["DepartmentID"];
            if (departmentId != null)
            {
                // Catalog.GetCategoriesInDepartment returns a DataTable
                // object containing category data, which is displayed by the DataList
                dlCategories.DataSource = CatalogAccess.GetCategoriesInDepartment(departmentId);
                // Needed to bind the data bound controls to the data source
                dlCategories.DataBind();
            }
        }
    }
}