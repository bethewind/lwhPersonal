using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
public partial class ajaxUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request["type"])
        {
            case "0": Login(); break;
            case "1": Session.Remove("name"); Session.Remove("stept"); break;//清除Session
            case "2": CallNews(); break;//公告栏
            case "3": GetList1(); break;
            case "4": GetList(); break;
            case "5": Particular(); break;
            case "6": GetTop20(); break;
            case "7": List(); break;//全部列表
            case "8": List2(); break;
            case "9": MoreStuWork(); break;
            case "10": GetForumList(); break;
            case "11": ParticularForum(); break;
            case "12": ForumList(); break;
            case "13": Login1(); break;
            case "14": Session.Remove("student"); Session.Remove("student1"); Session.Remove("student2"); break;//清除Session
            case "15": GetDropdownList(); break;
            case "16": CheckUserName(); break;
            case "17": SubmitRegist(); break;
            case "18": GetSet(); break;
            case "19": GetImage(); break;
            case "20": GetRollImage(); break;
            case "21": Response.Write("<table><tr><td> 帐号：<input id=\"UserName1\" type=\"text\" height=\"30\" /></td></tr><tr><td>密码：<input id=\"UserPass1\" type=\"password\" height=\"30\" /></td></tr><tr><td  >验证：<input id=\"num1\" type=\"text\" height=\"23\" /><img src=\"Admin/images1.aspx\" alt = '看不清，换一张'onclick=\"this.src='Admin/images1.aspx?'+new Date();\" id=\"checkcode1\" name=\"checkcode1\"  /></td></tr><tr><td><img src=\"Images/gif-0554.gif\" onclick = \"javascript:login1(document.getElementById('UserName1').value,document.getElementById('UserPass1').value,document.getElementById('num1').value);\"/></td></tr></table>"); break;
            case "22": GetTopForum(); break;
            case "23": Particular1(); break;
            case "24": typeTop1(); break;
            case "25": SearchWorkState(); break;
            case "26": LoadAscx("ASCX/editpassword"); break;
            case "27": submiteditpassword(); break;
            case "28": Response.Write("<table style='border-top: 0px none #FFFFFF; width: 166px; height: 132px; border-left-color: #FFFFFF; border-left-width: 0px; border-right-color: #FFFFFF; border-right-width: 0px; border-bottom-color: #FFFFFF; border-bottom-width: 0px; margin-left: 3px;'><tr><td>帐号：<input id='UserName' type='text' height='20' /></td></tr><tr><td>密码：<input id='UserPass' type='password' height='20' /></td></tr><tr><td  >验证：<input id='num' type='text' height='20' /><img src='Admin/images3.aspx' alt = '看不清，换一张'onclick=\"this.src='Admin/images3.aspx?'+new Date();\" id='checkcode3'  /></td></tr><tr><td><img src='Images/gif-0554.gif' onclick = \"javascript:login(document.getElementById('UserName').value,document.getElementById('UserPass').value,document.getElementById('num').value);\"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href = 'javascript:regist()'><img src='Images/gif-0555.gif' style='border: 0px none #FFFFFF'/></a> </td></tr></table>"); break;
            case "29": GetTopRight(); break;
        }
    }
    protected void GetTopRight()
    {
        string sql = "SELECT * FROM WebSiteSet";
        DataTable dt = DB.OpenQuery(sql);
        string  tr= "<table border='0'style='border: 0px solid #99CCFF; float: left; width: 147px; height: 100px;'><tr style='border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #99CCFF'><td >&nbsp;<img src='Images/homepage.gif' style='width: 23px; height: 23px' /></td><td>&nbsp;<a href='#'   onClick=\"this.style.behavior='url(#default#homepage)';this.setHomePage('http://{0}')\"><img src='Images/dh1swsy.gif'style='border-style: none; border-width: 0px; width: 100px; height: 25px;' /></a></td></tr><tr style='border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #99CCFF'><td>&nbsp;<img src='Images/bookmark.gif' style='height: 23px; width: 23px' /></td><td>&nbsp;<a   href=\"javascript:window.external.addfavorite('http://{0}','{1}')\"><img src='Images/dh1jrsc.gif'style='border: 0px none #FFFFFF; width: 100px; height: 25px;' /></a></td></tr><tr><td>&nbsp;<img src='Images/Favorites.gif'style='border-style: none; border-width: 0px; height: 23px; width: 23px' /></td><td>&nbsp;<a href ='mailto:{2}'><img src='Images/dh1lxwm.gif' style='border: 0px none #FFFFFF; width: 100px; height: 25px;' /></a></td></tr></table>";
        string table = string.Format(tr, dt.Rows[0]["webUrl"], dt.Rows[0]["webSiteName"], dt.Rows[0]["email"]);
        Response.Write(table);
    }
    protected void submiteditpassword()
    {
        if (Request["password"].ToString().Trim() != Request["repassword"].ToString().Trim())
        {
            Response.Write("0"); return;
        }
        else 
        {
           
            string userPass = PageValidate.GetSafeStr(Request["oldpassword"]);
          
            string pass = MD5.Hash(userPass);
            //验证验证码用户名密码
            string sql = "SELECT password FROM studentlist WHERE studentID=" + Convert.ToInt32(Session["student2"]) + "";//构成sql语句
            if (DB.FindString(sql) == pass)
            {
                string sql1 = "UPDATE studentlist SET password =N'" + MD5.Hash(Request["password"]) + "' WHERE studentID=" + Convert.ToInt32(Session["student2"]) + "";
                DB.execnonsql(sql1);
            }
            else Response.Write("1");
        }
    }
    protected void LoadAscx(string name)
    {
        StringBuilder sb = new StringBuilder();
        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        HtmlTextWriter writer = new HtmlTextWriter(sw);
        Control d = LoadControl(name + ".ascx");
        d.RenderControl(writer);
        Response.Write(sb.ToString());

    }
    protected void SearchWorkState()
    {
        if (DB.hasSession ("student2"))
        {
            string sql = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(Session["student2"]) + " AND noworkID=" + Convert.ToInt32(Request["id"]) + "";
            System.Data.DataTable dt = DB.OpenQuery(sql);
            if (dt.Rows.Count == 0)
                Response.Write("0");
            else
            {
                if (Convert.ToInt32(dt.Rows[0]["isRemark"]) == 0)
                {
                    if (dt.Rows[0]["workContent"].ToString() == "")
                    {
                       
                         Response.Write("1"); 
                    }
                    else
                    {
                        if (dt.Rows[0]["workAdd"].ToString() == "")
                            Response.Write("3");
                        else Response.Write("4");
                    }
                }
                  
                else Response.Write("此次作业已批改,你的成绩:" + dt.Rows[0]["cord"]);
            }
        }
        else { Response.Write("2"); }
    }
    protected void GetRollImage()
    {
        string sql = "SELECT TOP 6 * FROM NewsList WHERE isProImg='" + true + "' AND newsid NOT IN (SELECT TOP 1 newsid FROM NewsList ORDER BY newsid DESC) ORDER BY newsid DESC";
        System.Data.DataTable dt = DB.OpenQuery(sql);

        string list = "<marquee direction='left' onmouseover='this.stop()' onmouseout='this.start()' behavior='alternate' scrollamount='2'><table ><tr>"; string str = "<td><a href = 'javascript:Particular({0},0)' title = '{1}'><img src='{2}' /></a></td>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i]["newsid"].ToString(), dt.Rows[i]["title"].ToString(), dt.Rows[i]["imgUrl"].ToString());
        }
        list += "</tr></table></marquee>";
        Response.Write(list);
    }
    protected void GetImage()
    {
        string sql = "SELECT top 1 * FROM NewsList WHERE isProImg='"+true+"' ORDER BY newsid DESC";
        System.Data.DataTable dt = DB.OpenQuery(sql);
        string list = ""; string str = "<a href = 'javascript:Particular({0},0)' title = '{1}'><img src='{2}' width='260' height='240' /></a>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i]["newsid"].ToString(), dt.Rows[i]["title"].ToString(), dt.Rows[i]["imgUrl"].ToString());
        }
       
        Response.Write(list);
    }
    protected void GetSet()
    {
        string sql = "SELECT * FROM WebSiteSet";
        System.Data.DataTable dt = DB.OpenQuery(sql);
        string list = ""; //string str = "<table width='800' border='0' style='height: 52px; background-color: #99CCFF; font-size: 14px;'><tr><td class='style2'>版权所有: {7}   </td><td class='style1'>{0}</td><td width='492'>站长:{6}<br /></td></tr><tr><td class='style2'>地址:{2} </td><td class='style1'>邮编:{5}    </td><td>信箱:{1}</td></tr><tr><td class='style2'>电话：{3}</td><td class='style1'>手机：{4}</td><td>QQ:{8}</td></tr></table>";
        string str = " <table border='0'style=' border-width: 0px 0px 0px 0px; margin: 3px auto 3px auto; height: 61px; background-color: #FFFFFF; font-size: 12px; width: 582px; color: #666666; '><tr><td class='style2'>版权所有 {7}  </td><td class='style1'>{0}</td><td class='style3'>&nbsp;站长:{6}<br /></td></tr><tr><td class='style2'>地址:{2} </td><td class='style1'>邮编:{5}</td><td class='style3'>信箱:{1}</td></tr><tr><td class='style2'>电话：{3}</td><td class='style1'>手机：{4}</td><td class='style3'>QQ:{8}</td></tr></table>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i]["webSiteName"].ToString(), dt.Rows[i]["email"].ToString(), dt.Rows[i]["address"].ToString(), dt.Rows[i]["phone"].ToString(), dt.Rows[0]["sjPhone"].ToString(), dt.Rows[0]["youbian"].ToString(), dt.Rows[0]["zhanzhang"].ToString(), dt.Rows[0]["banquan"].ToString(), dt.Rows[0]["qq"].ToString());
        }
        list += "</table>";
        Response.Write(list);
    }
    protected void SubmitRegist()
    {
        string sql = "INSERT INTO NetUser (name,nickname,spassword1,usermail,Typ_steptid)VALUES(N'" + Request["webName"] + "',N'" + Server.UrlDecode(Request["nick"]) + "',N'" + MD5.Hash(Request["webPassWord"]) + "',N'" + Request["email"] + "'," + 1 + ")";
        string num = PageValidate.GetSafeStr(Request["checkNum"]);
        if (num.CompareTo(Session["Vnumber2"].ToString()) == 0)
        {
            DB.execnonsql(sql); Response.Write("0");//成功
        }
        else Response.Write("1");
    }
    protected void ForumList()
    {
        StringBuilder sb = new StringBuilder("");
        string sql = "", id = "";
        int pageSize = 30;
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }
        sql = "select count(*) from ForumQuestion WHERE title!='" + 1 + "'"; sb.Append("select top " + pageSize.ToString() + " * from ForumQuestion WHERE title!='" + 1 + "'");
        //如果不是第一页
        if (page > 1)
        {
            sb.Append(" and questionid not in(select top " + (pageSize * (page - 1)).ToString() + " questionid from ForumQuestion WHERE title!='" + 1 + "' order by questionid desc)");
        }
        sb.Append(" order by questionid desc"); id = "questionid";
        int count = Convert.ToInt32(DB.FindString(sql));
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string str = "<tr><td style = 'width:10'><img src='Images/biao.gif' /></td><td style = 'width:150'><a href=\"javascript:void(ParticularForum1({0},'{1}'));\" title = '标题：{3}|||点击量：{4}||回复量:{5}'>{1}</a></td><td style = 'width:70'>{2}</td></tr>";
        string list = " <table style='width: 220px;font-size: 12px; margin-top: 0px;'>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 10 ? dt.Rows[i]["title"].ToString().Substring(0, 10) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clicknum"].ToString(), dt.Rows[i]["replynum"].ToString());
        }
        list += "</table>";

        string lis = "<div id = 'to'style='  border-bottom: 1px solid #99CCFF; margin: 0px 0px 0px 0px; width: 220px; height: 27px; font-size: 16px; color: #66CCFF;'><img src='Images/gif-0230.GIF' style='height: 24px; width: 31px;' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 帖子列表</div>";
        Response.Write(lis+list + "<div id='pager'>" + this.GetPager3(page, pageSize, count) + "</div></div>");
    }
    public string GetPager3(int page, int pageSize, int count)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 5) * 5 + 1;

        for (int i = start; i <= pageCount && i < start + 5; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:ForumList(" + i + ")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:ForumList(" + (start - 1).ToString() + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:ForumList(" + (1).ToString() + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 5 < pageCount)
        {
            sb.Append("<a href='javascript:ForumList(" + (start + 5).ToString() + ")' title='第" + (start + 5).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:ForumList(" + pageCount.ToString() + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    protected void GetTopForum()
    {
        string sql = "";


        sql = "SELECT top 1 * FROM ForumQuestion ORDER BY questionid DESC";

        string sql2 = "UPDATE ForumQuestion SET clicknum=clicknum+1 WHERE questionid IN (SELECT top 1 questionid FROM ForumQuestion ORDER BY questionid DESC ) ";

       System.Data.DataTable dt = DB.OpenQuery(sql);
       string list = ""; string str = "<table class = 'tableForum' style='width: 728px; font-size: 14px;'><tr><td style = 'background-image: url(Images/%E8%83%8C%E6%99%AF.jpg);'>{0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;楼主</td></tr><tr><td>{1}</td></tr><tr><td style='overflow: scroll; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0;'>作者:{2}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}&nbsp;&nbsp;点击数：{7}&nbsp;&nbsp;回复数：{6}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href = \"javascript:replyForum({4},'{5}');\">回复此帖</a></td></tr></table>";

       for (int i = 0; i < dt.Rows.Count; i++)
       {
           list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["content"].ToString(), dt.Rows[i]["author"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[0]["questionid"].ToString(), dt.Rows[0]["title"].ToString(), dt.Rows[0]["replynum"].ToString(), dt.Rows[0]["clicknum"].ToString());
       }
       list += "</table>";

       string sql1 = "SELECT * FROM ForumAnswer WHERE For_questionid =" + Convert.ToInt32(dt.Rows[0]["questionid"].ToString()) + "";
       System.Data.DataTable dt1 = DB.OpenQuery(sql1);
       string list1 = "";
       for (int i = 0; i < dt1.Rows.Count; i++)
       {
           int j = i + 1;
           string str1 = "<table class = 'tableForum' style='width: 728px; font-size: 12px;'><tr><td style = 'background-image: url(Images/%E8%83%8C%E6%99%AF.jpg);'>回复：{0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + j + "楼</td></tr><tr><td>{1}</td></tr><tr><td style='overflow: scroll; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0;'>作者:{2}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href = \"javascript:replyForum({4},'{5}');\">回复此帖</a></td></tr></table>";
           list1 += string.Format(str1, dt1.Rows[i]["title"].ToString(), dt1.Rows[i]["content"].ToString(), dt1.Rows[i]["author"].ToString(), dt1.Rows[i]["time"].ToString(), dt.Rows[0]["questionid"].ToString(), dt.Rows[0]["title"].ToString());
       }
       list1 += "</table>";
       list += list1;
       //Response.Write(list);
       //string sql2 = "UPDATE ForumQuestion SET clicknum=clicknum+1 WHERE questionid =" + Convert.ToInt32(Request["id"]) + "";
       //DB.execnonsql(sql2);
       string sqllock = "SELECT islockForum FROM WebSiteSet";
       int stept;
       if (Convert.ToBoolean(DB.FindString(sqllock)) == false)
       {
           if (DB.hasSession("stept"))
               stept = Convert.ToInt32(Session["stept"]);
           else stept = 1;
           if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()))
           {
               Response.Write(list);
               DB.execnonsql(sql2);
           }
           else Response.Write("<font color='red'>抱歉你的会员级别暂时无法阅读此文章!<font><br>");
       }
       else Response.Write("<font color='red'>抱歉此论坛暂时已关闭!<font><br>");
        
    }
    protected void GetForumList()
    {
        string sql = "", id = "";


        sql = "SELECT top 10 questionid,title,time,clicknum FROM ForumQuestion ORDER BY questionid DESC "; id = "questionid";
           

        
        System.Data.DataTable dt = DB.OpenQuery(sql);
        string str = "<tr><td><img src='Images/biao.gif' /></td><td style = 'width:385'><a href=\"javascript:void(ParticularForum({0},'{1}'));\" title = '标题：{3}|||点击量：{4}'>{1}</a></td><td style = 'width:65'>{2}</td></tr>";
        string list = " <table style='width: 450px;font-size: 12px; margin-top: 0px;'>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 24 ? dt.Rows[i]["title"].ToString().Substring(0, 24) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clicknum"].ToString());
        }
        list += "</table>";

        Response.Write(list);
    }
    protected void CheckUserName()
    {
        string sql = "SELECT count(*) FROM NetUser WHERE name=N'" + Request["userName"].ToString() + "'";
        if (Convert.ToInt32(DB.FindString(sql)) > 0)
            //Response.Write("此用户已存在！");
            Response.Write("0");
        //else Response.Write("恭喜你！次用户可注册！");
        else Response.Write("1");
    }
    protected void Login()
    {

        //加密
        string userName = PageValidate.GetSafeStr(Request["name"]);
        string userPass = PageValidate.GetSafeStr(Request["pass"]);
        string num = PageValidate.GetSafeStr(Request["num"]);
        string pass = MD5.Hash(userPass);
        //验证验证码用户名密码
        string sql = "SELECT spassword1 FROM NetUser WHERE name=N'" + userName + "'";//构成sql语句
        string sql1 = "SELECT Typ_steptid FROM NetUser WHERE name=N'" + userName + "'";
        string sql2 = "SELECT islock1 FROM NetUser WHERE name=N'" + userName + "'";
        string sql3 = "SELECT nickname FROM NetUser WHERE name=N'" + userName + "'";
        if (num.CompareTo(Session["Vnumber3"].ToString()) == 0)
        {
            if (DB.FindString(sql) == pass)
            {


                Response.Write("<br/><br/><br/>欢迎" + userName + "<br/>" + DB.FindString(sql3) + "<br/><input id='edit' type='button' value = '退出'onclick = 'javascript:express();' />");
                Session["stept"] = DB.FindString(sql1);
                Session["name"] = DB.FindString(sql3);



            }
            else Response.Write("1"); //用户名密码不正确
        }
        else Response.Write("2"); //验证码不正确



    }
    protected void Login1()
    {

        //加密
        string userName = PageValidate.GetSafeStr(Request["name1"]);
        string userPass = PageValidate.GetSafeStr(Request["pass1"]);
        string num = PageValidate.GetSafeStr(Request["num1"]);
        string pass = MD5.Hash(userPass);
        //验证验证码用户名密码
        string sql = "SELECT password FROM studentlist WHERE name=N'" + userName + "'";//构成sql语句
        string sql2 = "SELECT nickname FROM studentlist WHERE name=N'" + userName + "'";
        string sql3 = "SELECT * FROM studentlist WHERE name=N'" + userName + "'";
        System.Data.DataTable dt = DB.OpenQuery(sql3);
        if (dt.Rows.Count == 0) { Response.Write("3"); return; }
        string sql4 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[0]["sclass"]).ToString() + "";
        if (num.CompareTo(Session["Vnumber1"].ToString()) == 0)
        {
            if (DB.FindString(sql) == pass)
            {
               
                    //Response.Write("0");
                Response.Write("<br /><br />" + DB.FindString(sql4) + "<br />" + DB.FindString(sql2) + "<br />" + dt.Rows[0]["studyNum"].ToString() + "<br />编号:" + dt.Rows[0]["studentID"].ToString() + "<br /><input id='edit1' type='button' value = '更改密码'onclick = 'javascript:editPassword();' /><input id='edit1' type='button' value = '退出'onclick = 'javascript:express1();' />");
                    Session["student"] = DB.FindString(sql2);

                    Session["student1"] = userName;
                    Session["student2"] = dt.Rows[0]["studentID"].ToString();



            }
            else Response.Write("1"); //用户名密码不正确
        }
        else Response.Write("2"); //验证码不正确



    }
    protected void CallNews()
    {
        string sql = "SELECT adr FROM WebSiteSet";
        Response.Write("   <marquee id= 'scrollarea' style = 'height:194px' onmouseover=this.stop(); onmouseout=this.start();  scrollAmount=2 scrollDelay=50 direction=up>" + DB.FindString(sql) + "</marquee>");
    }
    protected void GetList()
    {
        string sql = "", id = "",str = "",list="";
        switch(Request["park"])
        {
            //case "0": sql = "SELECT top 10 newsid,title,time,lookTime FROM NewsList ORDER BY newsid DESC "; id = "newsid"; break;
            case "1": sql = "SELECT top 10 teachParkID,title,time,lookTime FROM TeachPark ORDER BY teachParkID DESC "; id = "teachParkID"; break;
            case "2": sql = "SELECT top 10 researchId,title,time,lookTime FROM ResearchList ORDER BY researchId DESC "; id = "researchId"; break;
            case "5": sql = "SELECT top 10 upId,title,time,lookTime FROM StuUpFIleList WHERE isPro='" + true + "' ORDER BY upId DESC "; id = "upId"; break;
            case "4": sql = "SELECT top 10 subjectID,title,time,lookTime FROM SubjectList ORDER BY subjectID DESC "; id = "subjectID"; break;
            case "3": sql = "SELECT top 10 resourcesID,title,time,lookTime FROM ResourcesList ORDER BY resourcesID DESC "; id = "resourcesID"; break;
            case "6": sql = "SELECT top 10 TeacherUpWorkID,title,time,lookTime FROM TeacherUpFileWorkList ORDER BY TeacherUpWorkID DESC "; id = "TeacherUpWorkID"; break;
            case "8": sql = "SELECT top 10 upWorkId,title,time,lookTime FROM stuWorkList ORDER BY upWorkId DESC "; id = "upWorkId"; break;
        }
        System.Data.DataTable dt = DB.OpenQuery(sql);
        if (Request["park"] == "8")
        {
            str = "<tr><td><img src='Images/biao.gif' /></td><td style = 'width:400'><a href=\"javascript:void(Particular({0},{5}));\" title = '标题：{3}|||点击量：{4}'>{1}</a></td><td style = 'width:65'>{2}</td></tr>";
            list = " <table style='width: 460px;font-size: 12px; margin-top: 0px;'>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if(Request["park"]=="6")
                //    list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 16 ? dt.Rows[i]["title"].ToString().Substring(0, 16) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString().Substring(0, 9), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clickNum"].ToString(), Request["park"]);
                list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 25 ? dt.Rows[i]["title"].ToString().Substring(0, 25) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), dt.Rows[i]["title"].ToString(), dt.Rows[i]["lookTime"].ToString(), Request["park"]);
            }
        }
        else
        {
            str = "<tr><td><img src='Images/biao.gif' /></td><td style = 'width:300'><a href=\"javascript:void(Particular({0},{5}));\" title = '标题：{3}|||点击量：{4}'>{1}</a></td><td style = 'width:65'>{2}</td></tr>";
            list = " <table style='width: 360px;font-size: 12px; margin-top: 0px;'>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if(Request["park"]=="6")
                //    list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 16 ? dt.Rows[i]["title"].ToString().Substring(0, 16) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString().Substring(0, 9), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clickNum"].ToString(), Request["park"]);
                list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 20 ? dt.Rows[i]["title"].ToString().Substring(0, 20) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), dt.Rows[i]["title"].ToString(), dt.Rows[i]["lookTime"].ToString(), Request["park"]);
            }
        }
        
        list += "</table>";
       
        Response.Write(list);
    }
    protected void typeTop1()
    {
        string sql = "", str = "", sql2 = "";

        switch (Request["park"])
        {
            case "0": sql = "SELECT top 1 * FROM NewsList WHERE New_newstypeid =" + Convert.ToInt32(Request["id"]) + " ORDER BY newsid DESC"; sql2 = "UPDATE NewsList SET lookTime=lookTime+1 WHERE newsid in(SELECT top 1 newsid FROM NewsList WHERE New_newstypeid =" + Convert.ToInt32(Request["id"]) + " ORDER BY newsid DESC )"; break;
            case "1": sql = "SELECT top 1 * FROM TeachPark WHERE Tea_teachtypeid =" + Convert.ToInt32(Request["id"]) + " ORDER BY teachParkID DESC"; sql2 = "UPDATE TeachPark SET lookTime=lookTime+1 WHERE teachParkID in(SELECT top 1 teachParkID FROM TeachPark WHERE Tea_teachtypeid =" + Convert.ToInt32(Request["id"]) + " ORDER BY teachParkID DESC )"; break;
            case "2": sql = "SELECT top 1 * FROM ResearchList WHERE res_researchTypeId =" + Convert.ToInt32(Request["id"]) + " ORDER BY researchId DESC"; sql2 = "UPDATE ResearchList SET lookTime=lookTime+1 WHERE researchId in(SELECT top 1 researchId FROM ResearchList WHERE res_researchTypeId =" + Convert.ToInt32(Request["id"]) + " ORDER BY researchId DESC )"; break;
            //case "5": sql = "SELECT top 1 * FROM StuUpFIleList WHERE isPro='" + true + "' ORDER BY upId DESC"; sql2 = "UPDATE StuUpFIleList SET lookTime=lookTime+1 WHERE upId in(SELECT top 1 upId FROM StuUpFIleList WHERE isPro='" + true + "' ORDER BY upId DESC )"; break;
            case "4": sql = "SELECT top 1 * FROM SubjectList WHERE Sub_subTypeID =" + Convert.ToInt32(Request["id"]) + " ORDER BY subjectID DESC"; sql2 = "UPDATE SubjectList SET lookTime=lookTime+1 WHERE subjectID in(SELECT top 1 subjectID FROM SubjectList WHERE Sub_subTypeID =" + Convert.ToInt32(Request["id"]) + " ORDER BY subjectID DESC )"; break;
            case "3": sql = "SELECT top 1 * FROM ResourcesList WHERE Res_resourcestypeid =" + Convert.ToInt32(Request["id"]) + " ORDER BY resourcesID DESC"; sql2 = "UPDATE ResourcesList SET lookTime=lookTime+1 WHERE resourcesID in(SELECT top 1 resourcesID FROM ResourcesList WHERE Res_resourcestypeid =" + Convert.ToInt32(Request["id"]) + " ORDER BY resourcesID DESC )"; break;
            //case "6": sql = "SELECT * FROM ForumQuestion WHERE questionid =" + Convert.ToInt32(Request["id"]) + "";  break;
            case "6": sql = "SELECT top 1 * FROM TeacherUpFileWorkList WHERE Tea_teachUpTypeID =" + Convert.ToInt32(Request["id"]) + " ORDER BY TeacherUpWorkID DESC"; sql2 = "UPDATE TeacherUpFileWorkList SET lookTime=lookTime+1 WHERE TeacherUpWorkID in(SELECT top 1 TeacherUpWorkID FROM TeacherUpFileWorkList WHERE Tea_teachUpTypeID =" + Convert.ToInt32(Request["id"]) + " ORDER BY TeacherUpWorkID DESC )"; break;
            //case "8": sql = "SELECT top 1 * FROM CompleteWork WHERE isPro='" + true + "' ORDER BY completWorkID DESC"; sql2 = "UPDATE CompleteWork SET lookTime=lookTime+1 WHERE completWorkID in(SELECT top 1 completWorkID FROM CompleteWork WHERE isPro='" + true + "' ORDER BY completWorkID DESC )"; break;
        }
        System.Data.DataTable dt = DB.OpenQuery(sql);
        //  if(Request["park"] == "6")
        //      str = "<table style='width: 570;'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {0}</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 点击次数：{2} 上传时间：{1}所属课程：{4}</td><td><a href = 'doWork.aspx?&courseid={5}'target = '_blank'</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
        //else str = "<table style='width: 570;'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {0}</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 点击次数：{2}&nbsp;&nbsp; 上传时间：{1}</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
        string list = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {


            if (Request["park"] == "6" || Request["park"] == "1")
            {
                if (Request["park"] == "1")
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";

                    str = "<table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
                    list += string.Format(str,dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString());
                }
                else
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
                    string sqlwork = "SELECT name FROM TeacherUpType WHERE teachUpTypeID = '" + dt.Rows[i]["Tea_teachUpTypeID"].ToString() + "'";
                    if (DB.FindString(sqlwork).ToString() == "课堂作业") str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 14px;'><tr><td style='font-size: 14px; text-align: center;'>{0}&nbsp;&nbsp;&nbsp;&nbsp;<a href = \"javascript:doworkopenwin({5},'{0}',{6})\">做做试试</a></td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";
                    else str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";
                    list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), dt.Rows[i]["TeacherUpWorkID"]);
                }
            }
            else
            {
                if (Request["park"] == "5" || Request["park"] == "8")
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + Convert.ToInt32(dt.Rows[i]["Cou_courseid"].ToString()) + "'";
                    string sqlwork = "SELECT nickname FROM studentlist WHERE studentID = '" + Convert.ToInt32(dt.Rows[i]["stu_studentID"].ToString()) + "'";
                    str = "<table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}&nbsp;&nbsp;&nbsp;&nbsp;</td></tr><tr><td style=' text-align: center;'> 点击次数：{2} 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr><tr><td>学生名:{6}</td></tr></table>";

                    list += string.Format(str,dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), DB.FindString(sqlwork));
                }
                else
                {
                    if (Request["park"] == "2")
                    {
                        string sqlCourse = "SELECT name FROM pass WHERE passId = '" + Convert.ToInt32(dt.Rows[i]["pas_passId"].ToString()) + "'";
                        str = "<table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}&nbsp;&nbsp;&nbsp;&nbsp;</td></tr><tr><td style=' text-align: center;'> 点击次数：{2} 上传时间：{1}&nbsp;&nbsp;科研方向：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse));
                    }
                    else { str = "<table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}</td></tr><tr><td>&nbsp;{3}</td></tr></table>"; list += string.Format(str,dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString()); }
                }
            }
        }

        int stept;
        if (DB.hasSession("stept"))
            stept = Convert.ToInt32(Session["stept"]);
        else stept = 1;
        if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()))
        {

            Response.Write(list);
            DB.execnonsql(sql2);
        }
        else Response.Write("<font color='red'>抱歉你的会员级别暂时无法阅读此文章!<font><br>");
    }
    protected void GetTop20()
    {
        string sql = "", id = "", id1 = "", sql1 = "",sql2="",str="",list1="";
        if (Request["park"] != "5" && Request["park"] != "8")
        {
            switch (Request["park"])
            {
                case "0": sql1 = "SELECT * FROM NewsType ORDER BY newstypeid DESC"; id1 = "newstypeid"; break;
                case "1": sql1 = "SELECT * FROM TeachParkType ORDER BY teachtypeid DESC"; id1 = "teachtypeid"; break;
                case "2": sql1 = "SELECT * FROM researchType ORDER BY researchTypeId DESC"; id1 = "researchTypeId"; break;

                case "4": sql1 = "SELECT * FROM SubjectType ORDER BY subTypeID DESC"; id1 = "subTypeID"; break;

                case "3": sql1 = "SELECT * FROM RescourcesType ORDER BY resourcestypeid DESC"; id1 = "resourcestypeid"; break;
                case "6": sql1 = "SELECT * FROM TeacherUpType ORDER BY teachUpTypeID DESC"; id1 = "teachUpTypeID"; break;


            }
            System.Data.DataTable dt1 = new DataTable("");
            dt1 = DB.OpenQuery(sql1);
            list1 = "<div style = 'width:728;font-size: 12px;' ><table id = 'tabType' style = 'width:728;font-size: 12px;'><tr><td>";
            string str1 = "<a href = 'javascript:List2(1,{2},{0});'>{1}</a>";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                //if (Request["park"] != "6" && Request["park"] != "3" && Request["park"] != "8")
                list1 += string.Format(str1, dt1.Rows[i][id1].ToString(), dt1.Rows[i]["name"].ToString(), Request["park"]);

            }
            list1 += "</td></tr></table></div>";
        }
        switch (Request["park"])
        {
            case "0": sql = "SELECT top 1 * FROM NewsList ORDER BY newsid DESC"; sql2 = "UPDATE NewsList SET lookTime=lookTime+1 WHERE newsid in(SELECT top 1 newsid FROM NewsList ORDER BY newsid DESC )"; break;
            case "1": sql = "SELECT top 1 * FROM TeachPark ORDER BY teachParkID DESC"; sql2 = "UPDATE TeachPark SET lookTime=lookTime+1 WHERE teachParkID in(SELECT top 1 teachParkID FROM TeachPark ORDER BY teachParkID DESC )"; break;
            case "2": sql = "SELECT top 1 * FROM ResearchList ORDER BY researchId DESC"; sql2 = "UPDATE ResearchList SET lookTime=lookTime+1 WHERE researchId in(SELECT top 1 researchId FROM ResearchList ORDER BY researchId DESC )"; break;
            case "5": sql = "SELECT top 1 * FROM StuUpFIleList WHERE isPro='" + true + "' ORDER BY upId DESC"; sql2 = "UPDATE StuUpFIleList SET lookTime=lookTime+1 WHERE upId in(SELECT top 1 upId FROM StuUpFIleList WHERE isPro='" + true + "' ORDER BY upId DESC )"; break;
            case "4": sql = "SELECT top 1 * FROM SubjectList ORDER BY subjectID DESC"; sql2 = "UPDATE SubjectList SET lookTime=lookTime+1 WHERE subjectID in(SELECT top 1 subjectID FROM SubjectList ORDER BY subjectID DESC )"; break;
            case "3": sql = "SELECT top 1 * FROM ResourcesList ORDER BY resourcesID DESC"; sql2 = "UPDATE ResourcesList SET lookTime=lookTime+1 WHERE resourcesID in(SELECT top 1 resourcesID FROM ResourcesList ORDER BY resourcesID DESC )"; break;
            //case "6": sql = "SELECT * FROM ForumQuestion WHERE questionid =" + Convert.ToInt32(Request["id"]) + "";  break;
            case "6": sql = "SELECT top 1 * FROM TeacherUpFileWorkList ORDER BY TeacherUpWorkID DESC"; sql2 = "UPDATE TeacherUpFileWorkList SET lookTime=lookTime+1 WHERE TeacherUpWorkID in(SELECT top 1 TeacherUpWorkID FROM TeacherUpFileWorkList ORDER BY TeacherUpWorkID DESC )"; break;
            case "8": sql = "SELECT top 1 * FROM stuWorkList ORDER BY upWorkId DESC"; sql2 = "UPDATE stuWorkList SET lookTime=lookTime+1 WHERE upWorkId in(SELECT top 1 upWorkId FROM stuWorkList ORDER BY upWorkId DESC )"; break;
        }
        System.Data.DataTable dt = DB.OpenQuery(sql);
        //  if(Request["park"] == "6")
        //      str = "<table style='width: 570;'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {0}</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 点击次数：{2} 上传时间：{1}所属课程：{4}</td><td><a href = 'doWork.aspx?&courseid={5}'target = '_blank'</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
        //else str = "<table style='width: 570;'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {0}</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 点击次数：{2}&nbsp;&nbsp; 上传时间：{1}</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
        string list = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {


            if (Request["park"] == "6" || Request["park"] == "1")
            {
                if (Request["park"] == "1")
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";

                    str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";
                    list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString());
                }
                else
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
                    string sqlwork = "SELECT name FROM TeacherUpType WHERE teachUpTypeID = '" + dt.Rows[i]["Tea_teachUpTypeID"].ToString() + "'";
                   str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";
                    list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), dt.Rows[i]["TeacherUpWorkID"]);
                }
            }
            else
            {
                if (Request["park"] == "5" || Request["park"] == "8")
                {
                    if (Request["park"] == "8")
                    {
                        string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + Convert.ToInt32(dt.Rows[i]["Cou_courseid"].ToString()) + "'";

                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}&nbsp;&nbsp;&nbsp;&nbsp;<a href = \"javascript:doworkopenwin({5},'{0}',{6},{7},{8},{9},{10})\">做做试试</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href = 'javascript:SearchWorkState({7})'>查询作业状态</a></td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;所属课程：{4}&nbsp;&nbsp;第{6}次作业&nbsp;&nbsp;上传期限:{8}年{9}月{10}日</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), dt.Rows[i]["workNum"].ToString(), dt.Rows[i]["upWorkId"].ToString(), dt.Rows[i]["lastUpYear"].ToString(), dt.Rows[i]["lastUpMonth"].ToString(), dt.Rows[i]["lastUpDay"].ToString());
                    }
                    else
                    {
                        string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + Convert.ToInt32(dt.Rows[i]["Cou_courseid"].ToString()) + "'";
                        string sqlwork = "SELECT nickname FROM studentlist WHERE studentID = '" + Convert.ToInt32(dt.Rows[i]["stu_studentID"].ToString()) + "'";
                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr><tr><td>学生名:{6}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), DB.FindString(sqlwork));
                    }
                }
                else
                {
                    if (Request["park"] == "2")
                    {
                        string sqlCourse = "SELECT name FROM pass WHERE passId = '" + Convert.ToInt32(dt.Rows[i]["pas_passId"].ToString()) + "'";
                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}&nbsp;&nbsp;&nbsp;&nbsp;</td></tr><tr><td style=' text-align: center;'> 点击次数：{2} 上传时间：{1}&nbsp;&nbsp;科研方向：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse));
                    }
                    else { str = "<div id = 'contentList' style = 'border-top-color: #99CCFF; border-top-width: 2px;'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>"; list += string.Format(str,dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString()); }
                }
            }
        }

        if (Request["park"] == "5" || Request["park"] == "8")
        {
            int stept;
            if (DB.hasSession("stept"))
                stept = Convert.ToInt32(Session["stept"]);
            else stept = 1;
            if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()) || DB.hasSession("student"))
            {
                list1 += list;
                Response.Write(list1);
                DB.execnonsql(sql2);
            }
            else Response.Write(list1 + "<div id = 'contentList'style = 'border-bottom-color: #99CCFF; border-bottom-width: 2px; '><font color='red'>抱歉你的会员级别暂时无法阅读此文章若是学生请先登录!<font><br></div>");
        }
        else
        {
            int stept;
            if (DB.hasSession("stept"))
                stept = Convert.ToInt32(Session["stept"]);
            else stept = 1;
            if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()))
            {
                list1 += list;
                Response.Write(list1);
                DB.execnonsql(sql2);
            }
            else Response.Write(list1 + "<div id = 'contentList'style = 'border-bottom-color: #99CCFF; border-bottom-width: 2px; '><font color='red'>抱歉你的会员级别暂时无法阅读此文章!<font><br></div>");
        }

       
    }
    protected void GetList1()
    {
        string sql = "", id = "";
        switch (Request["park"])
        {
            case "0": sql = "SELECT top 10 newsid,title,time,lookTime FROM NewsList ORDER BY newsid DESC "; id = "newsid"; break;
            //case "7": sql = "SELECT top 10 TeacherUpWorkID,title,time,lookTime FROM TeacherUpFileWorkList ORDER BY TeacherUpWorkID DESC "; id = "TeacherUpWorkID"; break;
            //case "8": sql = "SELECT top 10 completWorkID,title,time,lookTime FROM CompleteWork ORDER BY completWorkID DESC "; id = "completWorkID"; break;
            
        }
        System.Data.DataTable dt = DB.OpenQuery(sql);
        string str = "<tr><td><img src='Images/biao.gif' /></td><td style = 'width:405'><a href=\"javascript:void(Particular({0},{5}));\" title = '标题：{3}|||点击量：{4}'>{1}</a></td><td style = 'width:65'>{2}</td></tr>";
        string list = " <table style='width: 480px;font-size: 12px; margin-top: 0px;'>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
           // DateTime time = Convert.ToDateTime(dt.Rows[i]["time"]);
            
            //if (Request["park"] == "6")
            //    list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 16 ? dt.Rows[i]["title"].ToString().Substring(0, 16) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString().Substring(0, 9), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clickNum"].ToString(), Request["park"]);
            list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 30 ? dt.Rows[i]["title"].ToString().Substring(0, 30) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), dt.Rows[i]["title"].ToString(), dt.Rows[i]["lookTime"].ToString(), Request["park"]);
        }
        list += "</table>";

        Response.Write(list);
    }
    protected void ParticularForum()
    {
        string sql = "SELECT * FROM ForumQuestion WHERE questionid =" + Convert.ToInt32(Request["id"]) + "";
        System.Data.DataTable dt = DB.OpenQuery(sql);
        string list = ""; string str = "<table class = 'tableForum' style='width: 728px; font-size: 12px;'><tr><td style = 'background-image: url(Images/%E8%83%8C%E6%99%AF.jpg);'>{0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;楼主</td></tr><tr><td >{1}</td></tr><tr><td style='overflow: scroll; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0;'>作者:{2}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}&nbsp;&nbsp;点击数：{7}&nbsp;&nbsp;回复数：{6}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href = \"javascript:replyForum({4},'{5}');\">回复此帖</a></td></tr></table>";
       
         for (int i = 0; i < dt.Rows.Count; i++)
         {
             list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["content"].ToString(), dt.Rows[i]["author"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[0]["questionid"].ToString(), dt.Rows[0]["title"].ToString(), dt.Rows[0]["replynum"].ToString(), dt.Rows[0]["clicknum"].ToString());
         }
         list += "</table>";

         string sql1 = "SELECT * FROM ForumAnswer WHERE For_questionid =" + Convert.ToInt32(dt.Rows[0]["questionid"].ToString()) + "";
         System.Data.DataTable dt1 = DB.OpenQuery(sql1);
         string list1 = ""; 
         for (int i = 0; i < dt1.Rows.Count; i++)
         {
             int j = i + 1;
             string str1 = "<table class = 'tableForum' style='width: 728px; font-size: 12px;'><tr><td style = 'background-image: url(Images/%E8%83%8C%E6%99%AF.jpg);'>回复：{0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + j + "楼</td></tr><tr><td>{1}</td></tr><tr><td style='overflow: scroll; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #C0C0C0;'>作者:{2}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href = \"javascript:replyForum({4},'{5}');\">回复此帖</a></td></tr></table>";
             list1 += string.Format(str1, dt1.Rows[i]["title"].ToString(), dt1.Rows[i]["content"].ToString(), dt1.Rows[i]["author"].ToString(), dt1.Rows[i]["time"].ToString(), dt.Rows[0]["questionid"].ToString(), dt.Rows[0]["title"].ToString());
         }
         list1 += "</table>";
         list += list1;
         //Response.Write(list);
         string sql2 = "UPDATE ForumQuestion SET clicknum=clicknum+1 WHERE questionid =" + Convert.ToInt32(Request["id"]) + "";
         //DB.execnonsql(sql2);
         string sqllock = "SELECT islockForum FROM WebSiteSet";
         int stept;
         if (Convert.ToBoolean(DB.FindString(sqllock)) == false)
         {
             if (DB.hasSession("stept"))
                 stept = Convert.ToInt32(Session["stept"]);
             else stept = 1;
             if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()))
             {
                 Response.Write(list);
                 DB.execnonsql(sql2);
             }
             else Response.Write("<font color='red'>抱歉你的会员级别暂时无法阅读此文章!<font><br>");
         }
         else Response.Write("<font color='red'>抱歉此论坛暂时已关闭!<font><br>");
        
    }
    protected void Particular()
    {
        string sql = "", str = "", sql2 = "";
        string sql1 = "";
        string id1 = "", list1 = "";
        if (Request["park"] != "5" && Request["park"] != "8")
        {
            switch (Request["park"])
            {
                case "0": sql1 = "SELECT * FROM NewsType ORDER BY newstypeid DESC"; id1 = "newstypeid"; break;
                case "1": sql1 = "SELECT * FROM TeachParkType ORDER BY teachtypeid"; id1 = "teachtypeid"; break;
                case "2": sql1 = "SELECT * FROM researchType ORDER BY researchTypeId"; id1 = "researchTypeId"; break;

                case "4": sql1 = "SELECT * FROM SubjectType ORDER BY subTypeID"; id1 = "subTypeID"; break;

                case "3": sql1 = "SELECT * FROM RescourcesType ORDER BY resourcestypeid"; id1 = "resourcestypeid"; break;
                case "6": sql1 = "SELECT * FROM TeacherUpType ORDER BY teachUpTypeID"; id1 = "teachUpTypeID"; break;


            }
            System.Data.DataTable dt1 = new DataTable("");
            dt1 = DB.OpenQuery(sql1);
            list1 = "<table id = 'tabType' style = 'width:728;font-size: 12px;'><tr><td>";
            string str1 = "<a href = 'javascript:List2(1,{2},{0});'>{1}</a>";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                //if (Request["park"] != "6" && Request["park"] != "3" && Request["park"] != "8")
                list1 += string.Format(str1, dt1.Rows[i][id1].ToString(), dt1.Rows[i]["name"].ToString(), Request["park"]);

            }
            list1 += "</td></tr></table>";
        }
        switch (Request["park"])
        {
            case "0": sql = "SELECT * FROM NewsList WHERE newsid =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE NewsList SET lookTime=lookTime+1 WHERE newsid =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "1": sql = "SELECT * FROM TeachPark WHERE teachParkID =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE TeachPark SET lookTime=lookTime+1 WHERE teachParkID =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "2": sql = "SELECT * FROM ResearchList WHERE researchId =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE ResearchList SET lookTime=lookTime+1 WHERE researchId =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "5": sql = "SELECT * FROM StuUpFIleList WHERE upId =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE StuUpFIleList SET lookTime=lookTime+1 WHERE upId =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "4": sql = "SELECT * FROM SubjectList WHERE subjectID =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE SubjectList SET lookTime=lookTime+1 WHERE subjectID =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "3": sql = "SELECT * FROM ResourcesList WHERE resourcesID =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE ResourcesList SET lookTime=lookTime+1 WHERE resourcesID =" + Convert.ToInt32(Request["id"]) + ""; break;
            //case "6": sql = "SELECT * FROM ForumQuestion WHERE questionid =" + Convert.ToInt32(Request["id"]) + "";  break;
            case "6": sql = "SELECT * FROM TeacherUpFileWorkList WHERE TeacherUpWorkID =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE TeacherUpFileWorkList SET lookTime=lookTime+1 WHERE TeacherUpWorkID =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "8": sql = "SELECT * FROM stuWorkList WHERE upWorkId =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE stuWorkList SET lookTime=lookTime+1 WHERE upWorkId =" + Convert.ToInt32(Request["id"]) + ""; break;
        }
        System.Data.DataTable dt = DB.OpenQuery(sql);
        //  if(Request["park"] == "6")
        //      str = "<table style='width: 570;'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {0}</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 点击次数：{2} 上传时间：{1}所属课程：{4}</td><td><a href = 'doWork.aspx?&courseid={5}'target = '_blank'</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
        //else str = "<table style='width: 570;'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {0}</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 点击次数：{2}&nbsp;&nbsp; 上传时间：{1}</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
        string list = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {


            if (Request["park"] == "6" || Request["park"] == "1")
            {
                if (Request["park"] == "1")
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";

                    str = "<div id = 'contentList' style='width: 728;font-size: 12px;'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'> 点击次数：{2}&nbsp;&nbsp; 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";
                    list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString());
                }
                else
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
                    string sqlwork = "SELECT name FROM TeacherUpType WHERE teachUpTypeID = '" + dt.Rows[i]["Tea_teachUpTypeID"].ToString() + "'";
                   str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";
                    list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), dt.Rows[i]["TeacherUpWorkID"]);
                }
            }
            else
            {
                if (Request["park"] == "5" || Request["park"] == "8")
                {
                    if (Request["park"] == "8")
                    {
                        string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + Convert.ToInt32(dt.Rows[i]["Cou_courseid"].ToString()) + "'";

                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}&nbsp;&nbsp;&nbsp;&nbsp;<a href = \"javascript:doworkopenwin({5},'{0}',{6},{7},{8},{9},{10})\">做做试试</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href = 'javascript:SearchWorkState({7})'>查询作业状态</a></td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;所属课程：{4}&nbsp;&nbsp;第{6}次作业&nbsp;&nbsp;上传期限:{8}年{9}月{10}日</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), dt.Rows[i]["workNum"].ToString(), dt.Rows[i]["upWorkId"].ToString(), dt.Rows[i]["lastUpYear"].ToString(), dt.Rows[i]["lastUpMonth"].ToString(), dt.Rows[i]["lastUpDay"].ToString());
                    }
                    else
                    {
                        string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + Convert.ToInt32(dt.Rows[i]["Cou_courseid"].ToString()) + "'";
                        string sqlwork = "SELECT nickname FROM studentlist WHERE studentID = '" + Convert.ToInt32(dt.Rows[i]["stu_studentID"].ToString()) + "'";
                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr><tr><td>学生名:{6}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), DB.FindString(sqlwork));
                    }
                }
                else
                {
                    if (Request["park"] == "2")
                    {
                        string sqlCourse = "SELECT name FROM pass WHERE passId = '" + Convert.ToInt32(dt.Rows[i]["pas_passId"].ToString()) + "'";
                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}&nbsp;&nbsp;&nbsp;&nbsp;</td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;科研方向：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse));
                    }
                    else { str = "<div id = 'contentList' style = 'width: 728;border-top-color: #99CCFF; border-top-width: 2px;'><table class = 'tableForum' style='width: 628;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'> 点击次数：{2}&nbsp;&nbsp; 上传时间：{1}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>"; list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString()); }
                }
            }
        }
        if (Request["park"] == "5" || Request["park"] == "8")
        {
            int stept;
            if (DB.hasSession("stept"))
                stept = Convert.ToInt32(Session["stept"]);
            else stept = 1;
            if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()) || DB.hasSession("student"))
            {
                list1 += list;
                Response.Write(list1);
                DB.execnonsql(sql2);
            }
            else Response.Write(list1 + "<div id = 'contentList'style = 'border-bottom-color: #99CCFF; border-bottom-width: 2px; '><font color='red'>抱歉你的会员级别暂时无法阅读此文章若是学生请先登录!<font><br></div>");
        }
        else
        {
            int stept;
            if (DB.hasSession("stept"))
                stept = Convert.ToInt32(Session["stept"]);
            else stept = 1;
            if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()))
            {
                list1 += list;
                Response.Write(list1);
                DB.execnonsql(sql2);
            }
            else Response.Write(list1 + "<div id = 'contentList'style = 'border-bottom-color: #99CCFF; border-bottom-width: 2px; '><font color='red'>抱歉你的会员级别暂时无法阅读此文章!<font><br></div>");
        }
    }
    protected void Particular1()
    {
        string sql = "", str = "", sql2 = "";
      
        switch (Request["park"])
        {
            case "0": sql = "SELECT * FROM NewsList WHERE newsid =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE NewsList SET lookTime=lookTime+1 WHERE newsid =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "1": sql = "SELECT * FROM TeachPark WHERE teachParkID =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE TeachPark SET lookTime=lookTime+1 WHERE teachParkID =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "2": sql = "SELECT * FROM ResearchList WHERE researchId =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE ResearchList SET lookTime=lookTime+1 WHERE researchId =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "5": sql = "SELECT * FROM StuUpFIleList WHERE upId =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE StuUpFIleList SET lookTime=lookTime+1 WHERE upId =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "4": sql = "SELECT * FROM SubjectList WHERE subjectID =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE SubjectList SET lookTime=lookTime+1 WHERE subjectID =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "3": sql = "SELECT * FROM ResourcesList WHERE resourcesID =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE ResourcesList SET lookTime=lookTime+1 WHERE resourcesID =" + Convert.ToInt32(Request["id"]) + ""; break;
            //case "6": sql = "SELECT * FROM ForumQuestion WHERE questionid =" + Convert.ToInt32(Request["id"]) + "";  break;
            case "6": sql = "SELECT * FROM TeacherUpFileWorkList WHERE TeacherUpWorkID =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE TeacherUpFileWorkList SET lookTime=lookTime+1 WHERE TeacherUpWorkID =" + Convert.ToInt32(Request["id"]) + ""; break;
            case "8": sql = "SELECT * FROM stuWorkList WHERE upWorkId =" + Convert.ToInt32(Request["id"]) + ""; sql2 = "UPDATE stuWorkList SET lookTime=lookTime+1 WHERE upWorkId =" + Convert.ToInt32(Request["id"]) + ""; break;
        }
        System.Data.DataTable dt = DB.OpenQuery(sql);
        //  if(Request["park"] == "6")
        //      str = "<table style='width: 570;'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {0}</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 点击次数：{2} 上传时间：{1}所属课程：{4}</td><td><a href = 'doWork.aspx?&courseid={5}'target = '_blank'</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
        //else str = "<table style='width: 570;'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {0}</td></tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 点击次数：{2}&nbsp;&nbsp; 上传时间：{1}</td></tr><tr><td>&nbsp;{3}</td></tr></table>";
        string list = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {


            if (Request["park"] == "6" || Request["park"] == "1")
            {
                if (Request["park"] == "1")
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";

                    str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";
                    list += string.Format(str,dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString());
                }
                else
                {
                    string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
                    string sqlwork = "SELECT name FROM TeacherUpType WHERE teachUpTypeID = '" + dt.Rows[i]["Tea_teachUpTypeID"].ToString() + "'";
                  
                    str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2}&nbsp;&nbsp; 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";
                    list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), dt.Rows[i]["TeacherUpWorkID"]);
                }
            }
            else
            {
                if (Request["park"] == "5" || Request["park"] == "8")
                {
                    if (Request["park"] == "8")
                    {
                        string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + Convert.ToInt32(dt.Rows[i]["Cou_courseid"].ToString()) + "'";

                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}&nbsp;&nbsp;&nbsp;&nbsp;<a href = \"javascript:doworkopenwin({5},'{0}',{6},{7},{8},{9},{10})\">做做试试</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href = 'javascript:SearchWorkState({7})'>查询作业状态</a></td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;所属课程：{4}&nbsp;&nbsp;第{6}次作业&nbsp;&nbsp;上传期限:{8}年{9}月{10}日</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), dt.Rows[i]["workNum"].ToString(), dt.Rows[i]["upWorkId"].ToString(), dt.Rows[i]["lastUpYear"].ToString(), dt.Rows[i]["lastUpMonth"].ToString(), dt.Rows[i]["lastUpDay"].ToString());
                    }
                    else
                    {
                        string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + Convert.ToInt32(dt.Rows[i]["Cou_courseid"].ToString()) + "'";
                        string sqlwork = "SELECT nickname FROM studentlist WHERE studentID = '" + Convert.ToInt32(dt.Rows[i]["stu_studentID"].ToString()) + "'";
                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;所属课程：{4}</td></tr><tr><td>&nbsp;{3}</td></tr><tr><td>学生名:{6}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["Cou_courseid"].ToString(), DB.FindString(sqlwork));
                    }
                }
                else
                {
                    if (Request["park"] == "2")
                    {
                        string sqlCourse = "SELECT name FROM pass WHERE passId = '" + Convert.ToInt32(dt.Rows[i]["pas_passId"].ToString()) + "'";
                        str = "<div id = 'contentList'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'>点击次数：{2} 上传时间：{1}&nbsp;&nbsp;科研方向：{4}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>";

                        list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse));
                    }
                    else { str = "<div id = 'contentList' style = 'border-top-color: #99CCFF; border-top-width: 2px;'><table class = 'tableForum' style='width: 728;font-size: 12px;'><tr><td style='font-size: 14px; text-align: center;'>{0}</td></tr><tr><td style=' text-align: center;'> 点击次数：{2}&nbsp;&nbsp; 上传时间：{1}</td></tr><tr><td>&nbsp;{3}</td></tr></table></div>"; list += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["lookTime"].ToString(), dt.Rows[i]["content"].ToString()); }
                }
            }
        }

        if (Request["park"] == "5" || Request["park"] == "8")
        {
            int stept;
            if (DB.hasSession("stept"))
                stept = Convert.ToInt32(Session["stept"]);
            else stept = 1;
            if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()) || DB.hasSession("student"))
            {
               
                Response.Write(list);
                DB.execnonsql(sql2);
            }
            else Response.Write("<font color='red'>抱歉你的会员级别暂时无法阅读此文章若是学生请先登录!<font>");
        }
        else
        {
            int stept;
            if (DB.hasSession("stept"))
                stept = Convert.ToInt32(Session["stept"]);
            else stept = 1;
            if (stept >= Convert.ToInt32(dt.Rows[0]["Typ_steptid"].ToString()))
            {
               
                Response.Write(list);
                DB.execnonsql(sql2);
            }
            else Response.Write("<font color='red'>抱歉你的会员级别暂时无法阅读此文章!<font>");
        }
    }
    //protected void List()
    //{
    //    string sql = "", id = "", id1 = "", sql1 = "";
    //     int pageSize = 3;
    //    int page = 1;
    //    //利用异常机制确保转换string到int类型不会出错
    //    try
    //    {
    //        page = Convert.ToInt32(Request.QueryString["page"]);
    //    }
    //    catch (Exception e1) { }

    //    sql = "select count(*) from NewsList WHERE time !='" + 1 + "'";
    //         StringBuilder sb = new StringBuilder("select top " + pageSize.ToString() + " * from NewsList WHERE time !='"+1+"'");
    //            //如果不是第一页
    //            if (page > 1)
    //            {
    //                sb.Append(" and newsid not in(select top " + (pageSize * (page - 1)).ToString() + " newsid from NewsList WHERE time !='" + 1 + "' order by newsid desc)");
    //            }
    //            sb.Append(" order by newsid desc"); id = "newsid"; sql1 = "SELECT * FROM NewsType ORDER BY newstypeid DESC"; id1 = "newstypeid";
      
    //    int count = Convert.ToInt32(DB.FindString(sql));
    //     System.Data.DataTable dt1= DB.OpenQuery(sql1);
    //     string list1 = "<table style = 'width:570;'><tr>";
    //     string str1 = "<td><a href = 'javascript:List(1,{2},{0});'>{1}</a></td>";
    //     for (int i = 0; i < dt1.Rows.Count; i++)
    //     {
    //         list1 += string.Format(str1, dt1.Rows[i][id1].ToString(), dt1.Rows[i]["name"].ToString(), Request["park"]);

    //     }
    //     list1 += "</tr></table>";
    //     System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
    //     string str = "<tr><td><img src='Images/biao.gif' /></td><td style = 'width:300'><a href=\"javascript:void(Particular({0},{5}));\" title = '标题：{3}|||点击量：{4}'>{1}</a></td><td style = 'width:79'>{2}</td></tr>";
    //     string list = "<div id = 'contentList'> <table style='width: 379px; margin-top: 0px;' bgcolor='#FFFFCC'>";
    //     for (int i = 0; i < dt.Rows.Count; i++)
    //     {
    //         //if (Request["park"] == "6")
    //         //    list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 16 ? dt.Rows[i]["title"].ToString().Substring(0, 16) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString().Substring(0, 9), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clickNum"].ToString(), Request["park"]);
    //         list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 16 ? dt.Rows[i]["title"].ToString().Substring(0, 16) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString().Substring(0, 9), dt.Rows[i]["title"].ToString(), dt.Rows[i]["lookTime"].ToString(), Request["park"]);
    //     }
    //     list += "</table>";
    //     list1 += list;
    //     Response.Write(list1 + "<div id='pager'>" + this.GetPager(page, pageSize, count, Convert.ToInt32(Request["park"])) + "</div></div>");
    //}
    protected void MoreStuWork()
    {
        StringBuilder sb = new StringBuilder("");
        string sql = "", id = "";
        int pageSize = 30;
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }
        switch (Request["park"])
        {

            case "5": sql = "select count(*) from StuUpFIleList WHERE isPro='" + true + "'"; sb.Append("select top " + pageSize.ToString() + " * from StuUpFIleList WHERE isPro ='" + true + "'");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and upId not in(select top " + (pageSize * (page - 1)).ToString() + " upId from StuUpFIleList WHERE isPro ='" + true + "' order by upId desc)");
                }
                sb.Append(" order by upId desc"); id = "upId"; break;
            case "8": sql = "select count(*) from stuWorkList WHERE workNum!=" + 0 + ""; sb.Append("select top " + pageSize.ToString() + " * from stuWorkList WHERE workNum !=" + 0 + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from stuWorkList WHERE workNum !=" + 0 + " order by upWorkId desc)");
                }
                sb.Append(" order by upWorkId desc"); id = "upWorkId"; break;

        }
       
        int count = Convert.ToInt32(DB.FindString(sql));
      
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string str = "<tr><td><img src='Images/biao.gif' /></td><td style = 'width:150'><a href=\"javascript:void(Particular1({0},{5}));\" title = '标题：{3}|||点击量：{4}'>{1}</a></td><td style = 'width:70'>{2}</td></tr>";
        string list = "<table style='width: 200px;font-size: 12px; margin-top: 0px;' >";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //if (Request["park"] == "6")
            //    list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 16 ? dt.Rows[i]["title"].ToString().Substring(0, 16) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString().Substring(0, 9), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clickNum"].ToString(), Request["park"]);
            list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 10 ? dt.Rows[i]["title"].ToString().Substring(0, 10) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), dt.Rows[i]["title"].ToString(), dt.Rows[i]["lookTime"].ToString(), Request["park"]);
        }
        list += "</table>";
        string lis = "<div id = 'to'style='  border-bottom: 1px solid #99CCFF; margin: 0px 0px 0px 0px; width: 220px; height: 27px; font-size: 16px; color: #66CCFF;'><img src='Images/gif-0230.GIF' style='height: 24px; width: 31px;' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 文章列表</div>";
        Response.Write(lis+list + "<div id='pager'>" + this.GetPager2(page, pageSize, count, Convert.ToInt32(Request["park"])) + "</div>");
    }
    public string GetPager2(int page, int pageSize, int count, int park)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 5) * 5 + 1;

        for (int i = start; i <= pageCount && i < start + 5; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:MoreStuFile1(" + i + "," + park + ")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:MoreStuFile1(" + (start - 1).ToString() + "," + park + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:MoreStuFile1(" + (1).ToString() + "," + park + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 5 < pageCount)
        {
            sb.Append("<a href='javascript:MoreStuFile1(" + (start + 5).ToString() + "," + park + ")' title='第" + (start + 5).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:MoreStuFile1(" + pageCount.ToString() + "," + park + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    protected void List2()
    {
        StringBuilder sb = new StringBuilder("");
        string sql = "", id = "";
        int pageSize = 30;
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }
        switch (Request["park"])
        {
            case "0": sql = "select count(*) from NewsList where New_newstypeid =" + Convert.ToInt32(Request["id"]) + ""; sb.Append("select top " + pageSize.ToString() + " * from NewsList where New_newstypeid =" + Convert.ToInt32(Request["id"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and newsid not in(select top " + (pageSize * (page - 1)).ToString() + " newsid from NewsList where New_newstypeid =" + Convert.ToInt32(Request["id"]) + " order by newsid desc)");
                }
                sb.Append(" order by newsid desc"); id = "newsid"; break;
            case "1": sql = "select count(*) from TeachPark where Tea_teachtypeid =" + Convert.ToInt32(Request["id"]) + ""; sb.Append("select top " + pageSize.ToString() + " * from TeachPark where Tea_teachtypeid =" + Convert.ToInt32(Request["id"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and teachParkID not in(select top " + (pageSize * (page - 1)).ToString() + " teachParkID from TeachPark where Tea_teachtypeid =" + Convert.ToInt32(Request["id"]) + " order by teachParkID desc)");
                }
                sb.Append(" order by teachParkID desc"); id = "teachParkID";  break;
            case "2": sql = "select count(*) from ResearchList where res_researchTypeId =" + Convert.ToInt32(Request["id"]) + ""; sb.Append("select top " + pageSize.ToString() + " * from ResearchList where res_researchTypeId =" + Convert.ToInt32(Request["id"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and researchId not in(select top " + (pageSize * (page - 1)).ToString() + " researchId from ResearchList where res_researchTypeId =" + Convert.ToInt32(Request["id"]) + " order by researchId desc)");
                }
                sb.Append(" order by researchId desc"); id = "researchId";  break;

            case "4": sql = "select count(*) from SubjectList where Sub_subTypeID =" + Convert.ToInt32(Request["id"]) + ""; sb.Append("select top " + pageSize.ToString() + " * from SubjectList where Sub_subTypeID =" + Convert.ToInt32(Request["id"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and subjectID not in(select top " + (pageSize * (page - 1)).ToString() + " subjectID from SubjectList where Sub_subTypeID =" + Convert.ToInt32(Request["id"]) + " order by subjectID desc)");
                }
                sb.Append(" order by subjectID desc"); id = "subjectID"; break;

            case "3": sql = "select count(*) from ResourcesList where Res_resourcestypeid =" + Convert.ToInt32(Request["id"]) + ""; sb.Append("select top " + pageSize.ToString() + " * from ResourcesList where Res_resourcestypeid =" + Convert.ToInt32(Request["id"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and resourcesID not in(select top " + (pageSize * (page - 1)).ToString() + " resourcesID from ResourcesList where Res_resourcestypeid =" + Convert.ToInt32(Request["id"]) + " order by resourcesID desc)");
                }
                sb.Append(" order by resourcesID desc"); id = "resourcesID";  break;
            case "6": sql = "select count(*) from TeacherUpFileWorkList where Tea_teachUpTypeID =" + Convert.ToInt32(Request["id"]) + ""; sb.Append("select top " + pageSize.ToString() + " * from TeacherUpFileWorkList where Tea_teachUpTypeID =" + Convert.ToInt32(Request["id"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and TeacherUpWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " TeacherUpWorkID from TeacherUpFileWorkList where Tea_teachUpTypeID =" + Convert.ToInt32(Request["id"]) + " order by TeacherUpWorkID desc)");
                }
                sb.Append(" order by TeacherUpWorkID desc"); id = "TeacherUpWorkID"; break;


        }
       
        int count = Convert.ToInt32(DB.FindString(sql));
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string str = "<tr><td style = 'width:10'><img src='Images/biao.gif' /></td><td style = 'width:150'><a href=\"javascript:void(Particular1({0},{5}));\" title = '标题：{3}|||点击量：{4}'>{1}</a></td><td style = 'width:70'>{2}</td></tr>";
        string list = "<table style='width: 220px;font-size: 12px; margin-top: 0px;'>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //if (Request["park"] == "6")
            //    list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 16 ? dt.Rows[i]["title"].ToString().Substring(0, 16) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString().Substring(0, 9), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clickNum"].ToString(), Request["park"]);
            list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 10 ? dt.Rows[i]["title"].ToString().Substring(0, 10) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), dt.Rows[i]["title"].ToString(), dt.Rows[i]["lookTime"].ToString(), Request["park"]);
        }
        list += "</table>";
        string lis = "<div id = 'to'style='  border-bottom: 1px solid #99CCFF; margin: 0px 0px 0px 0px; width: 220px; height: 27px; font-size: 16px; color: #66CCFF;'><img src='Images/gif-0230.GIF' style='height: 24px; width: 31px;' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 文章列表</div>";
        Response.Write(lis+list + "<div id='pager'>" + this.GetPager1(page, pageSize, count, Convert.ToInt32(Request["park"]), Convert.ToInt32(Request["id"])) + "</div>");
    }
    public string GetPager1(int page, int pageSize, int count, int park,int id)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 5) * 5 + 1;

        for (int i = start; i <= pageCount && i < start + 5; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:List2(" + i + "," + park + ","+id+")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:List2(" + (start - 1).ToString() + "," + park + "," + id + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:List2(" + (1).ToString() + "," + park + "," + id + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 5 < pageCount)
        {
            sb.Append("<a href='javascript:List2(" + (start + 5).ToString() + "," + park + "," + id + ")' title='第" + (start + 5).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:List2(" + pageCount.ToString() + "," + park + "," + id + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    protected void List()
    {
        StringBuilder sb = new StringBuilder("");
        string sql = "", id = "", id1 = "", sql1 = "";
        int pageSize = 30;
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }
        switch (Request["park"])
        {
            case "0": sql = "select count(*) from NewsList WHERE Typ_steptid !=" + 0 + ""; sb.Append("select top " + pageSize.ToString() + " * from NewsList WHERE Typ_steptid !=" + 0 + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and newsid not in(select top " + (pageSize * (page - 1)).ToString() + " newsid from NewsList WHERE Typ_steptid !=" + 0 + " order by newsid desc)");
                }
                sb.Append(" order by newsid desc"); id = "newsid"; sql1 = "SELECT * FROM NewsType ORDER BY newstypeid DESC"; id1 = "newstypeid"; break;
            case "1": sql = "select count(*) from TeachPark WHERE Typ_steptid !=" + 0 + " "; sb.Append("select top " + pageSize.ToString() + " * from TeachPark WHERE Typ_steptid !=" + 0 + " ");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and teachParkID not in(select top " + (pageSize * (page - 1)).ToString() + " teachParkID from TeachPark WHERE Typ_steptid !=" + 0 + " order by teachParkID desc)");
                }
                sb.Append(" order by teachParkID desc"); id = "teachParkID"; sql1 = "SELECT * FROM TeachParkType ORDER BY teachtypeid"; id1 = "teachtypeid"; break;
            case "2": sql = "select count(*) from ResearchList WHERE Typ_steptid !=" + 0 + " "; sb.Append("select top " + pageSize.ToString() + " * from ResearchList WHERE Typ_steptid !=" + 0 + " ");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and researchId not in(select top " + (pageSize * (page - 1)).ToString() + " researchId from ResearchList WHERE Typ_steptid !=" + 0 + " order by researchId desc)");
                }
                sb.Append(" order by researchId desc"); id = "researchId"; sql1 = "SELECT * FROM RescourcesType ORDER BY resourcestypeid"; id1 = "resourcestypeid"; break;

            case "4": sql = "select count(*) from SubjectList WHERE Typ_steptid !=" + 0 + " "; sb.Append("select top " + pageSize.ToString() + " * from SubjectList WHERE Typ_steptid !=" + 0 + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and subjectID not in(select top " + (pageSize * (page - 1)).ToString() + " subjectID from SubjectList WHERE WHERE Typ_steptid !=" + 0 + " order by subjectID desc)");
                }
                sb.Append(" order by subjectID desc"); id = "subjectID"; sql1 = "SELECT * FROM SubjectType ORDER BY subTypeID"; id1 = "subTypeID"; break;

            case "3": sql = "select count(*) from ResourcesList WHERE Typ_steptid !=" + 0 + ""; sb.Append("select top " + pageSize.ToString() + " * from ResourcesList WHERE Typ_steptid !=" + 0 + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and resourcesID not in(select top " + (pageSize * (page - 1)).ToString() + " resourcesID from ResourcesList WHERE Typ_steptid !=" + 0 + " order by resourcesID desc)");
                }
                sb.Append(" order by resourcesID desc"); id = "resourcesID"; sql1 = "SELECT * FROM RescourcesType ORDER BY resourcestypeid"; id1 = "resourcestypeid"; break;
            case "6": sql = "select count(*) from TeacherUpFileWorkList WHERE Typ_steptid !=" + 0 + ""; sb.Append("select top " + pageSize.ToString() + " * from TeacherUpFileWorkList WHERE Typ_steptid !=" + 0 + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and TeacherUpWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " TeacherUpWorkID from TeacherUpFileWorkList WHERE Typ_steptid !=" + 0 + " order by TeacherUpWorkID desc)");
                }
                sb.Append(" order by TeacherUpWorkID desc"); id = "TeacherUpWorkID"; sql1 = "SELECT * FROM TeacherUpType ORDER BY teachUpTypeID"; id1 = "teachUpTypeID"; break;
          

        }
        //System.Data.DataTable dt1 = new DataTable("");
        int count = Convert.ToInt32(DB.FindString(sql));
        //if (Request["park"] != "3" && Request["park"] != "6" && Request["park"] != "8")
        //dt1 = DB.OpenQuery(sql1);
        //string list1 = "<table style = 'width:628;font-size: 14px;'><tr><td>";
        //string str1 = "<a href = 'javascript:List2(1,{2},{0});'>{1}</a>||";
        //for (int i = 0; i < dt1.Rows.Count; i++)
        //{
        //    //if (Request["park"] != "6" && Request["park"] != "3" && Request["park"] != "8")
        //    list1 += string.Format(str1, dt1.Rows[i][id1].ToString(), dt1.Rows[i]["name"].ToString(), Request["park"]);

        //}
        //list1 += "</td></tr></table>";
        //if (Request["park"] == "6" || Request["park"] == "3" || Request["park"] == "8")
        //{
        //    list1 = "";
        //}
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string str = "<tr><td style = 'width:10'><img src='Images/biao.gif' /></td><td style = 'width:150'><a href=\"javascript:void(Particular1({0},{5}));\" title = '标题：{3}|||点击量：{4}'>{1}</a></td><td style = 'width:70'>{2}</td></tr>";
        string list = "<table style='width: 220px;font-size: 12px; margin-top: 0px;'>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //if (Request["park"] == "6")
            //    list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 16 ? dt.Rows[i]["title"].ToString().Substring(0, 16) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString().Substring(0, 9), dt.Rows[i]["title"].ToString(), dt.Rows[i]["clickNum"].ToString(), Request["park"]);
            list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["title"].ToString().Length > 10 ? dt.Rows[i]["title"].ToString().Substring(0, 10) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), dt.Rows[i]["title"].ToString(), dt.Rows[i]["lookTime"].ToString(), Request["park"]);
        }
        list += "</table>";
        string lis = "<div id = 'to'style='  border-bottom: 1px solid #99CCFF; margin: 0px 0px 0px 0px; width: 220px; height: 27px; font-size: 16px; color: #66CCFF;'><img src='Images/gif-0230.GIF' style='height: 24px; width: 31px;' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 文章列表</div>";
        Response.Write(lis+list + "<div id='pager'>" + this.GetPager(page, pageSize, count, Convert.ToInt32(Request["park"])) + "</div>");
    }
    public string GetPager(int page, int pageSize, int count, int park)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 5) * 5 + 1;

        for (int i = start; i <= pageCount && i < start + 5; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:List1(" + i + "," + park + ")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:List1(" + (start - 1).ToString() + "," + park + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:List1(" + (1).ToString() + "," + park + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 5 < pageCount)
        {
            sb.Append("<a href='javascript:List1(" + (start + 5).ToString() + "," + park + ")' title='第" + (start + 5).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:List1(" + pageCount.ToString() + "," + park + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    protected void GetDropdownList()//信息下拉
    {
        System.Data.DataTable dt;
        string str = "<option value='{0}'>{1}</option>";
        string check1 = "课程&方向：<select id='select3'runat='server'onchange = 'javascript:GetCourse();'><option value=''>请选择</option>";
           
              
                 dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
       
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               
                   check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString()); 
           

            }
            check1 += " </select>";
            Response.Write(check1);
      
    }
   
}
