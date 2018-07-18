using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationDevelopment
{
    public partial class suppliers : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["staff"] == null)
                Response.Redirect("~/Login.aspx");

            if (!Page.IsPostBack)
            {
                updateBtn.Visible = false;
                cancelBtn.Visible = false;
                DisplayRecord();
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWuserID", sqlCon);
                    sqlCon.Open();
                    userDropDown.DataSource = cmd.ExecuteReader();
                    userDropDown.DataTextField = "name";
                    userDropDown.DataValueField = "user_id";
                    userDropDown.DataBind();
                }
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWuserID", sqlCon);
                    sqlCon.Open();
                    userIdDropDown.DataSource = cmd.ExecuteReader();
                    userIdDropDown.DataTextField = "user_id";
                    userIdDropDown.DataValueField = "user_id";
                    userIdDropDown.DataBind();
                }
                userIndexChanged(sender, e);
            }
        }

        protected void insertBtnClicked(object sender, EventArgs e)
        {
            SqlConnection mySqlConnection = new SqlConnection(connectionString);
            try
            {
                mySqlConnection.Open();
                SqlCommand cmd = new SqlCommand("INSERT_SUPPLIER_RECORD", mySqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //SqlCommand cmd = new SqlCommand("INSERT INTO supplier VALUES @supplierId,@companyName,@address,@contactNumber,@email,@contactPerson,@userId)", mySqlConnection);
                cmd.Parameters.AddWithValue("@supplierId", txtSupplierId.Text);
                cmd.Parameters.AddWithValue("@companyName", txtCompanyName.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@contactPerson", txtContactPerson.Text);
                cmd.Parameters.AddWithValue("@userId", userIdDropDown.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                DisplayRecord();
                clear();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Session.Remove("admin");
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Session.Remove("staff");
                Response.Redirect("~/Login.aspx");
            }
        }

        public void DisplayRecord()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand readTransaction = new SqlCommand("ReadSupplier", sqlConnection);
                readTransaction.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(readTransaction);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        protected void editBtnClicked(object sender, EventArgs e)
        {
            insertBtn.Visible = false;
            updateBtn.Visible = true;
            cancelBtn.Visible = true;

            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            txtSupplierId.Text = row.Cells[1].Text;
            txtSupplierId.ReadOnly = true;
            txtCompanyName.Text = row.Cells[2].Text;
            txtAddress.Text = row.Cells[3].Text;
            txtContactNumber.Text = row.Cells[4].Text;
            txtEmail.Text = row.Cells[5].Text;
            txtContactPerson.Text = row.Cells[6].Text;
            userDropDown.SelectedValue = row.Cells[7].Text;            
        }
        protected void updateBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (String.IsNullOrEmpty(txtSupplierId.Text.ToString()) || String.IsNullOrEmpty(txtCompanyName.Text.ToString()))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myKey", "myFunction();", true);
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("UpdateSupplier", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@supplierId", txtSupplierId.Text);
                    cmd.Parameters.AddWithValue("@companyName", txtCompanyName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@contactNumber", txtContactNumber.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@contactPerson", txtContactPerson.Text);
                    cmd.Parameters.AddWithValue("@userId", userDropDown.SelectedValue);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    clear();
                    DisplayRecord();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            insertBtn.Visible = true;
            updateBtn.Visible = false;
            cancelBtn.Visible = false;
            txtSupplierId.ReadOnly = false;

        }

        protected void cancelBtnClicked(object sender, EventArgs e)
        {
            insertBtn.Visible = true;
            updateBtn.Visible = false;
            cancelBtn.Visible = false;
            txtSupplierId.ReadOnly = false;
            clear();

        }

        protected void deleteBtnClicked(object sender, EventArgs e)
        {
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string id = row.Cells[1].Text;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DeleteSupplier", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                clear();
                DisplayRecord();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void clear()
        {
            txtSupplierId.Text = "";
            txtCompanyName.Text = "";
            txtAddress.Text = "";
            txtContactNumber.Text = "";
            txtEmail.Text = "";
            txtContactPerson.Text = "";
        }

        protected void userIndexChanged(object sender, EventArgs e)
        {
            userIdDropDown.SelectedValue = userDropDown.SelectedValue;
        }
    }
}