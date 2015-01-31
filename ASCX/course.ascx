<%@ Control Language="C#" ClassName="addType" %>

<style type="text/css">
    #Button1
    {
        height: 24px;
        width: 1427px;
    }
    .style3
    {
        width: 700px;
    }
    #Button2
    {
        width: 124px;
    }
    </style>
<%--管理员列表页面--%>
<input id="title" style ="display :none" type="text" />
<table 
    style="border-style: solid; border-width: 2px 2px 1px 2px; border-color: #99CCFF; height: 44px; width: 840px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg); color: #0000FF;" 
   >
<tr>
        <td class="style3" style="text-align: center">
            课程列表</td>
        
    </tr>
    <%--<tr>
        
        <td class="style3">
            <div id = 'mList'>
         <%-- <table  style='border-style: none solid solid solid; border-width: 0px 2px 2px 2px; border-color: #FFFFFF #99CCFF #99CCFF #99CCFF; width: 764px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);'>
            <tr><td class='style9'>编号</td><td class='style10'>姓名</td><td class='style8'>昵称</td><td class='style6'>修改</td></tr><tr><td class='style9'>{0}</td><td class='style10'>{1}</td><td class='style8'>{2}</td><td class='style6'><a href=\"javascript:edit({0},'{1}','{2}');\"><img src='../Images/edit.gif' style='border: 0px none #FFFFFF' /></a></td></tr></table>
               <table style='width: 208%; color: #0000FF;'><tr><td class='style4'>姓名：</td><td><input id='Text1' type='text'/></td></tr><tr><td class='style4'>旧密码：</td><td><input id='Password2' type='password' /></td></tr><tr><td class='style4'>新密码：</td><td><input id='Password1' type='password' /></td></tr><tr><td><img src='../Images/submit.gif'  onclick = 'javascript:submit()'/></td></tr></table>
  <table style='border-style: none solid solid solid; border-width: 0px 2px 2px 2px; border-color: #FFFFFF #99CCFF #99CCFF #99CCFF; width: 770px; color: #0000FF;'><tr><td class='style4'>姓名：</td><td><input id='name' value = '" + Server.UrlDecode(Request["name"]) + "' type='text'/></td></tr><tr><td class='style4'>昵称：</td><td><input id='nickname'value = '" + Server.UrlDecode(Request["nickname"]) + "' type='text'/></td></tr><tr><td class='style4'>旧密码：</td><td><input id='oldpassword' type='password' /></td></tr><tr><td class='style4'>新密码：</td><td><input id='password' type='password' /></td></tr><tr><td><img src='../Images/submit.gif'  onclick = 'javascript:submitadmin()'/></td></tr></table>
               </div> 
        </td>
    </tr>--%>
</table>





