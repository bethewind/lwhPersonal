<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplyForum.aspx.cs" Inherits="ReplyForum" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>回复帖子</title>
</head>
<body>
    <form id="form1" runat="server">
   <%-- <div>
    
        标题：<asp:TextBox ID="boxtitle" runat="server" ReadOnly="True"></asp:TextBox>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Text="Label" 
            Font-Size="Small"></asp:Label>
    
    </div>
    <CE:Editor ID="Editor1" runat="server" SecurityPolicyFile="guest.config">
<FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="100%" Width="100%"></FrameStyle>
    </CE:Editor>
    <asp:Button ID="btnreply" runat="server" Text="回复" onclick="btnreply_Click" />--%>
     <table style='border-style: solid; border-width: 2px; border-color: #99CCFF; width: 628px; font-size: 14px;background-image: url(Images/%E8%83%8C%E6%99%AF.jpg);' 
            align="left" frame="box"><tr><td>
        标题：<asp:TextBox ID="boxtitle" runat="server" ReadOnly = 'true' Width="226px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
            ID="Label1" runat="server" Font-Size="Smaller" ForeColor="Black"></asp:Label>
                    </td></tr><tr><td>
                    <CE:Editor ID="Editor1" runat="server" 
                        SecurityPolicyFile="Guest.config" BackColor="#F4F4F3" Width="780px"  Height = "450px"
                        >
<FrameStyle  BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="100%" Width="100%"></FrameStyle>
                    </CE:Editor>
                    </td></tr><tr>
               <td style='overflow: scroll; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0; color: #000000;'>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="submit" runat="server" Text="回复" onclick="btnreply_Click" 
                            BackColor="White" Width="115px" /><font color='red'> 小提示：为了正常显示，请在宽度超出时换行<font></td></tr></table>
    </form>
</body>
</html>
