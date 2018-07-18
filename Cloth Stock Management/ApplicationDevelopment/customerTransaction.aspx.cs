using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationDevelopment
{
    public partial class customerTransaction : System.Web.UI.Page
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
                qtyCheck.Visible = false;
                DisplayRecord();

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWuserID", sqlCon);
                    sqlCon.Open();
                    userNameDropDown.DataSource = cmd.ExecuteReader();
                    userNameDropDown.DataTextField = "name";
                    userNameDropDown.DataValueField = "user_id";
                    userNameDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWuserID", sqlCon);
                    sqlCon.Open();
                    userDropDown.DataSource = cmd.ExecuteReader();
                    userDropDown.DataTextField = "user_id";
                    userDropDown.DataValueField = "user_id";
                    userDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWcustomerID", sqlCon);
                    sqlCon.Open();
                    customerNameDropDown.DataSource = cmd.ExecuteReader();
                    customerNameDropDown.DataTextField = "name";
                    customerNameDropDown.DataValueField = "customer_id";
                    customerNameDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWcustomerID", sqlCon);
                    sqlCon.Open();
                    customerDropDown.DataSource = cmd.ExecuteReader();
                    customerDropDown.DataTextField = "customer_id";
                    customerDropDown.DataValueField = "customer_id";
                    customerDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWproductID", sqlCon);
                    sqlCon.Open();
                    productNameDropDown.DataSource = cmd.ExecuteReader();
                    productNameDropDown.DataTextField = "name";
                    productNameDropDown.DataValueField = "product_id";
                    productNameDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWproductID", sqlCon);
                    sqlCon.Open();
                    productDropDown.DataSource = cmd.ExecuteReader();
                    productDropDown.DataTextField = "product_id";
                    productDropDown.DataValueField = "product_id";
                    productDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWtransactionsID", sqlCon);
                    sqlCon.Open();
                    transactionDropDown.DataSource = cmd.ExecuteReader();
                    transactionDropDown.DataTextField = "transactions_id";
                    transactionDropDown.DataValueField = "transactions_id";
                    transactionDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWstockID", sqlCon);
                    sqlCon.Open();
                    stockDropDown.DataSource = cmd.ExecuteReader();
                    stockDropDown.DataTextField = "stock_id";
                    stockDropDown.DataValueField = "stock_id";
                    stockDropDown.DataBind();
                }

                userIndexChanged(sender, e);
                customerIndexChanged(sender, e);
                productIndexChanged(sender, e);
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
                sqlConnection.Open();
                SqlCommand getQtys = new SqlCommand("getQuantity", sqlConnection);
                getQtys.Parameters.AddWithValue("@tid", transactionDropDown.SelectedValue);
                getQtys.Parameters.AddWithValue("@sid", stockDropDown.SelectedValue);
                getQtys.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(getQtys);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
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

            insertRecord();
        }

        private void insertRecord() {
            int tra = Convert.ToInt32(GridView2.Rows[0].Cells[0].Text.ToString());
            int stk = Convert.ToInt32(GridView2.Rows[0].Cells[1].Text.ToString());
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (tra <= stk)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("InsertCustomerTranscation", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@transcationId", transactionDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@userId", userDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@customerId", customerDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@productId", productDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@stockId", stockDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@tquantity", tra);
                    cmd.Parameters.AddWithValue("@sid", stockDropDown.SelectedValue);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    DisplayRecord();
                }
                else
                {
                    qtyCheck.Visible = true;
                    qtyCheck.Text = "Sales quantity is " + tra.ToString() + " but Stock has only " + stk.ToString() + " quantity";
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
                SqlCommand readTransaction = new SqlCommand("ReadCT", sqlConnection);
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
            transactionDropDown.SelectedValue = row.Cells[1].Text;
            transactionDropDown.Enabled = false;
            userDropDown.SelectedValue= row.Cells[2].Text;
            customerDropDown.SelectedValue = row.Cells[3].Text;
            productDropDown.SelectedValue = row.Cells[4].Text;
            stockDropDown.SelectedValue= row.Cells[5].Text;
        }

        protected void updateBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("UpdateCS", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@transcationId", transactionDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@userId", userDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@customerId", customerDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@productId", productDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@stockId", stockDropDown.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
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

        protected void cancelBtnClicked(object sender, EventArgs e)
        {
            insertBtn.Visible = true;
            updateBtn.Visible = false;
            cancelBtn.Visible = false;
            transactionDropDown.Enabled = true;

        }

        protected void deleteBtnClicked(object sender, EventArgs e)
        {
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string tid = row.Cells[1].Text;
            string uid = row.Cells[2].Text;
            string cid = row.Cells[3].Text;
            string pid = row.Cells[4].Text;
            string sid = row.Cells[5].Text;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DeleteCS", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@sid", sid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
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

        protected void customerIndexChanged(object sender, EventArgs e)
        {
            customerDropDown.SelectedValue = customerNameDropDown.SelectedValue;
        }

        protected void userIndexChanged(object sender, EventArgs e)
        {
            userDropDown.SelectedValue = userNameDropDown.SelectedValue;
        }

        protected void productIndexChanged(object sender, EventArgs e)
        {
            productDropDown.SelectedValue = productNameDropDown.SelectedValue;
        }
    }
}