<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CalenderEvent.aspx.cs" Inherits="secondwebapplication.CaldenderEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h2>Calender Event</h2>
    <div class="form-group row">
    &nbsp;&nbsp; &nbsp;<label for="exampleInputEmail1">Event Date&nbsp;&nbsp;&nbsp; </label>
    &nbsp;<asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Enter event date" TextMode="Date" width="20%"></asp:TextBox>
    </div>
        

    <div class="form-group row">
    &nbsp;&nbsp; &nbsp;<label for="exampleInputEmail1">Event Type </label>
        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  Width="20%" class="form-control">
            <asp:ListItem Selected disabled>Select</asp:ListItem>
            <asp:ListItem >Holiday</asp:ListItem>
            <asp:ListItem>Birthday</asp:ListItem>
        </asp:DropDownList>
    </div>
       

    <div class="form-group row">
    &nbsp;&nbsp; &nbsp;<label for="exampleInputEmail1">Event Name&nbsp;&nbsp;&nbsp; </label>
    &nbsp;<asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Enter event name" width="20%"></asp:TextBox>
       
    </div>


    <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" class="btn btn-primary"/>
    <br />
    <br />
    <br />

    <div>
    <br />
    <br />
        </div>
</form>
</asp:Content>
