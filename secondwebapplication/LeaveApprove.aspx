<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="LeaveApprove.aspx.cs" Inherits="secondwebapplication.LeaveApprove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<h2>Leave</h2>
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
     <Columns>
        <asp:BoundField DataField="ename" HeaderText="Name" />
        <asp:BoundField DataField="fromdate" HeaderText="From Date" />
        <asp:BoundField DataField="todate" HeaderText="To Date" />
        <asp:BoundField DataField="ltype" HeaderText="Leave type" />
        <asp:BoundField DataField="reason" HeaderText="Reason" />
        <asp:BoundField DataField="cl" HeaderText="CL" />
        <asp:BoundField DataField="pl" HeaderText="PL" />
        <asp:BoundField DataField="sl" HeaderText="Sl" />
        <asp:BoundField DataField="totalnumday" HeaderText="Total number days" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Approved" CommandName="Approved" CommandArgument='<%# Container.DataItemIndex %>' UseSubmitBehavior="False" class="btn btn-primary"/>
                <asp:Button ID="Button2" runat="server" Text="Rejected" CommandName="Rejected" CommandArgument='<%# Container.DataItemIndex %>' UseSubmitBehavior="False" class="btn btn-danger"/>
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
