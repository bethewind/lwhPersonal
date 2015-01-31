<%@ Control Language="C#" ClassName="EditTeachType" %>

<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'>
    <tr>
       
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            编辑信息类型&nbsp;</td>
    </tr>
    <tr>
        
        <td>
            编号：<input id="id" type="text" readonly="readonly" value="<%=Request.QueryString["id"] %>" />内容：<input id="content"
                type="text" style="width: 177px" value="<%=Server.UrlDecode(Request.QueryString["content"])%>" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <img src = '../images/submit.gif'
                onclick = 'javascript:SubmitType("<%=Request.QueryString["park"] %>");'/>
            <div id = 'selectNewType'style="width: 379px">
            </div>
        </td>
    </tr>
    <tr>
       
        <td>
            &nbsp;</td>
    </tr>
</table>