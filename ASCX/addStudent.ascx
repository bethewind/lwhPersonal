<%@ Control Language="C#" ClassName="addStudent" %>
<table style="border-style: solid; border-width: 2px 2px 1px 2px; border-color: #99CCFF; width: 840px; font-size: 14px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);" >
    
    <tr>
        <td class="style1">
            帐号：</td>
        <td>
            <input id="name"  style="width: 137px; margin-left: 0px" type="text" /></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            姓名：</td>
        <td>
            <input id="nickname" type="text" style="width: 137px" /></td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style1">
            密码：</td>
        <td>
            <input id="password" type="text" style="width: 137px" /></td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style1">
            班级：</td>
        <td>
             <div id = 'divClass'>
           <input 
                    id="Button1" type="button" value="获取班级下拉框" onclick = 'javascript:GetClass();' /></div></td>
        <td>
            &nbsp;</td>
    </tr>
     
    <tr>
        <td class="style1">
            学号：</td>
        <td>
            <input 
                id="studyNum" type="text" style="width: 137px"  /></td>
        <td>
            &nbsp;</td>
    </tr>
     <tr>
        <td class="style1">
            班级序号：</td>
        <td>
            <input 
                id="classNum" type="text" style="width: 137px"  /></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        
        <td>
            <img src = '../images/submit.gif'onclick = 'javascript:submitaddstudent()' /></td>
    </tr>
</table>