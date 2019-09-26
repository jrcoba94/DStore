using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DisqueraAdmin.GUI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Salir();
        }

        public void Salir()
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}