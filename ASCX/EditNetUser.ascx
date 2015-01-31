<%@ Control Language="C#" ClassName="EditNetUser" %>

<%--<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 770px'>
    
        
    
    <tr>
        <td class="style1">
            会员权限：</td>
        <td class="style2">
            <input id="txtstept" value ='<%=Server.UrlDecode(Request["stept"])%>'readonly = 'true' type="text" /><input 
                id="Button1" type="button" onclick = 'javascript:GetNetUserStept()' value="选择权限" /><div id = 'stept'>
            </div>
             </td>
        <td class="style2">
            </td>
    </tr>
    <tr>
        
        <td>
             <img src = '../images/submit.gif'onclick = 'javascript:submitNetUser("<%=Request["id"]%>")' />
            &nbsp;</td>
    </tr>
</table>
--%>
<div style="border-style: solid; border-width: 2px 2px 1px 2px; border-color: #99CCFF; width: 836px; font-size: 14px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);" >
 <div style="width: 236px; float:left" >会员权限： 
     <input id="txtstept" 
         value ='<%=Server.UrlDecode(Request["stept"])%>'readonly = 'true' type="text" 
         style="height: 21px" /></div>
        <div id = 'stept' style="width: 216px; float:left; height: 28px;">
            <input 
                id="Button1" type="button" onclick = 'javascript:GetNetUserStept()' value="选择权限" /></div>
&nbsp;<img src = '../images/submit.gif' onclick = 'javascript:edituserstept("<%=Request["id"]%>")'; 
        style="height: 25px; width: 76px" /></div>
