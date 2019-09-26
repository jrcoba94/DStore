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
    public partial class Disquera : System.Web.UI.Page
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        DisqueraBO obj;
        DisqueraDAO objdao;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DisqueraBO();
            objdao = new DisqueraDAO();

            if (!Page.IsPostBack)
            {
                Facade("Select");
            }
        }

        public Disquera()
        {
            conn = conexion.ObtenerConexion();
        }

        public DisqueraBO InterfaceToData()
        {
            obj.idDisquera = Convert.ToInt32(HiddenId.Value == "" ? "0" : HiddenId.Value);
            obj.Nombre = txtNombre.Text;

            return obj;
        }

        public void Guardar()
        {
            DisqueraBO dis = InterfaceToData();
            if (dis.idDisquera == 0)
            {
                objdao.Insert(dis);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Modificar()
        {
            DisqueraBO dis = InterfaceToData();
            if (dis.idDisquera != 0)
            {
                objdao.Update(dis);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Eliminar()
        {
            DisqueraBO dis = InterfaceToData();
            if (dis.idDisquera > 0)
            {
                objdao.Delete(dis);
                Facade("Select");
            }
        }

        public void Select()
        {
            gvDisquera.DataSource = objdao.Select();
            gvDisquera.DataBind();
        }

        public void limpiarDatos()
        {
            txtNombre.Text = "";
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

        protected void gvDisquera_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenId.Value = gvDisquera.SelectedDataKey["idDisquera"].ToString();
            txtNombre.Text = gvDisquera.SelectedRow.Cells[0].Text;
        }

        protected void gvDisquera_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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
                string find = "select * from Disquera where Nombre like('" + txtBuscar.Text + "%') ";
                SqlDataAdapter dalistado = new SqlDataAdapter(find, conn);
                DataTable dtlistado = new DataTable();
                dalistado.Fill(dtlistado);
                this.gvDisquera.DataSource = dtlistado;
                gvDisquera.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}