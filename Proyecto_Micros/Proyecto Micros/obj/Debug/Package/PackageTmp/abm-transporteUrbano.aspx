<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="abm-transporteUrbano.aspx.cs" Inherits="Proyecto_Micros.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div id="cabecera" class="text-center bg-primary" runat="server">MENU ESTUDIANTES</div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
                    <h3>Alta de Transporte Urbano</h3>
                     <asp:TextBox ID="TXTdescripcion" class="form-control" runat="server" placeholder="Descripcion"></asp:TextBox>
                     <asp:TextBox ID="TXTlinea" class="form-control" runat="server" placeholder="Linea"></asp:TextBox>
                    <asp:Button ID="Button1" class="form-control" runat="server" Text="Guardar" OnClick="button1_Click" />
                </div>
               </div>
                <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
                <h3>Baja y Modificacion</h3>
                    <asp:GridView AutoPostBack="true" ID="GridView1" runat="server"  align="center" 
                        onrowdeleting="GridView1_RowDeleting"  
                        ForeColor="Black" >
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button"/>
                        </Columns>
                        </asp:GridView>
                         
                    <br />
                         
                </div>
                 
            </div>
        </div>    
    </div>
</asp:Content>
