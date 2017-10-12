<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_usuario.aspx.cs" Inherits="Proyecto_Micros.Login_usuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/estilos.css" rel="stylesheet" type="text/css" />
 
</head>
<body class = "bg">
    <form id="form2" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-offset-3" >
                <div class="modulo-contenedor bg-primary cl-primary "align="center">
                    <h3>Login</h3>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="E-Mail"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" TextMode="password" class="form-control" runat="server" placeholder="Contraseña"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="Usuario incorrecto" Visible="false"></asp:Label>
                    <asp:Button ID="Button1" class="form-control" runat="server" Text="Ingresar" 
                        onclick="Button1_Click"  />
                    </div>
                </div>
            </div>
    </div>   
    </form>
</body>
</html>
