using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.DataAccess;

namespace VacationReservations
{
    public partial class OrderPlaced : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = VacationReservationsConfiguration.SiteName + " : Успешна поръчка";
        }

        protected override void OnInit(EventArgs e)
        {
            // Uncomment to enforce SSL (as explained in Chapter 16)
            // (Master as BalloonShop).EnforceSSL = true;
            base.OnInit(e);
        }   
    }
}