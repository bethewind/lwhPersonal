<%@ Control Language="C#" ClassName="EditStudent" %>
<style type="text/css">
    .style1
    {
        width: 150px;
    }
    #nickname
    {
        width: 137px;
    }
    #password
    {
        width: 137px;
    }
    #sclass
    {
        width: 137px;
    }
    #studyNum
    {
        width: 137px;
    }
    #classNum
    {
        width: 137px;
    }
</style>
<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            帐号：</td>
        <td>
            <input id="name" value = '<%=Server.UrlDecode(Request["name"]) %>' style="width: 137px; margin-left: 0px" type="text" /></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            姓名：</td>
        <td>
            <input id="nickname" value = '<%=Server.UrlDecode(Request["nickname"]) %>'type="text" /></td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style1">
            密码：</td>
        <td>
            <input id="password" type="text" />&nbsp;&nbsp; 填写更新，不填则为原来密码</td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style1">
            班级：</td>
        <td>
            <div id = 'divClass'>
            <input id="sclass"value = '<%=Server.UrlDecode(Request["sclass"]) %>' type="text" /><input 
                    id="Button1" type="button" value="获取班级下拉框" onclick = 'javascript:GetClass();' /></div></td>
        <td>
            &nbsp;</td>
    </tr>
     
     <tr>
        <td class="style1">
            学号：</td>
        <td>
            <input 
                id="studyNum" type="text" value = '<%=Server.UrlDecode(Request["studyNum"])%>' /></td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style1">
            班级序号：</td>
        <td>
            <input 
                id="classNum" type="text" value = '<%=Server.UrlDecode(Request["classNum"])%>' /></td>
        <td>
            &nbsp;</td>
    </tr>
   
    <tr>
        
        <td>
               <img src = '../images/submit.gif' onclick = 'javascript:submitstudent("<%=Server.UrlDecode(Request["id"])%>")'  />
            &nbsp;</td>
    </tr>
</table>
