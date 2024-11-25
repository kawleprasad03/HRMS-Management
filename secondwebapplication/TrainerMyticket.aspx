<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="TrainerMyticket.aspx.cs" Inherits="secondwebapplication.TrainerMyticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <form id="form1" runat="server">
           <h2>MY Ticket</h2>
           <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvTickets_RowCommand" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
    <Columns>
        <asp:BoundField DataField="raiseto" HeaderText="Raised To" />
        
       
        <asp:BoundField DataField="ticketmessage" HeaderText="Message" />

       
        <asp:TemplateField HeaderText="Attachment">
            <ItemTemplate>
                <asp:Button ID="btnDownload" runat="server" CommandName="Download" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-primary" Text="Download"></asp:Button>
            </ItemTemplate>
        </asp:TemplateField>

       
        <asp:BoundField DataField="dateofraise" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />

     
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <%--<asp:Button ID="btnClose" runat="server"  Text="Close" data-toggle="modal" data-target="#exampleModal"/>--%>
                <%--runat="server" CommandName="CloseTicket" CommandArgument='<%# Eval("id") %>'--%>
               <%-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
  clsoe
</button>--%>
          <button type="button" class="btn btn-primary" onclick="setTicketId('<%# Eval("id") %>')" data-toggle="modal" data-target="#exampleModal">
            Close
        </button>
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
  <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Ticket Solution</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <asp:TextBox ID="TextBox1" runat="server" placeholder="Solution" CssClass="form-control"></asp:TextBox>
           <asp:HiddenField ID="hfTicketId" runat="server" />
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
           <asp:Button ID="btnSaveChanges" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSaveChanges_Click" />
      </div>
    </div>
  </div>
</div>

       </form>
<script type="text/javascript">
    function setTicketId(ticketId) {
        // Set the ticket ID in the HiddenField
        document.getElementById('<%= hfTicketId.ClientID %>').value = ticketId;
    }
</script>
</asp:Content>
