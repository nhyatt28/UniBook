using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TEST_App
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "Penis Party!!! -->";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "You've been Dicked";
        }
    }
}