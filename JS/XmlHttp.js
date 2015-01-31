function $() {
  var elements = new Array();
  for (var i = 0; i < arguments.length; i++) {
    var element = arguments[i];
    if (typeof element == 'string')
      element = document.getElementById(element);
    if (arguments.length == 1)
      return element;
    elements.push(element);
  }
  return elements;
}

//------------------------------------------------------------------------------------------

//封装XMLHTTP的Request类的代码 
var Request = new Object();
//定义一个XMLHTTP的数组
Request.reqList = [];
//创建一个XMLHTTP对象，兼容不同的浏览器
function getAjax()
{
    var ajax=false; 
    try 
    { 
     ajax = new ActiveXObject("Msxml2.XMLHTTP"); 
    } 
    catch (e)
     { 
      try 
      { 
      ajax = new ActiveXObject("Microsoft.XMLHTTP"); 
      } 
     catch (E)
      { 
      ajax = false; 
      } 
    }
    if (!ajax && typeof XMLHttpRequest!='undefined') 
    { 
     ajax = new XMLHttpRequest(); 
    } 
    return ajax;
}
//封装XMLHTTP向服务器发送请求的操作
//url:向服务器请求的路径；method：请求的方法，即是GET还是POST；callback：当服务器成功返回结果时，调用的函数
//data：向服务器请求时附带的数据；urlencoded：url是否编码；callback2;当服务器返回错误时调用的函数
Request.send = function(url, method, callback, data, urlencoded, callback2)
 { 
    var req=getAjax();  //得到一个XMLHTTP的实例
	//当XMLHTTP的请求状态发生改变时调用
    req.onreadystatechange = function() 
    {
	// 当请求已经加载
    if (req.readyState == 4) 
    {
			// 当请求返回成功
			if (req.status < 400) 
			{
			// 当定义了成功回调函数时，执行成功回调函数
			if(callback)
				callback(req,data);
			} 
			// 当请求返回错误
//			else 
//			{
//				alert("当加载数据时发生错误 :\n" + req.status+ "/" + req.statusText);
//				//当定义了失败回调函数时，执行失败回调函数
//				if (callback2) 
//				callback2(req,data);
//			}
			//服务器已经进行了处理，更改界面提示信息
		afterLoading();
		//删除XMLHTTP，释放资源
			try {
				delete req;
				req = null;
			} catch (e) {}
		}
	}
	//如果以POST方式回发服务器
	if (method=="POST")
	 {
		req.open("POST", url, true);
		//请求需要编码
		if (urlencoded) 
		    req.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');		
		req.send(data);
		Request.reqList.push(req);
	}
	//以GET方式请求
	 else 
	{
		req.open("GET", url, true);
		req.send(null);
		Request.reqList.push(req);
	}
	//正在向服务器发送请求，页面显示正在加载的提示
loading();	
	return req;
}
//全部清除XMLHTTP数组元素，释放资源
Request.clearReqList = function() 
{
	var ln = Request.reqList.length;
	for (var i=0; i<ln; i++) {
		var req = Request.reqList[i];
		if (req) 
		{
		try 
		{
			delete req;
		} catch(e) {}
		}
	}
	Request.reqList = [];
}
//进一步封装XMLHTTP以POST方式发送请求时的代码
//clear：是否清除XMLHTTP数组的所有元素；其他参数的意义参见Request.send
Request.sendPOST = function(url, data, callback, clear, callback2) 
{
	if (clear)
		Request.clearReqList();
	Request.send(url, "POST", callback, data, true, callback2);
}
//进一步封装XMLHTTP以GET方式发送请求时的代码
Request.sendGET = function(url, callback, args, clear, callback2) 
{
	if (clear)
		Request.clearReqList();
	return Request.send(url, "GET", callback, args, false, callback2);
}
//向服务器发送请求过程中，显示页面加载提示
function loading()
{
var div = $("loading");
if(div)
div.style.display ="";
//document.getElementById('loading').innerHTML ='正在加载。。';
}
//服务器处理完成后，页面加载提示消失
function afterLoading()
{
var div = $("loading");
if(div)
div.style.display ="none";
}
//  function callback(req,data)
//{
//$("loading").innerHTML = req.responseText;
//}
////成功执行回复或添加留言后，显示提示，重新加载留言列表
//function callback3(req,data)
//{
//$("loading").innerHTML='操作成功。'; getallmsg();
//}
////服务器端返回错误时，显示提示
//function callback2(req,data)
//{
//$("s").innerHTML="出现错误，请重试！";
//}

