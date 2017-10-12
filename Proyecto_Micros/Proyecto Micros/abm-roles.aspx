<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="abm-roles.aspx.cs" Inherits="Proyecto_Micros.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div id="cabecera" class="text-center bg-primary" runat="server">MENU ROLES</div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
                    <h3>Alta de Roles</h3>
                    <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Descripcion"></asp:TextBox>
                    <asp:Button ID="Button1" class="form-control" runat="server" 
                        Text="Generar rol" onclick="Button1_Click" />

                    <asp:Button ID="Button2" class="form-control" runat="server" 
                        Text="Ir a ABM estudiantes" onclick="Button2_Click" />
                    </div>
               </div>
             </div>                 
            </div>
</asp:Content>
