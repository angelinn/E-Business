using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.Common;
using VacationReservations.DataAccess;

namespace VacationReservations
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // fill the table contents
                string searchString = Request.QueryString["Search"];
                lblFirst.Text = "Product Search";
                lblSecond.Text = "You searched for \"" + searchString + "\"";
                // set the title of the page
                this.Title = VacationReservationsConfiguration.SiteName +
                " : Product Search : " + searchString;
            }
        }
    }
}
