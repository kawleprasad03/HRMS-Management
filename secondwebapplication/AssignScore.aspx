<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="AssignScore.aspx.cs" Inherits="secondwebapplication.AssignScore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
         <h2>Assign Score</h2>
         <div class="form-group row">
     &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Select Staus :"></asp:Label>
        
    &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="20%">
            <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
            <asp:ListItem>complete</asp:ListItem>
            <asp:ListItem>incomplete</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-success my-2 my-sm-0" Text="search" OnClick="Button1_Click" />

 </div>
        <br/>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="taskname" HeaderText="Task Name" />
                <asp:TemplateField HeaderText="Solution">
                    <ItemTemplate>
                        <%--<asp:LinkButton ID="lnkDownload" runat="server" CommandName="Download" CommandArgument='<%# Eval("taskname") %>'>Download</asp:LinkButton>--%>
                        <asp:Button ID="Button2" runat="server" Text="Download" CommandName="Download" CssClass="btn btn-primary" CommandArgument='<%# Eval("taskname") + "|" + Eval("email") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score">
                    <ItemTemplate>
                        <asp:TextBox ID="txtScore" runat="server" Text='<%# Eval("score") %>' ReadOnly="False" CssClass="form-control"  TextMode="Number" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnAdd" runat="server" CommandName="AddScore" CssClass="btn btn-primary" CommandArgument='<%# Eval("taskname") + "|" + Eval("email") %>' Text="Add" />
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
