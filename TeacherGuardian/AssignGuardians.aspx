<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignGuardians.aspx.cs" Inherits="AssignGuardians" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="Label1" runat="server" Text="Faculty"></asp:Label>
    <br />
    <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="FacultyName" DataValueField="FacultyId"></asp:ListBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Students"></asp:Label>
    <br />
    <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id"></asp:ListBox>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\mssqllocaldb;Initial Catalog=TeacherGuardian;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT Id,Name from STUDENT Where HasGuardian=0"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(localdb)\mssqllocaldb;Initial Catalog=TeacherGuardian;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT FacultyId, FacultyName from Faculty "></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Text="Assign" OnClick="AssignGuardian" />
    
    </asp:Content>

