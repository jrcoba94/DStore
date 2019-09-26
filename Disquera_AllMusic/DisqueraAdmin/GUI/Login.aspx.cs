using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using AllMusic_DLL.BO;
using AllMusic_DLL.DAO;

namespace DisqueraAdmin.GUI
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
            txtUser.Text = "JoseR";
            txtPassword.Text = "jc@1234";
        }

        public void Loguear()
        {
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Usuarios where Usuario = '" + txtUser.Text + "' and Password = '" + txtPassword.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Session["Usuario"] = dr["idUsuario"].ToString();
                Response.Redirect("Inicio.aspx");
            }

            cnn.Close();
            lblAlerta.Text = "Credenciales incorrectas";
        }

     

        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            Loguear();
        }
    }
}