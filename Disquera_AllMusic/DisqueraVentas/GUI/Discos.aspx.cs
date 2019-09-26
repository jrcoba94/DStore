using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AllMusic_DLL.BO;
using AllMusic_DLL.DAO;
using DisqueraVentas.src;

namespace DisqueraVentas.GUI
{
    public partial class Discos : System.Web.UI.Page
    {
        DiscosBO oDiscoBO;
        DiscosDAO oDiscoDAO;
        ClientesBO oClienteBO;
        int countCard = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            oDiscoBO = new DiscosBO();
            oDiscoDAO = new DiscosDAO();
            oClienteBO = new ClientesBO();

            if (Session["Usuario"] != null)
            {
                Response.Write(Session["Usuario"].ToString());
                oClienteBO.idCliente = Convert.ToInt32(Session["Usuario"]);
            }

            FacadeMth("Listar");
        }

        public DiscosBO InterfaceToData()
        {
            oDiscoBO.idDisco = Convert.ToInt32(txtId.Value);

            return oDiscoBO;
        }

        private void FacadeMth(string accion)
        {
            switch (accion)
            {
                case "Listar":
                    Listado();
                    break;
                case "Limpia":
                    Limpiar();
                    break;
            }
        }

        public void Listado()
        {
            dsDisqueraTableAdapters.Disco_vTableAdapter prod = new dsDisqueraTableAdapters.Disco_vTableAdapter();
            gvDiscos.DataSource = prod.GetData();
            gvDiscos.DataBind();
        }

        public void Limpiar()
        {
            //txtId.Value = "";
            txtGenero.Text = "";
            txtArtista.Text = "";
            txtDisquera.Text = "";
        }

        protected void gvDiscos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnAdd = sender as ImageButton;
            GridViewRow gvr = (GridViewRow)btnAdd.NamingContainer;
            int index = gvr.RowIndex;
            int Codigo = 0;
            double total = 0;
            string Nombre = "";
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Codigo = int.Parse(gvDiscos.DataKeys[index]["idDisco"].ToString());
                    total = double.Parse(gvDiscos.DataKeys[index]["Precio"].ToString());
                    Nombre = gvDiscos.DataKeys[index]["Album"].ToString();

                    if (Session["Carrito"] != null)
                    {
                        dsDisquera.dtDetalleCarritoDataTable dt = (dsDisquera.dtDetalleCarritoDataTable)Session["Carrito"];
                        if (dt.Select("idDisco =" + Codigo).Length <= 0)
                        {
                            dt.Rows.Add(Codigo, Nombre, 1, total, total);
                            countCard += dt.Rows.Count;
                            countShop.Text = dt.Rows.Count.ToString();
                            Session["Carrito"] = dt;
                            //countCard += Convert.ToInt32(Session["Carrito"]);
                            countShop.Text = countCard.ToString();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", string.Format("<script> alert('El producto ya se encuentra en la lista!'); </script>"));
                            //Session["Carrito"] = dt;
                        }
                    }
                    else
                    {
                        dsDisquera.dtDetalleCarritoDataTable dt = new dsDisquera.dtDetalleCarritoDataTable();
                        if (dt.Select("idDisco = " + Codigo).Length <= 0)
                        {
                            dt.Rows.Add(Codigo, Nombre, 1, total, total);
                            Session["Carrito"] = dt;
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", string.Format("<script> alert('El producto ya se encuentra en la lista!');</script>"));
                            //Session["Carrito"] = dt;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            dsDisqueraTableAdapters.Disco_vTableAdapter prod = new dsDisqueraTableAdapters.Disco_vTableAdapter();
            gvDiscos.DataSource = prod.GetFilter(txtGenero.Text,txtArtista.Text,txtDisquera.Text);
            gvDiscos.DataBind();
            Limpiar();
        }

        protected void btnAgregarM_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ListaCompra.aspx");
        }
    }
}