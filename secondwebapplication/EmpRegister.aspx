<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmpRegister.aspx.cs" Inherits="secondwebapplication.EmpRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <form id="form1" runat="server">
       <h2>Employee Register</h2>
       <div>
           <div class="form-group row">
            &nbsp;&nbsp; &nbsp; Username:&nbsp;&nbsp;
<asp:TextBox ID="TextBox1" runat="server" class="form-control"  Width="20%"></asp:TextBox>
               </div>

               <div class="form-group row">
 &nbsp;&nbsp; &nbsp;Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox2" runat="server" class="form-control"  Width="20%"></asp:TextBox>
                   </div>

                   <div class="form-group row">
 &nbsp;&nbsp; &nbsp;Password:&nbsp;&nbsp;
<asp:TextBox ID="TextBox3" runat="server" class="form-control"  Width="20%"></asp:TextBox>
                       </div>
                              <div class="form-group row">
 &nbsp;&nbsp; &nbsp;Profile Photo:&nbsp;&nbsp;
<asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="false" Width="20%" accept=".png,.jpg,.jpeg"  class="form-control"/>
                                  </div>
<%--                              <div class="form-group row">
 &nbsp;&nbsp; &nbsp;Role:&nbsp;&nbsp;
                                  <asp:DropDownList ID="DropDownList1" runat="server"  class="form-control" Width="20%">
                                      <asp:ListItem Selected="True">Select Option</asp:ListItem>
                                      <asp:ListItem>Trainee</asp:ListItem>
                                      <asp:ListItem>Trainer</asp:ListItem>
                                  </asp:DropDownList>
                       </div>--%>
<asp:Button ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" class="btn btn-primary"/>
    
       </div>
   </form>
</asp:Content>
