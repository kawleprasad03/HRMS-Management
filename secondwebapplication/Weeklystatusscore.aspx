<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Weeklystatusscore.aspx.cs" Inherits="secondwebapplication.Weeklystatusscore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form id="form1" runat="server">
          Select Weekly Score:&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
          </asp:DropDownList>
          <br />

          <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
              <ItemTemplate>
                  <div style="border: 1px solid #ccc; padding: 10px; margin: 5px; background: white;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);     border-radius: 4px;">
                      <div style="text-align: center;">
                          <asp:Image ID="ProfileImage" runat="server" 
                                     ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("profilephoto")) %>' 
                                     Width="100px" Height="100px" />
                          <h4><%# Eval("username") %></h4>
                          <p>Score: <%# Eval("totalscore") %></p>
                      </div>
                  </div>
              </ItemTemplate>
         </asp:DataList>
      </form>
</asp:Content>
