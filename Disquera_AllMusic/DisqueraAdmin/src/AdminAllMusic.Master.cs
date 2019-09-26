using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AllMusic_DLL.BO;
using AllMusic_DLL.DAO;

namespace DisqueraAdmin.src
{
    public partial class AdminAllMusic : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                int idUsuario = Convert.ToInt32(Session["Usuario"]);
                DataTable dt;
                UsuariosBO oUsuarioBO = new UsuariosBO();
                UsuariosDAO oUsuarioDAO = new UsuariosDAO();
                oUsuarioBO.idUsuario = idUsuario;
                dt = oUsuarioDAO.Select();
                txtUser.Text = dt.Rows[0]["Nombre"].ToString();
                //txtEmail.Text = dt.Rows[0]["Usuario"].ToString();
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
            //txtEmail.Text = "";
            lbtnSalir.Visible = false;
        }

        protected void lbtnSalir_Click(object sender, EventArgs e)
        {
            closeSession();
            ClearUser();
            Response.Redirect("Inicio.aspx");
        }
    }
}