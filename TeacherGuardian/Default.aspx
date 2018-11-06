<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:SqlDataSource runat="server" id="sqlds" ConnectionString="<%$ConnectionStrings:con %>" SelectCommand="Select * from student where hasGuardian=@hasGuardian">
        <SelectParameters>
            <asp:ControlParameter Name="hasGuardian" PropertyName="Value" ControlID="cp1" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView runat="server" DataSourceID="sqlds" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField  DataField="name" HeaderText="Name"/>
            <asp:BoundField  DataField="section" HeaderText="Section"/>
            <asp:BoundField DataField="branch"  HeaderText="Branch"/>
        </Columns>
        
    </asp:GridView> 
    <asp:DropDownList ID="slotSelection" runat="server" AutoPostBack="true">
        <asp:ListItem>Filled</asp:ListItem>
        <asp:ListItem>Free</asp:ListItem>
    </asp:DropDownList>
 </asp:Content>

