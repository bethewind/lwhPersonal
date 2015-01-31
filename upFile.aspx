<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upFile.aspx.cs" Inherits="upFile" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生上传资源</title>
     <link href="user.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="JS/XmlHttp.js"> </script>
    <script type="text/javascript" src ="JS/commentUser.js"></script>
     <script type ="text/javascript">
    
    function GetCourse()
    {
         $('boxCourse').value = $('select3').value;
    }
   
    </script>
    <style type="text/css">
        #check2
        {
            width: 786px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"><div id = 'check2' 
        
        style="border-style: solid solid none solid; border-width: 2px 2px 0px 2px; border-color: #99CCFF #99CCFF #FFFFFF #99CCFF; font-size: 14px;"><input id="Button1" style="width: 84px" onclick = 'javascript:ShowDropdownList()' type="button" value="点击选择课程" /></div>
    <div>
    
      <table style='border: 2px solid #99CCFF; width: 628px; font-size: 14px; background-image: url(Images/%E8%83%8C%E6%99%AF.jpg);'><tr><td>
        标题：<asp:TextBox ID="boxTitle" runat="server" Width="196px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div style ="display:none;">课程编号自动：&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
              ID="boxCourse" runat="server" Height="16px" Width="16px"></asp:TextBox></div>
          &nbsp;&nbsp;</td></tr><tr><td>
                    <CE:Editor ID="Editor1" runat="server" 
                        SecurityPolicyFile="Guest.config" BackColor="#F4F4F3" Width="780px"  Height = "450px"
                        >
<FrameStyle  BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="100%" Width="100%"></FrameStyle>
                    </CE:Editor>
                    </td></tr><tr><td style='overflow: scroll; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0;'>
                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="submit" runat="server" Text="上传" onclick="submit_Click" />&nbsp; <font color='red'> 小提示：为了正常显示，请在宽度超出时换行<font></td></tr></table>
    
    </div>
    </form>
</body>
</html>
