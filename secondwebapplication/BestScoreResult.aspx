<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer.Master" AutoEventWireup="true" CodeBehind="BestScoreResult.aspx.cs" Inherits="secondwebapplication.BestScoreResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #DataList1 {
             background: white;
               box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
    </style>
     <form id="form1" runat="server">
          <h2>Top 3 Best Score</h2>
          <div class="form-group row">
         <asp:Label ID="Label1" runat="server" Text="From Date :"></asp:Label>
     &nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" CssClass="form-control" Width="20%"></asp:TextBox>
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="To Date :"></asp:Label>
     &nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="form-control" Width="20%"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" class="btn btn-outline-success my-2 my-sm-0"/>

        </div><br/> <br/>
         <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
            <ItemTemplate>
                <div style="border: 1px solid #ccc; padding: 10px; margin: 5px; background: white;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);     border-radius: 4px;">
                    <div style="text-align: center;">
                        <asp:Image ID="ProfileImage" runat="server" 
                                   ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("profilephoto")) %>' 
                                   Width="100px" Height="100px" />
                        <h4><%# Eval("username") %></h4>
                        <p>Score: <%# Eval("total_score") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
         <br/>
          <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
          <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" CssClass="btn btn-primary" Text="Push" />
     </form>
</asp:Content>
