<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuDatabase.aspx.cs" Inherits="WebApplication1.MenuDatabase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Order Items From Any Menu</h1>
    Select the Menu Group:
<asp:DropDownList ID="Ddl1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GroupSelected"></asp:DropDownList>
<asp:Label ID="SelectedGroup" runat="server" Visible="false"></asp:Label>
    <br />
<asp:Label ID="MessageLabel" ForeColor="White" BackColor="Green" runat="server" />
<asp:GridView ID="Gv1" runat="server" AutoGenerateColumns="true" AutoGenerateSelectButton="true" OnSelectedIndexChanging="ItemSelect"></asp:GridView>
</asp:Content>
