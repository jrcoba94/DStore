<%@ Page Title="" Language="C#" MasterPageFile="~/src/AdminAllMusic.Master" AutoEventWireup="true" CodeBehind="Discos.aspx.cs" Inherits="DisqueraAdmin.GUI.Discos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="left-align">

        <div class="row">
            <div class="action">
                <%--<div class="col s12 m12 white-text">--%>
                <h4 class="title">Disco</h4>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col s12 m12 text-center">
            <label>Nombre</label>
            <div class="input-field">
                <asp:TextBox runat="server" ID="txtNombre" />
            </div>
            <label>Año</label>
            <div class="input-field">
                <asp:TextBox runat="server" ID="txtAnio" />
            </div>
            <label>Total de Pistas</label>
            <div class="input-field">
                <asp:TextBox runat="server" ID="txtTotalPistas" />
            </div>
            <label>Precio</label>
            <div class="input-field">
                <asp:TextBox runat="server" ID="txtPrecio" />
            </div>
            <label>Género</label>
            <div class="input-field">
                <asp:DropDownList runat="server" ID="ddGenero" CssClass="browser-default">
                </asp:DropDownList>
            </div>
            <label>Disquera</label>
            <div class="input-field">
                <asp:DropDownList runat="server" ID="ddDisquera" CssClass="browser-default">
                </asp:DropDownList>
            </div>
            <label>Artista</label>
            <div class="input-field">
                <asp:DropDownList runat="server" ID="ddArtista" CssClass="browser-default">
                </asp:DropDownList>
            </div>
            <div class="input-field">
                <div class="btn btn-green">
                    <span>Subir Imagen</span>
                    <asp:FileUpload runat="server" type="file" ID="uploadImage" />
                </div>
                <div class="file-path-wrapper">
                    <input class="file-path validate" type="text" />
                </div>
            </div>
            <div class="input-field">
                <asp:Button Text="Guardar" ID="btnGuardar" runat="server" CssClass="btn waves-effect waves-light" OnClick="btnGuardar_Click" />
                <asp:Button Text="Modificar" ID="btnModificar" runat="server" CssClass="btn waves-effect waves-light" OnClick="btnModificar_Click" />
            </div>
        </div>
    </div>



    <div class="divider"></div>


    <div class="row">
        <div class="col s12 m12 text-center">
            <h4>Lista de Discos</h4>
            <div class="input-field col m8">
                <asp:TextBox runat="server" ID="txtBuscar" />
                <label>Buscar</label>
            </div>
            <div class="input-field col m4">

                <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn waves-effect" runat="server" OnClick="btnBuscar_Click" />
            </div>

            <asp:GridView runat="server" ID="gvDiscos" CellPadding="4"
                CssClass="responsive-table center striped" GridLines="None"
                DataKeyNames="idDisco" AutoGenerateColumns="false"
                OnSelectedIndexChanged="gvDiscos_SelectedIndexChanged"
                OnRowCommand="gvDiscos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Anio" HeaderText="Año" />
                    <asp:BoundField DataField="TotalPistas" HeaderText="Total Pistas" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="idGenero" HeaderText="Genero" />
                    <asp:BoundField DataField="idDisquera" HeaderText="Disquera" />
                    <asp:BoundField DataField="idArtista" HeaderText="Artista" />
                    <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto">
                        <ControlStyle Height="100px" Width="100px" />
                        <ItemStyle Height="110px" Width="110px" />
                    </asp:ImageField>
                    <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:Button Text="Eliminar" ID="btnEliminar" runat="server" CssClass="btn btn-flat" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Seguro que desea eliminar el registro?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HiddenField runat="server" ID="HiddenId" />
        </div>
    </div>

</asp:Content>
