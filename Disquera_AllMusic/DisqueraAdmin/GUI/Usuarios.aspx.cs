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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        UsuariosBO obj;
        UsuariosDAO objdao;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new UsuariosBO();
            objdao = new UsuariosDAO();
            if (!Page.IsPostBack)
            {
                Facade("Select");
            }
        }

        public Usuarios()
        {
            conn = conexion.ObtenerConexion();
        }

        public UsuariosBO InterfaceToData()
        {
            obj.idUsuario = Convert.ToInt32(HiddenId.Value == "" ? "0" : HiddenId.Value);
            obj.Nombre = txtNombre.Text;
            obj.Usuario = txtUsuario.Text;
            obj.Password = txtContraseña.Text;

            return obj;
        }

        public void Guardar()
        {
            UsuariosBO us = InterfaceToData();
            if (us.idUsuario == 0)
            {
                objdao.Insert(us);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Modificar()
        {
            UsuariosBO us = InterfaceToData();
            if (us.idUsuario != 0)
            {
                objdao.Update(us);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Eliminar()
        {
            UsuariosBO us = InterfaceToData();
            if (us.idUsuario > 0)
            {
                objdao.Delete(us);
                Facade("Select");
            }
        }

        public void Select()
        {
            gvUsuarios.DataSource = objdao.Select();
            gvUsuarios.DataBind();
        }

        public void limpiarDatos()
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenId.Value = gvUsuarios.SelectedDataKey["idUsuario"].ToString();
            txtNombre.Text = gvUsuarios.SelectedRow.Cells[0].Text;
            txtUsuario.Text = gvUsuarios.SelectedRow.Cells[1].Text;
            txtContraseña.Text = gvUsuarios.SelectedRow.Cells[2].Text;
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public void Facade(string action)
        {
            switch (action)
            {
                case "Guardar":
                    Guardar();
                    break;
                case "Modificar":
                    Modificar();
                    break;
                case "Eliminar":
                    Eliminar();
                    break;
                case "Select":
                    Select();
                    break;
                case "limpiarDatos":
                    limpiarDatos();
                    break;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Facade("Guardar");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Facade("Modificar");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Facade("Eliminar");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string find = "select * from Usuarios where Nombre like('" + txtBuscar.Text + "%') or Usuario like('" + txtBuscar.Text + "%')";
                SqlDataAdapter dalistado = new SqlDataAdapter(find, conn);
                DataTable dtlistado = new DataTable();
                dalistado.Fill(dtlistado);
                this.gvUsuarios.DataSource = dtlistado;
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}