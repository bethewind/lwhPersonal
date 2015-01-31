<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewWork.aspx.cs" Inherits="Admin_AddNewWork" %>
<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>信息添加</title>
    <script type ="text/javascript">
   
    function GetNewWorkCourse()
    {
         $('course').value = $('select3').value;
    }
    function GetStept()
    {
         $('steptbox').value = $('stept22').value;
    }
    </script>
     <script type="text/javascript" src="../JS/XmlHttp.js"> </script>
    <script type="text/javascript" src ="../JS/comment.js"></script>
        
    <style type="text/css">
        #form1 #check2 {
	float: left;
	height: 24px;
	width: 409px;
}
        #parkdiv
        {
            width: 179px;
        }
        #stept
        {
            width: 186px;
            height: 24px;
        }
        #d
        {
            width: 780px;
        }
        #div5
        {
            height: 31px;
            width: 777px;
        }
        #Select1
        {
            height: 15px;
        }
        #Div2
        {
            height: 28px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
     <div style="border: 2px solid #99CCFF; width: 780px; font-size: 14px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);">
<div id = 'titlediv' 
             style="font-size: 24px; color: #0000CC; text-align: center; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #99CCFF;">
        作业添加</div>
     <div id = 'Div2'>
     
       <div id = 'stept' style="float: left"><input type='button' value='点击选择权限&课程' onclick='javascript:GetSteCourse()'/>  </div>
                    <div id = 'check2'style="float: left">
            </div>
        
     
    </div> <div id = 'd' 
             style="float: left; height: 28px; border-top-style: solid; border-bottom-style: solid; border-top-width: 1px; border-bottom-width: 1px; border-top-color: #99CCFF; border-right-color: #FFFFFF; border-bottom-color: #99CCFF;">标题：<asp:TextBox 
                 ID="title" runat="server" style="width: 128px" Width="138px"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;上传期限:<asp:TextBox
            ID="year" runat="server" Width="56px"></asp:TextBox>年<asp:TextBox
            ID="month" runat="server" Width="32px"></asp:TextBox>
             月<asp:TextBox ID="day" runat="server" Width="30px"></asp:TextBox>
             日</div>
     <div id = 'Div4' style="float: left;">
       <CE:Editor ID="content" runat="server" AutoConfigure="Default" 
                SecurityPolicyFile="admin.config" Width="780px" Height = "350px" Font-Size="X-Small">
<FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="350px" Width="100%"></FrameStyle>
            </CE:Editor>
    </div>
    <div id = 'div5' style="text-align: center"><asp:Button ID="submit" runat="server" 
            Text="提交" onclick="submit_Click" Width="95px" />
            &nbsp;&nbsp; <font color='red'> 小提示：为了正常显示，请在宽度超出时换行<font></div>
            <div id = 'hd'style = 'display:none;' > 权限ID:&nbsp;<asp:TextBox ID="steptbox" runat="server"></asp:TextBox>
                   
            &nbsp;课程&amp;方向ID:<asp:TextBox ID="course" runat="server"></asp:TextBox></div></div>
</form>
</body>
</html>
