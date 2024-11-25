<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="TrainerTicketRaise.aspx.cs" Inherits="secondwebapplication.TrainerTicketRaise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <form id="form1" runat="server">
               <h2>Raise Ticket</h2>
        <div>
          
            <div class="form-group row">

            <asp:Label ID="Label1" runat="server" Text="Role"></asp:Label>
&nbsp;&nbsp;
            <asp:DropDownList CssClass="form-control" Width="20%" ID="ddlRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged1">
                <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
                <asp:ListItem>Trainee</asp:ListItem>
                <asp:ListItem>Trainer</asp:ListItem>
                <asp:ListItem Value="Admin">HR</asp:ListItem>
            </asp:DropDownList>
            </div>
           
              <div class="form-group row">
            <asp:Label ID="Label2" runat="server" Text="Raise To"></asp:Label>
&nbsp;
            
            
            
            <asp:DropDownList ID="ddlRaiseto" CssClass="form-control" Width="20%" runat="server" >
            </asp:DropDownList>
            </div>

         
             <div class="form-group row">
             <label for="txtTicket">Ticket:</label>
            <asp:TextBox ID="txtTicket" CssClass="form-control" Width="20%" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>

             <div class="form-group row">
              <label for="fileUploadAttachment">Attachment:</label>
            <asp:FileUpload CssClass="form-control" Width="20%" ID="fileUploadAttachment" runat="server" />
            </div>

            <br />
             <asp:Button ID="btnRaiseTicket" runat="server" CssClass="btn btn-primary" Text="Raise Ticket" OnClick="btnRaiseTicket_Click" />
            
          
        </div>
       
    
  </form>   
</asp:Content>
