<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="UI.Web.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="frmMain" runat="server" Height="177px" HorizontalAlign="Center">
        <br />
        <h1>Bienvenido</h1>
        <asp:Button ID="btnABMClientes" runat="server" Text="Gestion de Clientes" Width="193px" OnClick="btnABMClientes_Click" />
        <br />
        <asp:Button ID="btnNuevaFactura" runat="server" Text="Nueva Factura" Width="193px" />
        <br />
        <asp:Button ID="btnCerrarSesion" runat="server" BackColor="Red" Font-Bold="True" ForeColor="White" OnClick="btnCerrarSesion_Click" Text="Cerrar Sesion" Width="193px" />
        <br />
        <br />
        <br />
    </asp:Panel>
</asp:Content>
