<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Faculty.aspx.cs" Inherits="Faculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label Text="Email" runat="server"></asp:Label>
    <asp:TextBox runat="server" ID="emailIdBox"></asp:TextBox>
    <br /><br />
    <asp:Label Text="Password" runat="server"></asp:Label>
    <asp:TextBox runat="server" ID="passwordBox"></asp:TextBox>

    <asp:Button  runat="server" ID="submit" OnClick="submit_Click" Text="Submit"/>
</asp:Content>

