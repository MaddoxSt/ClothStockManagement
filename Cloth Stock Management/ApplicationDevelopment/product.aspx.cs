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
    public partial class product : System.Web.UI.Page
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

                categoryDropDown.Items.Add(new ListItem("Male Small(S)"));
                categoryDropDown.Items.Add(new ListItem("Male Medium(M)"));
                categoryDropDown.Items.Add(new ListItem("Male Large(X)"));
                categoryDropDown.Items.Add(new ListItem("Male Drouble Large(XX)"));
                categoryDropDown.Items.Add(new ListItem("Male Triple Large(XXX)"));

                categoryDropDown.Items.Add(new ListItem("Female Small(S)"));
                categoryDropDown.Items.Add(new ListItem("Female Medium(M)"));
                categoryDropDown.Items.Add(new ListItem("Female Large(X)"));
                categoryDropDown.Items.Add(new ListItem("Female Drouble Large(XX)"));
                categoryDropDown.Items.Add(new ListItem("Female Triple Large(XXX)"));

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
                    searchDropDown.DataSource = cmd.ExecuteReader();
                    searchDropDown.DataTextField = "name";
                    searchDropDown.DataValueField = "product_id";
                    searchDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWproductID", sqlCon);
                    sqlCon.Open();
                    searchIDDropDown.DataSource = cmd.ExecuteReader();
                    searchIDDropDown.DataTextField = "product_id";
                    searchIDDropDown.DataValueField = "product_id";
                    searchIDDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWsupplierID", sqlCon);
                    sqlCon.Open();
                    supplierNameDropDown.DataSource = cmd.ExecuteReader();
                    supplierNameDropDown.DataTextField = "company_name";
                    supplierNameDropDown.DataValueField = "supplier_id";
                    supplierNameDropDown.DataBind();
                }

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DWsupplierID", sqlCon);
                    sqlCon.Open();
                    supplierIdDropDown.DataSource = cmd.ExecuteReader();
                    supplierIdDropDown.DataTextField = "supplier_id";
                    supplierIdDropDown.DataValueField = "supplier_id";
                    supplierIdDropDown.DataBind();
                }

                productIndexChanged(sender, e);
                supplierIndexChanged(sender, e);
                userIndexChanged(sender, e);
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

                SqlCommand cmd = new SqlCommand("INSERT_PRODUCT_RECORD", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@productId", idBox.Text.ToString());
                cmd.Parameters.AddWithValue("@productName", nameBox.Text.ToString());
                cmd.Parameters.AddWithValue("@description", descriptionBox.Text.ToString());
                cmd.Parameters.AddWithValue("@price", priceBox.Text.ToString());
                cmd.Parameters.AddWithValue("@purchaseDate", purchaseBox.Text.ToString());
                cmd.Parameters.AddWithValue("@category", categoryDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@userId", userDropDown.SelectedValue);
                cmd.Parameters.AddWithValue("@supplierId", supplierIdDropDown.SelectedValue);

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

        public void DisplayRecord()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand readTransaction = new SqlCommand("ReadProduct", sqlConnection);
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
            descriptionBox.Text = row.Cells[3].Text;
            priceBox.Text = row.Cells[4].Text;
            purchaseBox.Text = row.Cells[5].Text;
            categoryDropDown.SelectedValue = row.Cells[6].Text;
            userDropDown.SelectedValue = row.Cells[7].Text;
        }
        protected void updateBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                if (String.IsNullOrEmpty(idBox.Text.ToString()) || String.IsNullOrEmpty(nameBox.Text.ToString()))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myKey", "myFunction();", true);
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("UpdateProduct", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productId", idBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@productName", nameBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@description", descriptionBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@price", priceBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@purchaseDate", purchaseBox.Text.ToString());
                    cmd.Parameters.AddWithValue("@category", categoryDropDown.SelectedValue);
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
                SqlCommand cmd = new SqlCommand("DeleteProduct", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@psid", id);
                cmd.Parameters.AddWithValue("@pid", id);
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
            descriptionBox.Text = "";
            priceBox.Text = "";
            purchaseBox.Text = "";
        }

        protected void productIndexChanged(object sender, EventArgs e)
        {
            searchIDDropDown.SelectedValue = searchDropDown.SelectedValue;
            searchResult.Visible = false;
        }

        protected void supplierIndexChanged(object sender, EventArgs e)
        {
            supplierIdDropDown.SelectedValue = supplierNameDropDown.SelectedValue;
        }

        protected void searchBtnClicked(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand searchProduct= new SqlCommand("SearchProduct", sqlConnection);
                searchProduct.CommandType = CommandType.StoredProcedure;
                searchProduct.Parameters.AddWithValue("@id",searchIDDropDown.SelectedValue);
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

        protected void userIndexChanged(object sender, EventArgs e)
        {
            userIdDropDown.SelectedValue = userDropDown.SelectedValue;
        }

        protected void refreshPage()
        {
            Response.Redirect("~/product.aspx");
        }
    }
}