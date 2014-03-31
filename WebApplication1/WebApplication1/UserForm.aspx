<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="WebApplication1.UserForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"   
            AllowSorting="True" AutoGenerateColumns="False" 
        OnRowCommand="GridView1_RowCommand"
         DataKeyNames="ID,EMail,FullName"   
            DataSourceID="SqlDataSource1">  
    <Columns>
      <asp:BoundField DataField="FullName" HeaderText="Full Name" ReadOnly="True" />  
      <asp:BoundField DataField="EMail" HeaderText="email" ReadOnly="True" />  
      <asp:BoundField DataField="Phone" HeaderText="Telephone" ReadOnly="True" />  
        <asp:ButtonField buttontype="Button" Text="email" CommandName="SendEmail" />
    </Columns>
    </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"   
            ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"   
            SelectCommand="SELECT * FROM [UserProfiles]"></asp:SqlDataSource>  

</asp:Content>
