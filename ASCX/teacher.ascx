<%@ Control Language="C#" ClassName="teacher" %>

<table style="border-style: solid; border-width: 2px 2px 1px 2px; border-color: #99CCFF; width: 836px; font-size: 14px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);" ><tr><td>
    <input id="btnTeachPark" 
        type="button" value="教师信息" onclick = 'javascript:GetList(23,24);' 
        style="width: 102px" /><input id="btnTeachType" 
       
        type="button" value="教师信息类型" onclick = "javascript:GetTypeList('1');" />
           </td></tr></table>
        <%--<div id = 'divCourseList'>
            </div>
--%>