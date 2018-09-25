using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace crudGridView_01
{
    public partial class Default : System.Web.UI.Page
    {
        string sqlConnectionString = @"Server=localhost\SQLEXPRESS;Database=TestDb;Trusted_Connection=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        /// <summary>
        /// load grid data
        /// </summary>
        public void loadGrid()
        {
            DataTable dtbl = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(sqlConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM PhoneBook", sqlCon);
                dataAdapter.Fill(dtbl);
            }

            gvPhoneBook.DataSource = dtbl;
            gvPhoneBook.DataBind();
        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(sqlConnectionString))
                    {
                        sqlCon.Open();
                        string query = @"INSERT INTO [dbo].[PhoneBook] ([FirstName],[LastName],[Contact],[Email]) VALUES (@FirstName,@LastName,@Contact,@Email)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", (gvPhoneBook.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (gvPhoneBook.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        loadGrid();
                        lblSuccessMessage.Text = "New Row added successfully";
                        lblErrorMessage.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = string.Empty;
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;
            loadGrid();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex = -1;
            loadGrid();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(sqlConnectionString))
                {
                    sqlCon.Open();
                    string query = @"UPDATE PhoneBook SET FirstName = @FirstName,LastName = @LastName,Contact = @Contact,Email = @Email where phoneBookID = @Id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    loadGrid();
                    lblSuccessMessage.Text = "Row updated successfully";
                    lblErrorMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = string.Empty;
                lblErrorMessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// row deleting event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(sqlConnectionString))
                {
                    sqlCon.Open();
                    string query = @"DELETE from PhoneBook where phoneBookID = @Id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    loadGrid();
                    lblSuccessMessage.Text = "Row deleted successfully";
                    lblErrorMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = string.Empty;
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}