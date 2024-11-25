<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="trainerIntraChat.aspx.cs" Inherits="secondwebapplication.trainerIntraChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <style>
    

     
     #btnLoadChat, #btnSend {
         background-color: #5cb85c;
         color: white;
         border: none;
         padding: 10px 15px;
         border-radius: 4px;
         cursor: pointer;
         margin-top: 10px;
     }

/*     #btnLoadChat:hover, #btnSend:hover {
         background-color: #4cae4c;
     }*/

     #chatArea {
         border: 1px solid #ccc;
         height: 200px;
         overflow: auto;
         margin-top: 10px;
         padding: 10px;
         background-color: #fafafa;
         border-radius: 4px;
     }

     #litChat {
         white-space: pre-wrap; /* Preserve whitespace and line breaks */
     }
 </style>
    <form  id="form1" runat="server">
         <h2>Intra Chat</h2>
    <div>
        <%--<label for="txtName">Your Name:</label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />--%>
        <div>
        <div class="form-group row">
        &nbsp;&nbsp;&nbsp;<label for="ddlEmployees">Select Employee:</label>
        &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlEmployees" runat="server" class="form-control" Width="20%" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployees_SelectedIndexChanged">
            <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
        </asp:DropDownList><br />
        </div>

      <%--  <asp:Button ID="btnLoadChat" runat="server" Text="Load Chat" OnClick="btnLoadChat_Click" /><br />--%>

        <div id="chatArea" class="from-control" style="border: 1px solid #ccc;width:40%; height: 200px; overflow: auto;">
            &nbsp;&nbsp;&nbsp;<asp:Literal ID="litChat" runat="server" ></asp:Literal>
        </div>

        <div class="d-flex align-items-center">
           <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" class="form-control" Rows="2" Width="20%"></asp:TextBox>
           &nbsp;&nbsp;&nbsp; <asp:Button ID="btnSend" runat="server" class="ms-3 btn btn-success" Text="Send" OnClick="btnSend_Click" />
        </div>
        </div>
    </div>
</form>

</asp:Content>
