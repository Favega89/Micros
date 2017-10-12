<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="abm-nivelEducativo.aspx.cs" Inherits="Proyecto_Micros.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="cabecera" class="text-center bg-primary" runat="server">MENU NIVELES 
        EDUCATIVOS</div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
                    <h3>Alta de Niveles Educativos</h3>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Descripcion"></asp:TextBox>
                    <asp:Button ID="Button1" class="form-control" runat="server" Text="Guardar" OnClick="button1_Click" />
                    <asp:Button ID="Button2" class="form-control" runat="server" Text="Ir a Institucion Educativa" OnClick="button2_Click" />
                </div>
               </div>
                <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
                <h3>Baja y Modificacion</h3>
                    <asp:GridView CssClass="mGrid" AutoPostBack="true" ID="GridView1" runat="server"  align="center" 
                        onrowdeleting="GridView1_RowDeleting"  
                        ForeColor="Black" onselectedindexchanged="GridView1_SelectedIndexChanged" >
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button"/>
                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" 
                                ButtonType="Button"/>
                        </Columns>
                        </asp:GridView>
                         <asp:TextBox Visible="false" ID="TextBox2" class="form-control" runat="server" placeholder="Nueva descripcion"></asp:TextBox>
                         <asp:Button ID="Button3" Visible="false" class="form-control" runat="server" Text="Confirmar edicion" 
                        onclick="Button3_Click" />
                    <br />
                </div>
            </div>
        </div>    
    </div>
</asp:Content>
