<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CheckTask.aspx.cs" Inherits="secondwebapplication.CheckTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h2>Check Tasks</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" >
    <Columns>
        <%--<asp:BoundField DataField="email" HeaderText="Email" />--%>
        <asp:BoundField DataField="taskname" HeaderText="Task Name" />
        <asp:TemplateField HeaderText="Download">
            <ItemTemplate>
                <asp:Button ID="btnDownload" runat="server" Text="Download" class="btn btn-primary" CommandName="Download" CommandArgument='<%# Eval("taskname") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Solution">
            <ItemTemplate>
                <asp:FileUpload ID="FileUpload1" runat="server" accept=".pdf"/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" CommandName="Upload" CommandArgument='<%# Eval("taskname") %>' />
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
