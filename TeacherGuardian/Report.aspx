<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="sqlds" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="Select * from Guardian g  inner join student s on g.studentid = s.id"></asp:SqlDataSource>
    
    <asp:DropDownList ID="Category" runat="server">
       <asp:ListItem Value="StudentName">Student Name</asp:ListItem>
        
       <asp:ListItem Value="Section">Section</asp:ListItem>
        
       <asp:ListItem Value="Branch">Stream</asp:ListItem>
        
       <asp:ListItem Value="FacultyName">Guardian Assigned</asp:ListItem>
    </asp:DropDownList>
    
    <asp:Label runat="server" Text="Enter parameter value: "></asp:Label>
    <asp:TextBox ID="categoryValue" runat="server"></asp:TextBox>
    <asp:Button runat="server" ID="search" OnClick="search_Click" Text="Search"/>
    <asp:Button  runat="server" ID="showAll" OnClick="showAll_Click" Text="Show All"/>
    <br />
    <br />
<asp:GridView runat="server" AutoGenerateColumns="false" ID="gv" DataSourceID="sqlds">
    <Columns>
        <asp:BoundField  DataField="StudentName" HeaderText="Student Name"/>
        <asp:BoundField DataField="Section" HeaderText="Section"/>
        <asp:BoundField DataField="Branch" HeaderText="Stream" />
        <asp:BoundField DataField="facultyname" HeaderText="Guardian Assigned" />
    </Columns>  
</asp:GridView>
</asp:Content>

