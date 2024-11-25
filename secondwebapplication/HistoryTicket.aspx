<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="HistoryTicket.aspx.cs" Inherits="secondwebapplication.HistoryTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
         <h2>History of Ticket</h2>
         <div class="form-group row">
         History&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="form-control" Width="20%">
             <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
             <asp:ListItem>Daily</asp:ListItem>
             <asp:ListItem>Weekly</asp:ListItem>
             <asp:ListItem>Monthly</asp:ListItem>
             <asp:ListItem>Yearly</asp:ListItem>
         </asp:DropDownList>
         </div>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                 <asp:BoundField DataField="raiseto" HeaderText="Raised To" />
                 <asp:BoundField DataField="ticketsolution" HeaderText="Solution" />
                <asp:BoundField DataField="dateofraise" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' 
                           CssClass='<%# Eval("status").ToString() == "closed" ? "badge badge-success" : "badge badge-warning" %>'>
                </asp:Label>
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
