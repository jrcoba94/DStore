using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AllMusic_DLL.BO;
using AllMusic_DLL.DAO;
using LibPrintTicket;

namespace DisqueraVentas.GUI
{
    public partial class ListaCompra : System.Web.UI.Page
    {
        DataTable dsCarritoDt = new DataTable();
        ClientesBO oClienteBO = new ClientesBO();
        ClientesDAO oClienteDAO = new ClientesDAO();
        double Total = 0;
        Ticket ticket = new Ticket();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Carrito();
                CalcularTotal();

            }
            if (Session["Usuario"] != null)
            {
                int idCliente = Convert.ToInt32(Session["Usuario"]);
                DataTable dt;
                
                oClienteBO.idCliente = idCliente;
                dt = oClienteDAO.Select();
                oClienteBO.Nombre = dt.Rows[0]["Nombre"].ToString();
            }
        }

        private void Carrito()
        {
            try
            {
                if (Session["Carrito"] != null)
                {
                    this.dsCarritoDt = (dsDisquera.dtDetalleCarritoDataTable)Session["Carrito"];
                }

                this.gvListaCompra.DataSource = this.dsCarritoDt;
                this.gvListaCompra.DataBind();
            }
            catch (Exception ex) { }
        }

        public double CalcularTotal()
        {
            foreach (GridViewRow row in gvListaCompra.Rows)
            {
                Total += double.Parse(row.Cells[3].Text);
            }
            return Total;
        }

        public void print()
        {
            Ticket ticket = new Ticket();
            ticket.FontSize = 10;
            ticket.FontName = "Arial";
            ticket.MaxCharDescription = 100;
            ticket.MaxChar = 50;
            
            ticket.AddHeaderLine("                      U-Sound                     ");
            ticket.AddHeaderLine(" ");
            ticket.AddHeaderLine("Cliente: " + oClienteBO.Nombre);
            ticket.AddHeaderLine(" ");
            ticket.AddHeaderLine("Expedido en: "+ DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine(" ");
            ticket.AddHeaderLine("Dirección de entrega:");
            ticket.AddHeaderLine(txtDireccionEnt.Text);
            ticket.AddHeaderLine(" ");
            ticket.AddHeaderLine("C.P. "+txtCP.Text);
            ticket.AddHeaderLine(" ");
            ticket.AddHeaderLine("'"+txtEstado.Text+"','"+txtEstado.Text+"'");
            ticket.AddHeaderLine(" ");
            ticket.AddHeaderLine("RFC: CSI-020226-MV4");

            ticket.AddSubHeaderLine("Ticket # 1");
            ticket.AddSubHeaderLine(DateTime.Now.ToShortTimeString());
            
            foreach(GridViewRow row in gvListaCompra.Rows){
                TextBox txt = row.FindControl("txtCantidad") as TextBox;
                ticket.AddItem("'" + txt.Text + "'", "'" + row.Cells[1].Text + "'","'" + row.Cells[4].Text + "'");
            }
            ticket.AddTotal("TOTAL", txtTotalC.Text);
            ticket.AddTotal("", "");

            ticket.AddFooterLine("Gracias");

            ticket.PrintTicket("Microsoft XPS Document Writer");
        }

        public void AddPedido()
        {
            dsDisqueraTableAdapters.PedidoTableAdapter dt = new dsDisqueraTableAdapters.PedidoTableAdapter();
            dt.InsertPedido(DateTime.Now.ToShortDateString(),oClienteBO.idCliente,txtDireccionEnt.Text,txtCP.Text,txtEstado.Text,txtTelefono.Text,Convert.ToDecimal(txtTotalC.Text));
        }

        public void AddDP()
        {
            dsDisqueraTableAdapters.DetallePedidoTableAdapter dt = new dsDisqueraTableAdapters.DetallePedidoTableAdapter();
            dsDisqueraTableAdapters.PedidoTableAdapter dtp = new dsDisqueraTableAdapters.PedidoTableAdapter();
            int idPedido = Convert.ToInt32(dtp.GetLastId().Rows[0]["idPedido"].ToString());
            foreach (GridViewRow row in gvListaCompra.Rows)
            {
                TextBox txt = row.FindControl("txtCantidad") as TextBox;
                dt.InsertDetallePedido(idPedido,Convert.ToInt32(row.Cells[0].Text),Convert.ToDecimal(row.Cells[3].Text),Convert.ToInt32(txt.Text),Convert.ToDecimal(row.Cells[4].Text));
            }
        }

        public void limpiar()
        {
            txtCP.Text = "";
            txtDireccionEnt.Text = "";
            txtEstado.Text = "";
            txtTelefono.Text = "";
        }

        protected void btnAgregarM_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Discos.aspx");
        }

        protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
        {
            AddPedido();
            AddDP();
            print();
            limpiar();
        }

        protected void gvListaCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int Codigo = int.Parse(gvListaCompra.DataKeys[index]["idDisco"].ToString());
                this.dsCarritoDt = (dsDisquera.dtDetalleCarritoDataTable)Session["Carrito"];
                dsCarritoDt.Rows.Remove(dsCarritoDt.Select("idDisco =" + Codigo)[0]);
                Session["Carrito"] = dsCarritoDt;
                gvListaCompra.DataSource = dsCarritoDt;
                gvListaCompra.DataBind();
            }

            if (e.CommandName == "Subtotal")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                TextBox txt = gvListaCompra.Rows[index].FindControl("txtCantidad") as TextBox;
                int Codigo = int.Parse(gvListaCompra.DataKeys[index]["idDisco"].ToString());
                int Cantidad = int.Parse(txt.Text);
                this.dsCarritoDt = (dsDisquera.dtDetalleCarritoDataTable)Session["Carrito"];
                dsCarritoDt.Rows[index]["Cantidad"] = Cantidad;
                dsCarritoDt.Rows[index]["Total"] = Cantidad * Convert.ToDouble(gvListaCompra.DataKeys[index]["PrecioUnitario"]);
                Session["Carrito"] = dsCarritoDt;
                gvListaCompra.DataSource = dsCarritoDt;
                gvListaCompra.DataBind();

                txtTotalC.Text = CalcularTotal().ToString();
            }
        }
    }
}