<%@ Page Title="" Language="C#" MasterPageFile="~/src/VentasAllMusic.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="DisqueraVentas.GUI.Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="left-align" style="background: rgba(52, 60, 65, 0.69)">
            <div class="container">
                <div class="row">
                    <div class="action">
                        <div class="col s12 m12 white-text">
                            <h4 class="title">Pedido</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="section">
            <div class="container">
                <div class="row">
                    <div class="col s12 m12 text-center">
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtNombre" />
                            <label>Nombre</label>
                        </div>
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtAnio" />
                            <label>Año</label>
                        </div>
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtTotalPistas" />
                            <label>Total de Pistas</label>
                        </div>
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="txtPrecio" />
                            <label>Precio</label>
                        </div>
                        <label>Genero</label>
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
                            <asp:Button Text="Guardar" ID="btnGuardar" runat="server" CssClass="btn waves-effect waves-light"/>
                            <asp:Button Text="Modificar" ID="btnModificar" runat="server" CssClass="btn waves-effect waves-light"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="divider"></div>

    <div class="container">
        <div class="row">
            <div class="col s12 m12 text-center">
                <h4>Lista de Discos</h4>
                <div class="input-field col m8">
                    <asp:TextBox runat="server" ID="txtBuscar" />
                    <label>Buscar</label>
                </div>
                <div class="input-field col m4">
                    <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn waves-effect" runat="server"/>
                </div>

                <asp:GridView runat="server" ID="gvDiscos" CellPadding="4"
                    CssClass="responsive-table center striped" GridLines="None"
                    DataKeyNames="idDisco" AutoGenerateColumns="false"
                    >
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
                                <asp:Button Text="Eliminar" ID="btnEliminar" runat="server" CssClass="btn btn-flat" OnClientClick="return confirm('¿Seguro que desea eliminar el registro?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField runat="server" ID="HiddenId" />
            </div>
        </div>
    </div>
</asp:Content>
