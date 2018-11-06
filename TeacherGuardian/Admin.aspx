<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label Text="Email" runat="server"></asp:Label>
    <asp:TextBox runat="server" ID="emailIdBox"></asp:TextBox>
    <br /><br />
    <asp:Label Text="Password" runat="server"></asp:Label>
    <asp:TextBox runat="server" ID="passwordBox"></asp:TextBox>

    <asp:Button  runat="server" ID="submit" OnClick="submit_Click" Text="Submit"/>

    <asp:Label ID="status" Visible="false" runat="server"></asp:Label>
    <asp:RegularExpressionValidator runat="server" ValidationExpression=".+@.+" ControlToValidate="emailIdbox" ErrorMessage="Invalid email format"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="rfv" ControlToValidate="passwordbox" runat="server" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
</asp:Content>

