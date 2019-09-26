<%@ Page Title="" Language="C#" MasterPageFile="~/src/AdminAllMusic.Master" AutoEventWireup="true" CodeBehind="ArtistaDisquera.aspx.cs" Inherits="DisqueraAdmin.GUI.ArtistaDisquera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="left-align">
            
                <div class="row">
                    <div class="action">
                        <div class="col s12 m12 white-text">
                            <h4 class="title">Artistas por Disquera</h4>
                        </div>
                    </div>
                </div>
           
        </div>

        
                <div class="row">
                    <div class="col s12 m12 text-center">
                        <label>Artista</label>
                        <div class="input-field">
                            <asp:DropDownList ID="ddArtista" CssClass="browser-default" runat="server"></asp:DropDownList>
                        </div>
                        <label>Disquera</label>
                        <div class="input-field">
                            <asp:DropDownList runat="server" ID="ddDisquera" CssClass="browser-default"></asp:DropDownList>
                        </div>
                        <div class="input-field">
                            <asp:Button Text="Guardar" ID="btnGuardar" runat="server" CssClass="btn waves-effect waves-light" OnClick="btnGuardar_Click"/>
                            <asp:Button Text="Modificar" ID="btnModificar" runat="server" CssClass="btn waves-effect waves-light" OnClick="btnModificar_Click"/>
                        </div>
                    </div>
                </div>
           
    

    <div class="divider"></div>

    
        <div class="row">
            <div class="col s12 m12 text-center">
                <h4>Lista de Artistas por Disquera</h4>
                <div class="input-field col m8">
                    <asp:TextBox runat="server" ID="txtBuscar" />
                    <label>Buscar</label>
                </div>
                <div class="input-field col m4">
                    <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn waves-effect waves-light" runat="server" OnClick="btnBuscar_Click"/>
                </div>
                <asp:GridView runat="server" ID="gvArtistasDisquera" CellPadding="4" 
                    CssClass="responsive-table center striped" GridLines="None" 
                    DataKeyNames="idArtistaD" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gvArtistasDisquera_SelectedIndexChanged"
                    OnRowCommand="gvArtistasDisquera_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Artista" HeaderText="Artista" />
                        <asp:BoundField DataField="Disquera" HeaderText="Disquera" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:Button Text="Eliminar" CssClass="btn btn-flat" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Seguro que desea eliminar el registro?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField runat="server" ID="HiddenId" />
            </div>
        </div>
    
</asp:Content>
