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
    public partial class ArtistaDisquera : System.Web.UI.Page
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        ArtistasDisqueraBO obj;
        ArtistasDisqueraDAO objdao;

        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new ArtistasDisqueraBO();
            objdao = new ArtistasDisqueraDAO();

            if (!Page.IsPostBack)
            {
                Facade("Select");
                Facade("Combos");
            }
        }

        public ArtistaDisquera()
        {
            conn = conexion.ObtenerConexion();
        }

        public ArtistasDisqueraBO InterfaceToData()
        {
            obj.idAD = Convert.ToInt32(HiddenId.Value == ""?"0": HiddenId.Value);
            obj.idArtista = Convert.ToInt32(ddArtista.SelectedItem.Text);
            obj.idDisquera = Convert.ToInt32(ddDisquera.SelectedItem.Text);

            return obj;
        }

        public void CargarCombos()
        {
            ArtistasDAO art = new ArtistasDAO();
            ddArtista.DataSource = art.Select();
            ddArtista.DataTextField = "NombreArtistico";
            ddArtista.DataValueField = "idArtista";
            ddArtista.DataBind();

            DisqueraDAO disc = new DisqueraDAO();
            ddDisquera.DataSource = disc.Select();
            ddDisquera.DataTextField = "Nombre";
            ddDisquera.DataValueField = "idDisquera";
            ddDisquera.DataBind();
        }

        public void Guardar()
        {


            objdao.Insert(InterfaceToData());

            Facade("Select");
        }

        public void Modificar()
        {
            ArtistasDisqueraBO artD = InterfaceToData();
            if (artD.idAD != 0)
            {
                objdao.Update(artD);
            }
            Facade("Select");
        }

        public void Eliminar()
        {
            ArtistasDisqueraBO artD = InterfaceToData();
            if (artD.idAD > 0)
            {
                objdao.Delete(artD);
                Facade("Select");
            }
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
                case "Combos":
                    CargarCombos();
                    break;
            }
        }

        public void Select()
        {
            dsDisqueraAdminTableAdapters.ArtistaPorDisquera_vTableAdapter dt = new dsDisqueraAdminTableAdapters.ArtistaPorDisquera_vTableAdapter();
            gvArtistasDisquera.DataSource = dt.GetData();
            gvArtistasDisquera.DataBind();
            //gvArtistasDisquera.DataSource = objdao.Select();
            //gvArtistasDisquera.DataBind();
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

        protected void gvArtistasDisquera_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenId.Value = gvArtistasDisquera.SelectedDataKey["idArtistaD"].ToString();
            ddArtista.SelectedItem.Text = gvArtistasDisquera.SelectedRow.Cells[0].Text;
            ddDisquera.SelectedItem.Text = gvArtistasDisquera.SelectedRow.Cells[1].Text;
        }

        protected void gvArtistasDisquera_RowCommand(object sender, GridViewCommandEventArgs e)
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
                string find = "select * from ArtistasPorDisquera where idArtista like('" + txtBuscar.Text + "%') or idDisquera like('" + txtBuscar.Text + "%')";
                SqlDataAdapter dalistado = new SqlDataAdapter(find, conn);
                DataTable dtlistado = new DataTable();
                dalistado.Fill(dtlistado);
                this.gvArtistasDisquera.DataSource = dtlistado;
                gvArtistasDisquera.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}