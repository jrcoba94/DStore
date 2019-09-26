<%@ Page Title="" Language="C#" MasterPageFile="~/src/VentasAllMusic.Master" AutoEventWireup="true" CodeBehind="ListaCompra.aspx.cs" Inherits="DisqueraVentas.GUI.ListaCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="left-align" style="background: rgba(52, 60, 65, 0.69)">
            <div class="container">
                <div class="row">
                    <div class="action">
                        <div class="col s12 m12 white-text">
                            <h1 class="title">Lista de compra</h1>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="section container">
        <div class="row col s12 m12">
            <asp:ImageButton ID="btnAgregarM" runat="server" CssClass="z-depth-3 btn btn-block btn-blue-green-light waves-effect waves-light" ImageUrl="~/src/Img/ic_add_shopping_cart_white_36dp.png" OnClick="btnAgregarM_Click" />
            <asp:ImageButton ID="btnImprimir" runat="server" CssClass="z-depth-3 btn btn-block btn-blue-green-light waves-effect waves-light" ImageUrl="~/src/Img/ic_print_white_36dp.png" OnClick="btnImprimir_Click" />
        </div>
    </div>
    <div class="section container">
        <div class="row col s12 m12">
            <div class="input-field col s3 m3">
                <asp:TextBox ID="txtDireccionEnt" runat="server"></asp:TextBox>
                <label for="first_name">Dirección</label>
            </div>
            <div class="input-field  col s3 m3">
                <asp:TextBox ID="txtCP" runat="server"></asp:TextBox>
                <label for="first_name">C.P.</label>
            </div>
            <div class="input-field  col s3 m3">
                <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
                <label for="first_name">Estado</label>
            </div>
            <div class="input-field  col s3 m3">
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                <label for="first_name">Teléfono</label>
            </div>
        </div>
    </div>
    <div class="section container">
        <asp:GridView ID="gvListaCompra" runat="server" CellPadding="4"
            CssClass="responsive-table" GridLines="None"
            DataKeyNames="idDisco,PrecioUnitario" AutoGenerateColumns="false"
            ForeColor="#333333" OnRowCommand="gvListaCompra_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="idDisco"/>
                <asp:BoundField DataField="Album" HeaderText="Disco" />

                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCantidad" runat="server" Text='<%#Eval("Cantidad")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnitario" DataFormatString="{0:C}" />
                <asp:BoundField HeaderText="Sub-Total" DataField="Total" DataFormatString="{0:C}" />

                <asp:ButtonField Text="Calcular" HeaderText="Calcular Subtotal" CommandName="Subtotal" />
                <asp:ButtonField Text="Eliminar" HeaderText="Quitar" CommandName="Eliminar" />
            </Columns>

            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="true" ForeColor="#333333" />
        </asp:GridView>
    </div>

    <div class="section container">
        <div class="row">
            <div class="input-field">
                <label>Total:</label>
                <asp:TextBox ID="txtTotalC" runat="server" Enabled="false"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
