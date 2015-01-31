//验证用户名
var a = 1;
var b = 1;
var c = 1;
var e = 1;
function j_username()
{
	document.getElementById("NameError").innerHTML = "";//清空错误信息
	var userName = document.getElementById("Txt_UserName").value;
	var reg = "[^a-zA-Z_0-9]";//判断用户名只能为字母，数字，下划线的正则表达式
	var reg1 = "\\D";//判断用户名必须以字母开头的正则表达式
	if(userName == "")//用户名为空，不可以
	{
		document.getElementById("NameError").innerHTML = "<font color='red'>用户名不能为空!<font><br>";
		a = 1;
		return ;
	}
	else if(userName.length < 5||userName.length > 18)//判断用户名长度
	{
		document.getElementById("NameError").innerHTML = "<font color=\"red\">你输入的用户名长度太短！长度必须为5～18位！<font><br>";
		a = 1;
			return ;
	}
	else 
	{
		if(!userName.substring(0,1).match(reg1))//用户名不是以字母开头
		{
			document.getElementById("NameError").innerHTML = "<font color=\"red\">必须已字母开头!<font><br>";
		a = 1;
				return ;
		}
		else if(userName.match(reg))//用户名中出现其他特殊字符
		{
			document.getElementById("NameError").innerHTML = "<font color=\"red\">用户名只能是字母、数字、下划线!<font><br>";
		a = 1;
				return ;
		}
		
    }
    var userName = document.getElementById("Txt_UserName").value;
	var d = new Date();
	var url = "ajaxUser.aspx?type=16&userName="+userName+"&guid=" + d.getTime();//发送请求的路径
    Request.sendGET(url, check1 , null, true, null); 
}
function check1(req){
switch (req.responseText)
{
case "0": document.getElementById('NameError').innerHTML= "此用户已存在！";a=1;break;
case "1": document.getElementById('NameError').innerHTML = "恭喜你！次用户可注册";a=0;break;

//document.getElementById('NameError').innerHTML= req.responseText;
//canSubmit = true;
}
}
//验证密码是否符合规则
function j_password()
{
	var password = document.getElementById("Txt_Password").value;
	if (password.length < 6 || password.length > 12)//密码长度是否符合规则
	{
		document.getElementById("PwdError").innerHTML = "<font color=\"red\">密码长度不正确。<font>";
	b = 1;
		return;
	}
	if (document.getElementById("Txt_UserName").value == password)//用户名和密码不能相同
	{
		document.getElementById("PwdError").innerHTML = "<font color=\"red\">为了您的安全，用户名与密码不能一致，请使用新的密码<font>";
		b = 1;
		return;
	}
	var reg = "\\W";
	if(password.match(reg))//密码是否出现英文或数字之外的字符
	{
		document.getElementById("PwdError").innerHTML = "<font color=\"red\">密码只能是英文或者数字!<font>";
		b = 1;
		return;
	}
b = 0;//都符合条件，验证通过

	document.getElementById("PwdError").innerHTML = "";
}
//判断两次输入的密码是否一致
function j_password1()
{
	var password = document.getElementById("Txt_Password_AG").value;
	if(password != document.getElementById("Txt_Password").value)//两次输入的密码不相同，出现错误提示
	{
		document.getElementById("PwdError2").innerHTML = "<font color=\"red\">两次输入的密码不一致,请重新输入!<font>";
		document.getElementById("Txt_Password_AG").value = "";
		c = 1;
		return;
	}
	//两次输入的密码相同，校验通过。
	document.getElementById("PwdError2").innerHTML = "";
	c = 0;
}
//检验邮件格式是否正确
function j_email()
{
	var email = document.getElementById("Txt_Email").value;//得到输入的邮箱
	var reg = /^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$/;//定义验证邮件的正则表达式
	if(!email.match(reg))//验证失败，显示错误信息，返回
	{
		document.getElementById("EmailError").innerHTML = "<font color=\"red\">邮件地址无效!<font>";
	e = 1;
		return;
	}
	document.getElementById("EmailError").innerHTML = "";
e = 0;//验证通过

}
//提交注册
function j_submit()
{
    var m = a+b+c+e;
	if(m==0)//验证没有通过，返回
	{
	var webName = $('Txt_UserName').value;
  var webPassWord = $('Txt_Password').value;
   var nick = $('txt_realname').value;
    var email = $('Txt_Email').value;
     var checkNum = $('txt_check').value;
    var d = new Date();
	var url = "ajaxUser.aspx?type=17&webName="+webName+"&webPassWord="+webPassWord+"&nick="+escape(nick)+"&email="+email+"&checkNum="+checkNum+"&guid=" + d.getTime();//发送请求的路径
    Request.sendGET(url, check11 , null, true, null); 
//	alert("输入错误，请检查您的输入！");
//	return;
	}
else {
 alert("输入错误，请检查您的输入！");
    }
}
function check11(req){

switch (req.responseText)
{
case "0":  alert("登录成功！可到首页登录了！");window.close();;break;
case "1": document.getElementById('checkdiv').innerHTML = "<font color='red'> 验证码不正确！<font>";break;


}

}
