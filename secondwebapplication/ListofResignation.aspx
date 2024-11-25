<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListofResignation.aspx.cs" Inherits="secondwebapplication.ListofResignation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h2>Resignation List</h2>
        <asp:GridView ID="GridViewResignations" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewResignations_RowCommand" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="designation" HeaderText="Designation" />
                <asp:TemplateField HeaderText="Attachment">
                    <ItemTemplate>
                        <asp:Button ID="btnDownload" runat="server" CommandName="Download" class="btn btn-primary" CommandArgument='<%# Eval("email") %>' Text="Download" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" class="btn btn-success" runat="server" CommandName="Approve" CommandArgument='<%# Eval("email") %>' Text="Approve" />
                        <asp:Button ID="btnReject" class="btn btn-danger" runat="server" CommandName="Reject" CommandArgument='<%# Eval("email") %>' Text="Reject" />
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
