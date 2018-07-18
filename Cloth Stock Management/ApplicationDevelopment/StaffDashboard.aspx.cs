using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace ApplicationDevelopment
{
    public partial class StaffDashboard : System.Web.UI.Page
    {
        ArrayList productIDArray = new ArrayList();
        ArrayList quantityArray = new ArrayList();

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["staff"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                GridView2.Visible = false;
                itemNotSold();
            }

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                //query of ques no 9
                string query = "SELECT distinct pd.name, st.TotalQuantity FROM stock AS s JOIN(SELECT product_id, SUM(quantity) AS TotalQuantity FROM stock GROUP BY product_id ) AS st ON s.product_id = st.product_id JOIN product pd on s.product_id = pd.product_id WHERE st.TotalQuantity <= 10; ";
                SqlCommand stockOut = new SqlCommand(query, sqlConnection);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(stockOut);
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
                    GridView1.Rows[0].Cells[0].Text = "No items are running out of stock";
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

            try
            {
                sqlConnection.Open();
                //query of ques no 11
                string query = "SELECT distinct pd.product_id, pd.name FROM stock AS s JOIN(SELECT product_id, SUM(quantity) AS TotalQuantity FROM stock GROUP BY product_id) AS st ON s.product_id = st.product_id JOIN product pd on s.product_id = pd.product_id WHERE st.TotalQuantity = 0; ";
                SqlCommand stockOut = new SqlCommand(query, sqlConnection);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(stockOut);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView3.Rows[0].Cells.Clear();
                    GridView3.Rows[0].Cells.Add(new TableCell());
                    GridView3.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView3.Rows[0].Cells[0].Text = "No items are out of stock";
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

            try
            {
                sqlConnection.Open();

                //query used to generate chart
                string query = "select productId, SUM(quantity) AS TotalQuantity from(select p.product_id As productId, p.name AS name, t.quantity AS quantity from product p join customertransactions ct on ct.product_id = p.product_id join transactions t on t.transactions_id = ct.transactions_id) AS result GROUP BY productId; ";
                SqlCommand stockOut = new SqlCommand(query, sqlConnection);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(stockOut);
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
                    int columncount = GridView2.Rows[0].Cells.Count;
                    GridView2.Rows[0].Cells.Clear();
                    GridView2.Rows[0].Cells.Add(new TableCell());
                    GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView2.Rows[0].Cells[0].Text = "No items are sold Yet";
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
            getData();
            chart_generate();
        }

        public void TotalStock()
        {

        }

        public void TotalProduct()
        {

        }

        public void OutOfStock()
        {

        }

        private void itemNotSold()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                //query of ques no 10
                string query = "select distinct id, name from (select distinct p.product_id AS id, p.name as name, t.transactions_date AS date from product p inner join stock s on s.product_id = p.product_id inner join customertransactions ct on ct.stock_id = s.stock_id inner join transactions t on t.transactions_id = ct.transactions_id) as result where date<DateADD(DAY, -60, GETDATE()); ";
                SqlCommand itemNotSold = new SqlCommand(query, sqlConnection);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(itemNotSold);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    longTimeStock.DataSource = ds;
                    longTimeStock.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    longTimeStock.DataSource = ds;
                    longTimeStock.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    longTimeStock.Rows[0].Cells.Clear();
                    longTimeStock.Rows[0].Cells.Add(new TableCell());
                    longTimeStock.Rows[0].Cells[0].ColumnSpan = columncount;
                    longTimeStock.Rows[0].Cells[0].Text = "No items on the stock which are not sold in these 2 months";
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

        protected void deleteBtnClicked(object sender, EventArgs e)
        {
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string id = row.Cells[1].Text;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("delete from product where product_id=@id", sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
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

        private void chart_generate()
        {
            double total;
            string productId;

            Series series = Chart1.Series["Series1"];
            series.Points.Clear();
            for (int a = 0; a < quantityArray.Count; a++)
            {
                total = Convert.ToDouble(quantityArray[a]);
                productId = Convert.ToString(productIDArray[a]);
                series.Points.AddXY(productId, total);
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

        private void getData()
        {
            double quantity;
            string id;
            for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
            {
                if (GridView2.Rows.Count > 1)
                {
                    id = GridView2.Rows[i].Cells[0].Text.ToString();
                    quantity = Convert.ToDouble(GridView2.Rows[i].Cells[1].Text.ToString());

                    if (productIDArray.Contains(id))
                    {
                        int index = productIDArray.IndexOf(id);
                        double value = Convert.ToDouble(quantityArray[index]);
                        value = value + quantity;
                        quantityArray[index] = value;
                    }
                    else
                    {
                        productIDArray.Add(id);
                        quantityArray.Add(quantity);
                    }
                }
            }
        }
    }
}