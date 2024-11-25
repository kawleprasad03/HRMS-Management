<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="secondwebapplication.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Employee Register</h2>
        <div>
             Username:&nbsp;&nbsp;
 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
 <br />
 <br />
 Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
 <br />
 <br />
 Password:&nbsp;&nbsp;
 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
 <br />
 <br />
 <asp:Button ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
     
        </div>
    </form>
</body>
</html>
