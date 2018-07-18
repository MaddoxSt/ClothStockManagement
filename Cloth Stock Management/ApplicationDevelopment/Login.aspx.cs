using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationDevelopment
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logout();
        }

        protected string MD5Hash(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(new UTF8Encoding().GetBytes(input));
            for (int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString("x2"));
            }
            return stringBuilder.ToString();

        }

        public void Logout()
        {
            if (Session["admin"] == null)
            {
                Session.Remove("admin");
            }
            else
            {
                Session.Remove("staff");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-RVF1OET\SQLEXPRESS;Initial Catalog=ClothStockManagement;Integrated Security=True;"))
            {
                con.Open();
                string query = "select user_type from user_privilege where user_id=@username and password=@password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", userNameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@password", MD5Hash(passwordBox.Text.Trim()));

                SqlDataReader reader = cmd.ExecuteReader();
                if (!(reader.Read()))
                {
                    messageBox.Text = "Sorry invalid Credentials!";
                    messageBox.ForeColor = System.Drawing.Color.Red;

                }
                else if (reader[0].ToString() == "Staff")
                {

                    Session["staff"] = userNameBox.Text;

                    Response.Redirect("StaffDashboard.aspx");
                }
                else
                {
                    Session["admin"] = userNameBox.Text;
                    Response.Redirect("AdminDashboard.aspx");
                }
            }
        }

    }
}