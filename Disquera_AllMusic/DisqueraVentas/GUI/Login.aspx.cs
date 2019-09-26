using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using AllMusic_DLL.DAO;

namespace DisqueraVentas.GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected SqlConnection cnn;
        Conexion conexion = new Conexion();

        public Login()
        {
            cnn = conexion.ObtenerConexion();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUser.Text = "cm.ru76@gmail.com";
            txtPassword.Text = "cm@5678";
        }

        public void Loguear()
        {
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Clientes where CorreoElectronico = '" + txtUser.Text + "' and Password = '" + txtPassword.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Session["Usuario"] = dr["idCliente"].ToString();
                Response.Redirect("Discos.aspx");
            }

            cnn.Close();
            //lblAlerta.Text = "Credenciales incorrectas";
        }

        public void limpiar()
        {
            txtUser.Text = "";
            txtPassword.Text = "";
        }

        protected void btlRegistro_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Loguear();
        }
    }
}