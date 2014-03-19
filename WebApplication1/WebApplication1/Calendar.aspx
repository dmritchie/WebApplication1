<%@ Page Title="Calendar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="WebApplication1.Calendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
Enter a Date:
   <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>
    <ajaxControlToolkit:CalendarExtender
        ID="CalendarExtender1"
        TargetControlID="StartDate"
        runat="server" />
</asp:Content>
