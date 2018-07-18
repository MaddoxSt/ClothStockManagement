using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationDevelopment

{
    public partial class transactions : System.Web.UI.Page
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

            }

            if (!Page.IsPostBack)
            {
                DisplayRecord();
                updateBtn.Visible = false;
                cancelBtn.Visible = false;
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

        protected void insertBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (String.IsNullOrEmpty(idBox.Text.ToString()) || String.IsNullOrEmpty(dateBox.Text.ToString()) || String.IsNullOrEmpty(paymentBox.Text.ToString()) || String.IsNullOrEmpty(quantityBox.Text.ToString()))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myKey", "myFunction();", true);
                }
                else
                {
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("INSERT_TRANSACTION_RECORD", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@transactionsId", idBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@transactionsDate", dateBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@paymentAmount", paymentBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@quantity", quantityBox.Text.ToString());

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
        }

        public void DisplayRecord()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand readTransaction = new SqlCommand("ReadTransactions", sqlConnection);
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

        protected void editBtnClicked(object sender, EventArgs e) {
            insertBtn.Visible = false;
            updateBtn.Visible = true;
            cancelBtn.Visible = true; 

            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            idBox.Text = row.Cells[1].Text;
            idBox.ReadOnly = true;
            dateBox.Text = row.Cells[2].Text;
            paymentBox.Text = row.Cells[3].Text;
            quantityBox.Text = row.Cells[4].Text;
        }

        protected void updateBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (String.IsNullOrEmpty(idBox.Text.ToString()) || String.IsNullOrEmpty(dateBox.Text.ToString()) || String.IsNullOrEmpty(paymentBox.Text.ToString()) || String.IsNullOrEmpty(quantityBox.Text.ToString()))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myKey", "myFunction();", true);
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("UpdateTransactions", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tid", idBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@tdate", dateBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@amt", paymentBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@qty", quantityBox.Text.ToString());

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

        protected void cancelBtnClicked(object sender, EventArgs e)
        {
            insertBtn.Visible = true;
            updateBtn.Visible = false;
            cancelBtn.Visible = false;
            idBox.ReadOnly = false;
            clear();

        }

        protected void deleteBtnClicked(object sender, EventArgs e) {
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string id = row.Cells[1].Text;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DeleteTransactions", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@transactionsId", id);
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

        protected void clear()
        {
            idBox.Text = "";
            dateBox.Text = "";
            paymentBox.Text = "";
            quantityBox.Text = "";
        }
    }

    
}