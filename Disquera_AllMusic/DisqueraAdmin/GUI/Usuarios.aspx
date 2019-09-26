<%@ Page Title="" Language="C#" MasterPageFile="~/src/AdminAllMusic.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="DisqueraAdmin.GUI.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <h4>Usuarios</h4>
    
    <div class="row">
        <div class="input-field">
            <asp:textbox runat="server" ID="txtNombre" />
            <label>Nombre</label>
        </div>

        <div class="input-field">
            <asp:TextBox runat="server" ID="txtUsuario" />
            <label>Usuario</label>
        </div>

        <div class="input-field">
            <asp:TextBox runat="server" ID="txtContraseña" type="Password" />
            <label>Contraseña</label>
        </div>

        <div class="input-field">
            <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn waves-effect waves-light" runat="server" OnClick="btnGuardar_Click" />
            <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn waves-effect waves-light" runat="server" OnClick="btnModificar_Click" />
        </div>

    </div>

    <div class="divider"></div>

    <div class="row">
        <h4>Lista de Usuarios</h4>
        <div class="input-field col m8">
            <asp:TextBox runat="server" ID="txtBuscar" />
            <label>Buscar</label>
        </div>
        <div class="input-field col m4">
            
            <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn waves-effect" runat="server" OnClick="btnBuscar_Click" />
        </div>

        <asp:GridView runat="server" ID="gvUsuarios" CellPadding="4" CssClass="responsive-table center striped" GridLines="None" DataKeyNames="idUsuario" AutoGenerateColumns="false" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" OnRowCommand="gvUsuarios_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
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

</asp:Content>