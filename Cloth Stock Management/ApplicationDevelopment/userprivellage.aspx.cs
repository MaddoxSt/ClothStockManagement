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
    public partial class userprivellage : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.userPrivilegeDetails();
        }

        protected void insertPrivilege(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("InsertPrivilege", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idBox.Text.ToString());
                cmd.Parameters.AddWithValue("@type", typeBox.Text.ToString());
                cmd.Parameters.AddWithValue("@password", passwordBox.Text.ToString());
                cmd.Parameters.AddWithValue("@recovery", ansBox.Text.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                idBox.Text = "";
                typeBox.Text = "";
                passwordBox.Text = "";
                ansBox.Text = "";
                userPrivilegeDetails();
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

        public void userPrivilegeDetails()
        {
            
        }
    }
}