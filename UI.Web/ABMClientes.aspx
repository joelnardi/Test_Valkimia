<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="UI.Web.ABMClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="frnMenu" runat="server" Height="37px">
        <asp:HyperLink ID="lnkInicio" runat="server" NavigateUrl="~/Main.aspx" CssClass="navbar-btn">Inicio</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="lnkABMClientes" runat="server" NavigateUrl="~/ABMClientes.aspx" CssClass="navbar-btn">Gestion de Clientes</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="lnkNuevaFactura" runat="server" NavigateUrl="~/NuevaFactura.aspx" CssClass="navbar-btn">Nueva Factura</asp:HyperLink>
    </asp:Panel>   
    <asp:Panel ID="frmClientes" runat="server" Height="192px" HorizontalAlign="Center">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="odsClientes" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" SortExpression="Domicilio" />
                <asp:BoundField DataField="IdCiudad" HeaderText="IdCiudad" SortExpression="IdCiudad" />
                <asp:BoundField DataField="EMail" HeaderText="EMail" SortExpression="EMail" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:CheckBoxField DataField="Habilitado" HeaderText="Habilitado" ReadOnly="True" SortExpression="Habilitado" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsClientes" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.ClienteLogic"></asp:ObjectDataSource>
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Button ID="Button3" runat="server" Text="Button" />
        <asp:Button ID="Button4" runat="server" Text="Button" />
    </asp:Panel>
    <asp:Panel ID="frmEdit" runat="server" Height="56px">
    </asp:Panel>
</asp:Content>
