<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Offerletter.aspx.cs" Inherits="secondwebapplication.Offerletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <form id="form1" runat="server">
     <h2>Generate Offer Letter</h2>
    <p class="form-group row">
       &nbsp;&nbsp; &nbsp; Name &nbsp; <asp:TextBox ID="TextBox1" runat="server" class="form-control"  Width="20%"></asp:TextBox>
    </p>
    <p class="form-group row">
       &nbsp;&nbsp; &nbsp; Email &nbsp;
        <asp:TextBox ID="TextBox2" runat="server" class="form-control"  Width="20%"></asp:TextBox>
    </p>
    <p class="form-group row">
        &nbsp;&nbsp; &nbsp;Date Of Join &nbsp;<asp:TextBox ID="TextBox3" TextMode="Date" runat="server" class="form-control"  Width="20%"></asp:TextBox>
    </p class="form-group row">
    <p class="form-group row">
       &nbsp;&nbsp; &nbsp; Designation &nbsp;<asp:TextBox ID="TextBox4" runat="server" class="form-control"  Width="20%"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="GENERATE" class="btn btn-primary" OnClick="Button1_Click"  />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
   </form>
</asp:Content>
