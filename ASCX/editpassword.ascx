<%@ Control Language="C#" ClassName="editpassword" %>
<table><tr><td> 旧密码：<input id="oldpassword" type="text" height="30" 
        style="width: 96px" /></td></tr><tr><td>新密码：<input id="password" 
            type="password" height="30" style="width: 96px" /></td></tr><tr><td  >
        确认新密码：<input id="repassword" type="text" height="23" style="width: 61px" /></td></tr><tr><td>
        <img src = 'images/submit.gif' onclick = 'javascript:submiteditpassword();' 
            style="width: 65px; height: 21px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Button1" type="button" value="退出" onclick = 'javascript:overeditpassword()' /></td></tr></table><div id = 'editpassworddiv'></div>