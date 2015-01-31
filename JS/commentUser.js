//用户登录，检测用户名密码是否正确
function login(name,pass,num)
{
	var d = new Date();
	var url = "ajaxUser.aspx?type=0&name=" + name +"&pass="+pass+ "&guid=" + d.getTime()+ "&num=" + num;//发送请求的路径
    Request.sendGET(url, Login , null, true, null); 

}
function GetTopRight()
{
      var url = "ajaxUser.aspx?type=29&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetTopRight1(req){document.getElementById('topRight').innerHTML= req.responseText;} , null, true, null); 
}
function overeditpassword()
{
    $('search1').style.display = '';document.getElementById('editpassworddiv').innerHTML="";document.getElementById('proLogin1').innerHTML="";
}
function submiteditpassword()
{
    var oldpassword = $('oldpassword').value;
    var password = $('password').value;
    var repassword = $('repassword').value;
     var url = "ajaxUser.aspx?type=27&oldpassword="+oldpassword+"&password="+password+"&repassword="+repassword+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, submiteditpassword1 , null, true, null); 
}
function submiteditpassword1(req)
{
    switch (req.responseText)
{
case "0":  document.getElementById('editpassworddiv').innerHTML="<font color='red'>两次输入密码不一致!<font>";break;
case "1": document.getElementById('editpassworddiv').innerHTML="<font color='red'>旧密码和新密码不一致!<font>";break;
default : $('search1').style.display = '';document.getElementById('editpassworddiv').innerHTML="";document.getElementById('proLogin1').innerHTML="<font color='red'>修改成功!<font>";break;
}
}
function editPassword()
{
$('search1').style.display = 'none';
    var url = "ajaxUser.aspx?type=26&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('proLogin1').innerHTML= req.responseText;} , null, true, null); 
}
function SearchWorkState(id)
{
     var url = "ajaxUser.aspx?type=25&id="+id+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, SearchWorkState1 , null, true, null); 
}
function SearchWorkState1(req)
{
    switch (req.responseText)
{
case "0":  alert("此次作业你还未交!");break;
case "1": alert("此次作业附件你已上交,作业未交,待老师批改!");break;
case "3": alert("此次作业你已上交,作业附件未交,待老师批改!");break;
case "4": alert("此次作业及其附件你都已上交,待老师批改!");break;
case "2":alert("学生请先登录!");break;
default : alert(req.responseText);break;
}
}
 function  askOpenWin()   {    
  window.open   ("ask.aspx","","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }    
  function doworkopenwin(courseid,title,workNum,noworkid,year,month,day)
  {
    window.open   ("doWork.aspx?courseid="+courseid+"&title="+title+"&year="+year+"&month="+month+"&day="+day+"&workNum="+workNum+"&noworkid="+noworkid,"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
  function replyForum(questionid,title)
  {
     window.open   ("ReplyForum.aspx?questionid="+questionid+"&title="+title,"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
  function upFile()
  {
     window.open   ("upFile.aspx","","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
  function regist()
  {
     window.open   ("regist.aspx","","height=370,   width=600,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
function GetLogin()
{
       var url = "ajaxUser.aspx?type=21&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('search1').innerHTML= req.responseText;} , null, true, null); 
 }
//function expandImage(img)
//{
//    img.style.width = "160";
//   img.style.height = "130";
////   document.getElementById('im').style.height = '133px';
//}
function editPandImage(img)
{
     img.style.width = "151";
   img.style.height = "121";
}
function GetRollImage()
{
     var url = "ajaxUser.aspx?type=20&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('imageMove').innerHTML= req.responseText;} , null, true, null); 
}
function GetImage()
{
      var url = "ajaxUser.aspx?type=19&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('imageContent').innerHTML= req.responseText;} , null, true, null); 
}
function GetSet()
{
      var url = "ajaxUser.aspx?type=18&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('bottom').innerHTML= req.responseText;} , null, true, null); 
}
function GetLogin1()
{
       var url = "ajaxUser.aspx?type=28&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('login1').innerHTML= req.responseText;} , null, true, null); 
 }
function Login(req){
switch (req.responseText)
{
//case "0":  document.getElementById('proLogin').innerHTML= "<br/><br/><br/><br/><br/><br/><br/><br/><br/><font color='red'>登录成功!<font><input id='edit' type='button' value = '退出'onclick = 'javascript:express();' />"; $('proLogin').style.display = '';$('login1').style.display = 'none';break;
case "1": $('proLogin').style.display = '';document.getElementById('proLogin').innerHTML = "<font color='red'>用户名密码不正确！<font>";break;
case "2": $('proLogin').style.display = '';document.getElementById('proLogin').innerHTML = "<font color='red'>验证码不正确！<font>";break;
default : $('proLogin').innerHTML = "";$('login1').innerHTML = req.responseText;break;
}
}
function login1(name,pass,num)
{
	var d = new Date();
	var url = "ajaxUser.aspx?type=13&name1=" + name +"&pass1="+pass+ "&guid=" + d.getTime()+ "&num1=" + num;//发送请求的路径
    Request.sendGET(url, Login1 , null, true, null); 

}
function Login1(req){
switch (req.responseText)
{
//case "0":  document.getElementById('proLogin1').innerHTML= "<font color='red'>登录成功!<font><input id='edit1' type='button' value = '退出'onclick = 'javascript:express1();' />"; $('proLogin1').style.display = '';$('search1').style.display = 'none';break;
case "1":document.getElementById('proLogin1').innerHTML = "<font color='red'>密码不正确！<font>";break;
case "2":document.getElementById('proLogin1').innerHTML = "<font color='red'>验证码不正确！<font>";break;
case "3":document.getElementById('proLogin1').innerHTML = "<font color='red'>用户名不正确！<font>";break;
default :document.getElementById('search1').innerHTML = req.responseText;document.getElementById('proLogin1').innerHTML ="";
// var url = "ajaxUser.aspx?type=28&guid=" + new Date().getTime();
//    Request.sendGET(url, null , null, true, null); 
break;
}
}
//退出登录
function express()
{
//document.getElementById('UserName').value = "";
//document.getElementById('UserPass').value = "";
//document.getElementById('num').value = "";
//$('checkcode3').src='Admin/images3.aspx?'+new Date();
//    $('login1').style.display = '';
//    //$('proLogin').style.display = 'none';
//    $('proLogin').innerHTML = '';
GetLogin1();
    var url = "ajaxUser.aspx?type=1&guid=" + new Date().getTime();
    Request.sendGET(url, null , null, true, null); 
}
function express1()
{
//document.getElementById('UserName1').value = "";
//document.getElementById('UserPass1').value = "";
//document.getElementById('num1').value = "";
//$('checkcode1').src='Admin/images1.aspx?'+new Date();
//    $('search1').style.display = '';
//    //$('proLogin1').style.display = 'none';
//      $('proLogin1').innerHTML = '';
    var url = "ajaxUser.aspx?type=14&guid=" + new Date().getTime();
    Request.sendGET(url, null , null, true, null); 
GetLogin();
}
//公告栏
function CallNews()
{
    var url = "ajaxUser.aspx?type=2&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Callnews(req){document.getElementById('callnewsContent').innerHTML= req.responseText;} , null, true, null); 
}
function ShowDropdownList()
{
    var url = "ajaxUser.aspx?type=15&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('check2').innerHTML= req.responseText;} , null, true, null); 
}
//文章列表
function GetList1(park,div)
{
     var url = "ajaxUser.aspx?type=3&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById(div).innerHTML= req.responseText;} , null, true, null); 
}
function GetList(park,div)
{
     var url = "ajaxUser.aspx?type=4&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById(div).innerHTML= req.responseText;} , null, true, null); 
}
//GETTOP20
function GetTop20(park,div)
{
    var url = "ajaxUser.aspx?type=6&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById(div).innerHTML= req.responseText;} , null, true, null); 
}
function ParticularForum(id,title)
{
     Hidden();
//      GetTopForum();
 var url = "ajaxUser.aspx?type=12&page=1&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenLeft').innerHTML= req.responseText;} , null, true, null); 
      var url = "ajaxUser.aspx?type=11&id="+id+"&title="+title+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenRight').innerHTML= req.responseText;} , null, true, null); 
}
function ParticularForum1(id,title)
{
    
      var url = "ajaxUser.aspx?type=11&id="+id+"&title="+title+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenRight').innerHTML= req.responseText;} , null, true, null); 
}
//
function Particular(id,park)
{
Hidden();
if(park=="5"||park=="8")
MoreStuFile1(1,park);
else
List1(1,park);
      var url = "ajaxUser.aspx?type=5&id="+id+"&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenRight').innerHTML= req.responseText;} , null, true, null); 
}
function Particular1(id,park)
{
      var url = "ajaxUser.aspx?type=23&id="+id+"&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('contentList').innerHTML= req.responseText;} , null, true, null); 
}
//隐藏Middle
function Hidden()
{
  $('hiddenLeft').style.display = '';
 $('hiddenMiddle').style.display = '';
  $('hiddenRight').style.display = '';
  $('hiddenMiddle').className = 'middle';
   $('hiddenLeft').className = 'contentleft';
    $('hiddenRight').className = 'contentright';
    $('middle').style.display = 'none';
}
//function Hidden1()
//{
// $('hiddenMiddle').style.display = '';
//  $('hiddenMiddle').className = 'middle';
//   $('hiddenLeft').style.display = '';
//    $('hiddenRight').className = 'contentRight1';
//    $('middle').style.display = 'none';
//}
//显示Middle
function Viable()
{
    $('middle').style.display = '';
    $('hiddenMiddle').style.display = 'none';
}
//全部列表
function List(page,park)
{
Hidden();
GetTop20(park,'hiddenRight');
      var url = "ajaxUser.aspx?type=7&page="+page+"&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenLeft').innerHTML= req.responseText;} , null, true, null); 
}
function List1(page,park) //点分页是列表
{
      var url = "ajaxUser.aspx?type=7&page="+page+"&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenLeft').innerHTML= req.responseText;} , null, true, null); 
}

function List2(page,park,id)//各分类列表
{
      var url = "ajaxUser.aspx?type=8&id="+id+"&page="+page+"&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenLeft').innerHTML= req.responseText;} , null, true, null); 
     var url = "ajaxUser.aspx?type=24&id="+id+"&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('contentList').innerHTML= req.responseText;} , null, true, null); 
}
function MoreStuFile(page,park)
{
    Hidden();
GetTop20(park,'hiddenRight');
      var url = "ajaxUser.aspx?type=9&page="+page+"&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenLeft').innerHTML= req.responseText;} , null, true, null); 
}
function MoreStuFile1(page,park)
{
   
      var url = "ajaxUser.aspx?type=9&page="+page+"&park="+park+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenLeft').innerHTML= req.responseText;} , null, true, null); 
}
//论坛列表
function GetForumList()
{
      var url = "ajaxUser.aspx?type=10&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('13').innerHTML= req.responseText;} , null, true, null); 
}
function ForumList(page)
{
 Hidden();
 GetTopForum();
      var url = "ajaxUser.aspx?type=12&page="+page+"&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenLeft').innerHTML= req.responseText;} , null, true, null); 
}
function GetTopForum()
{
    var url = "ajaxUser.aspx?type=22&guid=" + new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetList1(req){document.getElementById('hiddenRight').innerHTML= req.responseText;} , null, true, null); 
}