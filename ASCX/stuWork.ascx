<%@ Control Language="C#" ClassName="stuWork" %>

<div style='border-left: 2px solid #99CCFF; border-right: 2px solid #99CCFF; border-top: 0px solid #99CCFF; border-bottom: 1px solid #99CCFF; background-image: url(&#039;../Images/背景.jpg&#039;); margin-top: 0px; width: 836px'>
    <input id="btnTeachPark" 
        type="button" value="学生列表" onclick = 'javascript:GetList(55,56);' 
        style="width: 65px" /><input id="btnTeachType" 
      
        type="button" value="作业信息" 
        onclick = "javascript:GetList(61,62);" style="width: 72px" /><input id="Button1" 
        type="button" value="作业信息类型" onclick = 'javascript:GetTypeList(3);' 
        style="width: 72px" /><input id="Button2" 
   
        type="button" value="学生上传资料" 
        onclick = "javascript:GetList(63,64);" style="width: 78px" /> 
    <input id="Button3" 
        type="button" value="学生上传作业" onclick = 'javascript:GetList2(66,67);' 
        style="width: 72px" />
        <input id="Button5" 
        type="button" value="布置作业" onclick = 'javascript:GetNewWorkList(90,91);' 
        style="width: 72px" /><input id="Button6" 
        type="button" value="班级交作业次数汇总" onclick = 'javascript:GetStuUpWorkNum();' 
        style="width: 80px" />
        </div>
        <%--<div id = 'divCourseList'>
            </div>--%>