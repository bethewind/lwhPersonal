//用户登录，检测用户名密码是否正确
function login(name,pass,num)
{
	var d = new Date();
	var url = "ajax.aspx?type=0&name=" + name +"&pass="+pass+ "&guid=" + d.getTime()+ "&num=" + num;//发送请求的路径
    Request.sendGET(url, getallok, null, true, callback2); 

}

function GetPageStuUpWorknum(page,type)
{
 $('List3').innerHTML = "";
 var classid = $('classSelect1').value;
  var courseid = $('courseSelect1').value;
 var url = "ajax.aspx?type="+type+"&page="+page+"&classid="+classid+"&courseid="+courseid+"&date="+new Date().getTime();//发送请求的路径
Request.sendGET(url, function NList2(req){document.getElementById('List1').innerHTML= req.responseText;} , null, true, null); 
}
function GetStuUpWorkNum()
{
$('List3').innerHTML = "";
$('List1').innerHTML = "";
     var url = "ajax.aspx?type=100&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
}
function editCorStept(id,remarkTime)
{var d = new Date();
    var stept = $('stept22').value;
    var cord = $('txtCord').value;
    var url = "ajax.aspx?type=96&id=" + id +"&stept="+stept+"&cord="+escape(cord)+"&remarkTime="+escape(remarkTime)+"&guid=" + d.getTime();//发送请求的路径
    Request.sendGET(url, function editCorStept1(req){document.getElementById('List3').innerHTML= req.responseText;}, null, true, callback2); 
 GetPageWork(1,67);
 }
function GetWorkStept()
{
     var url = "ajax.aspx?type=95&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('steptWork').innerHTML= req.responseText;} , null, true, null); 
}
function editCompleteStuWork(id,stept,cord,workContent,workAdd,remarkTime)
{
    var url = "ajax.aspx?type=94&id=" + id+"&stept="+escape(stept)+"&cord="+escape(cord)+"&remarkTime="+escape(remarkTime)+"&workContent="+escape(workContent)+"&workAdd="+escape(workAdd)+"&date="+new Date().getTime(); //发送请求的路径
    Request.sendGET(url, function editCompleteStuWork1(req){document.getElementById('List2').innerHTML= req.responseText;}, null, true, null); 
}
function DelNewWorkSelect (park,id1)
{   
$('List3').innerHTML = "";
var j = 0;
  for(var i=0; i<$('form1').elements.length; i++)
	        {
		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].checked== true )
		        {
			      j+=1;
		        }
	        }
	        if(j==0) {document.getElementById('List3').innerHTML ="<font color='red'> 没有选定！<font>";return;}
 if(confirm ("确认删除吗？")){
     for(var i=0; i<$('form1').elements.length; i++)
	        {
		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].id != CheckAll&& $('form1').elements[i].checked == true)
		        {
			        var url = "ajax.aspx?type=46&id="+$('form1').elements[i].value+"&park="+park+"&date="+new Date().getTime();//发送请求的路径
			        Request.sendGET(url, function DelNews1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
		        }
	        }
	      
     GetPageNewWork(1,id1);
	        }
	       
}
function DelNewWork(id,park,id1)
{    $('List3').innerHTML = "";
 var url = "ajax.aspx?type=46&id="+id+"&park="+park+"&date="+new Date().getTime();//发送请求的路径
    if(confirm ("确认删除吗？")){
     Request.sendGET(url, function DelNews1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
  GetPageNewWork(1,id1);
     }
     else return ;

 }
 
function GetCouClass()
{
     var url = "ajax.aspx?type=92&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetCouClass1(req){document.getElementById('couClass').innerHTML= req.responseText;} , null, true, null); 
}
function GetClass()
{
    var url = "ajax.aspx?type=99&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('divClass').innerHTML= req.responseText;} , null, true, null); 
}
function GetSteCourse()
{
     var url = "ajax.aspx?type=93&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('check2').innerHTML= req.responseText;} , null, true, null); 
     var url = "ajax.aspx?type=6&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('stept').innerHTML= req.responseText;} , null, true, null); 
}
function GetNewWorkList(type,id1)
{
    $('List3').innerHTML = "";
    var url = "ajax.aspx?type="+type+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function NList1(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
     GetPageNewWork(1,id1);
}
function  GetPageNewWork(page,type)
{
$('List3').innerHTML = "";
var  key = escape(document.getElementById('title').value);
if(document.getElementById('select3'))
{
var courseId = document.getElementById('select3').value;
   
  
    var url = "ajax.aspx?type="+type+"&page="+page+"&key="+escape(key)+"&courseId="+courseId+"&date="+new Date().getTime();//发送请求的路径
}
 
 else{
     var url = "ajax.aspx?type="+type+"&page="+page+"&key="+escape(key)+"&date="+new Date().getTime();//发送请求的路径
   
}
Request.sendGET(url, function NList2(req){document.getElementById('List1').innerHTML= req.responseText;} , null, true, null); 
}
function GetList2(type,id1)
{
$('List3').innerHTML = "";
    var url = "ajax.aspx?type="+type+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function NList1(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
     GetPageWork(1,id1);
}
function GetPageWork11(page,type)
{
$('List3').innerHTML = "";
var  key = escape(document.getElementById('title').value);
var  num = escape(document.getElementById('workNum').value);
if(document.getElementById('courseSelect'))
{
var courseId = document.getElementById('courseSelect').value;
   
    var classId = document.getElementById('classSelect').value;
    var url = "ajax.aspx?type="+type+"&page="+page+"&key="+escape(key)+"&num="+num+"&courseId="+courseId+"&classId="+classId+"&date="+new Date().getTime();//发送请求的路径
}
 
 else{
     var url = "ajax.aspx?type="+type+"&page="+page+"&key="+escape(key)+"&num="+num+"&date="+new Date().getTime();//发送请求的路径
   
}
Request.sendGET(url, function NList2(req){alert(req.responseText);} , null, true, null); 
}
function GetPageWork(page,type)
{
$('List3').innerHTML = "";
var  key = escape(document.getElementById('title').value);
var  num = escape(document.getElementById('workNum').value);
if(document.getElementById('courseSelect'))
{
var courseId = document.getElementById('courseSelect').value;
   
    var classId = document.getElementById('classSelect').value;
    var url = "ajax.aspx?type="+type+"&page="+page+"&key="+escape(key)+"&num="+num+"&courseId="+courseId+"&classId="+classId+"&date="+new Date().getTime();//发送请求的路径
}
 
 else{
     var url = "ajax.aspx?type="+type+"&page="+page+"&key="+escape(key)+"&num="+num+"&date="+new Date().getTime();//发送请求的路径
   
}
Request.sendGET(url, function NList2(req){document.getElementById('List1').innerHTML= req.responseText;} , null, true, null); 
}
function editNewWorkOpenWin(id,title,stept,course,year,month,day)
{
     window.open   ("EditNewWork.aspx?id="+id+"&title="+escape(title)+"&stept="+escape(stept)+"&year="+year+"&month="+month+"&day="+day+"&course="+escape(course),"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
}
function AddNewWorkOpenWin()
{
     window.open("AddNewWork.aspx","","height=600,   width=840,   left=200,   top=80,   toolbar=no,menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
}
function openWinAddStu()
{
     window.open("insertStudent.aspx","","height=180,   width=400,   left=350,   top=280,   toolbar=no,menubar=no,   scrollbars=no,   resizable=no,   location=no,   status=no") ;   
}
function  addOpenWin()   {    
  window.open("Add.aspx","","height=600,   width=840,   left=200,   top=80,   toolbar=no,menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }    
  function  edititOpenWin(id,type,title,stept,park)   {    
  window.open   ("EditIt.aspx?id="+id+"&title="+escape(title)+"&type="+escape(type)+"&stept="+escape(stept)+"&park="+park,"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }    
  function edititcourseOpenWin(id,type,title,stept,course,park)
  {
     window.open   ("EditIt.aspx?id="+id+"&title="+escape(title)+"&type="+escape(type)+"&stept="+escape(stept)+"&park="+park+"&course="+escape(course),"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
  function editForumOpenWin(id,title,author,stept,park)
  {
     window.open   ("EditForumQuestion.aspx?id="+id+"&title="+escape(title)+"&author="+escape(author)+"&stept="+escape(stept)+"&park="+park,"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
  function editForumOpen(id,title,author,park)
  {
     window.open   ("EditForumQuestion.aspx?id="+id+"&title="+escape(title)+"&author="+escape(author)+"&park="+park,"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
  function editStuOpenwin(id,title,stept,course,isPro,park)
  {
     window.open   ("EditStuWork.aspx?id="+id+"&title="+escape(title)+"&isPro="+escape(isPro)+"&stept="+escape(stept)+"&park="+park+"&course="+escape(course),"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
  function editStuWorkOpenwin(id,title,stept,course,isPro,studentId,remarkTime,park)
  {
     window.open   ("EditStuWork.aspx?id="+id+"&title="+escape(title)+"&isPro="+escape(isPro)+"&studentId="+escape(studentId)+"&remarkTime="+escape(remarkTime)+"&stept="+escape(stept)+"&park="+park+"&course="+escape(course),"","height=600,   width=840,   left=200,   top=80,   toolbar=no,   menubar=no,   scrollbars=yes,   resizable=no,   location=no,   status=no") ;   
  }
function editLogin()
{if(confirm("确认退出吗？")){
    var d = new Date();
	var url = "ajax.aspx?type=88&guid=" + d.getTime();//发送请求的路径
    Request.sendGET(url, ediLogin1, null, true, callback2); 
      dd1('2');
      $('List').innerHTML = "";
$('List1').innerHTML = "";
$('List3').innerHTML = "";
    }
}
function ex()
{
  if($('left').style.display == "none")
   $('left').style.display = "";
     else $('left').style.display = "none";

}
function GetCourse()
{
     var url = "ajax.aspx?type=84&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('divCourse').innerHTML= req.responseText;} , null, true, null); 
}

function submitSet()
{   var webSiteName = $('Text1').value;
 var email = $('Text2').value;
 var address = $('Text3').value;
 var phone = $('Text4').value;
 var sjphone = $('Text5').value;
 var youbian = $('Text6').value;
 var islockForum = $('Checkbox1').checked;
  var adr = $('Text7').value;
  var zhanzhang = $('Text8').value;
  var banquan = $('Text9').value;
  var qq = $('Text10').value;
   var webUrl = $('webUrl').value;
    var url = "ajax.aspx?type=79&webSiteName="+escape(webSiteName)+"&email="+escape(email)+"&address="+escape(address)+"&phone="+phone+"&webUrl="+webUrl+"&sjPhone="+sjphone+"&youbian="+youbian+"&islockForum="+islockForum+"&adr="+escape(adr)+"&zhanzhang="+escape(zhanzhang)+"&qq="+escape(qq)+"&banquan="+escape(banquan)+"&date="+new Date().getTime(); //发送请求的路径
    Request.sendGET(url, function getallo1(req){document.getElementById('setcall').innerHTML= req.responseText;}, null, true, null); 
//  dd('78');
}
function getallok(req)
{
switch (req.responseText)
{
case "0":  document.getElementById('left1').style.display= "";expand1();break;
case "1": document.getElementById('l1').innerHTML = "<font color='red'> 用户名密码不正确！<font>";break;
case "2": document.getElementById('l1').innerHTML = "<font color='red'> 验证码不正确！<font>";break;
}
}
function ediLogin1(req)
{
$('UserPass').value = "";
$('num').value = "";
$('checkcode').src='images.aspx?'+new Date();
 $('login').style.display ="";
     $('l1').style.display ="";
 document.getElementById('left1').style.display= "none";

}
function expandadmin(img1,img2)
{
    if($('left1').style.display == "none")
    $('left1').style.display == "";
    else $('left1').style.display == "none";
//    $(img1).style.display == "";
//    $(img2).style.display == "none";
}
//document.getElementById('left1').innerHTML= req.responseText;
//    if(req.responseText == "否") //服务器返回0，代表验证码验证失败
//	    {	
//    document.getElementById("num").value="";
//    alert("账号或者密码错误！");
//	    }
//	    else alert("df");
//    if(req.responseText=="1") //服务器返回1，代表账号密码验证失败
//    {	
//	    document.getElementById("UserName").value=document.getElementById("UserPass").value="";
//	    alert("账号或者密码错误！");
//	    }

function expand1()
{
    $('login').style.display ="none";
     $('l1').style.display ="none";
}
function expand(di)
{
//   if(document.getElementById('di').className == 'di1')
//   document.getElementById('di').className = 'di';
//   else document.getElementById('di').className = 'di1';
if(di.className == 'di1')
di.className = 'di';
else di.className = 'di1';
}
function dd(name,id,id1)
{	
	var url = "ajax.aspx?type=" + name+"&date="+new Date().getTime(); //发送请求的路径
    Request.sendGET(url, function getallo1(req){document.getElementById('List0').innerHTML= req.responseText;}, null, true, null); 
 GetList(id);
  GetPage(1,id1);
}
function dd1(name)
{	
	var url = "ajax.aspx?type=" + name+"&date="+new Date().getTime(); //发送请求的路径
    Request.sendGET(url, function getallo1(req){document.getElementById('List0').innerHTML= req.responseText;}, null, true, null); 
   switch (name)
   {
  case"8": mList();break;
  case "31": CourseList();break;
  case"1": ClassList();break;
  }
}
 function GetCourse1()
    {
         $('course').value = $('select3').value;
    }
function select(val)
{ 
  var url = "ajax.aspx?type=4&value="+val+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, getallo , null, true, null); 
//   var n = parseInt(document.getElementById('p').innerHTML);
//  document.getElementById('middle').innerHTML= document.getElementById('Select2').options.length;
   
 var url = "ajax.aspx?type=6&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetStept(req){document.getElementById('stept').innerHTML= req.responseText;} , null, true, null); 
}
//填充教师信息下拉框
//function ShowTeachList()
//{
//     var url = "ajax.aspx?type=26&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, getallo , null, true, null); 
//     var url = "ajax.aspx?type=6&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function GetStept(req){document.getElementById('stept').innerHTML= req.responseText}, null, true, null); 
//}
function ShowDropdownList(park)
{
    var url = "ajax.aspx?type=45&park="+park+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, getallo , null, true, null); 
     var url = "ajax.aspx?type=6&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetStept(req){document.getElementById('stept').innerHTML= req.responseText}, null, true, null); 
}
function ShowDropdownList67()
{
    var url = "ajax.aspx?type=65&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, getallo , null, true, null); 
     var url = "ajax.aspx?type=6&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetStept(req){document.getElementById('stept').innerHTML= req.responseText}, null, true, null); 
}
function GetNetUserStept()
{
     var url = "ajax.aspx?type=6&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function GetStept(req){document.getElementById('stept').innerHTML= req.responseText}, null, true, null); 
}
//function sel9(i)
//{ 
////for(var i = 0;i < 3; i++)
////  {
//     var d = new Date();
//	var url = "ajax.aspx?type=4&row="+i;//发送请求的路径
//    Request.sendGET(url, getallo, null, true, null); 
////    }
//}
function getallo(req){
//var a = [];a =req.responseText;
//document.getElementById('middle').innerHTML= a[1];
//for( var i = 0;i < a.length; i++)
//{
//   var item = new Option();
//  item.value = i;
//   item.text = req.responseText;
//   document.getElementById('Select2').options.add(item);
//}
document.getElementById('check2').innerHTML= req.responseText;
}
//function Add()
//{
////alert(document.getElementById('stept22').value);
//   if($('title').value == ""|| window.frames["if"].document.getElementById('content').value == "")
//   {
//       alert("标题和内容不能为空。");
//       return;
//   }
//    if(document.getElementById('select3'))
//  var whydata  = 'type=5&title='+escape(document.getElementById('title').value)+'&content='+escape(window.frames["if"].document.getElementById('content').value)+'&typeid='+escape(document.getElementById('select2').value)+'&park='+escape(document.getElementById('Select1').value)+'&course='+escape(document.getElementById('select3').value)+'&stept='+escape(document.getElementById('stept22').value)+"&date="+new Date().getTime();	
// else  var whydata  = 'type=5&title='+escape(document.getElementById('title').value)+'&content='+escape(window.frames["if"].document.getElementById('content').value)+'&typeid='+escape(document.getElementById('select2').value)+'&park='+escape(document.getElementById('Select1').value)+'&stept='+escape(document.getElementById('stept22').value)+"&date="+new Date().getTime();	
// Request.sendPOST("ajax.aspx", whydata, callback3, true, callback2) ;
////alert(window.frames["if"].document.getElementById('Text1').value);
//}
function AddCourse()
{
$('List3').innerHTML = "";
     var url = "ajax.aspx?type=36&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('divDoCourse').innerHTML= req.responseText;} , null, true, null); 
}
function AddClass()
{
$('List3').innerHTML = "";
     var url = "ajax.aspx?type=18&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('divDoClass').innerHTML= req.responseText;} , null, true, null); 
}
function AddType(park)
{
$('List3').innerHTML = "";
     var url = "ajax.aspx?type=38&park="+park+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AAddTeachType1(req){document.getElementById('editType').innerHTML= req.responseText;} , null, true, null); 
}
function AddStudent()
{
$('List3').innerHTML = "";
     var url = "ajax.aspx?type=59&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AAddTeachType1(req){document.getElementById('List2').innerHTML= req.responseText;} , null, true, null); 
}
//function AddNewsType()
//{
//     var url = "ajax.aspx?type=40&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function AAddTeachType1(req){document.getElementById('editNewsType').innerHTML= req.responseText;} , null, true, null); 
//}
//提交编辑的新闻
//function AddNews()
//{
//    if($('title').value == ""|| window.frames["if"].document.getElementById('content').value == "")
//    {
//        alert("标题和内容不能为空。");
//        return;
//    }
//    var whydata  = 'type=15&title='+escape(document.getElementById('title').value)+'&content='+window.frames["if"].document.getElementById('content').value+'&typeid='+escape(document.getElementById('select2').value)+'&id='+escape(document.getElementById('Hidden1').value)+'&stept='+escape(document.getElementById('stept').value)+"&date="+new Date().getTime();	
// Request.sendPOST("ajax.aspx", whydata, function NList(req){document.getElementById('newsList1').innerHTML= "提交成功！";}, true, callback2) ;
//}
//服务器端操作后的回调函数
//服务器端返回界面代码时，负责显示这些代码
function callback(req,data)
{
$("middle").innerHTML = req.responseText;
}
//成功执行回复或添加留言后，显示提示，重新加载留言列表
function callback3(req,data)
{
$("loadingflag").innerHTML="<font color='red'> 操作成功！<font>"; dd('2');
}
//服务器端返回错误时，显示提示
function callback2(req,data)
{
$("loading").innerHTML="<font color='red'> 出现错误，请重试！<font>";
}
//管理员列表函数
function mList()
{
$('List1').innerHTML = "";
$('List3').innerHTML = "";

     var url = "ajax.aspx?type=7&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function MList(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
}
//课程列表函数
function CourseList()
{$('List1').innerHTML = "";

$('List3').innerHTML = "";
     var url = "ajax.aspx?type=32&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function MList(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
}
function ClassList()
{$('List1').innerHTML = "";

$('List3').innerHTML = "";
     var url = "ajax.aspx?type=14&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function MList(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
}
//编辑管理员请求
function edit(id,name,nickname)
{
$('List3').innerHTML = "";
      var url = "ajax.aspx?type=9&id="+id+"&name="+escape(name)+"&nickname="+escape(nickname)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 


}
function edituserstept(id)
{
    var steptid = $('stept22').value;
    var id = id;
    $('List3').innerHTML = "";
      var url = "ajax.aspx?type=89&id="+id+"&steptid="+steptid+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
     GetPage(1,71);
}
//编辑学生列表
function EditStudent(id,name,nickname,password,sclass,studyNum,classNum)
{
$('List3').innerHTML = "";
     var url = "ajax.aspx?type=57&id="+id+"&name="+escape(name)+"&nickname="+escape(nickname)+"&password="+escape(password)+"&sclass="+escape(sclass)+"&classNum="+escape(classNum)+"&studyNum="+escape(studyNum)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function edit1(req){document.getElementById('List2').innerHTML= req.responseText;} , null, true, null); 
}
function EditNetUser(id,stept)
{
$('List3').innerHTML = "";
     var url = "ajax.aspx?type=72&id="+id+"&stept="+escape(stept)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function edit1(req){document.getElementById('List2').innerHTML= req.responseText;} , null, true, null); 

}
//编辑课程
function EditCourseList(id,name)
{
$('List3').innerHTML = "";
      var url = "ajax.aspx?type=33&id="+id+"&name="+escape(name)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function edit1(req){document.getElementById('divDoCourse').innerHTML= req.responseText;} , null, true, null); 


}
function EditClassList(id,name)
{
$('List3').innerHTML = "";
      var url = "ajax.aspx?type=15&id="+id+"&name="+escape(name)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function edit1(req){document.getElementById('divDoClass').innerHTML= req.responseText;} , null, true, null); 


}
//编辑管理员
function submitadmin()
{
    var id = $('ID').value;
    var name = $('name').value;
    var nickname = $('nickname').value;
    var oldpassword = $('oldpassword').value;
    var password = $('password').value;
     var repassword = $('repassword').value;
var url = "ajax.aspx?type=10&id="+id+"&name="+escape(name)+"&nickname="+escape(nickname)+"&oldpassword="+oldpassword+"&password="+password+"&repassword="+repassword+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
    mList();
}
//编辑学生列表
function submitstudent(id)
{var sclass;
    var studyNum = $('studyNum').value;
     var classNum = $('classNum').value;
    var name = $('name').value;
    var nickname = $('nickname').value;
    var password = $('password').value;
    if($('classSelect'))
        sclass = $('classSelect').value;
       else    sclass = "";
         
var url = "ajax.aspx?type=58&id="+id+"&name="+escape(name)+"&sclass="+escape(sclass)+"&nickname="+escape(nickname)+"&password="+password+"&studyNum="+studyNum+"&classNum="+classNum+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
     GetPage(1,56);
}
function submitNetUser(id)
{
       var stept = $('stept22').value;
//          var islock = $('islock').checked;
var url = "ajax.aspx?type=73&id="+id+"&stept="+stept+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List2').innerHTML= req.responseText;} , null, true, null); 
        GetPage(1,71);
    
}
function submitaddstudent()
{
if($('studyNum').value==""||$('classNum').value==""||$('name').value==""||$('nickname').value==""||$('password').value=="")
{
document.getElementById('List3').innerHTML= "<font color='red'> 不能有空值！<font>";
return;
}
     var studyNum = $('studyNum').value;
     var classNum = $('classNum').value;
    var name = $('name').value;
    var nickname = $('nickname').value;
    var password = $('password').value;
     var sclass = $('classSelect').value;
        
var url = "ajax.aspx?type=60&name="+escape(name)+"&sclass="+escape(sclass)+"&nickname="+escape(nickname)+"&password="+password+"&studyNum="+studyNum+"&classNum="+classNum+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
GetPage(1,56);
}
//提交编辑的课程类别
function SubmitCourse()
{
    var id = $('ID').value;
    var name = $('name').value;
var url = "ajax.aspx?type=34&id="+id+"&name="+escape(name)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
    CourseList();
}
function SubmitClass()
{
    var id = $('ID').value;
    var name = $('name').value;
var url = "ajax.aspx?type=16&id="+id+"&name="+escape(name)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
    ClassList();
}
function SubmitAddCourse()
{
   
    var name = $('name').value;
var url = "ajax.aspx?type=37&name="+escape(name)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
    CourseList();
}
function SubmitAddClass()
{
   
    var name = $('name').value;
var url = "ajax.aspx?type=19&name="+escape(name)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
    ClassList();
}
function SubmitAddType(park)
{
   
    var name = $('name').value;
var url = "ajax.aspx?type=39&park="+park+"&name="+escape(name)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function Edit1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
     GetTypeList(park);
}
//function SubmitAddNewsType()
//{
//   
//    var name = $('name').value;
//var url = "ajax.aspx?type=41&name="+escape(name)+"&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function Edit1(req){document.getElementById('editNewsType').innerHTML= req.responseText;} , null, true, null); 
//}
//获取新闻列表
//function getNewsList()
//{
//    var url = "ajax.aspx?type=12&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function NList1(req){document.getElementById('newsList').innerHTML= req.responseText;} , null, true, null); 
////    getPage1(1);
//}
//获取列表

function GetList(type,id1)
{
$('List3').innerHTML = "";
    var url = "ajax.aspx?type="+type+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function NList1(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
     GetPage(1,id1);
}
function GetList11(type)
{
$('List3').innerHTML = "";
 document.getElementById('List1').innerHTML = "";
    var url = "ajax.aspx?type="+type+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function NList1(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
    
}
//获取留言回复列表
function ShowAnswer(id,page)
{ $('List').innerHTML = "";
$('List3').innerHTML = "";
    var url = "ajax.aspx?type=77&id="+id+"&page="+page+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function NList1(req){document.getElementById('List1').innerHTML= req.responseText;} , null, true, null); 
}
function SearchStudent(studentId)
{
$('List3').innerHTML = "";
    var url = "ajax.aspx?type=68&studentId="+studentId+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function NList1(req){document.getElementById('List2').innerHTML= req.responseText;} , null, true, null); 
}
function SearchStudent1(studentId)
{
$('List3').innerHTML = "";
    var url = "ajax.aspx?type=80&studentId="+studentId+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function NList1(req){document.getElementById('List2').innerHTML= req.responseText;} , null, true, null); 
}
//获取教师信息列表
//function GetTeachList()
//{
//     var url = "ajax.aspx?type=23&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function GetTeachList1(req){document.getElementById('divTeachList').innerHTML= req.responseText;} , null, true, null); 
//}
//function getPage1(page)
//{
// 
//   var  key = null;
//  
//    var url = "ajax.aspx?type=13&page="+page+"&key="+key;//发送请求的路径
//    Request.sendGET(url, function NList2(req){document.getElementById('newsList2').innerHTML= req.responseText;} , null, true, null); 
//}
//function getPage(page)
//{
// 
//   var  key = document.getElementById('title').value;
//  
//    var url = "ajax.aspx?type=13&page="+page+"&key="+key+"&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function NList2(req){document.getElementById('newsList1').innerHTML= req.responseText;} , null, true, null); 
//}
//获取教师信息分页
// function GetTeachPage(page)
//{
// 
//   var  key = document.getElementById('title').value;
//  
//    var url = "ajax.aspx?type=24&page="+page+"&key="+key+"&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function NList2(req){document.getElementById('List1').innerHTML= req.responseText;} , null, true, null); 
//}
function GetPage(page,type)
{
$('List3').innerHTML = "";
var  key = escape(document.getElementById('title').value);

if(document.getElementById('select3'))
{
    var  key1 = document.getElementById('select3').value;
    if(document.getElementById('select4'))
    {
         var  key2 = document.getElementById('select4').value;
           var url = "ajax.aspx?type="+type+"&page="+page+"&key="+key+"&key1="+key1+"&key2="+key2+"&date="+new Date().getTime();//发送请求的路径
    }
    else var url = "ajax.aspx?type="+type+"&page="+page+"&key="+key+"&key1="+key1+"&date="+new Date().getTime();//发送请求的路径
}
 
 else{
  if(document.getElementById('select4'))
    {
         var  key2 = document.getElementById('select4').value;
           var url = "ajax.aspx?type="+type+"&page="+page+"&key="+key+"&key2="+key2+"&date="+new Date().getTime();//发送请求的路径
    }
    else var url = "ajax.aspx?type="+type+"&page="+page+"&key="+key+"&date="+new Date().getTime();//发送请求的路径
   
}
Request.sendGET(url, function NList2(req){document.getElementById('List1').innerHTML= req.responseText;} , null, true, null); 
}
function GetPage1(id,page,type)
{
 $('List3').innerHTML = "";
 var url = "ajax.aspx?type="+type+"&id="+id+"&page="+page+"&date="+new Date().getTime();//发送请求的路径
   Request.sendGET(url, function NList2(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
}
//编辑新闻
function EditNews(id,type1,title,stept)
{
    var url = "ajax.aspx?type=14&id="+id+"&type1="+escape(type1)+"&title="+escape(title)+"&stept="+escape(stept)+"&date="+new Date().getTime();//发送请求的路径
    
    Request.sendGET(url, function EditNews1(req){document.getElementById('newsList1').innerHTML= req.responseText;} , null, true, null); 
}

//重置添加的信息
function resetAdd()
{
    $('title').value = "";
    window.frames["if"].document.getElementById('content').value = "";
}
//function showList()
//{
////    window.frames["if"].document.getElementById('content').value = $('Hidden2').value;
//  var url = "ajax.aspx?type=16";//发送请求的路径
//    Request.sendGET(url, getallo , null, true, null); 
////   var n = parseInt(document.getElementById('p').innerHTML);
////  document.getElementById('middle').innerHTML= document.getElementById('Select2').options.length;
//   
//var url = "ajax.aspx?type=6&date="+new Date().getTime();//发送请求的路径
//   Request.sendGET(url, function GetStept1(req){document.getElementById('stept').innerHTML= req.responseText;} , null, true, null); 

//}
//删除新闻
//function DelNews(id)
//{     var url = "ajax.aspx?type=17&id="+id+"&date="+new Date().getTime();//发送请求的路径
//    if(confirm ("确认删除吗？"))
//     Request.sendGET(url, function DelNews1(req){document.getElementById('newsList').innerHTML= req.responseText;} , null, true, null); 
//     else return ;
//}
//删除教师信息
//function DelTeachPark(id)
//{     var url = "ajax.aspx?type=25&id="+id+"&date="+new Date().getTime();//发送请求的路径
//    if(confirm ("确认删除吗？"))
//     Request.sendGET(url, function DelNews1(req){document.getElementById('divTeachList').innerHTML= req.responseText;} , null, true, null); 
//     else return ;
//}
//删除
function submitNum(id)
{
    var num = $('num1').value;
     var url = "ajax.aspx?type=87&id="+id+"&num="+num+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
      GetPage(1,83);
}
function EditNum(id,num)
{
 $('List3').innerHTML = "";
     var url = "ajax.aspx?type=86&id="+id+"&num="+num+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function AddCourse1(req){document.getElementById('List2').innerHTML= req.responseText;} , null, true, null); 
}
function Del1(id,park,id1,id2)
{    $('List3').innerHTML = "";
 var url = "ajax.aspx?type=46&id="+id+"&park="+park+"&date="+new Date().getTime();//发送请求的路径
    if(confirm ("确认删除吗？")){
     Request.sendGET(url, function DelNews1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
    ShowAnswer(id2,1);
     }
     else return ;
      
}
function Del(id,park,id1)
{    $('List3').innerHTML = "";
 var url = "ajax.aspx?type=46&id="+id+"&park="+park+"&date="+new Date().getTime();//发送请求的路径
    if(confirm ("确认删除吗？")){
     Request.sendGET(url, function DelNews1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
  if(id1 == "67")
	      GetPageWork(1,id1);
	      else 
       GetPage(1,id1);
     }
     else return ;
      
}
//function del111(req,id1)
//{
//    switch (req.responseText){
//    case "0":document.getElementById('List3').innerHTML= "<font color='red'> 删除成功！<font>";GetPage(1,id1);break;
//     case "1":document.getElementById('List3').innerHTML= "<font color='red'> 请先删除与此项关联的信息！(学生上传资料，作业，作业次数或论坛回复)<font>";break;
//    }
//    
//    }
function over()
{     
$('List3').innerHTML = "";
var url = "ajax.aspx?type=85&date="+new Date().getTime();//发送请求的路径
    if(confirm ("确认删除吗？")){
     Request.sendGET(url, function DelNews1(req){document.getElementById('List2').innerHTML= req.responseText;} , null, true, null); 
      GetPage(1,83);
      }
     else return ;
}
//全选新闻
function CheckAll()
{
//   for (var i = 1; i <= count;i++)
//   $("Checkbox"+i).checked = $('checkAll').checked;
  for(var i=0; i<$('form1').elements.length; i++)
	        {
		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].id != CheckAll)
		        {
			       $('form1').elements[i].checked = $('checkAll').checked;
		        }
	        }
}
//删除新闻列表所选项
//function DelSelect ()
//{   
// if(confirm ("确认删除吗？")){
//     for(var i=0; i<$('form1').elements.length; i++)
//	        {
//		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].id != CheckAll&& $('form1').elements[i].checked == true)
//		        {
//			       var url = "ajax.aspx?type=17&id="+$('form1').elements[i].value+"&date="+new Date().getTime();//发送请求的路径
//			        Request.sendGET(url, function DelNews1(req){document.getElementById('newsList').innerHTML= req.responseText;} , null, true, null); 
//		        }
//	        }
//	        }
//	        else return ;
//}
//删除教师信息所选项
//function DelTeachSelect ()
//{   
// if(confirm ("确认删除吗？")){
//     for(var i=0; i<$('form1').elements.length; i++)
//	        {
//		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].id != CheckAll&& $('form1').elements[i].checked == true)
//		        {
//			       var url = "ajax.aspx?type=25&id="+$('form1').elements[i].value+"&date="+new Date().getTime();//发送请求的路径
//			        Request.sendGET(url, function DelNews1(req){document.getElementById('divTeachList').innerHTML= req.responseText;} , null, true, null); 
//		        }
//	        }
//	        }
//	        else return ;
//}
function DelItSelect1 (park,id1,id)
{   
$('List3').innerHTML = "";
var j = 0;
  for(var i=0; i<$('form1').elements.length; i++)
	        {
		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].checked== true )
		        {
			      j+=1;
		        }
	        }
	        if(j==0) {document.getElementById('List3').innerHTML ="<font color='red'> 没有选定！<font>";return;}
 if(confirm ("确认删除吗？")){
     for(var i=0; i<$('form1').elements.length; i++)
	        {
		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].id != CheckAll&& $('form1').elements[i].checked == true)
		        {
			        var url = "ajax.aspx?type=46&id="+$('form1').elements[i].value+"&park="+park+"&date="+new Date().getTime();//发送请求的路径
			        Request.sendGET(url, function DelNews1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
		        }
	        }
	      
	       ShowAnswer(id,1);
	        }
	       
}
function DelItSelect (park,id1)
{   
$('List3').innerHTML = "";
var j = 0;
  for(var i=0; i<$('form1').elements.length; i++)
	        {
		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].checked== true )
		        {
			      j+=1;
		        }
	        }
	        if(j==0) {document.getElementById('List3').innerHTML ="<font color='red'> 没有选定！<font>";return;}
 if(confirm ("确认删除吗？")){
     for(var i=0; i<$('form1').elements.length; i++)
	        {
		        if ($('form1').elements[i].type=="checkbox" && $('form1').elements[i].id != CheckAll&& $('form1').elements[i].checked == true)
		        {
			        var url = "ajax.aspx?type=46&id="+$('form1').elements[i].value+"&park="+park+"&date="+new Date().getTime();//发送请求的路径
			        Request.sendGET(url, function DelNews1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
		        }
	        }
	      if(id1 == "67")
	      GetPageWork(1,id1);
	      else 
       GetPage(1,id1);
	        }
	       
}
//获取新闻类型列表
//function getNewsType()
//{
//    var url = "ajax.aspx?type=18&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function getNewsType1(req){document.getElementById('newsList').innerHTML= req.responseText;} , null, true, null); 
//}
//获取信息类型列表
function GetTypeList(park)
{
 $('List3').innerHTML = "";
$('List1').innerHTML = "";

     var url = "ajax.aspx?type=27&park="+park+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function getNewsType1(req){document.getElementById('List').innerHTML= req.responseText;} , null, true, null); 
}
//function GetTypeList(park)
//{
//     var url = "ajax.aspx?type=47&park="+park+"&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function getNewsType1(req){document.getElementById('divTeachList').innerHTML= req.responseText;} , null, true, null); 
//}
//编辑新闻类型
//function EditNewsType(id,content)
//{
//    var url = "ajax.aspx?type=19&id="+id+"&content="+escape(content)+"&date="+new Date().getTime();//发送请求的路径
//    Request.sendGET(url, function EditNewsType1(req){document.getElementById('editNewsType').innerHTML= req.responseText;}, null, true, null); 
//}
//编辑教师信息类型
function EditType(id,content,park)
{
 $('List3').innerHTML = "";
    var url = "ajax.aspx?type=28&id="+id+"&park="+park+"&content="+escape(content)+"&date="+new Date().getTime();//发送请求的路径
    Request.sendGET(url, function EditNewsType1(req){document.getElementById('editType').innerHTML= req.responseText;}, null, true, null); 
      
}
//获取类型下拉框
//function GetNewsTypeSelect()
//{
//    var url = "ajax.aspx?type=20";//发送请求的路径
//    Request.sendGET(url, function GetNewsTypeSelect1(req){document.getElementById('selectNewType').innerHTML= req.responseText;} , null, true, null); 
//}
//提交编辑的新闻类型
//function SubmitNewsType()
//{
//    
// if($('content').value == "")
//    {
//        alert("标题和内容不能为空。");
//        return;
//    }
//    var whydata  = 'type=20&content='+escape(document.getElementById('content').value)+'&id='+escape(document.getElementById('id').value)+"&date="+new Date().getTime();
// Request.sendPOST("ajax.aspx", whydata, function SubmitNewsType1(req){document.getElementById('editNewsType').innerHTML= "提交成功！";}, true, callback2) ;
//}
//提交编辑的教师信息类型
function SubmitType(park)
{
    
 if($('content').value == "")
    {
       
        document.getElementById('List3').innerHTML= "<font color='red'> 内容不能为空!<font>";
        return;
    }
    var whydata  = 'type=29&park='+park+'&content='+escape(document.getElementById('content').value)+'&id='+escape(document.getElementById('id').value)+"&date="+new Date().getTime();
 Request.sendPOST("ajax.aspx", whydata, function SubmitNewsType1(req){document.getElementById('List3').innerHTML= "提交成功！";}, true, callback2) ;
   GetTypeList(park);
}
//function DelNewsType(id)
//{
//   
//var url = "ajax.aspx?type=21&id="+id+"&date="+new Date().getTime();//发送请求的路径
//    if(confirm ("确认删除吗？"))
//     Request.sendGET(url, function DelNews1(req){document.getElementById('newsList').innerHTML= req.responseText;} , null, true, null); 
//     else return ;

//}
function DelCourseList(id)
{
   $('List3').innerHTML = "";
var url = "ajax.aspx?type=35&id="+id+"&date="+new Date().getTime();//发送请求的路径
    if(confirm ("确认删除吗？")){
     Request.sendGET(url, function DelCourseList1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
       CourseList();
       }
     else return ;

}
function DelClassList(id)
{
   $('List3').innerHTML = "";
var url = "ajax.aspx?type=17&id="+id+"&date="+new Date().getTime();//发送请求的路径
    if(confirm ("确认删除吗？")){
     Request.sendGET(url, function DelCourseList1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
       ClassList();
       }
     else return ;

}
function DelType(id,park)
{
    $('List3').innerHTML = "";
var url = "ajax.aspx?type=30&id="+id+"&park="+park+"&date="+new Date().getTime();//发送请求的路径
    if(confirm ("确认删除吗？")){
     Request.sendGET(url, function DelTeachType1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
      GetTypeList(park);
      }
     else return ;
    
}
function DelNum(id,studentId)
{
  $('List3').innerHTML = "";
    var url = "ajax.aspx?type=81&id="+id+"&date="+new Date().getTime();//发送请求的路径
    if(confirm ("确认删除吗？")){
     Request.sendGET(url, function DelTeachType1(req){document.getElementById('List3').innerHTML= req.responseText;} , null, true, null); 
     SearchStudent1(studentId)
     }
     else return ;
       
}









