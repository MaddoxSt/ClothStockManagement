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
    public partial class user : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["staff"] == null)
                Response.Redirect("~/Login.aspx");

            if (Session["admin"] != null)
            {

            }

            else
            {
                Response.Redirect("~/RestrictedPage.aspx");

            }
            if (!Page.IsPostBack)
            {
                DisplayRecord();
                updateBtn.Visible = false;
                cancelBtn.Visible = false;
                
            }
            
        }

        protected void insertUser(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("InsertUser", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idBox.Text.ToString());
                cmd.Parameters.AddWithValue("@name", nameBox.Text.ToString());
                cmd.Parameters.AddWithValue("@address", addressBox.Text.ToString());
                cmd.Parameters.AddWithValue("@contact", contactBox.Text.ToString());
                cmd.Parameters.AddWithValue("@email", emailBox.Text.ToString());
                cmd.Parameters.AddWithValue("@dob", dobBox.Text.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                idBox.Text = "";
                nameBox.Text = "";
                addressBox.Text = "";
                contactBox.Text = "";
                emailBox.Text = "";
                dobBox.Text = "";
                userDetails();
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

        public void userDetails()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ReadUser";
            cmd.Connection = con;

            try

            {
                con.Open();

                GridView1.EmptyDataText = "No Records Found";

                GridView1.DataSource = cmd.ExecuteReader();

                GridView1.DataBind();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                con.Close();

                con.Dispose();

            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            insertBtn.Visible = false;
            updateBtn.Visible = true;
            cancelBtn.Visible = true;

            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            idBox.Text = row.Cells[1].Text;
            idBox.ReadOnly = true;
            nameBox.Text = row.Cells[2].Text;
            addressBox.Text = row.Cells[3].Text;
            contactBox.Text = row.Cells[4].Text;
            emailBox.Text = row.Cells[5].Text;
            dobBox.Text = row.Cells[6].Text;
        }

        protected void clear()
        {
            idBox.Text = "";
            nameBox.Text = "";
            addressBox.Text = "";
            contactBox.Text = "";
            emailBox.Text = "";
            dobBox.Text = "";
        }

        public void DisplayRecord()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand readTransaction = new SqlCommand("ReadUser", sqlConnection);
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string id = row.Cells[1].Text;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DeleteUser", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", id);
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

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            insertBtn.Visible = true;
            updateBtn.Visible = false;
            cancelBtn.Visible = false;
            idBox.ReadOnly = false;
            clear();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (String.IsNullOrEmpty(idBox.Text.ToString()) || String.IsNullOrEmpty(nameBox.Text.ToString()) || String.IsNullOrEmpty(addressBox.Text.ToString()) || String.IsNullOrEmpty(contactBox .Text.ToString()) || String.IsNullOrEmpty(emailBox.Text.ToString()) || String.IsNullOrEmpty(dobBox.Text.ToString()))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myKey", "myFunction();", true);
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("UpdateTransactions", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", idBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@name", nameBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@address", addressBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@contact_no", contactBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@email", emailBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@date_of_birth", dobBox.Text.ToString());

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
            idBox.ReadOnly = false;
        }
    }
}