<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="LeaveApprovalCalender.aspx.cs" Inherits="secondwebapplication.LeaveApprovalCalender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="calendar-container">
        <h2>Leave Approval Calendar</h2>
        <!-- Calendar to display leave dates -->
        <asp:Calendar ID="LeaveCalendar" runat="server" OnDayRender="LeaveCalendar_DayRender" ></asp:Calendar>
    </div>
        <%--OnDayRender="LeaveCalendar_DayRender--%>
    <%--<div class="grid-container">
        <h2>Leave Requests</h2>
        <!-- GridView to list pending leave requests for HR approval -->
        <asp:GridView ID="LeaveRequestsGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="LeaveRequestsGrid_RowCommand">
            <Columns>
                <asp:BoundField DataField="LeaveDate" HeaderText="Leave Date" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CommandName="Approve" CommandArgument='<%# Container.DataItemIndex %>' />
                        <asp:Button ID="btnReject" runat="server" Text="Reject" CommandName="Reject" CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>--%>
        <asp:Label ID="Label1" runat="server" Text="Approved" ForeColor="#66FF66"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" ForeColor="Yellow" Text="Rejected"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" ForeColor="Gray" Text="Pending"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Holidays"></asp:Label>
</form>
</asp:Content>
