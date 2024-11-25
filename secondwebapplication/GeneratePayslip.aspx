<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GeneratePayslip.aspx.cs" Inherits="secondwebapplication.GeneratePayslip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server">
            <h2>Generate PaySlip</h2>
            <div class="form-group row">
        &nbsp;&nbsp; &nbsp;Emp Email ID : &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" class="form-control" runat="server"  Width="20%"></asp:TextBox>
                </div>

           
            <div class="form-group row">
            &nbsp;&nbsp; &nbsp; Month :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" class="form-control"  Width="10%">
                <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
                <asp:ListItem>Jan</asp:ListItem>
                <asp:ListItem>Feb</asp:ListItem>
                <asp:ListItem>Mar</asp:ListItem>
                <asp:ListItem>Apr</asp:ListItem>
                <asp:ListItem>May</asp:ListItem>
                <asp:ListItem>June</asp:ListItem>
                <asp:ListItem>Jul</asp:ListItem>
                <asp:ListItem>Aug</asp:ListItem>
                <asp:ListItem>Sep</asp:ListItem>
                <asp:ListItem>Oct</asp:ListItem>
                <asp:ListItem>Nov</asp:ListItem>
                <asp:ListItem>Dec</asp:ListItem>
            </asp:DropDownList>
                </div>

            
           
            <asp:Button ID="Button1" runat="server" Text="Generate" OnClick="Button1_Click" class="btn btn-primary"/>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    </form>
</asp:Content>
