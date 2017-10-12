<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="abm-institucionEducativa.aspx.cs" Inherits="Proyecto_Micros.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div id="cabecera" class="text-center bg-primary" runat="server">MENU INSTITUCIONES 
        EDUCATIVAS
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
                    <h3>Alta de Instituciones Educativas</h3>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Nombre de la Institucion"></asp:TextBox>
                    <asp:CheckBoxList CssClass="ListControl" ID="CheckBoxList1" runat="server" >
                    </asp:CheckBoxList>  
                    </div>
               
                    <asp:Button ID="Button1" class="form-control" runat="server" Text="Guardar" onclick="Button1_Click"/> 
                    
              
            </div>
                <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
      <h3>Baja y Modificacion</h3>
                    <asp:GridView CssClass="mGrid" AutoPostBack="true" ID="GridView1" runat="server"  align="center" 
                        onrowdeleting="GridView1_RowDeleting" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                        ForeColor="Black"  >
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button"/>
                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" 
                                ButtonType="Button"/>
                        </Columns>
                        </asp:GridView>
                    <asp:TextBox Visible="false" ID="TextBox2" class="form-control" runat="server" 
                        placeholder="Nombre de la Institucion"></asp:TextBox>
                    <asp:CheckBoxList Visible="false" CssClass="ListControl" ID="CheckBoxList2" runat="server" >
                    </asp:CheckBoxList>  
               
                    <asp:Button Visible="false" ID="Button2" class="form-control" runat="server" Text="Guardar" 
                        onclick="Button2_Click"/> 
                    
              
                </div>
            </div>
        </div>    
    </div>
</asp:Content>
