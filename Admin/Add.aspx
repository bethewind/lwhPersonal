<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Add" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息添加</title>
    <script type ="text/javascript">
    function GetType()
    {
        $('type').value = $('select2').value;
    }
    function GetCourse1()
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
        信息添加</div>
     <div id = 'Div1' 
             style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #99CCFF">
       上传图片：
    <input 
                      id="file2" runat="server" class="inputBox" style="width: 134px" 
                      type="file" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" 
                    Font-Size="12px" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                &nbsp;
                  <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="上传" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="ispic" runat="server" 
                      Text="首页图片&只限新闻类别" Width="252px" Height="21px" />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
    </div>
     <div id = 'Div2'>
     
      <div id = 'parkdiv' style="float: left; height: 25px;"> 选择园地： <select id="Select1" runat="server" onchange="javascript:select(this.value);"  name="D1" style="width: 86px; height: 25px"><option value = '11'>请选择</option>
        <option value = '0'>时事新闻</option> <option value = '1'>教师园地</option> <option value = '2'>科研地带</option> <option value = '3'>学生园地</option> <option value = '4'>资源中心</option> <option value = '5'>学科知识</option>
    </select></div> <div id = 'stept' style="float: left"> </div>
                    <div id = 'check2'style="float: left">
            </div>
        
     
    </div> <div id = 'd' 
             style="float: left; height: 28px; border-top-style: solid; border-bottom-style: solid; border-top-width: 1px; border-bottom-width: 1px; border-top-color: #99CCFF; border-right-color: #FFFFFF; border-bottom-color: #99CCFF;">标题：<asp:TextBox 
                 ID="title" runat="server" style="width: 128px" Width="138px"></asp:TextBox></div>
     <div id = 'Div4' style="float: left;">
       <CE:Editor ID="content" runat="server" AutoConfigure="Default" 
                SecurityPolicyFile="admin.config" Width="780px" Height = "350px" Font-Size="X-Small">
<FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="350px" Width="100%"></FrameStyle>
            </CE:Editor>
    </div>
    <div id = 'div5' style="text-align: center"><asp:Button ID="submit" runat="server" 
            Text="提交" onclick="submit_Click" Width="95px" />
            &nbsp;&nbsp; <font color='red'> 小提示：为了正常显示，请在宽度超出时换行<font></div>
            <div id = 'hd'style ="display:none" > 权限ID:&nbsp;<asp:TextBox ID="steptbox" runat="server"></asp:TextBox>
                    &nbsp;类别ID:<asp:TextBox ID="type" 
                runat="server" ></asp:TextBox>
            &nbsp;课程&amp;方向ID:<asp:TextBox ID="course" runat="server"></asp:TextBox><asp:TextBox ID="pic" runat="server" Height="21px" 
                      Width="138px" ></asp:TextBox></div></div>
</form>
</body>
</html>
