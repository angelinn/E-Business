using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.DataAccess;

namespace VacationReservations
{
    public partial class AdminDepartments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load the grid only the first time the page is loaded
            if (!Page.IsPostBack)
            {
                // Load the departments grid
                BindGrid();
            }
        }

        // Populate the GridView with data
        private void BindGrid()
        {
            // Get a DataTable object containing the catalog departments
            gvMain.DataSource = CatalogAccess.GetDepartments();
            // Bind the data bound controls to the data source
            gvMain.DataBind();
        }

        protected void gvMain_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row for which to enable edit mode
            gvMain.EditIndex = e.NewEditIndex;
            // Set status message
            lblStatus.Text = "Редактиране на ред # " + e.NewEditIndex.ToString();
            // Reload the grid
            BindGrid();
        }

        protected void gvMain_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            gvMain.EditIndex = -1;
            // Set status message
            lblStatus.Text = "Редактирането спряно";
            // Reload the grid
            BindGrid();
        }

        protected void gvMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the ID of the record to be deleted
            string id = gvMain.DataKeys[e.RowIndex].Value.ToString();
            // Execute the delete command
            bool success = CatalogAccess.DeleteDepartment(id);
            // Cancel edit mode
            gvMain.EditIndex = -1;
            // Display status message
            lblStatus.Text = success ? "Изтриването успешно" : "Изтриването неуспешно";
            // Reload the grid
            BindGrid();
        }

        protected void gvMain_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Retrieve updated data
            string id = gvMain.DataKeys[e.RowIndex].Value.ToString();
            string name = ((TextBox)gvMain.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            string description = ((TextBox)gvMain.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
            // Execute the update command
            bool success = CatalogAccess.UpdateDepartment(id, name, description);
            // Cancel edit mode
            gvMain.EditIndex = -1;
            // Display status message
            lblStatus.Text = success ? "Обновяването успешно" : "Обновяването неуспешно";
            // Reload the g
            BindGrid();
        }

        protected void createDepartment_Click(object sender, EventArgs e)
        {
            // Execute the insert command
            bool success = CatalogAccess.AddDepartment(newName.Text, newDescription.Text);
            // Display status message
            lblStatus.Text = success ? "Въвеждането успешно" : "Въеждането неуспешно";
            // Reload the grid
            BindGrid();
        }
    }
}