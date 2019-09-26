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
    public partial class Artistas : System.Web.UI.Page
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        ArtistasBO obj;
        ArtistasDAO objdao;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new ArtistasBO();
            objdao = new ArtistasDAO();
            if (!Page.IsPostBack)
            {
                Facade("Select");
            }
        }

        public Artistas()
        {
            conn = conexion.ObtenerConexion();
        }

        public ArtistasBO InterfaceToData()
        {
            obj.idArtista = Convert.ToInt32(HiddenId.Value == "" ? "0" : HiddenId.Value);
            obj.NombreArtistico = txtNombreA.Text;
            obj.NombreReal = txtNombreR.Text;

            return obj;
        }

        public void Guardar()
        {
            ArtistasBO art = InterfaceToData();
            if (art.idArtista == 0)
            {
                objdao.Insert(art);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Modificar()
        {
            ArtistasBO art = InterfaceToData();
            if (art.idArtista != 0)
            {
                objdao.Update(art);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Eliminar()
        {
            ArtistasBO art = InterfaceToData();
            if (art.idArtista > 0)
            {
                objdao.Delete(art);
                Facade("Select");
            }
        }

        public void Select()
        {
            gvArtistas.DataSource = objdao.Select();
            gvArtistas.DataBind();
        }

        public void limpiarDatos()
        {
            txtNombreA.Text = "";
            txtNombreR.Text = "";
        }

        protected void gvArtistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenId.Value = gvArtistas.SelectedDataKey["idArtista"].ToString();
            txtNombreA.Text = gvArtistas.SelectedRow.Cells[0].Text;
            txtNombreR.Text = gvArtistas.SelectedRow.Cells[1].Text;
        }

        protected void gvArtistas_RowCommand(object sender, GridViewCommandEventArgs e)
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
                string find = "select * from Artista where NombreArtistico like('" + txtBuscar.Text + "%') or NombreReal like('" + txtBuscar.Text + "%')";
                SqlDataAdapter dalistado = new SqlDataAdapter(find, conn);
                DataTable dtlistado = new DataTable();
                dalistado.Fill(dtlistado);
                this.gvArtistas.DataSource = dtlistado;
                gvArtistas.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}