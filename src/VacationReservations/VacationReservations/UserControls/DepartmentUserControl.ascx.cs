using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.DataAccess;
using VacationReservations.Common;

namespace VacationReservations.UserControls
{
    public partial class DepartmentUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // CatalogAccess.GetDepartments returns a DataTable object containing
                // department data, which is read in the ItemTemplate of the DataList
                dlDepartments.DataSource = CatalogAccess.GetDepartments();
                // Needed to bind the data bound controls to the data source
                dlDepartments.DataBind();
            }
        }
    }
}