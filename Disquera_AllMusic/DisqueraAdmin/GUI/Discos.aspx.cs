using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using AllMusic_DLL.BO;
using AllMusic_DLL.DAO;

namespace DisqueraAdmin.GUI
{
    public partial class Discos : System.Web.UI.Page
    {
        protected SqlConnection conn;
        Conexion conexion = new Conexion();

        DiscosBO obj;
        DiscosDAO objdao;
        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new DiscosBO();
            objdao = new DiscosDAO();
            if (!Page.IsPostBack)
            {
                Facade("Select");
                Facade("Combos");
            }
        }

        public Discos()
        {
            conn = conexion.ObtenerConexion();
        }

        public DiscosBO InterfaceToData()
        {
            obj.idDisco = Convert.ToInt32(HiddenId.Value == "" ? "0" : HiddenId.Value);
            obj.Nombre = txtNombre.Text;
            obj.Anio = txtAnio.Text;
            obj.TotalPistas = Convert.ToInt32(txtTotalPistas.Text);
            obj.Precio = Convert.ToDecimal(txtPrecio.Text);
            obj.idGenero = Convert.ToInt32(ddGenero.Text);
            obj.idDisquera = Convert.ToInt32(ddDisquera.Text);
            obj.idArtista = Convert.ToInt32(ddArtista.Text);
            subirImagen();
            return obj;
        }

        public void subirImagen()
        {
            if (uploadImage.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(uploadImage.FileName);
                    uploadImage.SaveAs(Server.MapPath("~/Albums/") + fileName);
                    obj.Foto = fileName;
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void Combos()
        {
            GeneroDAO gen = new GeneroDAO();
            ddGenero.DataSource = gen.Select();
            ddGenero.DataTextField = "NombreGenero";
            ddGenero.DataValueField = "idGenero";
            ddGenero.DataBind();

            DisqueraDAO disc = new DisqueraDAO();
            ddDisquera.DataSource = disc.Select();
            ddDisquera.DataTextField = "Nombre";
            ddDisquera.DataValueField = "idDisquera";
            ddDisquera.DataBind();

            ArtistasDAO art = new ArtistasDAO();
            ddArtista.DataSource = art.Select();
            ddArtista.DataTextField = "NombreArtistico";
            ddArtista.DataValueField = "idArtista";
            ddArtista.DataBind();
        }

        public void Guardar()
        {
            DiscosBO disc = InterfaceToData();
            if (disc.idDisco == 0)
            {
                objdao.Insert(disc);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Modificar()
        {
            DiscosBO disc = InterfaceToData();
            if (disc.idDisco != 0)
            {
                objdao.Update(disc);
            }
            Facade("Select");
            Facade("limpiarDatos");
        }

        public void Eliminar()
        {
            DiscosBO disc = InterfaceToData();
            if (disc.idDisco > 0)
            {
                objdao.Delete(disc);
                Facade("Select");
            }
        }

        public void Select()
        {
            var dt = objdao.Select();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Foto"] = "~/Albums/" + dt.Rows[i]["Foto"].ToString();
                var nombre = dt.Rows[i]["Foto"].ToString();
            }
            gvDiscos.DataSource = dt;
            gvDiscos.DataBind();
        }

        public void limpiarDatos()
        {
            txtNombre.Text = "";
            txtAnio.Text = "";
            txtTotalPistas.Text = "";
            txtPrecio.Text = "";
        }

        protected void gvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenId.Value = gvDiscos.SelectedDataKey["idDisco"].ToString();
            txtNombre.Text = gvDiscos.SelectedRow.Cells[0].Text;
            txtAnio.Text = gvDiscos.SelectedRow.Cells[1].Text;
            txtTotalPistas.Text = gvDiscos.SelectedRow.Cells[2].Text;
            txtPrecio.Text = gvDiscos.SelectedRow.Cells[3].Text;
            ddGenero.Text = gvDiscos.SelectedRow.Cells[4].Text;
            ddDisquera.Text = gvDiscos.SelectedRow.Cells[5].Text;
            ddArtista.Text = gvDiscos.SelectedRow.Cells[6].Text;
        }

        protected void gvDiscos_RowCommand(object sender, GridViewCommandEventArgs e)
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
                case "Combos":
                    Combos();
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
                string find = "select * from Discos where Nombre like('" + txtBuscar.Text + "%') or Anio like('" + txtBuscar.Text + "%') or TotalPistas like('" + txtBuscar.Text + "%') or Precio like('" + txtBuscar.Text + "%') ";
                SqlDataAdapter dalistado = new SqlDataAdapter(find, conn);
                DataTable dtlistado = new DataTable();
                dalistado.Fill(dtlistado);
                this.gvDiscos.DataSource = dtlistado;
                gvDiscos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}