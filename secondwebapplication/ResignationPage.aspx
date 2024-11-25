<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ResignationPage.aspx.cs" Inherits="secondwebapplication.ResignationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server" style="margin-left:20px">
    <h2>Resignation Letter</h2>
         <div class="form-group row">
                 &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Name "></asp:Label>
             &nbsp;&nbsp;&nbsp;
                 <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="20%"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;

         </div>
          <div class="form-group row">
            &nbsp;<asp:Label ID="Label2" runat="server" Text="Designation "></asp:Label>
                 &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Width="20%"></asp:TextBox>

            </div>
         <div class="form-group row">
             &nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Reason "></asp:Label>
         &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Width="20%"></asp:TextBox>

        </div>
        
          <div class="form-group row">
                 &nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Date Of Leaving "></asp:Label>
             &nbsp;&nbsp;&nbsp;
                 <asp:TextBox ID="TextBox4" runat="server" TextMode="Date" CssClass="form-control" Width="20%"></asp:TextBox>

            </div>

         
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" class="btn btn-primary"/>
     </form>
</asp:Content>
