<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaFactura.aspx.cs" Inherits="UI.Web.NuevaFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="frnMenu" runat="server" Height="37px">
    <asp:HyperLink ID="lnkInicio" runat="server" NavigateUrl="~/Main.aspx" CssClass="navbar-btn">Inicio</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="lnkABMClientes" runat="server" NavigateUrl="~/ABMClientes.aspx" CssClass="navbar-btn">Gestion de Clientes</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="lnkNuevaFactura" runat="server" NavigateUrl="~/NuevaFactura.aspx" CssClass="navbar-btn">Nueva Factura</asp:HyperLink>
</asp:Panel>
</asp:Content>
