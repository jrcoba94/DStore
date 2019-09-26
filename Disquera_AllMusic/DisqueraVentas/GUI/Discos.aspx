<%@ Page Title="" Language="C#" MasterPageFile="~/src/VentasAllMusic.Master" AutoEventWireup="true" CodeBehind="Discos.aspx.cs" Inherits="DisqueraVentas.GUI.Discos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section center">
        <h3>Tienda</h3>
    </div>
    <div class="section">
        <div class="row">
            <div class="col s12">
                <div class="row">
                    <div class="col s3 input-field">
                        <asp:TextBox ID="txtGenero" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <label for="first_name">Género Musical</label>
                    </div>
                    <div class="col s3 input-field">
                        <asp:TextBox ID="txtArtista" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <label for="first_name">Artista</label>
                    </div>
                    <div class="col s3 input-field">
                        <asp:TextBox ID="txtDisquera" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <label for="first_name">Disquera</label>
                    </div>
                    <div class="col s2 input-field">
                        <asp:ImageButton ID="btnBusqueda" runat="server" ImageUrl="~/src/Img/ic_search_white_36dp.png" CssClass="btn btn-floating btn-blue-green-light waves-effect waves-light z-depth-4" OnClick="btnBusqueda_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="section container">
        <div class="row col s12 m12">
            <asp:ImageButton ID="btnAgregarM" runat="server" CssClass="z-depth-3 btn btn-block btn-blue-green-light waves-effect waves-light" ImageUrl="~/src/Img/ic_shopping_cart_white_36dp.png" OnClick="btnAgregarM_Click" /><span class="new badge fixed"><asp:Label ID="countShop" runat="server"></asp:Label></span>
        </div>
    </div>
    
    <div class="section container">
        <asp:GridView ID="gvDiscos" runat="server" CssClass="responsive-table"
            AutoGenerateColumns="false" CellPadding="4" CellSpacing="2" GridLines="Horizontal"
            DataKeyNames="idDisco,Album,Portada,Anio,No. de pistas,Precio,Género Musical,Artista,Disquera"
            OnRowCommand="gvDiscos_RowCommand" OnSelectedIndexChanged="gvDiscos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="idDisco" HeaderText="idDisco" Visible="false" />
                <asp:ImageField DataImageUrlFormatString="~/Albums/{0}" DataImageUrlField="Portada" HeaderText="Portada" Visible="false">
                    <ControlStyle Height="100px" Width="100px" />
                    <ItemStyle Height="110px" Width="110px" />
                </asp:ImageField>
                <asp:BoundField DataField="Album" HeaderText="Álbum" />
                <asp:BoundField DataField="Anio" HeaderText="Año" />
                <asp:BoundField DataField="No. de pistas" HeaderText="No. de pistas" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:$ 0.0}" />
                <asp:BoundField DataField="Género Musical" HeaderText="Género Musical" Visible="false" />
                <asp:BoundField DataField="Artista" HeaderText="Artista" />
                <asp:BoundField DataField="Disquera" HeaderText="Disquera" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/src/Img/ic_add_shopping_cart_black_18dp.png" OnClick="btnAdd_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:HiddenField ID="txtId" runat="server" />
</asp:Content>
