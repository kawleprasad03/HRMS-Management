<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="TaskAssign.aspx.cs" Inherits="secondwebapplication.TaskAssign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server">
             <h2>Assign Task</h2>
            <div class="form-group row">
                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Task Name :"></asp:Label>

            &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" class="form-control" Width="20%"></asp:TextBox>

            </div>
            <div class="form-group row">
               &nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Text="Attachment :"></asp:Label>
            &nbsp;&nbsp;&nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" Width="20%" accept=".pdf"/>
            </div>
            <div class="form-group row">
                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Assign To :"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" class="form-control" Width="20%" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                    
                </asp:CheckBoxList>
                <br />
                </div>
                <asp:Button ID="Button1" runat="server" Text="Assign" class="btn btn-primary" OnClick="Button1_Click" />

     

        </form>


</asp:Content>
