<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doWork.aspx.cs" Inherits="doWork" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提交作业</title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div>
    
        <table style="width:100%;">
            <tr>
                
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
           
            <tr>
                
                <td>
                    <CE:Editor ID="Editor1" runat="server">
                    </CE:Editor>
                </td>
            </tr>
        </table>
    
    </div>
    <asp:Button ID="Button1" runat="server" Text="交作业" onclick="Button1_Click" />--%>
     <table style='border-style: solid; border-width: 2px; border-color: #99CCFF; width: 628px; font-size: 14px;background-image: url(Images/%E8%83%8C%E6%99%AF.jpg);' 
            align="left" frame="box"><tr><td >
        标题：<asp:TextBox ID="boxtitle" runat="server" ReadOnly = 'true'></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr><tr><td>
                    上传作业：<input id="File1" runat="server" type="file" />&nbsp;&nbsp;&nbsp;<asp:Button
                        ID="Button1" runat="server" Text="上传" onclick="Button1_Click" />
                    <asp:Label 
                 ID="Label1" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
                </td></tr><tr><td>作业附件:<input id="File2" runat="server" 
                        type="file" />&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" 
                 Text="上传" onclick="Button2_Click" />
             <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label" 
                 Visible="False"></asp:Label>
                </td></tr><tr>
               <td style='overflow: scroll; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; color: #000000;'>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                        </td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            作业上传说明<br />
            1.上传作业学生请先登录。<br />
            2.上传后再次上传会覆盖原来的作页。<br />
            3.上传作业格式为.doc，最大10000k。付件格式为zip/rar，最大50000k.<br />
            4.在老师批改以后或已过上传期限将不能上传或覆盖。&nbsp;</td></tr></table>
    </form>
</body>
</html>
