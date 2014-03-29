<%@ Page Title="Calendar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="WebApplication1.Calendar" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<asp:Label runat="server">Start Date:</asp:Label>
    <cc1:CalendarExtender
        ID="CalendarExtender1"
        PopupButtonID="pop"
        TargetControlID="StartDate"
        PopupPosition="BottomRight"
        runat="server" ></cc1:CalendarExtender>
   <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>
</asp:Content>
