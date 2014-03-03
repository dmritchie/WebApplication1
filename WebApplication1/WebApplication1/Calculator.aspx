<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebApplication1.Calculator" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Resonant Frequency Calculator</h2>
    <p> f = 1/2pi*sqrt(L*C)</p>

    <p>The above formula is used to calculate resonant frequency. This calculator will calculate the 
        resonant frequency given a fixed inductor and capacitance with specified value. The plot shows
        the resonant frequency with the capacitance varying from 20% to 200% of the specified value.
</p>
    <asp:Label ID="Label1" runat="server" Text="Inductance (microHenries)"></asp:Label>
    <br />
    <asp:TextBox ID="Inductance"  runat="server" CssClass="form-control" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Capacitance (nanoFarads)"></asp:Label>
    <br />
    <asp:TextBox ID="Capacitance" runat="server" CssClass="form-control" />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Resonant Frequent"></asp:Label>
    <br />
    <asp:TextBox ID="Answer" runat="server" CssClass="form-control" />
    <asp:Button ID="Button1" runat="server" OnClick="Calculate" Text="Calculate" CssClass="btn btn-default" />
    <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
</asp:Content>
