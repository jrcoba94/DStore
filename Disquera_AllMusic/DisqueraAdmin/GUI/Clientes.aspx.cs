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
    public partial class Clientes : System.Web.UI.Page
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        ClientesBO obj;
        ClientesDAO objdao;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new ClientesBO();
            objdao = new ClientesDAO();
            if (!Page.IsPostBack)
            {
                Facade("Select");
            }
        }

        public Clientes()
        {
            conn = conexion.ObtenerConexion();
        }

        public ClientesBO InterfaceToData()
        {
            obj.idCliente = Convert.ToInt32(HiddenId.Value == "" ? "0" : HiddenId.Value);
            obj.Nombre = txtNombre.Text;
            obj.Ciudad = txtCiudad.Text;
            obj.CorreoElectronico = txtCorreoElectronico.Text;
            obj.Password = txtPassword.Text;

            return obj;
        }

        public void Guardar()
        {
            ClientesBO cl = InterfaceToData();
            if (cl.idCliente == 0)
            {
                objdao.Insert(cl);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Modificar()
        {
            ClientesBO cl = InterfaceToData();
            if (cl.idCliente != 0)
            {
                objdao.Update(cl);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Eliminar()
        {
            ClientesBO cl = InterfaceToData();
            if (cl.idCliente > 0)
            {
                objdao.Delete(cl);
                Facade("Select");
            }
        }

        public void Select()
        {
            gvClientes.DataSource = objdao.Select();
            gvClientes.DataBind();
        }

        public void limpiarDatos()
        {
            txtNombre.Text = "";
            txtCiudad.Text = "";
            txtCorreoElectronico.Text = "";
            txtPassword.Text = "";
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenId.Value = gvClientes.SelectedDataKey["idCliente"].ToString();
            txtNombre.Text = gvClientes.SelectedRow.Cells[0].Text;
            txtCiudad.Text = gvClientes.SelectedRow.Cells[1].Text;
            txtCorreoElectronico.Text = gvClientes.SelectedRow.Cells[2].Text;
            txtPassword.Text = gvClientes.SelectedRow.Cells[3].Text;
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void btnGuaradar_Click(object sender, EventArgs e)
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
                string find = "select * from Clientes where Nombre like('" + txtBuscar.Text + "%') or Ciudad like('" + txtBuscar.Text + "%') or CorreoElectronico like('" + txtBuscar.Text + "%') ";
                SqlDataAdapter dalistado = new SqlDataAdapter(find, conn);
                DataTable dtlistado = new DataTable();
                dalistado.Fill(dtlistado);
                this.gvClientes.DataSource = dtlistado;
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}