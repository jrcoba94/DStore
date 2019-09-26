<%@ Page Title="" Language="C#" MasterPageFile="~/src/AdminAllMusic.Master" AutoEventWireup="true" CodeBehind="Artistas.aspx.cs" Inherits="DisqueraAdmin.GUI.Artistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
        <div class="left-align">
            
                <div class="row">
                    <div class="action">
                        <div class="col s12 m12 white-text">
                            <h4 class="title">Artistas</h4>
                        </div>
                    </div>
                </div>
            
        </div>

                <div class="row">
                    <div class="col s12 m12 text-center">
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtNombreA" />
                            <label>Nombre Artistico</label>
                        </div>
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtNombreR" />
                            <label>Nombre Real</label>
                        </div>
                        <div class="input-field">
                            <asp:Button Text="Guardar" CssClass="btn waves-effect waves-light" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click"/>
                            <asp:Button Text="Modficar" CssClass="btn waves-effect waves-light" ID="btnModificar" runat="server" OnClick="btnModificar_Click"/>
                        </div>
                    </div>
                </div>
           

    <div class="divider"></div>

        <div class="row">
            <div class="col s12 m12 text-center">
                <h4>Lista de Artistas</h4>

                <div class="input-field col m8">
                    <asp:TextBox runat="server" ID="txtBuscar" />
                    <label>Buscar</label>
                </div>
                <div class="input-field col m4">
                    <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn waves-effect" runat="server" OnClick="btnBuscar_Click"/>
                </div>

                <asp:GridView runat="server" ID="gvArtistas" CellPadding="4" 
                    CssClass="responsive-table center striped" GridLines="None" 
                    DataKeyNames="idArtista" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gvArtistas_SelectedIndexChanged"
                    OnRowCommand="gvArtistas_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="NombreArtistico" HeaderText="Nombre Artistico" />
                        <asp:BoundField DataField="NombreReal" HeaderText="Nombre Real" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-flat" runat="server" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Seguro que desea eliminar el registro?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField runat="server" ID="HiddenId" />
            </div>
        </div>
</asp:Content>
