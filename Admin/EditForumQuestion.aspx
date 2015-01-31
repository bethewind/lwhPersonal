<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditForumQuestion.aspx.cs" Inherits="EditForumQuestion" %>

<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
     <script type="text/javascript" src="../JS/XmlHttp.js"> </script>
    <script type="text/javascript" src ="../JS/comment.js"></script>
     <script type ="text/javascript">
    function GetType()
    {
        $('student').value = $('select2').value;
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
   <%-- <div>
    <table style="width:100%; height: 771px;">
    <tr>
        <td style="color: #9999FF">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;编辑</td>
       
    </tr>
    <tr>
        <td>
           <asp:Panel ID="Panel1" 
                    runat="server">
                权限:<asp:TextBox 
                ID="steptbox" runat="server"></asp:TextBox>
                <input ID="Button1" onclick="javascript:GetNetUserStept()" style="width: 84px" 
                    type="button" value="选择权限" />
                </asp:Panel>
            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id = 'stept'></div>
        </td>
       
    </tr>
    <tr>
        <td>
            标题：<asp:TextBox ID="title" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
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
            作者：<asp:TextBox ID="author" runat="server"></asp:TextBox>
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
</table>
    </div>--%>
     <div style="border: 2px solid #99CCFF; width: 780px; font-size: 14px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);">
<div style="font-size: 24px; text-align: center; color: #0000CC; height: 26px;">编辑信息</div>
<div style="height: 28px"> <div style="height: 27px; width: 265px; float:left;">标题：<asp:TextBox 
        ID="title" runat="server" Width="215px"></asp:TextBox></div>
    <div style =" float:left; width: 257px;">
    <asp:Panel
                    ID="Panel1" runat="server" Width="242px">权限:<asp:TextBox 
                ID="steptbox1" runat="server" ReadOnly="True" Width="134px"></asp:TextBox> </asp:Panel></div>
                <div id = 'stept' style ="float:left;"> 
                    <asp:Panel
                    ID="Panel2" runat="server" Width="213px"><input ID="Button2" onclick="javascript:GetNetUserStept()" style="width: 84px" 
                    type="button" value="选择权限" /></asp:Panel></div>
   </div>
          
<div>  <CE:Editor ID="Editor1" runat="server" Height="350px" 
                SecurityPolicyFile="Admin.config" Width="780px"  AutoConfigure="Default">
<FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderWidth="1px" BorderStyle="Solid" CssClass="CuteEditorFrame" Height="350" Width="100%"></FrameStyle>
            </CE:Editor></div>
            <div> 作者：<asp:TextBox ID="author" runat="server"></asp:TextBox></div>
<div style="height: 26px; text-align: center;"><asp:Button ID="submitTeachPark" 
                runat="server" Text="提交" onclick="submitTeachPark_Click" 
        Width="54px"  />&nbsp; <font color='red'> 小提示：为了正常显示，请在宽度超出时换行<font></div>
<div style ="display:none"> 权限<asp:TextBox 
                ID="steptbox" runat="server"></asp:TextBox></div>
    </div>
    </form>
</body>
</html>
