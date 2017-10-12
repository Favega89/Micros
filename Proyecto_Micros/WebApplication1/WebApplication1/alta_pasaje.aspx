<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alta_pasaje.aspx.cs" Inherits="WebApplication1.alta_pasaje" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="cabecera" class="text-center bg-primary" runat="server">MENU NIVELES 
        EDUCATIVOS</div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
                    <h3>Alta de Pasaje Urbano </h3>
                    <asp:TextBox ID="TXTid" class="form-control" placeholder="Ingrese el Id del Estudiante" runat="server" ></asp:TextBox>
                     <asp:DropDownList ID="DropDownList1" runat="server" BackColor="Black">
                    </asp:DropDownList>
                    <asp:Label ID="LBLFecha" class="form-control" runat="server" Text="Label"></asp:Label>
                    <asp:Button ID="BTNacept" class="form-control" text="Confirmar Pasaje" 
                        runat="server" onclick="BTNacept_Click" ></asp:Button>
                </div>
            </div>
                <div class="col-md-6 text-center">
                    <div class="modulo-contenedor bg-primary cl-primary ">
                        <h3>Baja y Modificacion</h3>
                    </div>
                 </div>
            </div>    
        </div>
    </form>
</body>
</html>
