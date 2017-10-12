<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRespInst.Master" AutoEventWireup="true" CodeBehind="Estudiantes_institucion.aspx.cs" Inherits="Proyecto_Micros.Estudiantes_institucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="mGrid" AutoPostBack="true" ID="GridView1" 
        runat="server" align="center" AutoGenerateColumns="False" ForeColor="Black" DataKeyNames="Id" onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button"/>
            <asp:CommandField ButtonType="Button" ShowEditButton="True"/>

            <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
            <asp:Label ID="lblnombre" runat="server" Text='<%#Eval("Nombre")%>' ></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
            <asp:TextBox ID="txtnombre" runat="server" Text='<%#Eval("Nombre")%>'></asp:TextBox>
            </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Apellido">
            <ItemTemplate>
            <asp:Label ID="lblapellido" runat="server" Text='<%#Eval("Apellido")%>' ></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
            <asp:TextBox ID="txtapellido" runat="server" Text='<%#Eval("Apellido")%>'></asp:TextBox>
            </EditItemTemplate>
            </asp:TemplateField>
                        
            <asp:TemplateField HeaderText="Dni">
            <ItemTemplate>
            <asp:Label ID="lbldni" runat="server" Text='<%#Eval("Dni")%>' ></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
            <asp:TextBox ID="txtdni" runat="server" Text='<%#Eval("Dni")%>'></asp:TextBox>
            </EditItemTemplate>
            </asp:TemplateField>
                                    
            <asp:TemplateField HeaderText="Telefono">
            <ItemTemplate>
            <asp:Label ID="lbltel" runat="server" Text='<%#Eval("Telefono")%>' ></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
            <asp:TextBox ID="txttel" runat="server" Text='<%#Eval("Telefono")%>'></asp:TextBox>
            </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
