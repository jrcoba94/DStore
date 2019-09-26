<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DisqueraVentas.GUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>

    <link rel="shortcut icon" href="../src/Img/logoAM.ico" />
    <link href="../src/css/materialize.css" rel="stylesheet" />
    <link href="../src/css/materialize.min.css" rel="stylesheet" />
    <link href="../src/iconfont/material-icons.css" rel="stylesheet" />
    <link href="../src/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../src/css/animations.css" rel="stylesheet" />
    <link href="../src/css/style.css" rel="stylesheet" />
    <script src="../src/js/jquery-2.1.4.min.js"></script>
    <script src="../src/js/materialize.js"></script>
    <script src="../src/js/materialize.min.js"></script>

</head>
<body class="font-cover" id="login">
    <div class="container-login center-align z-depth-5 card-panel" style="border-radius: 20px 20px 20px 20px">
        <div style="margin: 15px 0;">
            <i class="fa fa-users z-depth-3" style="font-size:100px;border-radius:100%;background:#cccccc;color:#808080"></i>
            <p>Inicia sesión con tu cuenta</p>
        </div>
        <form id="frmLogin" runat="server">

            <asp:Label ID="lblAlerta" runat="server"></asp:Label>
            <div class="input-field row">
                <i class="fa fa-user prefix" style="color: lightgray"></i>
                <asp:TextBox ID="txtUser" runat="server" CssClass="validate" type="Email" Width="250"></asp:TextBox>
            </div>
            <div class="input-field row">
                <i class="fa fa-lock prefix" style="color: lightgray"></i>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="validate" type="password" Width="250"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnIngresar" CssClass="waves-effect waves-teal btn-flat" Text="Ingresar" OnClick="btnIngresar_Click"/>
            <asp:Button runat="server" ID="btnCancelar" CssClass="waves-effect waves-teal btn-flat" Text="Cancelar" OnClick="btnCancelar_Click"/>
            <br /><br />
            <div class="col s12 center-align" style="font-size:14px">
                <asp:LinkButton ID="btlRegistro" runat="server" Text="Registrarse" OnClick="btlRegistro_Click"></asp:LinkButton>
            </div>
        </form>
        <br />
    </div>
</body>
</html>
