<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="abm-usuario.aspx.cs" Inherits="Proyecto_Micros.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="cabecera" class="text-center bg-primary" runat="server" 
        title="Seleccione un rol">MENU USUARIOS</div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
                    <h3>Alta de Usuarios</h3>

                    <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Dni"></asp:TextBox>
                    <asp:TextBox ID="TextBox3" class="form-control" runat="server" placeholder="Apellido"></asp:TextBox>
                    <asp:TextBox ID="TextBox4" class="form-control" runat="server" placeholder="E-mail"></asp:TextBox>
                    <asp:TextBox ID="TextBox5" class="form-control" runat="server" placeholder="Password"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="Contraseñas incorrectas"></asp:Label>
                    <asp:TextBox ID="TextBox6" class="form-control" AutoPostBack="true" runat="server" 
                        placeholder="Repite Password" ontextchanged="TextBox6_TextChanged"></asp:TextBox>
                    Seleccione un rol :
                    <asp:DropDownList ID="DDLroles" runat="server" AutoPostBack="true" BackColor="Black" 
                        onselectedindexchanged="DDLroles_SelectedIndexChanged">
                        </asp:DropDownList>
                    <asp:Label ID="label2" Text = "Seleccione la Institucion" runat="server" Visible = "false"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" BackColor="Black" runat="server" Visible="false">
                    </asp:DropDownList>
        &nbsp;<asp:Button ID="Button2" class="form-control" runat="server" 
                        Text="Ir a ABM roles" onclick="Button2_Click" />
                    <asp:Button ID="Button1" class="form-control" runat="server" 
                        Text="Generar Usuario" onclick="Button1_Click" />
                    </div>
               </div>
               <div class="col-md-6 text-center">
                <div class="modulo-contenedor bg-primary cl-primary ">
      <h3>Baja y Modificacion</h3>
                    <asp:GridView CssClass="mGrid" AutoPostBack="true" ID="GridView1" runat="server" DataKeyNames="Id" AutoGenerateColumns="False"
                        ForeColor="Black" onrowcancelingedit="GridView1_RowCancelingEdit" 
                        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                        onrowupdating="GridView1_RowUpdating" >
                        
                        <Columns>
                           
                            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />

                            <asp:TemplateField HeaderText="Dni">
                            <ItemTemplate>
                            <asp:Label ID="lbldni" runat="server" Text='<%#Eval("Dni")%>' ></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="txtdni" runat="server" Text='<%#Eval("Dni")%>'></asp:TextBox>
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                            <asp:Label ID="lblnombre" runat="server" Text='<%#Eval("Apellido")%>' ></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="txtnombre" runat="server" Text='<%#Eval("Apellido")%>'></asp:TextBox>
                            </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="E-Mail">
                            <ItemTemplate>
                            <asp:Label ID="lblmail" runat="server" Text='<%#Eval("Email")%>' ></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="txtmail" runat="server" Text='<%#Eval("Email")%>'></asp:TextBox>
                            </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        </asp:GridView>
                    <asp:TextBox Visible="false" ID="TextBox1" class="form-control" runat="server" 
                        placeholder="Nombre de la Institucion"></asp:TextBox>
                    <asp:CheckBoxList Visible="false" CssClass="ListControl" ID="CheckBoxList2" runat="server" >
                    </asp:CheckBoxList>  
               
                    <asp:Button Visible="false" ID="Button3" class="form-control" runat="server" Text="Guardar" 
                        onclick="Button2_Click"/> 
                    
              
                </div>
            </div>
                <asp:Button ID="Button4" class="form-control" runat="server" 
                Text="Guardar y volver a menu Responsable de Institucion Academica" onclick="Button4_Click" />
             </div>   
         </div>
</asp:Content>
