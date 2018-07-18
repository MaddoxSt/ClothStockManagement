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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        private void Clear()
        {
            idBox.Text = "";
            newPasswordBox.Text = "";

        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-RVF1OET\SQLEXPRESS; Initial Catalog = ClothStockManagement; Integrated Security = True;"))
            {
                con.Open();
                string query = "select * from user_privilege";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (idBox.Text == dr["user_id"].ToString())
                    {
                        using (SqlConnection con1 = new SqlConnection(@"Data Source =DESKTOP-RVF1OET\SQLEXPRESS; Initial Catalog = ClothStockManagement; Integrated Security = True;"))
                        {
                            con1.Open();
                            string query1 = "select * from user_privilege update user_privilege set password = '" + MD5Hash(newPasswordBox.Text) + "' where user_id = '" + idBox.Text + "'";
                            SqlCommand cmd1 = new SqlCommand(query1, con1);
                            cmd1.ExecuteNonQuery();
                            messageBox.Text = "Passoword changed succesfully";
                            messageBox.ForeColor = System.Drawing.Color.Green;
                            Clear();
                            return;
                        }
                    }
                    else
                    {
                        messageBox.Text = "Invalid Credentials";
                        messageBox.ForeColor = System.Drawing.Color.Red;
                    }
                }
                dr.Close();
                con.Close();

            }


        }

    }
}