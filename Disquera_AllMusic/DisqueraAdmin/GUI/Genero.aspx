<%@ Page Title="" Language="C#" MasterPageFile="~/src/AdminAllMusic.Master" AutoEventWireup="true" CodeBehind="Genero.aspx.cs" Inherits="DisqueraAdmin.GUI.Genero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        <div class="left-align">
            
                <div class="row">
                    <div class="action">
                        <div class="col s12 m12 white-text">
                            <h4 class="title">Género</h4>
                        </div>
                    </div>
                </div>
        </div>

                <div class="row">
                    <div class="col s12 m12 text-center">
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtNombreGenero" />
                            <label>Nombre de Genero</label>
                        </div>
                        <div class="input-field">
                            <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn waves-effect waves-light" runat="server" OnClick="btnGuardar_Click"/>
                            <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn waves-effect waves-light" runat="server" OnClick="btnModificar_Click"/>
                        </div>
                    </div>
                </div>
          

    <div class="divider"></div>

        <div class="row">
            <div class="col s12 m12 text-center">
                <h4>Lista de Generos</h4>
                <div class="input-field col m8">
                    <asp:TextBox runat="server" ID="txtBuscar" />
                    <label>Buscar</label>
                </div>
                <div class="input-field col m4">

                    <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn waves-effect" runat="server" OnClick="btnBuscar_Click"/>
                </div>

                <asp:GridView runat="server" ID="gvGenero" 
                    CssClass="responsive-table center striped" CellPadding="4" 
                    GridLines="None" DataKeyNames="idGenero" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gvGenero_SelectedIndexChanged"
                    OnRowCommand="gvGenero_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="NombreGenero" HeaderText="Nombre de Genero" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-flat" runat="server" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Seguro que desea eliminar el registro?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="HiddenId" runat="server" />
            </div>
        </div>
</asp:Content>
