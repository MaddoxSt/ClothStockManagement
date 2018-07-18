using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationDevelopment
{
    public partial class customer : System.Web.UI.Page
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
                purchaseGrid.Visible = false;
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
                    userIdDropDown.DataTextField = "name";
                    userIdDropDown.DataValueField = "user_id";
                    userIdDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWcustomerID", sqlCon);
                    sqlCon.Open();
                    searchDropDown.DataSource = cmd.ExecuteReader();
                    searchDropDown.DataTextField = "name";
                    searchDropDown.DataValueField = "customer_id";
                    searchDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWcustomerID", sqlCon);
                    sqlCon.Open();
                    searchIDDropDown.DataSource = cmd.ExecuteReader();
                    searchIDDropDown.DataTextField = "customer_id";
                    searchIDDropDown.DataValueField = "customer_id";
                    searchIDDropDown.DataBind();
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

                customerIndexChanged(sender, e);
                userIndexChanged(sender, e);
                cusIndexChanged(sender, e);
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

                SqlCommand cmd = new SqlCommand("InsertCustomer", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idBox.Text.ToString());
                cmd.Parameters.AddWithValue("@name", nameBox.Text.ToString());
                cmd.Parameters.AddWithValue("@address", addressBox.Text.ToString());
                cmd.Parameters.AddWithValue("@contact", contactBox.Text.ToString());
                cmd.Parameters.AddWithValue("@email", emailBox.Text.ToString());
                cmd.Parameters.AddWithValue("@user_id", userDropDown.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                clear();
                DisplayRecord();
            }
            catch (SqlException ex){

                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            refreshPage();
        }

        public void DisplayRecord()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand readTransaction = new SqlCommand("ReadCustomer", sqlConnection);
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
            nameBox.Text = row.Cells[2].Text;
            addressBox.Text = row.Cells[3].Text;
            contactBox.Text = row.Cells[4].Text;
            emailBox.Text = row.Cells[5].Text;
            userDropDown.SelectedValue = row.Cells[6].Text;
        }
        protected void updateBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (String.IsNullOrEmpty(idBox.Text.ToString()) || String.IsNullOrEmpty(nameBox.Text.ToString()) || String.IsNullOrEmpty(addressBox.Text.ToString()))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myKey", "myFunction();", true);
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("UpdateCustomer", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", idBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@name", nameBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@address", addressBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@contact", contactBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@email", emailBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@user_id", userDropDown.SelectedValue);

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
                SqlCommand cmd = new SqlCommand("DeleteCustomer", sqlConnection);
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
            refreshPage();
        }

        private void clear()
        {
            idBox.Text = "";
            nameBox.Text = "";
            addressBox.Text = "";
            contactBox.Text = "";
            emailBox.Text = "";
        }

        protected void customerIndexChanged(object sender, EventArgs e)
        {
            searchIDDropDown.SelectedValue = searchDropDown.SelectedValue;
            searchResult.Visible = false;
        }

        protected void searchBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand searchCustomer = new SqlCommand("SearchCustomer", sqlConnection);
                searchCustomer.CommandType = CommandType.StoredProcedure;
                searchCustomer.Parameters.AddWithValue("@id", searchIDDropDown.SelectedValue);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(searchCustomer);
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

        protected void userIndexChanged(object sender, EventArgs e)
        {
            userIdDropDown.SelectedValue = userDropDown.SelectedValue;
        }

        protected void refreshPage()
        {
            Response.Redirect("~/customer.aspx");
        }

        protected void cusIndexChanged(object sender, EventArgs e)
        {
            customerDropDown.SelectedValue = customerNameDropDown.SelectedValue;
            purchaseGrid.Visible = false;
        }

        protected void purchaseCust(object sender, EventArgs e)
        {
            purchaseGrid.Visible = true;
            string id = customerDropDown.SelectedValue;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                string query = "select id, name, date, quantity, payment_amount from (select c.customer_id id, p.name AS name, t.transactions_date AS date, t.quantity AS quantity, t.payment_amount AS payment_amount from customer c left join customertransactions ct on c.customer_id = ct.customer_id left join product p on ct.product_id = p.product_id left join transactions t on t.transactions_id = ct.transactions_id) result where id = @id AND date<DateADD(DAY, -31, GETDATE()); ";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    purchaseGrid.DataSource = ds;
                    purchaseGrid.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    purchaseGrid.DataSource = ds;
                    purchaseGrid.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    purchaseGrid.Rows[0].Cells.Clear();
                    purchaseGrid.Rows[0].Cells.Add(new TableCell());
                    purchaseGrid.Rows[0].Cells[0].ColumnSpan = columncount;
                    purchaseGrid.Rows[0].Cells[0].Text = "This customer have not purchase any item in last 31 days";
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

        protected void unactiveCustomer(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                string query = "SELECT distinct c.customer_id, c.name from customer c INNER JOIN customertransactions ct ON c.customer_id = ct.customer_id INNER JOIN transactions t on ct.transactions_id = t.transactions_id WHERE t.transactions_date <= DATEADD(DAY, -31, getdate()); ";
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
                    GridView2.Rows[0].Cells[0].Text = "Every customer in the list have purchase item in this 31 days";
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