<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUserProfile.aspx.cs" Inherits="WebApplication1.Account.EditUserProfile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit User Profile for <%: Membership.GetUser() %></h2>
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <br />
    <asp:TextBox ID="Name"  runat="server" CssClass="form-control" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
    <br />
    <asp:TextBox ID="Address" runat="server" CssClass="form-control" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="City"></asp:Label>
    <br />
    <asp:TextBox ID="City" runat="server" CssClass="form-control" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="State"></asp:Label>
    <br />
    <asp:TextBox ID="State" runat="server" CssClass="form-control" />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
    <br />
    <asp:TextBox ID="Phone" runat="server" CssClass="form-control" />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
    <br />
    <asp:TextBox ID="Email" runat="server" CssClass="form-control" />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="UpdateProfile_Click" Text="Update" CssClass="btn btn-default" />
    <asp:Button ID="Button2" PostBackUrl="~/Account/Manage.aspx" runat="server" Text="Cancel" CssClass="btn btn-default" />
</asp:Content>

