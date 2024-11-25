<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewDocument.aspx.cs" Inherits="secondwebapplication.ViewDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
        <h2>View Documents</h2>
        <%--CellPadding="3" CellSpacing="1" Height="333px" Width="622px"--%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"  GridLines="None" CellPadding="3" CellSpacing="1"  OnRowCommand="GridView1_RowCommand1"    >
        <Columns>

            <asp:TemplateField HeaderText="Eamil Id">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Email_id") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>

             <%--<asp:TemplateField HeaderText="Documents">
                 <ItemTemplate>
                 <asp:Label ID="Label2" runat="server" Text='<%# Eval("Documents") %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>--%>

             <asp:TemplateField HeaderText="Documents Name">
                 <ItemTemplate>
                 <asp:Label ID="Label3" runat="server" Text='<%# Eval("Documents_name") %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField  HeaderText="Action">
                  <ItemTemplate>
                      <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="View" CommandArgument='<%# Eval("Documents_name") +"|" + Eval ("Email_id")%>'  CommandName="view"  />

                    <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Download" CommandArgument='<%# Eval("Documents_name") +"|" + Eval ("Email_id")%>'  CommandName="Download" />

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
    
       
    </div>
</form>
</asp:Content>
