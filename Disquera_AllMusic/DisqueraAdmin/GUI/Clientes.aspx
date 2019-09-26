<%@ Page Title="" Language="C#" MasterPageFile="~/src/AdminAllMusic.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="DisqueraAdmin.GUI.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div class="left-align">
            
                <div class="row">
                    <div class="action">
                        <div class="col s12 m12 white-text">
                            <h4 class="title">Cliente</h4>
                        </div>
                    </div>
                </div>
            
        </div>

                <div class="row">
                    <div class="col s12 m12 text-center">
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtNombre" />
                            <label>Nombre</label>
                        </div>
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtCiudad" />
                            <label>Ciudad</label>
                        </div>
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtCorreoElectronico" />
                            <label>Correo Eletronico</label>
                        </div>
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtPassword" type="Password" />
                            <label>Contraseña</label>
                        </div>
                        <div class="input-field">
                            <asp:Button Text="Guardar" ID="btnGuaradar" CssClass="btn waves-effect waves-light" runat="server" OnClick="btnGuaradar_Click"/>
                            <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn waves-effect waves-light" runat="server" OnClick="btnModificar_Click"/>
                        </div>
                    </div>
                </div>
           

    <div class="divider"></div>

        <div class="row">
            <div class="col s12 m12 text-center">
                <h4>Lista de Clientes</h4>

                <div class="input-field col m8">
                    <asp:TextBox runat="server" ID="txtBuscar" />
                    <label>Buscar</label>
                </div>
                <div class="input-field col m4">
                    <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn waves-effect" runat="server" OnClick="btnBuscar_Click"/>
                </div>

                <asp:GridView runat="server" ID="gvClientes" CellPadding="4" 
                    CssClass="responsive-table center striped" GridLines="None" 
                    DataKeyNames="idCliente" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gvClientes_SelectedIndexChanged"
                    OnRowCommand="gvClientes_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                        <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo" />
                        <asp:BoundField DataField="Password" HeaderText="Contraseña" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
                        <asp:TemplateField FooterText="Eliminar">
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
