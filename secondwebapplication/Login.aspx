<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="secondwebapplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <style type="text/css">
        #content{
                display: flex;
                justify-content: center;
                text-align: center;
                padding: 20px
        }
        #form1 {
    background: white;
    width: auto;
    margin:10px;
    padding: 40px;
    border-radius: 8px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
 
}
    </style>
</head>
<body>
    <div id="content">

    <form id="form1" runat="server" style="margin-left:2px">
        <h2>Login</h2>
        <div >
            <div class="form-group row">
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"  class="form-control"></asp:TextBox>
                </div>

            <div class="form-group row">
                Password:&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server"  class="form-control" ></asp:TextBox>
            </div>


<asp:Button ID="Button1" runat="server" Text="Sign In" OnClick="Button1_Click" class="btn btn-primary" />
<br />

<%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Register.aspx">Create New Account</asp:HyperLink>--%>
     
        </div>
    </form>
    </div>
</body>
</html>
