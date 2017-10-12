<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRespInst.Master" AutoEventWireup="true" CodeBehind="abm-estudiante.aspx.cs" Inherits="Proyecto_Micros.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-offset-3">
                <div class="modulo-contenedor bg-primary cl-primary ">
                    <h3>Alta de Estudiantes</h3>
                     <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Dni"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                        <asp:TextBox ID="TextBox3" class="form-control" runat="server" placeholder="Apellido"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" class="form-control" runat="server" placeholder="Telefono"></asp:TextBox> 
                    <asp:Label Text="Nivel Educativo:" runat="server" /> 
                                <asp:DropDownList runat="server" BackColor="Black" ID="DDLnivelEducativo" >
                                 </asp:DropDownList>
                             <br />
                             Fecha de Nacimiento<br />
                        &nbsp;<asp:DropDownList runat="server" BackColor="Black" ID="DDLdia">
                        <asp:ListItem Text="DIA" Enabled="true" />
                        <asp:ListItem Text="1" />
                        <asp:ListItem Text="2" />
                        <asp:ListItem Text="3" />
                        <asp:ListItem Text="4" />
                        <asp:ListItem Text="5" />
                        <asp:ListItem Text="6" />
                        <asp:ListItem Text="7" />
                        <asp:ListItem Text="8" />
                        <asp:ListItem Text="9" />
                        <asp:ListItem Text="10" />
                        <asp:ListItem Text="11" />
                        <asp:ListItem Text="12" />
                        <asp:ListItem Text="13" />
                        <asp:ListItem Text="14" />
                        <asp:ListItem Text="15" />
                        <asp:ListItem Text="16" />
                        <asp:ListItem Text="17" />
                        <asp:ListItem Text="18" />
                        <asp:ListItem Text="19" />
                        <asp:ListItem Text="20" />
                        <asp:ListItem Text="21" />
                        <asp:ListItem Text="22" />
                        <asp:ListItem Text="23" />
                        <asp:ListItem Text="24" />
                        <asp:ListItem Text="25" />
                        <asp:ListItem Text="26" />
                        <asp:ListItem Text="27" />
                        <asp:ListItem Text="28" />
                        <asp:ListItem Text="29" />
                        <asp:ListItem Text="30" />
                        <asp:ListItem Text="31" />
                    </asp:DropDownList>

                    <asp:DropDownList runat="server" contentplaceholderid="mes" ID="DDLmes" BackColor="Black">
                        <asp:ListItem Text="MES" Enabled="true" />
                        <asp:ListItem Text="ENERO" Value='1' />
                        <asp:ListItem Text="FEBRERO" Value='2' />
                        <asp:ListItem Text="MARZO"  Value='3'/>
                        <asp:ListItem Text="ABRIL" Value='4' />
                        <asp:ListItem Text="MAYO" Value='5' />
                        <asp:ListItem Text="JUNIO" Value='6' />
                        <asp:ListItem Text="JULIO" Value='7' />
                        <asp:ListItem Text="AGOSTO" Value='8' />
                        <asp:ListItem Text="SEPTIEMBRE" Value='9' />
                        <asp:ListItem Text="OCTUBRE" Value='10' />
                        <asp:ListItem Text="NOVIEMBRE" Value='11' />
                        <asp:ListItem Text="DICIEMBRE" Value='12' />
                    </asp:DropDownList>

                    <asp:TextBox runat="server" placeholder="AÑO" ID="TXTaño" BackColor="Black"/>
                        <asp:Button ID="Button1" class="form-control" runat="server" 
                        Text="Guardar e ir a generar usuario para dicho Estudiante" onclick="Button1_Click" />
                 </div>
            </div>
        </div>    
     </div>
</asp:Content>
