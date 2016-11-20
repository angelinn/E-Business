using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.Common;
using VacationReservations.DataAccess;

namespace VacationReservations
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve ProductID from the query string
            string productId = Request.QueryString["ProductID"];
            // Retrieves product details
            ProductDetails pd = CatalogAccess.GetProductDetails(productId);
            // Does the product exist?
            if (pd.Name != null)
            {
                PopulateControls(pd);
            }
        }

        // Fill the control with data
        private void PopulateControls(ProductDetails pd)
        {
            // Display product details
            titleLabel.Text = pd.Name;
            descriptionLabel.Text = pd.Description;
            priceLabel.Text = String.Format("{0:c}", pd.Price);
            productImage.ImageUrl = "ProductImages/" + pd.Image;
            // Set the title of the page
            this.Title = VacationReservationsConfiguration.SiteName + pd.Name;

            string productId = pd.ProductID.ToString();
            // obtain the attributes of the product
            DataTable attrTable = CatalogAccess.GetProductAttributes(productId);
            // temp variables
            string prevAttributeName = "";
            string attributeName, attributeValue, attributeValueId;
            // current DropDown for attribute values
            Label attributeNameLabel;
            DropDownList attributeValuesDropDown = new DropDownList();
            // read the list of attributes
            foreach (DataRow r in attrTable.Rows)
            {
                // get attribute data
                attributeName = r["AttributeName"].ToString();
                attributeValue = r["AttributeValue"].ToString();
                attributeValueId = r["AttributeValueID"].ToString();
                // if starting a new attribute (e.g. Color, Size)
                if (attributeName != prevAttributeName)
                {
                    prevAttributeName = attributeName;
                    attributeNameLabel = new Label();
                    attributeNameLabel.Text = attributeName + ": ";
                    attributeValuesDropDown = new DropDownList();
                    attrPlaceHolder.Controls.Add(attributeNameLabel);
                    attrPlaceHolder.Controls.Add(attributeValuesDropDown);
                }
                // add a new attribute value to the DropDownList
                attributeValuesDropDown.Items.Add(new ListItem(attributeValue, attributeValueId));
            }
        }
    }
}
