using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.DataAccess;

namespace VacationReservations
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the title of the page
            this.Title = VacationReservationsConfiguration.SiteName +
            " : Customer Details";

        }
    }
}