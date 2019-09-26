using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AllMusic_DLL.BO;
using AllMusic_DLL.DAO;

namespace DisqueraVentas.src
{
    public partial class VentasAllMusic : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                int idCliente = Convert.ToInt32(Session["Usuario"]);
                DataTable dt;
                ClientesBO oClienteBO = new ClientesBO();
                ClientesDAO oClienteDAO = new ClientesDAO();
                oClienteBO.idCliente = idCliente;
                dt = oClienteDAO.Select();
                txtUser.Text = dt.Rows[0]["Nombre"].ToString();
                txtEmail.Text = dt.Rows[0]["CorreoElectronico"].ToString();
                lbtnSalir.Visible = true;
            }
        }

        public void closeSession()
        {
            Session["Usuario"] = null;
        }

        public void ClearUser()
        {
            txtUser.Text = "";
            txtEmail.Text = "";
            lbtnSalir.Visible = false;
        }

        
        protected void lbtnSalir_Click(object sender, EventArgs e)
        {
            closeSession();
            ClearUser();
            Response.Redirect("Inicio.aspx");
        }

        //closeSession();
            //ClearUser();
            //Response.Redirect("Inicio.aspx");
    }
}