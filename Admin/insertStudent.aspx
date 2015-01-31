<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insertStudent.aspx.cs" Inherits="Admin_insertStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导入学生列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input id="File1" runat="server" type="file" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="导入" onclick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
       <%-- <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
    </div>
    </form>
</body>
</html>
