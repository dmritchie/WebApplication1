<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tabs.aspx.cs" Inherits="WebApplication1.Tabs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxControlToolkit:TabContainer ID="TabContainer1" runat="server">
        <ajaxControlToolkit:TabPanel ID="Tab1" runat="server">
            <HeaderTemplate>Tab1</HeaderTemplate>
            <ContentTemplate>This is the content for Tab 1</ContentTemplate>
        </ajaxControlToolkit:TabPanel>
        <ajaxControlToolkit:TabPanel ID="TabPanel1" runat="server">
            <HeaderTemplate>Tab2</HeaderTemplate>
            <ContentTemplate>The is the content for Tab 2 <br />The is more content for Tab 2</ContentTemplate>
        </ajaxControlToolkit:TabPanel>
    </ajaxControlToolkit:TabContainer>
</asp:Content>
