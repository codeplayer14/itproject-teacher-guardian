<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAdd.aspx.cs" Inherits="ViewAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label Text="Check status" runat="server"></asp:Label>
    <asp:Label Text="Request for guardianship" runat="server"></asp:Label>
    <asp:SqlDataSource runat="server" id="sqlds" ConnectionString="<%$ConnectionStrings:con %>" SelectCommand="Select * from student where hasGuardian=@hasGuardian">
        <SelectParameters>
            <asp:ControlParameter Name="hasGuardian" PropertyName="SelectedValue" ControlID="slotSelection" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView runat="server" DataSourceID="sqlds" AutoGenerateColumns="false" ID="gv">
        <Columns>
            
            <asp:BoundField  DataField="id" HeaderText="StudentId"/>
            <asp:BoundField  DataField="name" HeaderText="Name"/>
            <asp:BoundField  DataField="section" HeaderText="Section"/>
            <asp:BoundField DataField="branch"  HeaderText="Branch"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox runat="server" Enabled='<%# !Convert.ToBoolean(Eval("hasGuardian"))   %>' ID="hasGuardian" Checked='<%# Convert.ToBoolean(Eval("hasGuardian"))   %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
    </asp:GridView> 
    <asp:DropDownList ID="slotSelection" runat="server" AutoPostBack="true">
        <asp:ListItem Value="1">Filled</asp:ListItem>
        <asp:ListItem Value="0">Free</asp:ListItem>
    </asp:DropDownList>

    <asp:Button runat="server" Text="Submit" id="submitRequest" OnClick="submitRequest_Click"/>
    <asp:Label runat="server" ID="status"> </asp:Label>
 </asp:Content>

