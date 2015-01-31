<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户注册</title>
     <script type="text/javascript" src="JS/XmlHttp.js"> </script>
      <script type="text/javascript" src="JS/regist.js"> </script>
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
        .style2
        {
            height: 34px;
        }
        .style3
        {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1" cellpadding="0" cellspacing="0" 
            
            style="border: 2px solid #99CCFF; text-align: left; font-size: 14px; background-image: url(Images/%E8%83%8C%E6%99%AF.jpg);">
    <tr  border-bottom-style: solid; border-bottom-width: 1px">
        <td>
            <asp:Label ID="Label1" runat="server" Text="账号："></asp:Label></td>
        <td>
            <asp:TextBox ID="Txt_UserName" TabIndex="1" onBlur="j_username()" 
                runat="server" Height="23px" Width="138px"></asp:TextBox>
            <span id="NameError" style="color: #ff0033;"></span>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="style1">
            ※ 用户名只能是字母、数字、下划线 (_) 或其组合,并且以字母为开头长度为5～18个字符。</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label></td>
        <td class="style2">
            <asp:TextBox ID="Txt_Password" onBlur="j_password()" runat="server" TextMode="Password"
                Width="138px" Height="23px"></asp:TextBox>
            <span id="PwdError" style="color: #ff0033; "></span>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="style3">
            ※ 密码只能是6～12位字母、数字或二者组合，区分大小写。</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="确认密码"></asp:Label>：</td>
        <td>
            <asp:TextBox ID="Txt_Password_AG" runat="server" onBlur="j_password1()" TextMode="Password"
                Width="138px" Height="23px"></asp:TextBox>
            <span id="PwdError2" style="color: #ff0033; "></span>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="邮箱："></asp:Label></td>
        <td>
            <asp:TextBox ID="Txt_Email" runat="server" onblur="j_email();" Height="23px" 
                Width="138px"></asp:TextBox>
            <span id="EmailError" style="color: #ff0033;"></span>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="姓名："></asp:Label></td>
        <td>
            <asp:TextBox ID="txt_realname" runat="server" Height="23px" Width="138px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="验证码："></asp:Label></td>
        <td>
            <asp:TextBox ID="txt_check" runat="server" Width="138px"></asp:TextBox>
            &nbsp;
            <img src="Admin/images2.aspx" alt = '看不清，换一张'onclick="this.src='Admin/images2.aspx?'+new Date();" id="checkcode2" name="checkcode"  /><div 
             id = 'checkdiv'style="width: 233px">
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <input id="Button1" type="button" value="注册" onclick="j_submit()" />&nbsp; &nbsp;<input
                id="Reset2" type="reset" value="重置" /></td>
    </tr>
</table>

    </div>
    </form>
</body>
</html>
