<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewPayslips.aspx.cs" Inherits="secondwebapplication.ViewPayslips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h2>View PaySlips</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
    <Columns>
        <%--<asp:BoundField DataField="ename" HeaderText="Employee Name" />--%>
        <asp:BoundField DataField="month" HeaderText="Month" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="btnDownload" runat="server" Text="Download" CommandName="Download" CommandArgument='<%# Eval("ename") + "," + Eval("month") %>' Target="_blank" class="btn btn-primary"/>
                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("ename") + "," + Eval("month") %>' class="btn btn-info"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />

</asp:GridView>
        </form>
</asp:Content>
