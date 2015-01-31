<%@ Control Language="C#" ClassName="research" %>

<div style='border-left: 2px solid #99CCFF; border-right: 2px solid #99CCFF; border-top: 0px solid #99CCFF; border-bottom: 1px solid #99CCFF; background-image: url(&#039;../Images/背景.jpg&#039;); margin-top: 0px; width: 836px'>
    <input id="Button1" 
        type="button" value="科研列表" onclick = 'javascript:GetList(43,44);' 
        style="width: 123px" /><input id="Button2" 
      
        type="button" value="科研类型" onclick = "javascript:GetTypeList('2');" 
        style="width: 115px" /><input id="Button3" 

        type="button" value="科研方向" onclick = "javascript:GetTypeList('8');" 
        style="width: 115px" />
        </div>
        <%--<div id = 'divCourseList'>
            </div>--%>