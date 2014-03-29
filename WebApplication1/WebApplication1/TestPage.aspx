<%@ Page Title="TestPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="WebApplication1.TestPage" %>
<%@ Register Assembly= "AjaxControlToolkit" Namespace= "AjaxControlToolkit" TagPrefix="ajaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
This is a test
<asp:Label ID="Label1" runat="server">Pick a color:</asp:Label>
   <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>
    <ajaxControlToolkit:ColorPickerExtender 
        ID="ColorPickerExtender1" 
        TargetControlID="StartDate"
        runat="server"></ajaxControlToolkit:ColorPickerExtender>
</asp:Content>
