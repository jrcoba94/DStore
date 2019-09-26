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
    public partial class Genero : System.Web.UI.Page
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        GeneroBO obj;
        GeneroDAO objdao;

        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new GeneroBO();
            objdao = new GeneroDAO();
            if (!Page.IsPostBack)
            {
                Facade("Select");
            }
        }

        public Genero()
        {
            conn = conexion.ObtenerConexion();
        }

        public GeneroBO InterfaceToData()
        {
            obj.idGenero = Convert.ToInt32(HiddenId.Value == "" ? "0" : HiddenId.Value);
            obj.NombreGenero = txtNombreGenero.Text;

            return obj;
        }

        public void Guardar()
        {
            GeneroBO gen = InterfaceToData();
            if (gen.idGenero == 0)
            {
                objdao.Insert(gen);
            }
            Facade("Select");
            Facade("limpiarDatos");

        }

        public void Modificar()
        {
            GeneroBO gen = InterfaceToData();
            if (gen.idGenero != 0)
            {
                objdao.Update(gen);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Eliminar()
        {
            GeneroBO gen = InterfaceToData();
            if (gen.idGenero > 0)
            {
                objdao.Delete(gen);
                Facade("Select");
            }
        }

        public void Select()
        {
            gvGenero.DataSource = objdao.Select();
            gvGenero.DataBind();
        }

        public void limpiarDatos()
        {
            txtNombreGenero.Text = "";
        }

        protected void gvGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenId.Value = gvGenero.SelectedDataKey["idGenero"].ToString();
            txtNombreGenero.Text = gvGenero.SelectedRow.Cells[0].Text;
        }

        protected void gvGenero_RowCommand(object sender, GridViewCommandEventArgs e)
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
                string find = "select *  from Genero where NombreGenero like('" + txtBuscar.Text + "%')";
                SqlDataAdapter dalistado = new SqlDataAdapter(find, conn);
                DataTable dtlistado = new DataTable();
                dalistado.Fill(dtlistado);
                this.gvGenero.DataSource = dtlistado;
                gvGenero.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}