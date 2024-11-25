<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ApplyLeave.aspx.cs" Inherits="secondwebapplication.ApplyLeave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <form id="form1" runat="server">
    <h2>Apply Leave</h2>
             <div class="form-group row">
    &nbsp;&nbsp; &nbsp;<asp:Label ID="Label2" runat="server" Text="Leave Type : "></asp:Label>
    &nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control"  Width="20%">
            <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
            <asp:ListItem>CL</asp:ListItem>
            <asp:ListItem>SL</asp:ListItem>
            <asp:ListItem>PL</asp:ListItem>
        </asp:DropDownList>
    &nbsp;</div>
        
         <div class="form-group row">
          &nbsp;&nbsp;  &nbsp;<asp:Label ID="Label3" runat="server" Text="From :"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="fromd" runat="server" TextMode="Date" class="form-control"  Width="20%"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="To : "></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tod" runat="server" TextMode="Date" class="form-control"  Width="20%"></asp:TextBox>
             </div>
            
        
         <div class="form-group row">
       &nbsp;&nbsp; &nbsp; <asp:Label ID="Label5" runat="server" Text="Reason :"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" class="form-control"  Width="20%"></asp:TextBox>
        </div>
            
       
        &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Apply" UseSubmitBehavior="False" class="btn btn-primary"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" type="submit" Text="Check leave" UseSubmitBehavior="False" OnClick="Button2_Click" class="btn btn-info"/>
        <br />
        
            <asp:Label ID="Label6" runat="server"></asp:Label>
        
        
    &nbsp;
     
    </form>
</asp:Content>
