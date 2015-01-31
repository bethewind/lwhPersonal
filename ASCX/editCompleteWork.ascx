<%@ Control Language="C#" ClassName="editCompleteWork" %>
<div style='border-left: 2px solid #99CCFF; border-right: 2px solid #99CCFF; border-top: 0px solid #99CCFF; border-bottom: 1px solid #99CCFF; background-image: url(&#039;../Images/背景.jpg&#039;); margin-top: 0px; width: 836px'>
<div style="height: 22px"><div style="width: 236px; float:left" >会员权限： 
     <input id="txtstept" 
         value ='<%=Server.UrlDecode(Request["stept"])%>'readonly = 'true' type="text" 
         style="height: 19px" /></div><div id = 'steptWork' style="width: 216px; float:left; height: 28px;">
            <input 
                id="Button1" type="button" onclick = 'javascript:GetWorkStept()' value="选择权限" /></div>
    评价&amp;分数:<input id="txtCord"  value ='<%=Server.UrlDecode(Request["cord"])%>' type="text" style="height: 21px; width: 87px" /></div>
<div style="height: 23px">
    作业:<a href='<%=Server.UrlDecode(Request["workContent"])%>' target ='_blank '><%=Server.UrlDecode(Request["workContent"])%></a>
    附件:<a href='<%=Server.UrlDecode(Request["workAdd"])%>'  target ='_blank '><%=Server.UrlDecode(Request["workAdd"])%></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<img src = '../images/submit.gif' onclick = 'javascript:editCorStept("<%=Request["id"]%>","<%=Server.UrlDecode(Request["remarkTime"])%>")'; 
        style="height: 25px; width: 76px" /></div>
</div>
