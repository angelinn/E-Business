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
            dlDepartments.DataSource = CatalogAccess.GetDepartments();
            dlDepartments.DataBind();
        }
    }
}