<%@ Page Title="" Language="C#" MasterPageFile="~/src/AdminAllMusic.Master" AutoEventWireup="true" CodeBehind="Disquera.aspx.cs" Inherits="DisqueraAdmin.GUI.Disquera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        <div class="left-align">
            
                <div class="row">
                    <div class="action">
                        <div class="col s12 m12 white-text">
                            <h4 class="title">Disquera</h4>
                        </div>
                    </div>
                </div>
        </div>

                <div class="row">
                    <div class="col s12 m12 text-center">
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
                            <label>Nombre de Disquera</label>
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
                <h4>Lista de Disqueras</h4>
        <div class="input-field col m8">
            <asp:TextBox runat="server" ID="txtBuscar" />
            <label>Buscar</label>
        </div>
        <div class="input-field col m4">
            
            <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn waves-effect" runat="server" OnClick="btnBuscar_Click"/>
        </div>

        <asp:GridView runat="server" ID="gvDisquera" CellPadding="4" 
            CssClass="responsive-table center striped" GridLines="None" 
            DataKeyNames="idDisquera" AutoGenerateColumns="false"
            OnSelectedIndexChanged="gvDisquera_SelectedIndexChanged"
            OnRowCommand="gvDisquera_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre de Disquera" />
                <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:Button Text="Eliminar" CssClass="btn btn-flat" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Seguro que desea eliminar el registro?')" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="HiddenId" runat="server" />
            </div>
        </div>
</asp:Content>
