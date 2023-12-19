<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Encuestas.aspx.cs" Inherits="EXAMEN3_RobertoChavesBrenes.Encuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Encuestas</h1> 
    </div>
     <div>
     <br />
     <br />
     <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
         CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
         RowStyle-CssClass="rows" AllowPaging="True" />

     <br />
     <br />
     <br />

 </div>
 <div class="container text-center">
     
     Nombre: <asp:TextBox type="text" id="tnombre" class="form-control" required runat="server"></asp:TextBox>
     Edad: <asp:TextBox type="number" id="tedad" class="form-control" required min="18" max="50" runat="server"></asp:TextBox>
     CorreoElectronico: <asp:TextBox type="email" id="tcorreo" class="form-control" required runat="server"></asp:TextBox>

Partido:  <asp:DropDownList ID="DropPartido" class="form-control" runat="server">
 </asp:DropDownList>

 </div>
    <br />
    <br />
 <div class="container text-center">

     <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click" BorderStyle="Solid" />

 </div>

    <br />
    <br />

    <footer class="container text-center">
        Roberto Chaves // Prueba Final // Tercer Cuatrimetre // 2023
    </footer>
</asp:Content>
