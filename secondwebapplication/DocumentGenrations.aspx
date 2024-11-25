<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DocumentGenrations.aspx.cs" Inherits="secondwebapplication.DocumentGenrations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <form id="form1" runat="server">
  <div style="padding:20px;border: 5px solid Purple;width:25%; position:relative;left:30%">
           <h3>Generate Documents</h3>


 <div class="form-group">
  <label for="exampleInputEmail1">Email ID&nbsp;&nbsp;&nbsp;&nbsp; </label>
    &nbsp;<asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Enter your Email id"></asp:TextBox>
     <br />
     <br />
</div>

 <div class="form-group">
 <label for="exampleInputEmail1">Documents&nbsp; </label>
     &nbsp;<asp:FileUpload class="form-control" ID="FileUpload1"  runat="server" />
     <br />
     <br />
     <label for="exampleInputEmail1">Documents Name&nbsp; </label>
 &nbsp;<asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Enter your documents name"></asp:TextBox>
     <br />
     <br />
 </div>
           <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="ADD" Height="35px" Width="67px" OnClick="Button1_Click" />


       </div>
   </form>
</asp:Content>
