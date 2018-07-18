using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationDevelopment
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userTypeDW.Items.Insert(0, new ListItem("Admin"));
            userTypeDW.Items.Insert(1, new ListItem("Staff"));
        }

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


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

        //protected void FillDropDropDown()
        //{
        //    string str = "select * from user_privellage";
        //    SqlDataAdapter da = new SqlDataAdapter(str, connectionString);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "user_privellage");
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        userTypeBox.DataSource = ds.Tables[0];
        //        userTypeBox.DataTextField = "user_type";
        //        userTypeBox.DataBind();
        //        userTypeBox.Items.Insert(0, "Select a user type");
        //        userTypeBox.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        userTypeBox.DataSource = null;
        //        userTypeBox.DataBind();
        //        userTypeBox.Items.Insert(0, "Select a user type");
        //        userTypeBox.SelectedIndex = 0;
        //    }
        //}

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("Register_User", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", idBox.Text.ToString());
                cmd.Parameters.AddWithValue("@name", nameBox.Text.ToString());
                cmd.Parameters.AddWithValue("@address", addressBox.Text.ToString());
                cmd.Parameters.AddWithValue("@contact_no", contactBox.Text.ToString());
                cmd.Parameters.AddWithValue("@email", emailBox.Text.ToString());
                cmd.Parameters.AddWithValue("@date_of_birth", dobBox.Text.ToString());
                cmd.Parameters.AddWithValue("@user_type", userTypeDW.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@password", MD5Hash(passwordBox.Text.ToString()));
                cmd.Parameters.AddWithValue("@recover_ans", recoveryAnsBox.Text.ToString());

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                clear();

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
            idBox.Text = "";
            nameBox.Text = "";
            contactBox.Text = "";
            addressBox.Text = "";
            emailBox.Text = "";
            dobBox.Text = "";
            passwordBox.Text = "";
            rePasswordBox.Text = "";
            recoveryAnsBox.Text = "";
        }
    }
}