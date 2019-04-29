<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Panel ID="formLogin" runat="server" HorizontalAlign="Center">
            <asp:Label ID="lblEmail" runat="server" Text="Ingrese E-Mail:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Ingrese Password:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ToolTip="Ingrese Password"></asp:TextBox>
            <br />
            <asp:Label ID="lblIncorrecto" runat="server" CssClass="alert" Font-Bold="True" ForeColor="Red" Text="Password o Email incorrectos. Intente Nuevamente." Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Ingresar" />
        </asp:Panel>
    </div>

    </asp:Content>
