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
    public partial class stock : System.Web.UI.Page
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
                GridView2.Visible = false;

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

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWproductID", sqlCon);
                    sqlCon.Open();
                    productDropDown.DataSource = cmd.ExecuteReader();
                    productDropDown.DataTextField = "name";
                    productDropDown.DataValueField = "product_id";
                    productDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWproductID", sqlCon);
                    sqlCon.Open();
                    productIDDropDown.DataSource = cmd.ExecuteReader();
                    productIDDropDown.DataTextField = "product_id";
                    productIDDropDown.DataValueField = "product_id";
                    productIDDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWstockID", sqlCon);
                    sqlCon.Open();
                    searchIDDropDown.DataSource = cmd.ExecuteReader();
                    searchIDDropDown.DataTextField = "stock_id";
                    searchIDDropDown.DataValueField = "stock_id";
                    searchIDDropDown.DataBind();
                }

                stockIndexChanged(sender, e);
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

                SqlCommand cmd = new SqlCommand("InsertStock", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@stockId", idBox.Text.ToString());
                cmd.Parameters.AddWithValue("@quantity", qtyBox.Text.ToString());
                cmd.Parameters.AddWithValue("@stockDate", stockDateBox.Text.ToString());
                cmd.Parameters.AddWithValue("@userId", userDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@productId", productDropDown.SelectedValue);
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
            refreshPage();
        }

        private void clear()
        {
            idBox.Text = "";
            qtyBox.Text = "";
            stockDateBox.Text = "";
        }

        public void DisplayRecord()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand readTransaction = new SqlCommand("ReadStock", sqlConnection);
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
            idBox.Text = row.Cells[1].Text;
            idBox.ReadOnly = true;
            qtyBox.Text = row.Cells[2].Text;
            stockDateBox.Text = row.Cells[3].Text;
            userDropDown.ClearSelection();
            userDropDown.SelectedValue = row.Cells[4].Text; ;
            productDropDown.SelectedValue = row.Cells[5].Text;
        }
        protected void updateBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (String.IsNullOrEmpty(idBox.Text.ToString()) || String.IsNullOrEmpty(qtyBox.Text.ToString()))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myKey", "myFunction();", true);
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("UpdateStock", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stockId", idBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@quantity", qtyBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@stockDate", stockDateBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@userId", userDropDown.SelectedValue);
                    cmd.Parameters.AddWithValue("@productId", productDropDown.SelectedValue);

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

        protected void deleteBtnClicked(object sender, EventArgs e)
        {
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string id = row.Cells[1].Text;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DeleteStock", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stockId", id);
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
            refreshPage();
        }

        protected void searchBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand searchProduct = new SqlCommand("SearchStock", sqlConnection);
                searchProduct.CommandType = CommandType.StoredProcedure;
                searchProduct.Parameters.AddWithValue("@id", searchIDDropDown.SelectedValue);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(searchProduct);
                da.Fill(ds);
                searchResult.DataSource = ds;
                searchResult.DataBind();
                searchResult.Visible = true;
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

        protected void stockIndexChanged(object sender, EventArgs e)
        {
            searchResult.Visible = false;
        }

        protected void userIndexChanged(object sender, EventArgs e)
        {
            userIdDropDown.SelectedValue = userDropDown.SelectedValue;
        }

        protected void productIndexChanged(object sender, EventArgs e)
        {
            productIDDropDown.SelectedValue = productDropDown.SelectedValue;
        }

        private void refreshPage() {
            Response.Redirect("~/stock.aspx");
        }

        protected void displayStock(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                string query = "select distinct id, name from (select p.product_id As id, p.name AS name, s.stock_id As sid, s.quantity AS sq, ct.transactions_id AS cti, t.transactions_date ctd from stock s left join product p on s.product_id = p.product_id left join customertransactions ct on ct.stock_id = s.stock_id left join transactions t on t.transactions_id = ct.transactions_id) result where cti IS NULL or ctd < DateADD(DAY, -31, GETDATE()); ";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView2.Rows[0].Cells.Clear();
                    GridView2.Rows[0].Cells.Add(new TableCell());
                    GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView2.Rows[0].Cells[0].Text = "Every item in the stock has sold in this 31 days";
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
    }
}