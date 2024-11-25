<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AddDocument.aspx.cs" Inherits="secondwebapplication.AddDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" enctype="multipart/form-data">
        <h2>Add Document</h2>
<p class="form-group row">
    Select Document Type:&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" Width="20%">
        <asp:ListItem Value="Select" disabled></asp:ListItem>
        <asp:ListItem Value="Aadhar Card"></asp:ListItem>
        <asp:ListItem Value="Pan Card"></asp:ListItem>
        <asp:ListItem Value="SSC Result"></asp:ListItem>
        <asp:ListItem Value="HSC Result"></asp:ListItem>
    </asp:DropDownList>
</p>
<div class="form-group row">
    Attachments:&nbsp;&nbsp;&nbsp;
    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="false"  Width="20%" class="form-control" accept=".pdf,.png,.jpg,.jpeg"/>
</div>
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" class="btn btn-primary" />


        <asp:GridView ID="GridViewFiles" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewFiles_RowCommand" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
    <Columns>
        <asp:BoundField DataField="FileName" HeaderText="File Name" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="ButtonDownload" runat="server" class="btn btn-primary" Text="Download" 
                    CommandArgument='<%# Eval("FileName") %>' CommandName="Download" />
                <asp:Button ID="ButtonView" runat="server" Text="View" 
                    CommandArgument='<%# Eval("FileName") %>' class="btn btn-info" CommandName="View" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
</asp:GridView>

<%--<asp:GridView ID="GridViewFiles" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewFiles_RowCommand">
    <Columns>
        <asp:BoundField DataField="FileName" HeaderText="File Name" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="ButtonDownload" runat="server" Text="Download" 
                    CommandArgument='<%# Eval("FileData") %>' CommandName="Download" />
                <asp:Button ID="ButtonView" runat="server" Text="View" 
                    CommandArgument='<%# Eval("FileData") %>' CommandName="View" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>--%>





<%--        <h2>Add Document</h2>
    <p>
        <br />
        Select Document Type:
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="Select"></asp:ListItem>
            <asp:ListItem Value="Aadhar Card"></asp:ListItem>
            <asp:ListItem Value="Pan Card"></asp:ListItem>
            <asp:ListItem Value="SSC Result"></asp:ListItem>
            <asp:ListItem Value="HSC Result"></asp:ListItem>
        </asp:DropDownList>
    </p>
    <div>
        Attachments:
        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
    </div>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
    

        <asp:GridView ID="GridViewFiles" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
    <Columns>
        <asp:BoundField DataField="Ename" HeaderText="Employee Name" />
        <asp:BoundField DataField="FileName" HeaderText="File Name" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="ButtonDownload" runat="server" Text="Download" 
                            CommandArgument='<%# Eval("FileName") %>' CommandName="Download" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>--%>

    <%--<asp:GridView ID="GridViewFiles" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="FileName" HeaderText="File Name" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLinkView" runat="server" 
                        NavigateUrl='<%# Eval("FilePath") %>' Text="View" Target="_blank"></asp:HyperLink>
                    <asp:Button ID="ButtonDownload" runat="server" Text="Download" 
                        CommandArgument='<%# Eval("FilePath") %>' OnCommand="ButtonDownload_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Ename" HeaderText="Employee Name" />
                    <asp:TemplateField HeaderText="Document Name">
                        <ItemTemplate>
                            <%# Eval("DocumentName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnDownload" runat="server" 
                                        Text="Download" 
                                        CommandName="Download" 
                                        CommandArgument='<%# Eval("Ename") + "," + Eval("DocumentName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
    
    <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>
</form>
</form>
</asp:Content>
