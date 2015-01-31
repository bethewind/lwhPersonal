<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditIt.aspx.cs" Inherits="Admin_EditIt" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文章编辑页面</title>
     <script type="text/javascript" src="../JS/XmlHttp.js"> </script>
    <script type="text/javascript" src ="../JS/comment.js"></script>
     <script type ="text/javascript">
    function GetType()
    {
        $('type').value = $('select2').value;
    }
    function GetCourse()
    {
         $('course').value = $('select3').value;
    }
    function GetStept()
    {
         $('steptbox').value = $('stept22').value;
    }
    </script>
          <link href =   "../CSS/Admin.css" rel = "stylesheet" type ="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div style="border: 2px solid #99CCFF; width: 780px; font-size: 14px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);">
    <%--<table style="width:100%; height: 771px;">
    <tr>
        <td style="color: #9999FF">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;编辑</td>
       
    </tr>
    <tr>
        <td>
            分类：<asp:TextBox ID="type" runat="server"></asp:TextBox>权限<asp:TextBox 
                ID="steptbox" runat="server"></asp:TextBox>&nbsp;&nbsp;课程&amp;方向<asp:TextBox 
                ID="course" runat="server"></asp:TextBox>
            &nbsp;<input id="Button1" style="width: 84px" onclick = 'javascript:ShowDropdownList("<%=Request.QueryString["park"] %>")' type="button" value="点击选择分类&权限" /><div id = 'check2' style="width: 729px">
            </div>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id = 'stept'></div>
        </td>
       
    </tr>
    <tr>
        <td>
            标题：<asp:TextBox ID="title" runat="server"></asp:TextBox>
                    </td>
      
    </tr>
    <tr>
        <td>
           </td>
      
    </tr>
     <tr>
        <td>
            &nbsp;</td>
      
    </tr>
     <tr>
        <td style="width: 976px; height: 351px">
            <CE:Editor ID="Editor1" runat="server" Height="374px" 
                SecurityPolicyFile="Admin.config" Width="860px" AutoConfigure="Default">
<FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="100%" Width="100%"></FrameStyle>
            </CE:Editor>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;<asp:Button ID="submitTeachPark" 
                runat="server" Text="提交" onclick="submitTeachPark_Click"  />
                    </td>
      
    </tr>
     <tr>
        <td>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
      
    </tr>
</table>--%>
<div style="font-size: 24px; text-align: center; color: #0000CC; height: 26px;">编辑信息</div>
<div style="height: 28px"><div style =" float:left">权限<asp:TextBox 
                ID="steptbox1" runat="server" ReadOnly="True"></asp:TextBox>分类：<asp:TextBox 
        ID="type1" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;</div>
                <div style ="float:left; width: 287px;">
                    <asp:Panel
                    ID="Panel1" runat="server" Width="287px"> 课程&amp;方向<asp:TextBox 
                ID="course1" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;
                </asp:Panel></div>
   </div>
<div style="height: 26px"><div id = 'stept' style ="float:left;"><input id="Button1" style="width: 117px" 
               onclick = 'javascript:ShowDropdownList("<%=Request.QueryString["park"] %>")' 
               type="button" value="点击选择分类&权限" /></div><div id = 'check2' style="width: 397px; float:left; height: 25px;">
            </div></div>
           <div style="height: 27px">标题：<asp:TextBox ID="title" runat="server" Width="215px"></asp:TextBox></div>
<div>  <CE:Editor ID="Editor1" runat="server" Height="350px" 
                SecurityPolicyFile="Admin.config" Width="780px"  AutoConfigure="Default">
<FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="350" Width="100%"></FrameStyle>
            </CE:Editor></div>
<div style="height: 26px; text-align: center;"><asp:Button ID="submitTeachPark" 
                runat="server" Text="提交" onclick="submitTeachPark_Click" 
        Width="54px"  />&nbsp;<font color='red'> 小提示：为了正常显示，请在宽度超出时换行<font></div>
<div style ="display:none"> 分类：<asp:TextBox ID="type" runat="server"></asp:TextBox>权限<asp:TextBox 
                ID="steptbox" runat="server"></asp:TextBox>&nbsp;&nbsp;课程&amp;方向<asp:TextBox 
                ID="course" runat="server"></asp:TextBox></div>
    </div>
    </form>
</body>
</html>
