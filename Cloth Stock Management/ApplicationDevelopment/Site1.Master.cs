using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationDevelopment
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["staff"] == null)
                Response.Redirect("~/Login.aspx");

            if (Session["admin"] != null)
            {
                userLabel.Text = "Admin";
            }
            else
            {
                userLabel.Text = "Staff";
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {

        }
    }
}