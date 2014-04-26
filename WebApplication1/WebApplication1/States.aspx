<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="States.aspx.cs" Inherits="WebApplication1.States" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<asp:DropDownList ID="Ddl1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="StateSelected"></asp:DropDownList>
<asp:Label ID="SState" runat="server"></asp:Label>
<asp:GridView ID="Gv1" runat="server" AutoGenerateColumns="true" OnSorting="GridViewSortEventHandler"></asp:GridView>
<asp:PlaceHolder ID="dyncontrol" runat="server"></asp:PlaceHolder>
</asp:Content>
