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
public partial class Admin_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //0:登录.1：系统设置。2：管理首页3添加信息4:填充check2;5:提交信息.6:权限选择7:显示管理员列表8:修改管理员9：10：提交管理员11，12,13：新闻列表
        switch (Request["type"])
        {
            case "0": Login(); break;
            //case "1": MM(); break;
            //case "1": LoadAscx("../ASCX/Set"); break;
            case "1": LoadAscx("../ASCX/class"); break;
            case "2": LoadAscx("../ASCX/adminIndex"); break;
            case "3": LoadAscx("../ASCX/Add"); break;
            case "4": FillSelect(Request["value"]); break;
            case "5": Add(); break;
            case "6": GetStept(); break;
            case "7": MList(); break;
            case "8": LoadAscx("../ASCX/Manager"); break;
            case "9": edit(); break;
            case "10": submit(); break;
            case "11": LoadAscx("../ASCX/newsask"); break;
            case "12": newsList(); break;
            case "13": newsList1(); break;
            case "14": ClassList(); break;
            case "15": EditClassList(); break;
            case "16": SubmitClass(); break;
            case "17": DelClassList(); break;
            case "18": AddClass(); break;
            case "19": SubmitAddClass(); break;
            //case "14": LoadAscx("../ASCX/EditNews"); break;
            //case "15": AddNews(); break;
            //case "16": eNews(); break;
            //case "17": DelNews(); break;
            //case "18": newsTypeList(); break;
            //case "19": LoadAscx("../ASCX/EditNewsType"); break;
            //case "20": SubmitNewsType(); break;
            //case "21": DelNewsType(); break;
            case "22": LoadAscx("../ASCX/teacher"); break;
            case "23": GetTeachList(); break;
            case "24": GetTeachList1(); break;
            //case "25": DelTeachPark(); break;
            //case "26": GetTeachDropdownList(); break;
            case "27": GetTypeList(); break;
            case "28": LoadAscx("../ASCX/EditType"); break;
            case "29": SubmitType(); break;
            case "30": DelType(); break;
            case "31": LoadAscx("../ASCX/course"); break;
            case "32": CourseList(); break;
            case "33": EditCourseList(); break;
            case "34": SubmitCourse(); break;
            case "35": DelCourseList(); break;
            case "36": AddCourse(); break;
            case "37": SubmitAddCourse(); break;
            case "38": AddType(); break;
            case "39": SubmitAddType(); break;
            //case "40": AddNewsType(); break;
            //case "41": SubmitAddNewsType(); break;
            case "42": LoadAscx("../ASCX/research"); break;
            case "43": ResearchList(); break;
            case "44": ResearchList1(); break;
            case "45": GetDropdownList(); break;
            case "46": Del(); break;
            //case "47": GetTypeList(); break;
            case "48": LoadAscx("../ASCX/resources"); break;
            case "49": ResourcesList(); break;
            case "50": ResourcesList1(); break;
            case "51": LoadAscx("../ASCX/subject"); break;
            case "52": Subject(); break;
            case "53": Subject1(); break;
            case "54": LoadAscx("../ASCX/stuWork"); break;
            case "55": Student(); break;
            case "56": Student1(); break;
            case "57": LoadAscx("../ASCX/EditStudent"); break;
            case "58": submitstudent(); break;
            case "59": LoadAscx("../ASCX/addStudent"); break;
            case "60": submitaddstudent(); break;
            case "61": WorkList(); break;
            case "62": WorkList1(); break;
            case "63": StuUpFileList(); break;
            case "64": StuUpFileList1(); break;
            case "65": GetDropdownList67(); break;
            case "66": CompleteWorkList(); break;
            case "67": CompleteWorkList1(); break;
            case "68": SearchStudent(); break;
            case "69": LoadAscx("../ASCX/netUser"); break;
            case "70": NetUser(); break;
            case "71": NetUser1(); break;
            case "72": LoadAscx("../ASCX/EditNetUser"); break;
            case "73": submitNetUser(); break;
            case "74": LoadAscx("../ASCX/forumQuestion"); break;
            case "75": forumQuestion(); break;
            case "76": forumQuestion1(); break;
            case "77": ShowAnswer(); break;
            case "78": ShowSet(); break;
            case "79": UpdateSet(); break;
            case "80": SearchStudent1(); break;
            //case "81": DelNum(); break;
            //case "82": WorkNum(); break;
            //case "83": WorkNum1(); break;
            case "84": GetCourse(); break;
            //case "85": over(); break;
            //case "86": LoadAscx("../ASCX/EditNum"); break;
            //case "87": SubmitNum(); break;
            case "88": Session.Remove("admin"); break;
            case "89": SubmitEditNetuser(); break;
            case "90": newWorkList(); break;
            case "91": newWorkList1(); break;
            case "92": GetCouClass(); break;
            case "93": GetDropdownListWork(); break;
            case "94": LoadAscx("../ASCX/editCompleteWork"); break;
            case "95": GetWorkStept(); break;
            case "96": SubmitEditWork(); break;
            case "97": NoReCompleteWorkList1(); break;
            case "98": SearchNoWorkStu(); break;
            case "99": GetClass(); break;
            case "100": GetStuUpWorkNum(); break;
            case "101": GetStuUpWorkNum1(); break;
            case "102": GetStuCord(); break;
        }
       
    }
    protected void GetStuUpWorkNum()
    {
        string table = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>";
        string check1 = "课程：<select id='courseSelect1'>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;";
        string check2 = "班级：<select id='classSelect1'>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM class ORDER BY classId DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["classId"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>&nbsp;&nbsp";
        check1 += check2;
        check1 += "<input type='button' value='查询' onclick='javascript:GetPageStuUpWorknum(1,101)'/><input id='workNum' style ='display :none' type='text' /><input id='title' style ='display :none' type='text' />";
        table += check1;
        table += "</td></tr></table>";
        Response.Write(table);
    }
    protected void GetStuUpWorkNum1()
    {
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }
        string sql = "select count(*) from studentlist where sclass = "+Convert.ToInt32(Request["classid"])+"";
        int count = Convert.ToInt32(DB.FindString(sql));
        //实现自定义的分页逻辑
        StringBuilder sb = new StringBuilder("select top " + pageSize.ToString() + " * from studentlist where sclass = " + Convert.ToInt32(Request["classid"]) + "");
        //如果不是第一页
        if (page > 1)
        {
            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where sclass = " + Convert.ToInt32(Request["classid"]) + " order by classNum)");
        }
        sb.Append(" order by classNum");

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>编号</td><td>班级序号</td><td>姓名</td><td>班级</td><td>学号</td><td>课程</td><td>作业次数</td></tr>";

        string str = "<tr><td>{0}</td><td>{6}</td><td>{2}</td><td>{4}</td><td>{5}</td><td>{7}</td><td>{8}</td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
             string sqlCourse = "SELECT name FROM CourseList WHERE courseid = " + Convert.ToInt32(Request["courseid"]) + "";
            string sql4 = "select count(*) from CompleteWork where Cou_courseid = " + Convert.ToInt32(Request["courseid"]) + " and stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"].ToString()) + "";
            int count1 = Convert.ToInt32(DB.FindString(sql4));
            string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"].ToString()) + "";
            list += string.Format(str, dt.Rows[i]["studentID"].ToString(), dt.Rows[i]["name"].ToString(), dt.Rows[i]["nickname"].ToString(), dt.Rows[i]["password"].ToString(), DB.FindString(sql3), dt.Rows[i]["studyNum"].ToString(), dt.Rows[i]["classNum"].ToString(),DB.FindString(sqlCourse),count1);
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager' style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'>" + this.GetPageStuUpWorknum(page, pageSize, count, 101) + "</div><div id = 'List2'></div>");
    }
    protected void SubmitEditWork()
    {
        string sql = "";
        if (Server.UrlDecode(Request["remarkTime"]).ToString()=="")
            sql = "UPDATE CompleteWork SET cord = N'" + Server.UrlDecode(Request["cord"]) + "',remarkTime = '" + DateTime.Now + "',isRemark = " + 1 + ",Typ_steptid = " + Convert.ToInt32(Request["stept"]) + " WHERE completWorkID=" + Convert.ToInt32(Request["id"]) + "";
        else
            sql = "UPDATE CompleteWork SET cord = N'" + Server.UrlDecode(Request["cord"]) + "',Typ_steptid = " + Convert.ToInt32(Request["stept"]) + " WHERE completWorkID=" + Convert.ToInt32(Request["id"]) + "";
        try
        {
            DB.execnonsql(sql);
            Response.Write("<font color='red'>编辑成功!<font>");
        }
        catch {  }
    }
    protected void newWorkList()
    {
        string search = "<table style='border-left: 2px solid #99CCFF; border-right: 2px solid #99CCFF; border-top: 0px solid #99CCFF; border-bottom: 1px solid #99CCFF; background-image: url(&#039;../Images/背景.jpg&#039;); margin-top: 0px; width: 840px'><tr><td><div style='width: 250px; font-size: 12px; float: left;'>标题关键字：<input type='text' id='title' name='title'/></div><div id = 'divCourse' style='width: 220px; float: left;'>";
        string check1 = "课程：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>";
        search += check1;
        search += "</div>	<input type='button' value='查询' onclick='javascript:GetPageNewWork(1,91)'/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type='button' value='添加新作业' onclick='javascript:AddNewWorkOpenWin()'/> <input id='workNum' style ='display :none' type='text' /><select id='select4' style ='display :none'><option value=''>请选择</option> </select> </td></tr></table>";
        Response.Write(search);

    }
    protected void newWorkList1()   //
    {
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 15;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        int count;
        StringBuilder sb = new StringBuilder("");
        if (Request["courseId"]!=null)
        {
            if (Request["courseId"] == "")
            {
             
                    string sql = "select count(*) from stuWorkList where title like N'%" + key + "%'";
                  count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from stuWorkList where title like N'%" + key + "%'");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and upWorkId not in(select top " + (pageSize * (page - 1)).ToString() + " upWorkId from stuWorkList where title like N'%" + key + "%' order by upWorkId desc)");
                    }
                    sb.Append(" order by upWorkId desc");

              }
              
        
            else 
            {
                    string sql = "select count(*) from stuWorkList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from stuWorkList where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and upWorkId not in(select top " + (pageSize * (page - 1)).ToString() + " upWorkId from stuWorkList where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " order by upWorkId desc)");
                    }
                    sb.Append(" order by upWorkId desc");
              }
               
            }
        else
        {
            string sql = "select count(*) from stuWorkList where title like N'%" + key + "%'";
        count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
            sb.Append("select top " + pageSize.ToString() + " * from stuWorkList where title like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and upWorkId not in(select top " + (pageSize * (page - 1)).ToString() + " upWorkId from stuWorkList where title like N'%" + key + "%' order by upWorkId desc)");
            }
            sb.Append(" order by upWorkId desc");
        }
       

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属次数</td><td>标题</td><td>上传时间</td><td>权限</td><td>课程名称</td><td>上传期限</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{8}年{6}月{7}日</td><td><a href = \"javascript:editNewWorkOpenWin({0},'{2}','{4}','{5}',{8},{6},{7});\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(DelNewWork({0},10,91));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            //string sqlnewtypecontent = "SELECT name FROM TeacherUpType WHERE teachUpTypeID = '" + dt.Rows[i]["Tea_teachUpTypeID"].ToString() + "'";
            string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["upWorkId"].ToString(), dt.Rows[i]["workNum"].ToString(), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent), DB.FindString(sqlCourse), dt.Rows[i]["lastUpMonth"].ToString(), dt.Rows[i]["lastUpDay"].ToString(),dt.Rows[i]["lastUpYear"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager' style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836'><input type='button' value='删除选中项' onclick='javascript:DelNewWorkSelect(10,91)'/>" + this.GetPageNewWork(page, pageSize, count, 91) + "</div>" + "<div id = 'List2'></div>");
    }
    public string GetPageStuUpWorknum(int page, int pageSize, int count, int type)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 10) * 10 + 1;

        for (int i = start; i <= pageCount && i < start + 10; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:GetPageStuUpWorknum(" + i + "," + type + ")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:GetPageStuUpWorknum(" + (start - 1).ToString() + "," + type + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:GetPageStuUpWorknum(" + (1).ToString() + "," + type + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 10 < pageCount)
        {
            sb.Append("<a href='javascript:GetPageStuUpWorknum(" + (start + 10).ToString() + "," + type + ")' title='第" + (start + 10).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:GetPageStuUpWorknum(" + pageCount.ToString() + "," + type + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    public string GetPageNewWork(int page, int pageSize, int count, int type)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 10) * 10 + 1;

        for (int i = start; i <= pageCount && i < start + 10; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:GetPageNewWork(" + i + "," + type + ")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:GetPageNewWork(" + (start - 1).ToString() + "," + type + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:GetPageNewWork(" + (1).ToString() + "," + type + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 10 < pageCount)
        {
            sb.Append("<a href='javascript:GetPageNewWork(" + (start + 10).ToString() + "," + type + ")' title='第" + (start + 10).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:GetPageNewWork(" + pageCount.ToString() + "," + type + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    protected void SubmitEditNetuser()
    {
        string sql = "UPDATE NetUser SET Typ_steptid = " + Convert.ToInt32(Request["steptid"]) + " WHERE userid=" + Convert.ToInt32(Request["id"]) + "";


        DB.execnonsql(sql);
        Response.Write("<font color='red'>编辑成功!<font>");
    }
    //protected void SubmitNum()
    //{
    //    string sql = "UPDATE workNumId SET num = " + Convert.ToInt32(Request["num"]) + " WHERE workNumId=" + Convert.ToInt32(Request["id"]) + "";


    //    DB.execnonsql(sql);
    //    Response.Write("<font color='red'>编辑成功!<font>");
    //}
    protected void UpdateSet()
    {
        string sql = "UPDATE WebSiteSet SET webSiteName = N'" + Server.UrlDecode(Request["webSiteName"]) + "',email = N'" + Server.UrlDecode(Request["email"]) + "',webUrl = N'" + Server.UrlDecode(Request["webUrl"]) + "',address = N'" + Server.UrlDecode(Request["address"]) + "',phone = N'" + Request["phone"] + "',sjPhone = N'" + Request["sjPhone"] + "',youbian = N'" + Request["youbian"] + "',adr = N'" + Server.UrlDecode(Request["adr"]) + "',zhanzhang = N'" + Server.UrlDecode(Request["zhanzhang"]) + "',qq = N'" + Server.UrlDecode(Request["qq"]) + "',banquan = N'" + Server.UrlDecode(Request["banquan"]) + "',islockForum = '" + Convert.ToBoolean(Request["islockForum"]) + "'";


        DB.execnonsql(sql);
        Response.Write("<font color='red'>编辑成功!<font>");
    }
    //protected void over()
    //{
    //    string sql = "UPDATE workNumId SET num = "+0+"";


    //    DB.execnonsql(sql);
    //    Response.Write("<font color='red'>成功!<font>");
    //}
    protected void ShowSet()
    {
        string list = "";
        string str = "<input id='title' style ='display :none' type='text' /><div id = 'set'><div id ='head' style=\"background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid solid none solid; border-width: 2px 2px 0px 2px; border-color: #99CCFF #99CCFF #FFFFFF #99CCFF; width: 836px; font-size: 24px; color: #00CCFF; text-align: center;\">系统设置</div><table width='840' border='0' style='border: 2px solid #99CCFF; font-size: 12px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);'><tr><td>设置名称</td><td><span class='B'>基本参数设置</span></td><td><span class='B'>设置说明</span></td></tr><tr><td>网站名称：</td><td><input id='Text1' value = '{0}' type='text' /></td><td>用于显示在页面标题的信息</td></tr><tr><td>网址：</td><td><input id='webUrl' value = '{11}' type='text' /></td><td>网站地址，加入收藏和设为首页</td></tr><tr><td>电子邮件：</td><td><input id='Text2'value = '{1}' type='text' /></td><td><span class='B'>电子邮件</span></td></tr><tr><td>联系地址：</td><td><input id='Text3' value = '{2}'type='text' /></td><td>联系地址：</td></tr><tr><td>联系电话：</td><td><input id='Text4'value = '{3}' type='text' /></td><td>联系电话：</td></tr><tr><td>手机号码：</td><td><input id='Text5' value = '{4}'type='text' /></td><td>手机号码：</td></tr><tr><td>邮政编码：</td><td><input id='Text6' value = '{5}'type='text' /></td><td>邮政编码：</td></tr><tr><td>版权：</td><td><input id='Text9'value = '{9}' type='text' /></td><td><span class='B'>网站版权所有</span></td></tr><tr><td>站长：</td><td><input id='Text8'value = '{8}' type='text' /></td><td><span class='B'>网站管理员</span></td></tr><tr><td>QQ：</td><td><input id='Text10'value = '{7}' type='text' /></td><td><span class='B'>qq</span></td></tr><tr><td>论坛开关：</td><td>{6}<input id='Checkbox1' type='checkbox' /></td><td>论坛开关：</td></tr><tr><td>网站公告信息：</td><td><textarea id='Text7'style='height: 102px; width: 264px'>{10}</textarea></td><td>网站公告信息</td></tr><tr><td> &nbsp;</td><td><img src = '../images/submit.gif' onclick = 'javascript:submitSet()' /></td><td>&nbsp;<div id = 'setcall'></div></td></tr></table></div>";
        string sql = "SELECT * FROM WebSiteSet ORDER BY siteId DESC";
        System.Data.DataTable dt = DB.OpenQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i]["webSiteName"].ToString(), dt.Rows[i]["email"].ToString(), dt.Rows[i]["address"].ToString(), dt.Rows[i]["phone"].ToString(), dt.Rows[i]["sjPhone"].ToString(), dt.Rows[i]["youbian"].ToString(), dt.Rows[i]["islockForum"].ToString(), dt.Rows[i]["qq"].ToString(), dt.Rows[i]["zhanzhang"].ToString(), dt.Rows[i]["banquan"].ToString(), dt.Rows[i]["adr"].ToString(), dt.Rows[i]["webUrl"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        Response.Write(list);
    }
    //protected void MM()
    //{

    //    string table = " <table bgcolor='#3399FF'>";
    //    table += " <tr><td class='style4'>标题</td><td class='style2'>姓名</td></tr>";
    //    string str = " <tr><td class='style4'>{0}</td><td class='style2'>{1}</td></tr>";
    //    System.Data.DataTable dt = DB.OpenQuery("SELECT title,content FROM NewsList WHERE newsid = "+33+"");
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        table += string.Format(str, dt.Rows[i]["title"].ToString(), dt.Rows[i]["content"].ToString());
    //    }
    //    table += "</table>";
    //    Response.Write(table);
    //}
    protected void Login()
    {
       
        //加密
        string userName = PageValidate.GetSafeStr(Request["name"]);
        string userPass = PageValidate.GetSafeStr(Request["pass"]);
        string num = PageValidate.GetSafeStr(Request["num"]);
        string pass = MD5.Hash(userPass);
        //验证验证码用户名密码
        string sql = "SELECT spassword FROM Admin WHERE name=N'" + userName + "'";//构成sql语句
        if (num.CompareTo(Session["Vnumber"].ToString()) == 0)
        {
            if (DB.FindString(sql) == pass)
            {
                //LoadAscx("../ASCX/index");
                //Response.Write("<a href='1.htm'>入口</a>");
                Response.Write("0");
                Session["admin"] = "管理员！";
            }
            else Response.Write("1"); //用户名密码不正确
        }
        else Response.Write("2"); //验证码不正确
      
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
    //根据园地选择类别。
    //0:
    //protected void eNews()
    //{
    //    System.Data.DataTable dt;
    //    string sql = "";
    //    string id = "", content = "";
    //    string str = "<option value='{0}'>{1}</option>";
    //    sql = "SELECT * FROM NewsType ORDER BY newstypeid DESC";

    //    id = "newstypeid"; content = "content";
    //    string check = "选择类别：<select id='select2'onchange = 'javascript:GetType();'>";
    //    dt = DB.OpenQuery(sql);
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        check += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i][content].ToString());
    //    }
    //    check += " </select>";
    //    Response.Write(check);
    //}
    //protected void GetTeachDropdownList()//教师信息下拉
    //{
    //    System.Data.DataTable dt;
    //    string sql = "";
    //    string id = "", content = "";
    //    string str = "<option value='{0}'>{1}</option>";
    //    sql = "SELECT * FROM TeachParkType ORDER BY teachtypeid DESC";

    //    id = "teachtypeid"; content = "name";
    //    string check = "选择类别：<select id='select2'onchange = 'javascript:GetType();'>";
    //    dt = DB.OpenQuery(sql);
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        check += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i][content].ToString());
    //    }
    //    check += " </select>";
    //    Response.Write(check);
    //    string check1 = "课程&方向：<select id='select3'runat='server'onchange = 'javascript:GetCourse();'>";
    //    dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
    //    }
    //    check1 += " </select>";
    //    Response.Write(check1);
    //}
    protected void GetDropdownList()//信息下拉
    {
        System.Data.DataTable dt;
        string sql = "";
        string id = "", content = "";
        string str = "<option value='{0}'>{1}</option>";
        switch (Request.QueryString["park"])
        {
            case "0": sql = "SELECT * FROM NewsType ORDER BY newstypeid DESC"; id = "newstypeid"; content = "name"; break;
            case "1": sql = "SELECT * FROM TeachParkType ORDER BY teachtypeid DESC"; id = "teachtypeid"; content = "name"; break;
            case "2": sql = "SELECT * FROM researchType ORDER BY researchTypeId DESC"; id = "researchTypeId"; content = "name"; break;
            case "4": sql = "SELECT * FROM RescourcesType ORDER BY resourcestypeid DESC"; id = "resourcestypeid"; content = "name"; break;
            case "5": sql = "SELECT * FROM SubjectType ORDER BY subTypeID DESC"; id = "subTypeID"; content = "name"; break;
            case "3": sql = "SELECT * FROM TeacherUpType ORDER BY teachUpTypeID DESC"; id = "teachUpTypeID"; content = "name"; break;
           
        }
        string check = "选择类别：<select id='select2'onchange = 'javascript:GetType();'><option value=''>请选择</option>";
        dt = DB.OpenQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i][content].ToString());
        }
        check += " </select>";
        Response.Write(check);
        if (Request.QueryString["park"] == "0" || Request.QueryString["park"] == "4" || Request.QueryString["park"] == "5")
        {

        }
        else
        {
            string check1 = "课程&方向：<select id='select3'runat='server'onchange = 'javascript:GetCourse();'><option value=''>请选择</option>";
            switch (Request.QueryString["park"])
            {
                case "1": dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");  break;
                case "2": dt = DB.OpenQuery("SELECT * FROM pass ORDER BY passId DESC"); break;
                case "3": dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC"); break;
                case "6": dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");  break;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (Request.QueryString["park"])
                {
                    case "1":  check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString()); break;
                    case "2": check1 += string.Format(str, dt.Rows[i]["passId"].ToString(), dt.Rows[i]["name"].ToString()); break;
                    case "6":  check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString()); break;
                    case "3": check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString()); break;
                }

            }
            check1 += " </select>";
            Response.Write(check1);
        }
    }
    protected void GetDropdownList67()//信息下拉
    {
        System.Data.DataTable dt;
        string str = "<option value='{0}'>{1}</option>";
        string check1 = "课程：<select id='select3'runat='server'onchange = 'javascript:GetCourse();'><option value=''>请选择</option>";
       
        
            
            dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
      
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            
            
               
             check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString()); 
            

        }
        check1 += " </select>";
        Response.Write(check1);
    }
    protected void GetDropdownListWork()//信息下拉
    {
        System.Data.DataTable dt;
        string str = "<option value='{0}'>{1}</option>";
        string check1 = "课程：<select id='select3'runat='server'onchange = 'javascript:GetNewWorkCourse();'><option value=''>请选择</option>";



        dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");

        for (int i = 0; i < dt.Rows.Count; i++)
        {



            check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());


        }
        check1 += " </select>";
        Response.Write(check1);
    }
    protected void GetCourse()
    {
        string check1 = "课程&方向：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>";
        Response.Write(check1);
    }
    protected void GetClass()
    {
       
        string check2 = "<select id='classSelect'><option value=''>请选择</option>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM class ORDER BY classId DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["classId"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>";
      
        Response.Write(check2);
    }
    protected void GetCouClass()
    {
        string check1 = "课程：<select id='courseSelect'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;";
        string check2 = "班级：<select id='classSelect'><option value=''>请选择</option>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM class ORDER BY classId DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["classId"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>";
        check1 += check2;
        Response.Write(check1);
    }
    protected void FillSelect(string value)
    {
        System.Data.DataTable dt;
        string sql = "";
        string id = "", content = "";
        string str = "<option value='{0}'>{1}</option>";
        switch (value)
        {
            case "0":
               
                sql = "SELECT * FROM NewsType ORDER BY newstypeid DESC";
               
                id = "newstypeid"; content = "name";
                break;
            case "1":
              sql = "SELECT * FROM TeachParkType ORDER BY teachtypeid DESC";
              
                id = "teachtypeid"; content = "name";
                break;
            case "2":
               sql = "SELECT * FROM researchType ORDER BY researchTypeId DESC";
                
                id = "researchTypeId"; content = "name";
                break;
            case "3":
               sql = "SELECT * FROM TeacherUPType ORDER BY teachUpTypeID DESC";
               
                id = "teachUpTypeID"; content = "name";
                break;
            case "4":
                sql = "SELECT * FROM RescourcesType ORDER BY resourcestypeid DESC";

                id = "resourcestypeid"; content = "name";
                break;
            case "5":
                sql = "SELECT * FROM SubjectType ORDER BY subTypeID DESC";

                id = "subTypeID"; content = "name";
                break;
        }
        string check = "选择类别：<select id='select2'runat='server' onchange = 'javascript:GetType();'><option value=''>请选择</option>";
         dt = DB.OpenQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i][content].ToString());
        }
        check += " </select>";
        Response.Write(check);
        string check1 = "课程&方向：<select id='select3'onchange = 'javascript:GetCourse1();'><option value=''>请选择</option>";
         
          switch (value)
          {
              case "1" :
                   dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
                  }
                  check1 += " </select>";
                  Response.Write(check1); break;
              case  "3":
                  dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
                  }
                  check1 += " </select>";
                  Response.Write(check1); break;
              case "2":
                  dt = DB.OpenQuery("SELECT * FROM pass ORDER BY passId DESC");
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      check1 += string.Format(str, dt.Rows[i]["passId"].ToString(), dt.Rows[i]["name"].ToString());
                  }
                  check += " </select>";
                  Response.Write(check1); break;
              default:
                  Response.Write(""); break;
          }


        //Array a = new Array();
        //a[0] = 1; a[1] = 3;
        //Response.Write("sdasd");
        //string[] a = new string[dt.Rows.Count];
        //string[] a = { "1" };
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
            //a[i] = dt.Rows[i]["newstypeid"].ToString();
        //int Row = Convert.ToInt32(row);
        //string a;
        //    a = dt.Rows[Row]["content"].ToString();
        //    Response.Write(a);
        //}  

    }
   
    //protected void Row()
    //{
    //    System.Data.DataTable dt = DB.OpenQuery("SELECT * FROM NewsType ORDER BY newstypeid DESC");
    //    int a = dt.Rows.Count;
    //    string[] b = new string[a];
    //    for (int i = 0; i < a; i++)
    //    {
    //        b[i] = "0";
    //        Response.Write(b[i]);
    //    }
        
    //}
    protected void SubmitAddClass()
    {
        try
        {
            DB.execnonsql("INSERT INTO class(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')");
          
        }
        catch { Response.Write("<font color='red'>班级名重复！<font>"); }

    }
    protected void SubmitAddCourse()
    {
        try
        {
            DB.execnonsql("INSERT INTO CourseList(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')");
            Response.Write("<font color='red'>添加成功！<font>");
            //string sql1 = "SELECT courseid FROM CourseList WHERE name=N'" + Server.UrlDecode(Request["name"]) + "'";
            //string sql2 = "SELECT * FROM studentlist ORDER BY studentID DESC";
            //System.Data.DataTable dt = DB.OpenQuery(sql2);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DB.execnonsql("INSERT INTO workNumId(courseId,studentId,num,sClass)VALUES(" + Convert.ToInt32(DB.FindString(sql1)) + "," + Convert.ToInt32(dt.Rows[i]["studentID"].ToString()) + "," + 0 + ",'"+dt.Rows[i]["sclass"].ToString()+"')");
            //}
        }
        catch { Response.Write("<font color='red'>课程名重复！<font>"); }
     
    }
    protected void SubmitAddType()
    {
        string sql = "";
        switch (Request.QueryString["park"])
        {
            case "0": sql = "INSERT INTO NewsType(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')"; break;
            case "1": sql = "INSERT INTO TeachParkType(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')"; break;
            case "2": sql = "INSERT INTO researchType(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')"; break;
            case "4": sql = "INSERT INTO RescourcesType(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')"; break;
            case "5": sql = "INSERT INTO SubjectType(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')"; break;
            case "3": sql = "INSERT INTO TeacherUpType(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')"; break;
            case "8": sql = "INSERT INTO pass(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')"; break;
            case "10": sql = "INSERT INTO TypeValueList(name)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')"; break;

        }
        DB.execnonsql(sql);
        Response.Write("<font color='red'>添加成功！<font>");
    }
    //protected void SubmitAddNewsType()
    //{
    //    DB.execnonsql("INSERT INTO NewsType(content)VALUES(N'" + Server.UrlDecode(Request["name"]) + "')");
    //    Response.Write("添加成功！");
    //}
    protected void Add()
    {
        DateTime  time = DateTime.Now;
        string sql = "";
       
        switch (Server.UrlDecode(Request.Form["park"]))
        {
            case "0":
                sql = "INSERT INTO NewsList(Typ_steptid,title,content,New_newstypeid,time)VALUES(" + Convert.ToInt32(Server.UrlDecode(Request.Form["stept"])) + ",N'" + Server.UrlDecode(Request.Form["title"]) + "',N'" + Server.UrlDecode(Request.Form["content"]) + "', " + Convert.ToInt32(Server.UrlDecode(Request.Form["typeid"])) + ",'" + time + "')";
                break;
            case "1":
                sql = "INSERT INTO TeachPark(Typ_steptid,title,content,Tea_teachtypeid,Cou_courseid,time)VALUES(" + Convert.ToInt32(Server.UrlDecode(Request.Form["stept"])) + ",N'" + Server.UrlDecode(Request.Form["title"]) + "',N'" + Server.UrlDecode(Request.Form["content"]) + "', " + Convert.ToInt32(Server.UrlDecode(Request.Form["typeid"])) + ",  " + Convert.ToInt32(Server.UrlDecode(Request.Form["course"])) + ",'" + time + "')";
                break;
            case "2":
                sql = "INSERT INTO ResearchList(Typ_steptid,title,content,res_researchTypeId,pas_passId,time)VALUES(4,N'" + Server.UrlDecode(Request.Form["title"]) + "',N'" + Request.Form["content"] + "', " + Convert.ToInt32(Server.UrlDecode(Request.Form["typeid"])) + ", " + Convert.ToInt32(Server.UrlDecode(Request.Form["course"])) + ",'" + time + "')";
                break;
            case "3":
                sql = "INSERT INTO TeacherUpFileWorkList(Typ_steptid,title,content,Tea_teachUpTypeID,Cou_courseid,time)VALUES(" + Convert.ToInt32(Server.UrlDecode(Request.Form["stept"])) + ",N'" + Server.UrlDecode(Request.Form["title"]) + "',N'" + Server.UrlDecode(Request.Form["content"]) + "', " + Convert.ToInt32(Server.UrlDecode(Request.Form["typeid"])) + ", " + Convert.ToInt32(Server.UrlDecode(Request.Form["course"])) + ",'" + time + "')";
                break;
            case "4":
                sql = "INSERT INTO ResourcesList(Typ_steptid,title,content,Res_resourcestypeid,time)VALUES(" + Convert.ToInt32(Server.UrlDecode(Request.Form["stept"])) + ",N'" + Server.UrlDecode(Request.Form["title"]) + "',N'" + Server.UrlDecode(Request.Form["content"]) + "', " + Convert.ToInt32(Server.UrlDecode(Request.Form["typeid"])) + ",'" + time + "')";
                break;
            case "5":
                sql = "INSERT INTO SubjectList(Typ_steptid,title,content,Sub_subTypeID,time)VALUES(" + Convert.ToInt32(Server.UrlDecode(Request.Form["stept"])) + ",N'" + Server.UrlDecode(Request.Form["title"]) + "',N'" + Server.UrlDecode(Request.Form["content"]) + "', " + Convert.ToInt32(Server.UrlDecode(Request.Form["typeid"])) + ",'" + time + "')";
                break;
        }
        DB.execnonsql(sql);
    }
    protected void AddClass()
    {
        Response.Write("<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td class='style4'>班级名：</td><td><input id='name' type='text'/><img src = '../images/submit.gif' onclick = 'javascript:SubmitAddClass();' /></td></tr></table>");
    }
    protected void AddCourse()
    {
        Response.Write("<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td class='style4'>课程名：</td><td><input id='name' type='text'/><img src = '../images/submit.gif' onclick = 'javascript:SubmitAddCourse();' /></td></tr></table>");
    }
    protected void AddType()
    {
        Response.Write(" <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td class='style4'>类型名：</td><td><input id='name' type='text'/>&nbsp;&nbsp;<img src = '../images/submit.gif' onclick = 'javascript:SubmitAddType(" + Request.QueryString["park"] + ");' /></td></tr></table>");
    }
    //protected void AddNewsType()
    //{
    //    Response.Write(" <table style='width: 109%;'><tr><td class='style4'>类型名：</td><td><input id='name' type='text'/><input id='sumit' type='button' value='提交' onclick = 'javascript:SubmitAddNewsType();' /></td></tr></table>");
    //}
    //protected void AddNews()
    //{
    //    string sql = "UPDATE NewsList SET title = N'" + Request["title"] + "', New_newstypeid = '" + Convert.ToInt32(Request["typeid"]) + "', Typ_steptid = '" + Convert.ToInt32(Request["stept"]) + "', content = N'" + Request["content"] + "'WHERE newsid ='" + Convert.ToInt32(Request["id"]) + "' ";
    //    DB.execnonsql(sql);
    //}
    protected void GetWorkStept()
    {

        System.Data.DataTable dt;
        string sql = "";
        string id = "", content = "";
        string str = "<option value='{0}'>{1}</option>";
        string check = "权限选择：<select id='stept22'runat='server'><option value=''>请选择</option>";
        sql = "SELECT * FROM TypeValueList ORDER BY steptid DESC";

        id = "steptid"; content = "name";
        dt = DB.OpenQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i][content].ToString());
        }
        check += " </select>";
        Response.Write(check);
    }
    protected void GetStept()
    {

        System.Data.DataTable dt;
        string sql = "";
        string id = "", content = "";
        string str = "<option value='{0}'>{1}</option>";
        string check = "权限选择：<select id='stept22'runat='server'onchange = 'javascript:GetStept();'><option value=''>请选择</option>";
        sql = "SELECT * FROM TypeValueList ORDER BY steptid DESC";

        id = "steptid"; content = "name";
        dt = DB.OpenQuery(sql);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i][content].ToString());
        }
        check += " </select>";
        Response.Write(check);
    }
    protected void MList()  //管理员列表
    {
        string table = " <table   style='border-style: none solid solid solid; border-width: 0px 2px 2px 2px; border-color: #FFFFFF #99CCFF #99CCFF #99CCFF; width: 840px; background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);'>";
        table += " <tr><td class='style9'>编号</td><td class='style10'>姓名</td><td class='style8'>昵称</td><td class='style6'>修改</td></tr>";
        string str = " <tr><td class='style9'>{0}</td><td class='style10'>{1}</td><td class='style8'>{2}</td><td class='style6'><a href=\"javascript:edit({0},'{1}','{2}');\"><img src='../Images/edit.gif' style='border: 0px none #FFFFFF' /></a></td></tr>";
        System.Data.DataTable dt = DB.OpenQuery("SELECT * FROM Admin ORDER BY adminID");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            table  += string.Format(str, dt.Rows[i]["adminID"].ToString(), dt.Rows[i]["name"].ToString(), dt.Rows[i]["nickname"].ToString());
        }
        table += "</table>";
        Response.Write(table);
        //Response.Write("<input id='11' value = '" + dt.Rows[0]["adminID"].ToString() + "'style = 'display:none'  type='text'/>");
        //Response.Write("<input id='12' value = '" + dt.Rows[0]["name"].ToString() + "'style = 'display:none'  type='text'/>");
        //Response.Write("<input id='13' value = '" + dt.Rows[0]["nickname"].ToString() + "'style = 'display:none'  type='text'/>");
    }
    protected void edit()
    {
        Response.Write("   <table style='border-style: none solid solid solid;background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg); border-width: 0px 2px 2px 2px; border-color: #FFFFFF #99CCFF #99CCFF #99CCFF; width: 840px;'><tr><td class='style4'>姓名：</td><td><input id='name' value = '" + Server.UrlDecode(Request["name"]) + "' type='text'/></td></tr><tr><td class='style4'>昵称：</td><td><input id='nickname'value = '" + Server.UrlDecode(Request["nickname"]) + "' type='text'/></td></tr><tr><td class='style4'>旧密码：</td><td><input id='oldpassword' type='password' /></td></tr><tr><td class='style4'>新密码：</td><td><input id='password' type='password' /></td></tr><tr><td class='style4'>确认新密码：</td><td><input id='repassword' type='password' /></td></tr><tr><td><img src='../Images/submit.gif'  onclick = 'javascript:submitadmin()'/></td></tr></table>");
        Response.Write("<input id='ID' value = '" + Request["id"] + "'style = 'display:none'  type='text'/>");
    }
    //protected void EditStudent() //编辑学生列表
    //{
    //    Response.Write(" <table style='width: 109%;'><tr><td class='style4'>姓名：</td><td><input id='name' value = '" + Server.UrlDecode(Request["name"]) + "' type='text'/></td></tr><tr><td class='style4'>昵称：</td><td><input id='nickname'value = '" + Server.UrlDecode(Request["nickname"]) + "' type='text'/></td></tr><tr><td class='style4'>密码：</td><td><input id='password'value = '" + Server.UrlDecode(Request["password"]) + "' type='text' /></td></tr><tr><td class='style4'>班级</td><td><input id='password' type='password' /></td></tr><input id='sumit' type='button' value='提交' onclick = 'javascript:submitadmin();' /></td></tr></table>");
    //    Response.Write("<input id='ID' value = '" + Request["id"] + "'style = 'display:none'  type='text'/>");
    //}
    protected void EditClassList()
    {
        Response.Write(" <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td class='style4'>编号</td><td><input id='ID'readonly = 'true' value = '" + Request["id"] + "' type='text'/><td class='style4'>名字：</td><td><input id='name' value = '" + Server.UrlDecode(Request["name"]) + "' type='text'/><input id='sumit' type='button' value='提交' onclick = 'javascript:SubmitClass();' /></td></tr></table>");

    }
    protected void EditCourseList()
    {
        Response.Write(" <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td class='style4'>编号</td><td><input id='ID'readonly = 'true' value = '" + Request["id"] + "' type='text'/><td class='style4'>名字：</td><td><input id='name' value = '" + Server.UrlDecode(Request["name"]) + "' type='text'/><input id='sumit' type='button' value='提交' onclick = 'javascript:SubmitCourse();' /></td></tr></table>");
       
    }
    protected void submit()
    {
        string sql = "SELECT spassword FROM Admin WHERE adminID = " + Request["id"] + "";
        string sql1 = "UPDATE Admin SET name = N'" + Server.UrlDecode(Request["name"]) + "',nickname = N'" + Server.UrlDecode(Request["nickname"]) + "',spassword = N'" + MD5.Hash(Request["password"]) + "'";
        string password = PageValidate.GetSafeStr(Request["oldpassword"]);
        string pass = MD5.Hash(password);
        if (DB.FindString(sql) == pass)
        {
            if (Request["password"].ToString().Trim() == Request["repassword"].ToString().Trim())
            {
                DB.execnonsql(sql1);
                Response.Write("<font color='red'>编辑成功!<font>");
            }
            else Response.Write("<font color='red'>两次输入密码不一致!<font>");
        }
        else Response.Write("<font color='red'>旧密码和新密码不一致!<font>");
    }
    protected void submitstudent()
    {
        string sql = "",sql2="";
        if (Request["password"].Trim() == "")
        {
            if (Request["sclass"].Trim() == "")
            { sql = "UPDATE studentlist SET name = N'" + Server.UrlDecode(Request["name"]) + "',nickname = N'" + Server.UrlDecode(Request["nickname"]) + "',studyNum = N'" + Server.UrlDecode(Request["studyNum"]) + "',classNum = " + Convert.ToInt32(Server.UrlDecode(Request["classNum"])) + "WHERE studentID=" + Request["id"] + ""; }
            else { sql = "UPDATE studentlist SET name = N'" + Server.UrlDecode(Request["name"]) + "',nickname = N'" + Server.UrlDecode(Request["nickname"]) + "',sclass = " + Convert.ToInt32(Server.UrlDecode(Request["sclass"])) + ",studyNum = N'" + Server.UrlDecode(Request["studyNum"]) + "',classNum = " + Convert.ToInt32(Server.UrlDecode(Request["classNum"])) + "WHERE studentID=" + Request["id"] + ""; }
        }

        else
        {
            if (Request["sclass"].Trim() == "")
            { sql = "UPDATE studentlist SET name = N'" + Server.UrlDecode(Request["name"]) + "',nickname = N'" + Server.UrlDecode(Request["nickname"]) + "',password = N'" + MD5.Hash(Request["password"]) + "',studyNum = N'" + Server.UrlDecode(Request["studyNum"]) + "',classNum = " + Convert.ToInt32(Server.UrlDecode(Request["classNum"])) + "WHERE studentID=" + Request["id"] + ""; }
            else { sql = "UPDATE studentlist SET name = N'" + Server.UrlDecode(Request["name"]) + "',nickname = N'" + Server.UrlDecode(Request["nickname"]) + "',password = N'" + MD5.Hash(Request["password"]) + "',sclass = " + Convert.ToInt32(Server.UrlDecode(Request["sclass"])) + ",studyNum = N'" + Server.UrlDecode(Request["studyNum"]) + "',classNum = " + Convert.ToInt32(Server.UrlDecode(Request["classNum"])) + "WHERE studentID=" + Request["id"] + ""; }
        }
        if (Request["sclass"].Trim() != "")
        {
            sql2 = "UPDATE CompleteWork SET classId =" + Convert.ToInt32(Server.UrlDecode(Request["sclass"])) + "WHERE stu_studentID=" + Request["id"] + "";
            DB.execnonsql(sql2);
        }
       
       
       
       
            DB.execnonsql(sql);
           
            Response.Write("<font color='red'>编辑成功!<font>");
    
       
    }
    protected void submitNetUser()
    {

        string sql = "UPDATE NetUser SET Typ_steptid = '" + Request["stept"] + "'WHERE userid=" + Request["id"] + "";


        DB.execnonsql(sql);
        Response.Write("<font color='red'>编辑成功!<font>");


    }
    protected void submitaddstudent()
    {
        string sql4 = "SELECT COUNT(*) FROM studentlist WHERE sclass = " + Convert.ToInt32(Server.UrlDecode(Request["sclass"])) + " AND classNum = " + Convert.ToInt32(Server.UrlDecode(Request["classNum"])) + " ";
        if (Convert.ToInt32(DB.FindString(sql4)) != 0)
        {
            Response.Write("<font color='red'> 班级号重复!<font>"); return;
        }
        else
        {
            string sql = "INSERT INTO studentlist(name,nickname,password,sclass,studyNum,classNum)VALUES(N'" + Server.UrlDecode(Request["name"]) + "',N'" + Server.UrlDecode(Request["nickname"]) + "',N'" + MD5.Hash(Request["password"]) + "'," + Convert.ToInt32(Server.UrlDecode(Request["sclass"])) + ",N'" + Server.UrlDecode(Request["studyNum"]) + "','" + Convert.ToInt32(Server.UrlDecode(Request["classNum"])) + "')";
            try
            {
                DB.execnonsql(sql);
                Response.Write("<font color='red'> 添加成功!<font>");



            }
            catch { Response.Write("<font color='red'> 学号&帐号重复!或数据不规范！<font>"); }
        }
  
   
           
     
    
    }
    protected void SubmitClass()
    {
        string sql1 = "UPDATE class SET name = N'" + Server.UrlDecode(Request["name"]) + "'WHERE classId=" + Request["id"] + "";
        DB.execnonsql(sql1);
        Response.Write("<font color='red'>编辑成功!<font>");
    }
    protected void SubmitCourse()
    {
        string sql1 = "UPDATE CourseList SET name = N'" + Server.UrlDecode(Request["name"]) + "'WHERE courseid=" + Request["id"] + "";
        DB.execnonsql(sql1);
        Response.Write("<font color='red'>编辑成功!<font>");
    }
    protected void ResearchList()
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>标题关键字：<input type='text' id='title'/>	";
        string check1 = "科研类型：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM researchType ORDER BY researchTypeId DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["researchTypeId"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string check2 = "科研方向：<select id='select4'><option value=''>请选择</option>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM pass ORDER BY passId DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["passId"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        check1 += check2;
        search += check1;
        search += "<input type='button' value='查询' onclick='javascript:GetPage(1,44)'/></td></tr></table>";
        Response.Write(search);

    }
    protected void ResearchList1()   //科研信息
    {
        StringBuilder sb = new StringBuilder("");
        int count;
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        if (Request["key2"] != null)
        {
            if (Request["key1"] == "")
            {
                if (Request["key2"] == "")
                {
                    string sql = "select count(*) from ResearchList where title like N'%" + key + "%'";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from ResearchList where title like N'%" + key + "%'");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and researchId not in(select top " + (pageSize * (page - 1)).ToString() + " researchId from ResearchList where title like N'%" + key + "%' order by researchId desc)");
                    }
                    sb.Append(" order by researchId desc");
                }
                else
                {
                    string sql = "select count(*) from ResearchList where title like N'%" + key + "%' and pas_passId=" + Convert.ToInt32(Request["key2"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from ResearchList where title like N'%" + key + "%' and pas_passId=" + Convert.ToInt32(Request["key2"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and researchId not in(select top " + (pageSize * (page - 1)).ToString() + " researchId from ResearchList where title like N'%" + key + "%' and pas_passId=" + Convert.ToInt32(Request["key2"]) + " order by researchId desc)");
                    }
                    sb.Append(" order by researchId desc");
                }
               
            }
            else
            {
                if (Request["key2"] == "")
                {
                    string sql = "select count(*) from ResearchList where title like N'%" + key + "%' and res_researchTypeId=" + Convert.ToInt32(Request["key1"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from ResearchList where title like N'%" + key + "%' and res_researchTypeId=" + Convert.ToInt32(Request["key1"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and researchId not in(select top " + (pageSize * (page - 1)).ToString() + " researchId from ResearchList where title like N'%" + key + "%' and res_researchTypeId=" + Convert.ToInt32(Request["key1"]) + " order by researchId desc)");
                    }
                    sb.Append(" order by researchId desc");
                }
                else
                {
                    string sql = "select count(*) from ResearchList where title like N'%" + key + "%' and res_researchTypeId=" + Convert.ToInt32(Request["key1"]) + " and pas_passId=" + Convert.ToInt32(Request["key2"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from ResearchList where title like N'%" + key + "%' and res_researchTypeId=" + Convert.ToInt32(Request["key1"]) + " and pas_passId=" + Convert.ToInt32(Request["key2"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and researchId not in(select top " + (pageSize * (page - 1)).ToString() + " researchId from ResearchList where title like N'%" + key + "%' and res_researchTypeId=" + Convert.ToInt32(Request["key1"]) + " and pas_passId=" + Convert.ToInt32(Request["key2"]) + " order by researchId desc)");
                    }
                    sb.Append(" order by researchId desc");
                }
            }
        }
        else
        {
            string sql = "select count(*) from ResearchList where title like N'%" + key + "%'";
           count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
           sb.Append("select top " + pageSize.ToString() + " * from ResearchList where title like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and researchId not in(select top " + (pageSize * (page - 1)).ToString() + " researchId from ResearchList where title like N'%" + key + "%' order by researchId desc)");
            }
            sb.Append(" order by researchId desc");
        }
      

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属分类</td><td>标题</td><td>上传时间</td><td>权限</td><td>科研方向</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{6}</td><td><a href = \"javascript:edititcourseOpenWin({0},'{1}','{2}','{4}','{6}',2);\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},2,44));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT name FROM researchType WHERE researchTypeId = '" + dt.Rows[i]["res_researchTypeId"].ToString() + "'";
            string sqlCourse = "SELECT name FROM pass WHERE passId = '" + dt.Rows[i]["pas_passId"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["researchId"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse));
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager'style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(2,44)'/>" + this.GetPager(page, pageSize, count, 44) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void newsList()
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>标题关键字：<input type='text' id='title'/>	";
        string check1 = "新闻类型：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM NewsType ORDER BY newstypeid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["newstypeid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        search += check1;
        search += "<input type='button' value='查询' onclick='javascript:GetPage(1,13)'/></td></tr></table>";
        Response.Write(search);
       
    }
    protected void newsList1()
    {   StringBuilder sb = new StringBuilder("");
        int count;
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        if (Request["key1"] != null)
        {
            if (Request["key1"] == "")
            {
                string sql = "select count(*) from NewsList where title like N'%" + key + "%'";

                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from NewsList where title like N'%" + key + "%'");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and newsid not in(select top " + (pageSize * (page - 1)).ToString() + " newsid from NewsList where title like N'%" + key + "%' order by newsid desc)");
                }
                sb.Append(" order by newsid desc");
            }
            else
            {
                string sql = "select count(*) from NewsList where title like N'%" + key + "%' and New_newstypeid="+Convert.ToInt32(Request["key1"])+"";

                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from NewsList where title like N'%" + key + "%' and New_newstypeid=" + Convert.ToInt32(Request["key1"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and newsid not in(select top " + (pageSize * (page - 1)).ToString() + " newsid from NewsList where title like N'%" + key + "%' and New_newstypeid=" + Convert.ToInt32(Request["key1"]) + " order by newsid desc)");
                }
                sb.Append(" order by newsid desc");
            }
        }
        else
        {
            string sql = "select count(*) from NewsList where title like N'%" + key + "%'";

            count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
            sb.Append("select top " + pageSize.ToString() + " * from NewsList where title like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and newsid not in(select top " + (pageSize * (page - 1)).ToString() + " newsid from NewsList where title like N'%" + key + "%' order by newsid desc)");
            }
            sb.Append(" order by newsid desc");
        }
    
       
        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
    System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
    string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属分类</td><td>标题</td><td>上传时间</td><td>权限</td><td>操作</td></tr>";

    string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href = \"javascript:edititOpenWin({0},'{1}','{2}','{4}',0);\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},0,13));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT name FROM NewsType WHERE newstypeid = '" + dt.Rows[i]["New_newstypeid"].ToString()+ "'";
            list += string.Format(str, dt.Rows[i]["newsid"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent), dt.Rows[i]["content"].ToString());
           // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager' style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' style = 'width: 70px' onclick='javascript:DelItSelect(0,13)'/>" + this.GetPager(page, pageSize, count, 13) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void forumQuestion()
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>论坛问题标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='javascript:GetPage(1,76)'/></td></tr></table>";
        //string list = " <table border='1' cellpadding='0' cellspacing='0' style='width: 100%; font-size:12px; border-style: dotted;border-collapse: separate'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属分类</td><td>标题</td><td>上传时间</td><td>操作</td></tr>";
        //System.Data.DataTable dt = DB.OpenQuery("SELECT * FROM NewsList ORDER BY newsid DESC");
        //string str = "<tr><td><input id='checkit' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href=\"javascript:void(EditNews({0},{1},{2},{4},{5}));\">编辑</a>||<a href=\"javascript:void(DelNews({0}));\">删除</a></td></tr>";
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    list += string.Format(str, dt.Rows[i]["newsid"].ToString(), dt.Rows[i]["New_newstypeid"].ToString(), dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["Typ_steptid"].ToString(), dt.Rows[i]["content"].ToString());
        //}
        //list += "</table>";
        Response.Write(search);

    }
    protected void forumQuestion1()
    {
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        string sql = "select count(*) from ForumQuestion where title like N'%" + key + "%'";

        int count = Convert.ToInt32(DB.FindString(sql));
        //实现自定义的分页逻辑
        StringBuilder sb = new StringBuilder("select top " + pageSize.ToString() + " * from ForumQuestion where title like N'%" + key + "%'");
        //如果不是第一页
        if (page > 1)
        {
            sb.Append(" and questionid not in(select top " + (pageSize * (page - 1)).ToString() + " questionid from ForumQuestion where title like N'%" + key + "%' order by questionid desc)");
        }
        sb.Append(" order by questionid desc");

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>点击数</td><td>回复数</td><td>标题</td><td>作者</td><td>上传时间</td><td>权限</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td><a href=\"javascript:void(ShowAnswer({0},1));\" title = '此问题的回复！'>{3}</a></td><td>{4}</td><td>{5}</td><td>{6}</td><td><a href = \"javascript:editForumOpenWin({0},'{3}','{4}','{6}',11);\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},11,76));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";

            list += string.Format(str, dt.Rows[i]["questionid"].ToString(), dt.Rows[i]["clicknum"].ToString(), dt.Rows[i]["replynum"].ToString(), dt.Rows[i]["title"].ToString().Length >15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["author"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent));
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager' style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(11,76)'/>" + this.GetPager(page, pageSize, count, 76) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void ShowAnswer()
    {
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        //string key = Server.UrlDecode(Request.QueryString["key"]);
        //if (key == null) key = string.Empty;
        ////过滤特殊符号，避免SQL注入
        //key = key.Replace("'", "").Replace("\"", "");
        string sql = "select count(*) from ForumAnswer where For_questionid=" + Convert.ToInt32(Request["id"]) + "";

        int count = Convert.ToInt32(DB.FindString(sql));
        //实现自定义的分页逻辑
        StringBuilder sb = new StringBuilder("select top " + pageSize.ToString() + " * from ForumAnswer where For_questionid=" + Convert.ToInt32(Request["id"]) + "");
        //如果不是第一页
        if (page > 1)
        {
            sb.Append(" and answerid not in(select top " + (pageSize * (page - 1)).ToString() + " answerid from ForumAnswer where For_questionid=" + Convert.ToInt32(Request["id"]) + " order by answerid desc)");
        }
        sb.Append(" order by answerid desc");

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>此留言的回复</td></tr><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>标题</td><td>作者</td><td>回复时间</td><td>回复留言标题</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href = \"javascript:editForumOpen({0},'{1}','{2}',12)\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del1({0},12,77,{5}));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT title FROM ForumQuestion WHERE questionid = '" + dt.Rows[i]["For_questionid"].ToString() + "'";

            list += string.Format(str, dt.Rows[i]["answerid"].ToString(), dt.Rows[i]["title"].ToString().Length > 15? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["author"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent).ToString().Length > 15 ? DB.FindString(sqlNewSteptContent).ToString().Substring(0, 15) + "..." : DB.FindString(sqlNewSteptContent).ToString(), Convert.ToInt32(Request["id"]));
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager'style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect1(12,77," + Convert.ToInt32(Request["id"]) + ")'/><input id='title' style ='display :none' type='text' />" + this.GetPager1(page, pageSize, count, 77, Convert.ToInt32(Request["id"])) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void WorkList()
    {
        //string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 770px'><tr><td>标题关键字：<input type='text' id='title' name='title'/>	";
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>标题关键字：<input type='text' id='title' name='title'/>";
        string check1 = "课程：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;";
        string check2 = "类型：<select id='select4'><option value=''>请选择</option>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM TeacherUpType ORDER BY teachUpTypeID DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["teachUpTypeID"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>";
        check1 += check2;
        search += check1;
        search += " &nbsp;&nbsp;<input type='button' value='查询' onclick='javascript:GetPage(1,62)'/><input id='workNum' style ='display :none' type='text' /></td></tr></table>";
        Response.Write(search);

    }
    protected void WorkList1()   //教师信息
    {
        StringBuilder sb = new StringBuilder("");
        int count;
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        if (Request["key1"] != null)
        {
            if (Request["key1"] == "")
            {
                if (Request["key2"] == "")
                {
                    string sql = "select count(*) from TeacherUpFileWorkList where title like N'%" + key + "%'";
                   count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from TeacherUpFileWorkList where title like N'%" + key + "%'");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and TeacherUpWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " TeacherUpWorkID from TeacherUpFileWorkList where title like N'%" + key + "%' order by TeacherUpWorkID desc)");
                    }
                    sb.Append(" order by TeacherUpWorkID desc");
                }
                else
                {
                    string sql = "select count(*) from TeacherUpFileWorkList where title like N'%" + key + "%' and Tea_teachUpTypeID=" + Convert.ToInt32(Request["key2"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from TeacherUpFileWorkList where title like N'%" + key + "%' and Tea_teachUpTypeID=" + Convert.ToInt32(Request["key2"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and TeacherUpWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " TeacherUpWorkID from TeacherUpFileWorkList where title like N'%" + key + "%' and Tea_teachUpTypeID=" + Convert.ToInt32(Request["key2"]) + " order by TeacherUpWorkID desc)");
                    }
                    sb.Append(" order by TeacherUpWorkID desc");
                }
            }
            else
            {
                if (Request["key2"] == "")
                {
                    string sql = "select count(*) from TeacherUpFileWorkList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from TeacherUpFileWorkList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and TeacherUpWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " TeacherUpWorkID from TeacherUpFileWorkList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + " order by TeacherUpWorkID desc)");
                    }
                    sb.Append(" order by TeacherUpWorkID desc");
                }
                else
                {
                    string sql = "select count(*) from TeacherUpFileWorkList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + " and Tea_teachUpTypeID=" + Convert.ToInt32(Request["key2"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from TeacherUpFileWorkList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + " and Tea_teachUpTypeID=" + Convert.ToInt32(Request["key2"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and TeacherUpWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " TeacherUpWorkID from TeacherUpFileWorkList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + " and Tea_teachUpTypeID=" + Convert.ToInt32(Request["key2"]) + " order by TeacherUpWorkID desc)");
                    }
                    sb.Append(" order by TeacherUpWorkID desc");
                }
            }
        }
        else
        {
            string sql = "select count(*) from TeacherUpFileWorkList where title like N'%" + key + "%'";
            count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
            sb.Append("select top " + pageSize.ToString() + " * from TeacherUpFileWorkList where title like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and TeacherUpWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " TeacherUpWorkID from TeacherUpFileWorkList where title like N'%" + key + "%' order by TeacherUpWorkID desc)");
            }
            sb.Append(" order by TeacherUpWorkID desc");
        }
       


       

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属分类</td><td>标题</td><td>上传时间</td><td>权限</td><td>课程名称</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{6}</td><td><a href = \"javascript:edititcourseOpenWin({0},'{1}','{2}','{4}','{6}',3);\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},3,62));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT name FROM TeacherUpType WHERE teachUpTypeID = '" + dt.Rows[i]["Tea_teachUpTypeID"].ToString() + "'";
            string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["TeacherUpWorkID"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse));
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager' style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(3,62)'/>" + this.GetPager(page, pageSize, count, 62) + "</div>" + "<div id = 'List2'></div>");
    }
    //protected void WorkNum()
    //{
    //    string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 770px'><tr><td>班级关键字：<input type='text' id='title' name='title'/><div id = 'divCourse'style = 'float:left;width:200px;'><input type='button' value='显示课程下拉框'onclick = 'javascript:GetCourse();'/></div>	<div style = 'float:left;width:400px;'><input type='button' value='查询' onclick='javascript:GetPage(1,83)'/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type='button' style = 'width:160px;' value='所以学生作业次数置0' onclick='javascript:over()'/>  <input id='workNum' style ='display :none' type='text' /></div></td></tr></table>";
    //    //string list = " <table border='1' cellpadding='0' cellspacing='0' style='width: 100%; font-size:12px; border-style: dotted;border-collapse: separate'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属分类</td><td>标题</td><td>上传时间</td><td>操作</td></tr>";
    //    //System.Data.DataTable dt = DB.OpenQuery("SELECT * FROM NewsList ORDER BY newsid DESC");
    //    //string str = "<tr><td><input id='checkit' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href=\"javascript:void(EditNews({0},{1},{2},{4},{5}));\">编辑</a>||<a href=\"javascript:void(DelNews({0}));\">删除</a></td></tr>";
    //    //for (int i = 0; i < dt.Rows.Count; i++)
    //    //{
    //    //    list += string.Format(str, dt.Rows[i]["newsid"].ToString(), dt.Rows[i]["New_newstypeid"].ToString(), dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), dt.Rows[i]["Typ_steptid"].ToString(), dt.Rows[i]["content"].ToString());
    //    //}
    //    //list += "</table>";
    //    Response.Write(search);

    //}
    //protected void WorkNum1()   //教师信息
    //{
       
    //    int pageSize = 15;//定义每页需要显示的记录数
    //    //获取查询字符串表示的页数，默认为1
    //    int page = 1;
    //    //利用异常机制确保转换string到int类型不会出错
    //    try
    //    {
    //        page = Convert.ToInt32(Request.QueryString["page"]);
    //    }
    //    catch (Exception e1) { }

    //    //获得查询条件
    //    string key = Server.UrlDecode(Request.QueryString["key"]);
    //    string key1 = Server.UrlDecode(Request.QueryString["key1"]);
    //    if (key == null) key = string.Empty;
     
    //    //过滤特殊符号，避免SQL注入
    //    key = key.Replace("'", "").Replace("\"", "");

    //    string sql = "select count(*) from workNumId where sClass like N'%" + key + "%' and courseId="+Convert.ToInt32 (key1)+"";
    //    int count = Convert.ToInt32(DB.FindString(sql));
    //    //实现自定义的分页逻辑
    //    StringBuilder sb = new StringBuilder("select top " + pageSize.ToString() + " * from workNumId where sClass like N'%" + key + "%' and courseId=" + Convert.ToInt32(key1) + "");
    //    //如果不是第一页
    //    if (page > 1)
    //    {
    //        sb.Append(" and workNumId not in(select top " + (pageSize * (page - 1)).ToString() + " workNumId from workNumId where sClass like N'%" + key + "%' and courseId=" + Convert.ToInt32(key1) + " order by workNumId desc)");
    //    }
    //    sb.Append(" order by workNumId desc");

    //    //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
    //    System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
    //    string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 770px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>姓名</td><td>交作业次数</td><td>课程</td><td>班级</td><td>操作</td></tr>";

    //    string str = "<tr><td><input id='Checkbox1' value = '{5}' type='checkbox' /></td><td><a href=\"javascript:void(SearchStudent({4}));\" title = '学生资料！'>{0}</a></td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href=\"javascript:EditNum({5},{1})\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({5},22,83));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        string sqlNewSteptContent = "SELECT name FROM studentlist WHERE studentID = '" + dt.Rows[i]["studentId"].ToString() + "'";

    //        string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["courseId"].ToString() + "'";
    //        list += string.Format(str, DB.FindString(sqlNewSteptContent), dt.Rows[i]["num"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["sClass"].ToString(), dt.Rows[i]["studentId"].ToString(), dt.Rows[i]["workNumId"].ToString());
    //        // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
    //    }
    //    list += "</table>";
    //    //list += "";
    //    Response.Write(list + "<div id='pager'style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 766px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(22,83)'/>" + this.GetPager(page, pageSize, count, 83) + "</div><div id = 'List2'></div>");
    //}
    protected void StuUpFileList()
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>标题关键字：<input type='text' id='title' name='title'/>";
        string check1 = "课程：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;";
        string check2 = "班级：<select id='select4'><option value=''>请选择</option>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM class ORDER BY classId DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["classId"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>";
        check1 += check2;
       
      
        search += check1;
        search += " &nbsp;&nbsp;<input type='button' value='查询' onclick='javascript:GetPage(1,64)'/><input id='workNum' style ='display :none' type='text' /></td></tr></table>";
        
        Response.Write(search);

    }
    protected void StuUpFileList1()   //教师信息
    {
        StringBuilder sb = new StringBuilder("");
        int count;
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        if (Request["key1"] != null)
        {
            if (Request["key1"] == "")
            {
                if (Request["key2"] == "")
                {
                    string sql = "select count(*) from StuUpFIleList where title like N'%" + key + "%'";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from StuUpFIleList where title like N'%" + key + "%'");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and upId not in(select top " + (pageSize * (page - 1)).ToString() + " upId from StuUpFIleList where title like N'%" + key + "%' order by upId desc)");
                    }
                    sb.Append(" order by upId desc");
                }
                else
                {
                    string sql = "select count(*) from StuUpFIleList where title like N'%" + key + "%' and classId=" + Convert.ToInt32(Request["key2"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from StuUpFIleList where title like N'%" + key + "%' and classId=" + Convert.ToInt32(Request["key2"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and upId not in(select top " + (pageSize * (page - 1)).ToString() + " upId from StuUpFIleList where title like N'%" + key + "%' and classId=" + Convert.ToInt32(Request["key2"]) + " order by upId desc)");
                    }
                    sb.Append(" order by upId desc");
                }
            }
            else
            {
                if (Request["key2"] == "")
                {
                    string sql = "select count(*) from StuUpFIleList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from StuUpFIleList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and upId not in(select top " + (pageSize * (page - 1)).ToString() + " upId from StuUpFIleList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + " order by upId desc)");
                    }
                    sb.Append(" order by upId desc");
                }
                else
                {
                    string sql = "select count(*) from StuUpFIleList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + " and classId=" + Convert.ToInt32(Request["key2"]) + "and classId=" + Convert.ToInt32(Request["key2"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from StuUpFIleList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + " and classId=" + Convert.ToInt32(Request["key2"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and upId not in(select top " + (pageSize * (page - 1)).ToString() + " upId from StuUpFIleList where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key1"]) + " and classId=" + Convert.ToInt32(Request["key2"]) + " order by upId desc)");
                    }
                    sb.Append(" order by upId desc");
                }
            }
        }
        else
        {
            string sql = "select count(*) from StuUpFIleList where title like N'%" + key + "%'";
            count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
            sb.Append("select top " + pageSize.ToString() + " * from StuUpFIleList where title like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and upId not in(select top " + (pageSize * (page - 1)).ToString() + " upId from StuUpFIleList where title like N'%" + key + "%' order by upId desc)");
            }
            sb.Append(" order by upId desc");
        }
       

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>上传学生姓名</td><td>班级</td><td>标题</td><td>上传时间</td><td>权限</td><td>课程名称</td><td>是否显示</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td><a href=\"javascript:void(SearchStudent({8}));\" title = '上传资料学生信息！'>{1}</a></td><td>{9}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{6}</td><td>{7}</td><td><a href = \"javascript:editStuOpenwin({0},'{2}','{4}','{6}','{7}',6);\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},6,64));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT nickname FROM studentlist WHERE studentID = '" + dt.Rows[i]["stu_studentID"].ToString() + "'";
            string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["upId"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse), dt.Rows[i]["isPro"].ToString(), dt.Rows[i]["stu_studentID"].ToString(), dt.Rows[i]["classId"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        list += "";
        Response.Write(list + "<div id='pager' style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(6,64)'/>" + this.GetPager(page, pageSize, count, 64) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void CompleteWorkList()
    {
        string search = "<table style='border-left: 2px solid #99CCFF; border-right: 2px solid #99CCFF; border-top: 0px solid #99CCFF; border-bottom: 1px solid #99CCFF; background-image: url(&#039;../Images/背景.jpg&#039;); margin-top: 0px; width: 840px'><tr><td><div style='width: 202px; font-size: 12px; float: left;'>标题关键字<input type='text'style = 'width:90px' id='title' name='title'/></div><div id = 'couClass' style='width: 310px; float: left;'>";
        string check1 = "课程<select id='courseSelect'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString().Length > 10 ? dt.Rows[i]["name"].ToString().Substring(0, 10) : dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;";
        string check2 = "班级<select id='classSelect'><option value=''>请选择</option>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM class ORDER BY classId DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["classId"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>";
        check1 += check2;
        search += check1;
        search += "</div>次数<input type='text' style = 'width:20px' id='workNum'/>	<input type='button'style = 'width:60px' value='查询所有' onclick='javascript:GetPageWork(1,67)'/> <input type='button'style = 'width:90px' value='未批改的作业' onclick='javascript:GetPageWork(1,97)'/><input type='button'style = 'width:90px' value='未交作业学生' onclick='javascript:GetPageWork(1,98)'/></td></tr></table>";
        Response.Write(search);

    }
    protected void SearchNoWorkStu()   //教师信息
    {
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        string num = Server.UrlDecode(Request.QueryString["num"]);
        if (num == null) num = string.Empty;
        //过滤特殊符号，避免SQL注入
        num = num.Replace("'", "").Replace("\"", "");
        int num1 = 0;
        try { num1 = Convert.ToInt32(num); }
        catch (Exception e1) { }
        int count;
        StringBuilder sb = new StringBuilder("");
        if (num.ToString() == "")
        {
            if (Request["courseId"] != null)
            {
                if (Request["courseId"] == "")
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork )";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork)");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork ) order by classNum)");
                        }
                        sb.Append(" order by classNum");
                    }
                    else
                    {
                        string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork ) and sclass=" + Convert.ToInt32(Request["classId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork ) and sclass=" + Convert.ToInt32(Request["classId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork ) and sclass=" + Convert.ToInt32(Request["classId"]) + " order by classNum)");
                        }
                        sb.Append(" order by classNum");
                    }
                }
                else
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " )";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " )");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " ) order by classNum)");
                        }
                        sb.Append(" order by classNum");
                    }
                    else
                    {
                        string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " ) and sclass=" + Convert.ToInt32(Request["classId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " ) and sclass=" + Convert.ToInt32(Request["classId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " ) and sclass=" + Convert.ToInt32(Request["classId"]) + " order by classNum)");
                        }
                        sb.Append(" order by classNum");
                    }
                }
            }
            else
            {
                string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork )";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork)");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork ) order by classNum)");
                }
                sb.Append(" order by classNum");

            }
        }



        else
        {
            if (Request["courseId"] != null)
            {
                if (Request["courseId"] == "")
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork WHERE workNum=" + num1 + "  )";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork WHERE workNum=" + num1 + " )");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork WHERE workNum=" + num1 + "  ) order by classNum)");
                        }
                        sb.Append(" order by classNum");
                    }
                    else
                    {
                        string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork WHERE workNum=" + num1 + "  ) and sclass=" + Convert.ToInt32(Request["classId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork WHERE workNum=" + num1 + "  ) and sclass=" + Convert.ToInt32(Request["classId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork  WHERE workNum=" + num1 + " ) and sclass=" + Convert.ToInt32(Request["classId"]) + " order by classNum)");
                        }
                        sb.Append(" order by classNum");
                    }
                }
                else
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + " )";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + " )");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + " ) order by classNum)");
                        }
                        sb.Append(" order by classNum");
                    }
                    else
                    {
                        string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + " ) and sclass=" + Convert.ToInt32(Request["classId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + " ) and sclass=" + Convert.ToInt32(Request["classId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork where Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + " ) and sclass=" + Convert.ToInt32(Request["classId"]) + " order by classNum)");
                        }
                        sb.Append(" order by classNum");
                    }
                }
            }
            else
            {
                string sql = "select count(*) from studentlist where studentID not in(select stu_studentID from CompleteWork WHERE workNum=" + num1 + "  )";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from studentlist where studentID not in(select stu_studentID from CompleteWork WHERE workNum=" + num1 + " )");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where studentID not in(select stu_studentID from CompleteWork WHERE workNum=" + num1 + "  ) order by classNum)");
                }
                sb.Append(" order by classNum");

            }
        }


        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>编号</td><td>班级序号</td><td>姓名</td><td>班级</td><td>学号</td></tr>";

        string str = "<tr><td>{0}</td><td>{4}</td><td><a href=\"javascript:void(SearchStudent1({0}));\" title = '此学生交作业次数！'>{1}</a></td><td>{2}</td><td>{3}</td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"].ToString()) + "";
            list += string.Format(str, dt.Rows[i]["studentID"].ToString(),  dt.Rows[i]["nickname"].ToString(), DB.FindString(sql3), dt.Rows[i]["studyNum"].ToString(), dt.Rows[i]["classNum"].ToString());
           
        }
        list += "</table>";
       
        Response.Write(list + "<div id='pager'style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'>" + this.GetPagerWork(page, pageSize, count, 98) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void NoReCompleteWorkList1()   //教师信息
    {
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        string num = Server.UrlDecode(Request.QueryString["num"]);
        if (num == null) num = string.Empty;
        //过滤特殊符号，避免SQL注入
        num = num.Replace("'", "").Replace("\"", "");
        int num1 = 0;
        try { num1 = Convert.ToInt32(num); }
        catch (Exception e1) { }
        int count;
        StringBuilder sb = new StringBuilder("");
        if (num.ToString() == "")
        {
            if (Request["courseId"] != null)
            {
                if (Request["courseId"] == "")
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");

                    }
                    else
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and classId=" + Convert.ToInt32(Request["classId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and classId=" + Convert.ToInt32(Request["classId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%'AND isRemark=" + 0 + " and classId=" + Convert.ToInt32(Request["classId"]) + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                }
                else
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                    else
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                }
            }
            else
            {
                string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark="+0+"";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark="+0+"");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " order by completWorkID desc)");
                }
                sb.Append(" order by completWorkID desc");

            }
        }



        else
        {
            if (Request["courseId"] != null)
            {
                if (Request["courseId"] == "")
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " AND workNum=" + num1 + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " AND workNum=" + num1 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " AND workNum=" + num1 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");

                    }
                    else
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                }
                else
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                    else
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                }
            }
            else
            {
                string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " AND workNum=" + num1 + "";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " AND workNum=" + num1 + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND isRemark=" + 0 + " AND workNum=" + num1 + " order by completWorkID desc)");
                }
                sb.Append(" order by completWorkID desc");

            }
        }


        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>上传学生姓名</td><td>标题</td><td>上传时间</td><td>权限</td><td>课程名称</td><td>班级</td><td>作业次数</td><td>分数</td><td>批改时间</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td><a href=\"javascript:void(SearchStudent({9}));\" title = '交作业学生资料！'>{1}</a></td><td>{2}</td><td>{3}</td><td>{4}</td><td>{6}</td><td>{7}</td><td>{10}</td><td>{11}</td><td>{8}</td><td><a href = \"javascript:editCompleteStuWork({0},'{4}','{11}','{12}','{13}','{8}')\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},7,97));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT nickname FROM studentlist WHERE studentID = '" + dt.Rows[i]["stu_studentID"].ToString() + "'";
            string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
            string sqlClass = "SELECT name FROM class WHERE classId='" + dt.Rows[i]["classId"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["completWorkID"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), DB.FindString(sqlNewSteptContent), dt.Rows[i]["lookTime"].ToString(), DB.FindString(sqlCourse), DB.FindString(sqlClass), String.Format("{0:M}", dt.Rows[i]["remarkTime"]), dt.Rows[i]["stu_studentID"].ToString(), dt.Rows[i]["workNum"].ToString(), dt.Rows[i]["cord"].ToString(), dt.Rows[i]["workContent"].ToString(), dt.Rows[i]["workAdd"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager'style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(7,97)'/>" + this.GetPagerWork(page, pageSize, count, 97) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void CompleteWorkList1()   //教师信息
    {
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        string num = Server.UrlDecode(Request.QueryString["num"]);
        if (num == null) num = string.Empty;
        //过滤特殊符号，避免SQL注入
        num = num.Replace("'", "").Replace("\"", "");
        int num1 = 0;
        try { num1 = Convert.ToInt32(num); }
        catch (Exception e1) { }
        int count;
        StringBuilder sb = new StringBuilder("");
        if (num.ToString() == "")
        {
            if (Request["courseId"] != null)
            {
                if (Request["courseId"] == "")
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%'";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%'");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");

                    }
                    else
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' and classId=" + Convert.ToInt32(Request["classId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%'and classId=" + Convert.ToInt32(Request["classId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%'and classId=" + Convert.ToInt32(Request["classId"]) + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                }
                else
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                    else
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                }
            }
            else
            {
                string sql = "select count(*) from CompleteWork where title like N'%" + key + "%'";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%'");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' order by completWorkID desc)");
                }
                sb.Append(" order by completWorkID desc");

            }
        }



        else 
        {
            if (Request["courseId"] != null)
            {
                if (Request["courseId"] == "")
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND workNum="+num1+"";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND workNum=" + num1 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND workNum=" + num1 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");

                    }
                    else
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%'and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%'and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                }
                else
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " AND workNum=" + num1 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                    else
                    {
                        string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + "";
                        count = Convert.ToInt32(DB.FindString(sql));
                        //实现自定义的分页逻辑
                        sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + "");
                        //如果不是第一页
                        if (page > 1)
                        {
                            sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%'and Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + " and classId=" + Convert.ToInt32(Request["classId"]) + " AND workNum=" + num1 + " order by completWorkID desc)");
                        }
                        sb.Append(" order by completWorkID desc");
                    }
                }
            }
            else
            {
                string sql = "select count(*) from CompleteWork where title like N'%" + key + "%' AND workNum=" + num1 + "";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from CompleteWork where title like N'%" + key + "%' AND workNum=" + num1 + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and completWorkID not in(select top " + (pageSize * (page - 1)).ToString() + " completWorkID from CompleteWork where title like N'%" + key + "%' AND workNum=" + num1 + " order by completWorkID desc)");
                }
                sb.Append(" order by completWorkID desc");

            }
        }
       

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>上传学生姓名</td><td>标题</td><td>上传时间</td><td>权限</td><td>课程名称</td><td>班级</td><td>作业次数</td><td>分数</td><td>批改时间</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td><a href=\"javascript:void(SearchStudent({9}));\" title = '交作业学生资料！'>{1}</a></td><td>{2}</td><td>{3}</td><td>{4}</td><td>{6}</td><td>{7}</td><td>{10}</td><td>{11}</td><td>{8}</td><td><a href = \"javascript:editCompleteStuWork({0},'{4}','{11}','{12}','{13}','{8}')\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},7,67));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT nickname FROM studentlist WHERE studentID = '" + dt.Rows[i]["stu_studentID"].ToString() + "'";
            string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
            string sqlClass = "SELECT name FROM class WHERE classId='" + dt.Rows[i]["classId"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["completWorkID"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), String.Format("{0:M}", dt.Rows[i]["time"]), DB.FindString(sqlNewSteptContent), dt.Rows[i]["lookTime"].ToString(), DB.FindString(sqlCourse), DB.FindString(sqlClass), String.Format("{0:M}", dt.Rows[i]["remarkTime"]), dt.Rows[i]["stu_studentID"].ToString(), dt.Rows[i]["workNum"].ToString(), dt.Rows[i]["cord"].ToString(), dt.Rows[i]["workContent"].ToString(), dt.Rows[i]["workAdd"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager'style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(7,67)'/>&nbsp;&nbsp;&nbsp;&nbsp;" + this.GetPagerWork(page, pageSize, count, 67) + "&nbsp;&nbsp;&nbsp;&nbsp;<a href = 'javascript:GetPageWork11(1,102)'>导出成绩</a></div>" + "<div id = 'List2'></div>");
    }
    protected void GetStuCord()   //教师信息
    {

       
        string num = Server.UrlDecode(Request.QueryString["num"]);
        if (num == null) num = string.Empty;
        //过滤特殊符号，避免SQL注入
        num = num.Replace("'", "").Replace("\"", "");
        int num1 = 0;
        try { num1 = Convert.ToInt32(num); }
        catch (Exception e1) { }
      DataTable exceldt= new DataTable();
      DataColumn dc = new DataColumn("学号");//0
      exceldt.Columns.Add(dc);
      dc = new DataColumn("班级");//1
      exceldt.Columns.Add(dc);
      dc = new DataColumn("班级序号");//2
      exceldt.Columns.Add(dc);
      dc = new DataColumn("姓名");//3
      exceldt.Columns.Add(dc);
      dc = new DataColumn("课程");//4
      exceldt.Columns.Add(dc);
      dc = new DataColumn("作业次数");//5
      exceldt.Columns.Add(dc);
      dc = new DataColumn("成绩");//6
      exceldt.Columns.Add(dc);
        if (num.ToString() == "")
        {
           
            
                if (Request["courseId"] == "")
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "SELECT * FROM studentlist order by classNum";
                        System.Data.DataTable dt = DB.OpenQuery(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"]) + " AND isRemark=" + 1 + "";
                            DataTable dt1 = DB.OpenQuery(sql1);
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                string sql2 = "SELECT name FROM CourseList WHERE courseid=" + Convert.ToInt32(dt1.Rows[j]["Cou_courseid"]) + "";
                                string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"]) + "";
                                DataRow dr = exceldt.NewRow();
                                dr[0] = dt.Rows[i]["studyNum"].ToString(); dr[1] = DB.FindString(sql3).ToString(); dr[2] = dt.Rows[i]["classNum"].ToString(); dr[3] = dt.Rows[i]["nickname"].ToString(); dr[4] = DB.FindString(sql2); dr[5] = dt1.Rows[j]["workNum"].ToString(); dr[6] = dt1.Rows[j]["cord"].ToString();
                                exceldt.Rows.Add(dr);
                            }
                        }

                    }
                    else
                    {
                        string sql = "SELECT * FROM studentlist WHERE sclass=" + Convert.ToInt32(Request["classId"]) + " order by classNum";
                        System.Data.DataTable dt = DB.OpenQuery(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"]) + " AND isRemark=" + 1 + "";
                            DataTable dt1 = DB.OpenQuery(sql1);
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                string sql2 = "SELECT name FROM CourseList WHERE courseid=" + Convert.ToInt32(dt1.Rows[j]["Cou_courseid"]) + "";
                                string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"]) + "";
                                DataRow dr = exceldt.NewRow();
                                dr[0] = dt.Rows[i]["studyNum"].ToString(); dr[1] = DB.FindString(sql3).ToString(); dr[2] = dt.Rows[i]["classNum"].ToString(); dr[3] = dt.Rows[i]["nickname"].ToString(); dr[4] = DB.FindString(sql2); dr[5] = dt1.Rows[j]["workNum"].ToString(); dr[6] = dt1.Rows[j]["cord"].ToString();
                                exceldt.Rows.Add(dr);
                            }
                        }
                    }
                }
                else
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "SELECT * FROM studentlist order by classNum";
                        System.Data.DataTable dt = DB.OpenQuery(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"]) + " AND Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "AND isRemark=" + 1 + "";
                            DataTable dt1 = DB.OpenQuery(sql1);
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                string sql2 = "SELECT name FROM CourseList WHERE courseid=" + Convert.ToInt32(dt1.Rows[j]["Cou_courseid"]) + "";
                                string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"]) + "";
                                DataRow dr = exceldt.NewRow();
                                dr[0] = dt.Rows[i]["studyNum"].ToString(); dr[1] = DB.FindString(sql3).ToString(); dr[2] = dt.Rows[i]["classNum"].ToString(); dr[3] = dt.Rows[i]["nickname"].ToString(); dr[4] = DB.FindString(sql2); dr[5] = dt1.Rows[j]["workNum"].ToString(); dr[6] = dt1.Rows[j]["cord"].ToString();
                                exceldt.Rows.Add(dr);
                            }
                        }
                    }
                    else
                    {
                        string sql = "SELECT * FROM studentlist WHERE sclass=" + Convert.ToInt32(Request["classId"]) + " order by classNum";
                        System.Data.DataTable dt = DB.OpenQuery(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"]) + " AND Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "AND isRemark=" + 1 + "";
                            DataTable dt1 = DB.OpenQuery(sql1);
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                string sql2 = "SELECT name FROM CourseList WHERE courseid=" + Convert.ToInt32(dt1.Rows[j]["Cou_courseid"]) + "";
                                string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"]) + "";
                                DataRow dr = exceldt.NewRow();
                                dr[0] = dt.Rows[i]["studyNum"].ToString(); dr[1] = DB.FindString(sql3).ToString(); dr[2] = dt.Rows[i]["classNum"].ToString(); dr[3] = dt.Rows[i]["nickname"].ToString(); dr[4] = DB.FindString(sql2); dr[5] = dt1.Rows[j]["workNum"].ToString(); dr[6] = dt1.Rows[j]["cord"].ToString();
                                exceldt.Rows.Add(dr);
                            }
                        }
                    }
                }
           
           
        }



        else
        {
           
            
                if (Request["courseId"] == "")
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "SELECT * FROM studentlist order by classNum";
                        System.Data.DataTable dt = DB.OpenQuery(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"]) + " AND workNum=" + num1 + " AND isRemark=" + 1 + "";
                            DataTable dt1 = DB.OpenQuery(sql1);
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                string sql2 = "SELECT name FROM CourseList WHERE courseid=" + Convert.ToInt32(dt1.Rows[j]["Cou_courseid"]) + "";
                                string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"]) + "";
                                DataRow dr = exceldt.NewRow();
                                dr[0] = dt.Rows[i]["studyNum"].ToString(); dr[1] = DB.FindString(sql3).ToString(); dr[2] = dt.Rows[i]["classNum"].ToString(); dr[3] = dt.Rows[i]["nickname"].ToString(); dr[4] = DB.FindString(sql2); dr[5] = dt1.Rows[j]["workNum"].ToString(); dr[6] = dt1.Rows[j]["cord"].ToString();
                                exceldt.Rows.Add(dr);
                            }
                        }
                    }
                    else
                    {
                        string sql = "SELECT * FROM studentlist WHERE sclass=" + Convert.ToInt32(Request["classId"]) + " order by classNum";
                        System.Data.DataTable dt = DB.OpenQuery(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"]) + " AND workNum=" + num1 + " AND isRemark=" + 1 + "";
                            DataTable dt1 = DB.OpenQuery(sql1);
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                string sql2 = "SELECT name FROM CourseList WHERE courseid=" + Convert.ToInt32(dt1.Rows[j]["Cou_courseid"]) + "";
                                string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"]) + "";
                                DataRow dr = exceldt.NewRow();
                                dr[0] = dt.Rows[i]["studyNum"].ToString(); dr[1] = DB.FindString(sql3).ToString(); dr[2] = dt.Rows[i]["classNum"].ToString(); dr[3] = dt.Rows[i]["nickname"].ToString(); dr[4] = DB.FindString(sql2); dr[5] = dt1.Rows[j]["workNum"].ToString(); dr[6] = dt1.Rows[j]["cord"].ToString();
                                exceldt.Rows.Add(dr);
                            }
                        }
                    }
                }
                else
                {
                    if (Request["classId"] == "")
                    {
                        string sql = "SELECT * FROM studentlist order by classNum";
                        System.Data.DataTable dt = DB.OpenQuery(sql);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"]) + " AND workNum=" + num1 + " AND Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "AND isRemark=" + 1 + "";
                            DataTable dt1 = DB.OpenQuery(sql1);
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                string sql2 = "SELECT name FROM CourseList WHERE courseid=" + Convert.ToInt32(dt1.Rows[j]["Cou_courseid"]) + "";
                                string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"]) + "";
                                DataRow dr = exceldt.NewRow();
                                dr[0] = dt.Rows[i]["studyNum"].ToString(); dr[1] = DB.FindString(sql3).ToString(); dr[2] = dt.Rows[i]["classNum"].ToString(); dr[3] = dt.Rows[i]["nickname"].ToString(); dr[4] = DB.FindString(sql2); dr[5] = dt1.Rows[j]["workNum"].ToString(); dr[6] = dt1.Rows[j]["cord"].ToString();
                                exceldt.Rows.Add(dr);
                            }
                        }
                    }
                    else
                    {
                        string sql = "SELECT * FROM studentlist WHERE sclass=" + Convert.ToInt32(Request["classId"]) + " order by classNum";
                         System.Data.DataTable dt = DB.OpenQuery(sql);
                         for (int i = 0; i < dt.Rows.Count; i++)
                         {
                             string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(dt.Rows[i]["studentID"]) + " AND workNum=" + num1 + " AND Cou_courseid=" + Convert.ToInt32(Request["courseId"]) + "AND isRemark="+1+"";
                             DataTable dt1 = DB.OpenQuery(sql1);
                             for (int j = 0; j < dt1.Rows.Count; j++)
                             {
                                 string sql2 = "SELECT name FROM CourseList WHERE courseid=" + Convert.ToInt32(dt1.Rows[j]["Cou_courseid"]) + "";
                                 string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"]) + "";
                                 DataRow dr = exceldt.NewRow();
                                 dr[0] = dt.Rows[i]["studyNum"].ToString(); dr[1] = DB.FindString(sql3).ToString(); dr[2] = dt.Rows[i]["classNum"].ToString(); dr[3] = dt.Rows[i]["nickname"].ToString(); dr[4] = DB.FindString(sql2); dr[5] = dt1.Rows[j]["workNum"].ToString(); dr[6] = dt1.Rows[j]["cord"].ToString();
                                 exceldt.Rows.Add(dr);
                             }
                         }
                    }
                }
          
        }
        try
        {
            ExcelHelper ex = new ExcelHelper();
            //导入所有！（从第一行第一列开始）
            ex.DataTableToExcel(exceldt, 1, 1);
            //导出Excel保存的路径！
            ex.OutputFilePath = "/lwhPersonal/uploads/excel/";
            ex.OutputExcelFile();
            //Response.Write("导出成功!");
        }
        catch { Response.Write("导出成功!"); }
      
    }
    public string GetPagerWork(int page, int pageSize, int count, int type)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 10) * 10 + 1;

        for (int i = start; i <= pageCount && i < start + 10; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:GetPageWork(" + i + "," + type + ")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:GetPageWork(" + (start - 1).ToString() + "," + type + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:GetPageWork(" + (1).ToString() + "," + type + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 10 < pageCount)
        {
            sb.Append("<a href='javascript:GetPageWork(" + (start + 10).ToString() + "," + type + ")' title='第" + (start + 10).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:GetPageWork(" + pageCount.ToString() + "," + type + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    protected void Subject()
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>标题关键字：<input type='text' id='title'/>	";
        string check1 = "知识类型：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM SubjectType ORDER BY subTypeID DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["subTypeID"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        search += check1;
        search += "<input type='button' value='查询' onclick='javascript:GetPage(1,53)'/></td></tr></table>";
        Response.Write(search);

    }
    protected void Subject1()
    {
        StringBuilder sb = new StringBuilder("");
        int count;
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        if (Request["key1"] != null)
        {
            if (Request["key1"] == "")
            {
                string sql = "select count(*) from SubjectList where title like N'%" + key + "%'";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from SubjectList where title like N'%" + key + "%'");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and subjectID not in(select top " + (pageSize * (page - 1)).ToString() + " subjectID from SubjectList where title like N'%" + key + "%' order by subjectID desc)");
                }
                sb.Append(" order by subjectID desc");
            }
            else
            {
                string sql = "select count(*) from SubjectList where title like N'%" + key + "%' and Sub_subTypeID=" + Convert.ToInt32(Request["key1"]) + "";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from SubjectList where title like N'%" + key + "%' and Sub_subTypeID=" + Convert.ToInt32(Request["key1"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and subjectID not in(select top " + (pageSize * (page - 1)).ToString() + " subjectID from SubjectList where title like N'%" + key + "%' and Sub_subTypeID=" + Convert.ToInt32(Request["key1"]) + " order by subjectID desc)");
                }
                sb.Append(" order by subjectID desc");
            }
        }
        else
        {
            string sql = "select count(*) from SubjectList where title like N'%" + key + "%'";
            count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
            sb.Append("select top " + pageSize.ToString() + " * from SubjectList where title like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and subjectID not in(select top " + (pageSize * (page - 1)).ToString() + " subjectID from SubjectList where title like N'%" + key + "%' order by subjectID desc)");
            }
            sb.Append(" order by subjectID desc");
        }
       

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属分类</td><td>标题</td><td>上传时间</td><td>权限</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href = \"javascript:edititOpenWin({0},'{1}','{2}','{4}',5);\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},5,53));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT name FROM SubjectType WHERE subTypeID = '" + dt.Rows[i]["Sub_subTypeID"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["subjectID"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent), dt.Rows[i]["content"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px' id='pager'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(5,53)'/>" + this.GetPager(page, pageSize, count, 53) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void ResourcesList()
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>标题关键字：<input type='text' id='title'/>	";
        string check1 = "资源类型：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM RescourcesType ORDER BY resourcestypeid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["resourcestypeid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        search += check1;
        search += "<input type='button' value='查询' onclick='javascript:GetPage(1,50)'/></td></tr></table>";
        Response.Write(search);

    }
    protected void ResourcesList1()
    {
        StringBuilder sb = new StringBuilder("");
        int count;
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        if (Request["key1"] != null)
        {
            if (Request["key1"] == "")
            {
                string sql = "select count(*) from ResourcesList where title like N'%" + key + "%'";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from ResourcesList where title like N'%" + key + "%'");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and resourcesID not in(select top " + (pageSize * (page - 1)).ToString() + " resourcesID from ResourcesList where title like N'%" + key + "%' order by resourcesID desc)");
                }
                sb.Append(" order by resourcesID desc");
            }
            else
            {
                string sql = "select count(*) from ResourcesList where title like N'%" + key + "%' and Res_resourcestypeid=" + Convert.ToInt32(Request["key1"]) + "";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from ResourcesList where title like N'%" + key + "%' and Res_resourcestypeid=" + Convert.ToInt32(Request["key1"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and resourcesID not in(select top " + (pageSize * (page - 1)).ToString() + " resourcesID from ResourcesList where title like N'%" + key + "%' and Res_resourcestypeid=" + Convert.ToInt32(Request["key1"]) + " order by resourcesID desc)");
                }
                sb.Append(" order by resourcesID desc");
            }
        }
        else
        {
            string sql = "select count(*) from ResourcesList where title like N'%" + key + "%'";
             count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
             sb.Append("select top " + pageSize.ToString() + " * from ResourcesList where title like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and resourcesID not in(select top " + (pageSize * (page - 1)).ToString() + " resourcesID from ResourcesList where title like N'%" + key + "%' order by resourcesID desc)");
            }
            sb.Append(" order by resourcesID desc");
        }
       

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属分类</td><td>标题</td><td>上传时间</td><td>权限</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href = \"javascript:edititOpenWin({0},'{1}','{2}','{4}',4);\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},4,50));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT name FROM RescourcesType WHERE resourcestypeid = '" + dt.Rows[i]["Res_resourcestypeid"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["resourcesID"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent), dt.Rows[i]["content"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager'style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(4,50)'/>" + this.GetPager(page, pageSize, count, 50) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void GetTeachList()   //教师信息
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>标题关键字：<input type='text' id='title'/>	";
        string check1 = "教师信息类型：<select id='select3'><option value=''>请选择</option>";
        string str = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt;
        dt = DB.OpenQuery("SELECT * FROM TeachParkType ORDER BY teachtypeid DESC");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            check1 += string.Format(str, dt.Rows[i]["teachtypeid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        check1 += " </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        string check2 = "课程：<select id='select4'><option value=''>请选择</option>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM CourseList ORDER BY courseid DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["courseid"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        check1 += check2;
        search += check1;
        search += "<input type='button' value='查询' onclick='javascript:GetPage(1,24)'/></td></tr></table>";
        Response.Write(search);
    }
    protected void GetTeachList1()   //教师信息
    {
      StringBuilder sb = new StringBuilder("");
        int count;
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        if (Request["key2"] != null)
        {
            if (Request["key1"] == "")
            {
                if (Request["key2"] == "")
                {
                    string sql = "select count(*) from TeachPark where title like N'%" + key + "%'";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from TeachPark where title like N'%" + key + "%'");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and teachParkID not in(select top " + (pageSize * (page - 1)).ToString() + " teachParkID from TeachPark where title like N'%" + key + "%' order by teachParkID desc)");
                    }
                    sb.Append(" order by teachParkID desc");
                }
                else
                {
                    string sql = "select count(*) from TeachPark where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key2"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from TeachPark where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key2"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and teachParkID not in(select top " + (pageSize * (page - 1)).ToString() + " teachParkID from TeachPark where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key2"]) + " order by teachParkID desc)");
                    }
                    sb.Append(" order by teachParkID desc");
                }
               
            }
            else
            {
                if (Request["key2"] == "")
                {
                    string sql = "select count(*) from TeachPark where title like N'%" + key + "%' and Tea_teachtypeid=" + Convert.ToInt32(Request["key1"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from TeachPark where title like N'%" + key + "%' and Tea_teachtypeid=" + Convert.ToInt32(Request["key1"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and teachParkID not in(select top " + (pageSize * (page - 1)).ToString() + " teachParkID from TeachPark where title like N'%" + key + "%' and Tea_teachtypeid=" + Convert.ToInt32(Request["key1"]) + " order by teachParkID desc)");
                    }
                    sb.Append(" order by teachParkID desc");
                }
                else
                {
                    string sql = "select count(*) from TeachPark where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key2"]) + " and Tea_teachtypeid=" + Convert.ToInt32(Request["key1"]) + "";
                    count = Convert.ToInt32(DB.FindString(sql));
                    //实现自定义的分页逻辑
                    sb.Append("select top " + pageSize.ToString() + " * from TeachPark where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key2"]) + " and Tea_teachtypeid=" + Convert.ToInt32(Request["key1"]) + "");
                    //如果不是第一页
                    if (page > 1)
                    {
                        sb.Append(" and teachParkID not in(select top " + (pageSize * (page - 1)).ToString() + " teachParkID from TeachPark where title like N'%" + key + "%' and Cou_courseid=" + Convert.ToInt32(Request["key2"]) + " and Tea_teachtypeid=" + Convert.ToInt32(Request["key1"]) + " order by teachParkID desc)");
                    }
                    sb.Append(" order by teachParkID desc");
                }
            }
        }
        else
        {
            string sql = "select count(*) from TeachPark where title like N'%" + key + "%'";
          count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
          sb.Append("select top " + pageSize.ToString() + " * from TeachPark where title like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and teachParkID not in(select top " + (pageSize * (page - 1)).ToString() + " teachParkID from TeachPark where title like N'%" + key + "%' order by teachParkID desc)");
            }
            sb.Append(" order by teachParkID desc");
        }
      

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>所属分类</td><td>标题</td><td>上传时间</td><td>权限</td><td>课程名称</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{6}</td><td><a href = \"javascript:edititcourseOpenWin({0},'{1}','{2}','{4}','{6}',1);\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},1,24));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            string sqlnewtypecontent = "SELECT name FROM TeachParkType WHERE teachtypeid = '" + dt.Rows[i]["Tea_teachtypeid"].ToString() + "'";
            string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt.Rows[i]["Cou_courseid"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["teachParkID"].ToString(), DB.FindString(sqlnewtypecontent), dt.Rows[i]["title"].ToString().Length > 15 ? dt.Rows[i]["title"].ToString().Substring(0, 15) + "..." : dt.Rows[i]["title"].ToString(), dt.Rows[i]["time"].ToString(), DB.FindString(sqlNewSteptContent), dt.Rows[i]["content"].ToString(), DB.FindString(sqlCourse));
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px' id='pager'> <input type='button' value='删除选中项' onclick='javascript:DelItSelect(1,24)'/>" + this.GetPager(page, pageSize, count, 24) + "</div>" + "<div id = 'List2'></div>");
    }
    protected void Student()   //学生信息
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>学生姓名关键字：<input type='text' id='title'/>";
        string check2 = "班级:<select id='select3'><option value=''>请选择</option>";
        string str1 = "<option value='{0}'>{1}</option>";
        System.Data.DataTable dt1;
        dt1 = DB.OpenQuery("SELECT * FROM class ORDER BY classId DESC");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            check2 += string.Format(str1, dt1.Rows[i]["classId"].ToString(), dt1.Rows[i]["name"].ToString());
        }
        check2 += " </select>";
        search += check2;
        search += "<input type='button' value='查询' onclick='javascript:GetPage(1,56)'/><input id='workNum' style ='display :none' type='text' /><select id='select4' style ='display :none'><option value=''>请选择</option> </select></td></tr></table>";
        Response.Write(search);
    }
    protected void Student1()   //学生信息
    {
       StringBuilder sb = new StringBuilder("");
        int count;
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        if (Request["key1"] != null)
        {
            if (Request["key1"] == "")
            {
                string sql = "select count(*) from studentlist where nickname like N'%" + key + "%'";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from studentlist where nickname like N'%" + key + "%'");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where nickname like N'%" + key + "%' order by classNum)");
                }
                sb.Append(" order by classNum");
            }
            else
            {
                string sql = "select count(*) from studentlist where nickname like N'%" + key + "%' and sclass="+Convert.ToInt32(Request["key1"])+"";
                count = Convert.ToInt32(DB.FindString(sql));
                //实现自定义的分页逻辑
                sb.Append("select top " + pageSize.ToString() + " * from studentlist where nickname like N'%" + key + "%' and sclass=" + Convert.ToInt32(Request["key1"]) + "");
                //如果不是第一页
                if (page > 1)
                {
                    sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where nickname like N'%" + key + "%' and sclass=" + Convert.ToInt32(Request["key1"]) + " order by classNum)");
                }
                sb.Append(" order by classNum");
            }
        }
        else
        {
            string sql = "select count(*) from studentlist where nickname like N'%" + key + "%'";
            count = Convert.ToInt32(DB.FindString(sql));
            //实现自定义的分页逻辑
            sb.Append("select top " + pageSize.ToString() + " * from studentlist where nickname like N'%" + key + "%'");
            //如果不是第一页
            if (page > 1)
            {
                sb.Append(" and studentID not in(select top " + (pageSize * (page - 1)).ToString() + " studentID from studentlist where nickname like N'%" + key + "%' order by classNum)");
            }
            sb.Append(" order by classNum");
        }
      

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>班级序号</td><td>姓名</td><td>班级</td><td>学号</td><td>帐号</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{6}</td><td><a href=\"javascript:void(SearchStudent1({0}));\" title = '此学生交作业次数！'>{2}</a></td><td>{4}</td><td>{5}</td><td>{1}</td><td><a href=\"javascript:EditStudent({0},'{1}','{2}','{3}','{4}','{5}',{6});\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},31,56));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sql3 = "SELECT name FROM class WHERE classId=" + Convert.ToInt32(dt.Rows[i]["sclass"].ToString()) + "";
            list += string.Format(str, dt.Rows[i]["studentID"].ToString(), dt.Rows[i]["name"].ToString(), dt.Rows[i]["nickname"].ToString(), dt.Rows[i]["password"].ToString(), DB.FindString(sql3),  dt.Rows[i]["studyNum"].ToString(), dt.Rows[i]["classNum"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "<tr><td><img src = '../images/add.gif'onclick = 'javascript:AddStudent();' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href = 'javascript:openWinAddStu()'>添加(外部Excel导入)</a></td></tr></table>";
        //list += "";
        Response.Write(list + "<div id='pager' style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836px'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(31,56)'/>" + this.GetPager(page, pageSize, count, 56) + "</div><div id = 'List2'></div>");
    }
    protected void NetUser()   //学生信息
    {
        string search = "<table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>会员标题关键字：<input type='text' id='title'/>	<input type='button' value='查询' onclick='javascript:GetPage(1,71)'/></td></tr></table>";
        Response.Write(search);
    }
    protected void NetUser1()   //学生信息
    {
        int pageSize = 15;//定义每页需要显示的记录数
        //获取查询字符串表示的页数，默认为1
        int page = 1;
        //利用异常机制确保转换string到int类型不会出错
        try
        {
            page = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch (Exception e1) { }

        //获得查询条件
        string key = Server.UrlDecode(Request.QueryString["key"]);
        if (key == null) key = string.Empty;
        //过滤特殊符号，避免SQL注入
        key = key.Replace("'", "").Replace("\"", "");
        string sql = "select count(*) from NetUser where name like N'%" + key + "%'";
        int count = Convert.ToInt32(DB.FindString(sql));
        //实现自定义的分页逻辑
        StringBuilder sb = new StringBuilder("select top " + pageSize.ToString() + " * from NetUser where name like N'%" + key + "%'");
        //如果不是第一页
        if (page > 1)
        {
            sb.Append(" and userid not in(select top " + (pageSize * (page - 1)).ToString() + " userid from NetUser where name like N'%" + key + "%' order by userid desc)");
        }
        sb.Append(" order by userid desc");

        //string search = "<div>标题关键字：<input type='text' id='title' name='title'/>	<input type='button' value='查询' onclick='getPage(1)'/></div>";
        System.Data.DataTable dt = DB.OpenQuery(sb.ToString());
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>全选<input id='checkAll' onclick = 'javascript:CheckAll();' type='checkbox' /></td><td>编号</td><td>帐号</td><td>姓名</td><td>密码</td><td>邮箱地址</td><td>会员权限</td><td>操作</td></tr>";

        string str = "<tr><td><input id='Checkbox1' value = '{0}' type='checkbox' /></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td><a href=\"javascript:EditNetUser({0},'{5}');\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(Del({0},9,71));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sqlNewSteptContent = "SELECT name FROM TypeValueList WHERE steptid = '" + dt.Rows[i]["Typ_steptid"].ToString() + "'";
            list += string.Format(str, dt.Rows[i]["userid"].ToString(), dt.Rows[i]["name"].ToString(), dt.Rows[i]["nickname"].ToString(), dt.Rows[i]["spassword1"].ToString(), dt.Rows[i]["usermail"].ToString(),DB.FindString(sqlNewSteptContent));
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        //list += "";
        Response.Write(list + "<div id='pager' style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 836x'><input type='button' value='删除选中项' onclick='javascript:DelItSelect(9,71)'/>" + this.GetPager(page, pageSize, count, 71) + "</div><div id = 'List2'></div>");
    }
    //新闻类型列表
    //protected void newsTypeList()
    //{
    //    string sql = "SELECT * FROM NewsType ORDER BY newstypeid";
    //    System.Data.DataTable dt = DB.OpenQuery(sql);
    //    string str = "<tr><td>{0}</td><td>{1}</td><td><a href=\"javascript:void(EditNewsType({0},'{1}'));\">编辑</a>||<a href=\"javascript:void(DelNewsType({0}));\">删除</a></td></tr>";
    //    string list = " <table style='width: 35%; margin-top: 0px;' bgcolor='#FFFFCC'><tr><td>编号</td><td>名字</td><td>操作</td></tr>";
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        list += string.Format(str, dt.Rows[i]["newstypeid"].ToString(), dt.Rows[i]["content"].ToString());
    //        // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
    //    }
    //    list += "<tr><td><input id='btnAddNewsType'value = '添加' type='button' onclick = 'javascript:AddNewsType();' /></td></tr></table>";
    //    list += "<div id = 'editNewsType'></div>";
    //    Response.Write(list);
    //}
    protected void ClassList()
    {
        string sql = "SELECT * FROM class ORDER BY classId";
        System.Data.DataTable dt = DB.OpenQuery(sql);
        string str = "<tr><td>{0}</td><td>{1}</td><td><a href=\"javascript:void(EditClassList({0},'{1}'));\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(DelClassList({0}));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>编号</td><td>名字</td><td>操作</td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i]["classId"].ToString(), dt.Rows[i]["name"].ToString());
        }
        list += "<tr><td><img src = '../images/add.gif' onclick = 'javascript:AddClass();' /></td></tr></table>";
        list += "<div id = 'divDoClass'></div>";
        Response.Write(list);
    }
    protected void CourseList()
    {
        string sql = "SELECT * FROM CourseList ORDER BY courseid";
        System.Data.DataTable dt = DB.OpenQuery(sql);
        string str = "<tr><td>{0}</td><td>{1}</td><td><a href=\"javascript:void(EditCourseList({0},'{1}'));\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(DelCourseList({0}));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>编号</td><td>名字</td><td>操作</td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i]["courseid"].ToString(), dt.Rows[i]["name"].ToString());
        }
        list += "<tr><td><img src = '../images/add.gif' onclick = 'javascript:AddCourse();' /></td></tr></table>";
        list += "<div id = 'divDoCourse'></div>";
        Response.Write(list);
    }
    //教师信息类型列表
    //protected void GetTeachType()
    //{
    //    string sql = "SELECT * FROM TeachParkType ORDER BY teachtypeid";
    //    System.Data.DataTable dt = DB.OpenQuery(sql);
    //    string str = "<tr><td>{0}</td><td>{1}</td><td><a href=\"javascript:void(EditTeachType({0},'{1}'));\">编辑</a>||<a href=\"javascript:void(DelTeachType({0}));\">删除</a></td></tr>";
    //    string list = " <table style='width: 35%; margin-top: 0px;' bgcolor='#FFFFCC'><tr><td>编号</td><td>名字</td><td>操作</td></tr>";
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        list += string.Format(str, dt.Rows[i]["teachtypeid"].ToString(), dt.Rows[i]["name"].ToString());
    //        // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
    //    }
    //    list += "<tr><td><input id='btnAddTeachType'value = '添加' type='button' onclick = 'javascript:AddTeachType();' /></td></tr></table>";
    //    list += "<div id = 'editTeachType'></div>";
    //    Response.Write(list);
    //}
    protected void GetTypeList()
    {
       
        string sql = "", id = "";
        switch (Request.QueryString["park"])
        {
            case "0": sql = "SELECT * FROM NewsType ORDER BY newstypeid"; id = "newstypeid"; break;
            case "1": sql = "SELECT * FROM TeachParkType ORDER BY teachtypeid"; id = "teachtypeid"; break;
            case "2": sql = "SELECT * FROM researchType ORDER BY researchTypeId"; id = "researchTypeId"; break;
            case "4": sql = "SELECT * FROM RescourcesType ORDER BY resourcestypeid"; id = "resourcestypeid"; break;
            case "5": sql = "SELECT * FROM SubjectType ORDER BY subTypeID"; id = "subTypeID"; break;
            case "3": sql = "SELECT * FROM TeacherUpType ORDER BY teachUpTypeID"; id = "teachUpTypeID"; break;
            case "8": sql = "SELECT * FROM pass ORDER BY passId"; id = "passId"; break;
            case "10": sql = "SELECT * FROM TypeValueList ORDER BY steptid"; id = "steptid"; break;
        }

        System.Data.DataTable dt = DB.OpenQuery(sql);
        string str = "<tr><td>{0}</td><td>{1}</td><td><a href=\"javascript:void(EditType({0},'{1}',{2}));\"><img src = '../Images/edit.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a><a href=\"javascript:void(DelType({0},{2}));\"><img src = '../Images/del.gif'style='border-style: solid none none none; border-width: 0px 0px 0px 0px; border-color: #FFFFFF'/></a></td></tr>";
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>编号</td><td>名字</td><td>操作</td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list += string.Format(str, dt.Rows[i][id].ToString(), dt.Rows[i]["name"].ToString(), Request.QueryString["park"]);
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "<tr><td><img src = '../Images/add.gif' onclick = 'javascript:AddType(" + Request.QueryString["park"] + ");' /></td></tr></table>";
        list += "<div id = 'editType'></div><input id='title' style ='display :none' type='text' /><input id='workNum' style ='display :none' type='text' />";
        Response.Write(list);
    }
    protected void SearchStudent()
    {
        string sql = "SELECT studentID,nickname,sclass,studyNum ,classNum FROM studentlist WHERE studentID="+Convert.ToInt32(Request["studentId"])+"";
        System.Data.DataTable dt = DB.OpenQuery(sql);
        string str = "<tr><td>{0}</td><td>{4}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>";
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>编号</td><td>班级序号</td><td>名字</td><td>班级</td><td>学号</td></tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sql1 = "select name from class where classId = "+Convert.ToInt32(dt.Rows[i]["sclass"])+"";
            list += string.Format(str, dt.Rows[i]["studentID"].ToString(), dt.Rows[i]["nickname"].ToString(), DB.FindString(sql1), dt.Rows[i]["studyNum"].ToString(), dt.Rows[i]["classNum"].ToString());
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        Response.Write(list);
    }
    protected void SearchStudent1()
    {
        string sql = "SELECT * FROM studentlist WHERE studentId=" + Convert.ToInt32(Request["studentId"]) + "";
       
        string sql2 = "SELECT * FROM CourseList ORDER BY courseid";
        System.Data.DataTable dt = DB.OpenQuery(sql);
        System.Data.DataTable dt1 = DB.OpenQuery(sql2);
        string str = "<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>";
        string list = " <table style='background-image: url(../Images/%E8%83%8C%E6%99%AF.jpg);border-style: solid;margin-top: 0px; border-width: 0px 2px 1px 2px; border-color: #99CCFF; width: 840px'><tr><td>名字</td><td>课程</td><td>交作业次数</td></tr>";
       
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            string sql1 = "SELECT count(*) FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(Request["studentId"]) + " AND Cou_courseid=" + Convert.ToInt32(dt1.Rows[i]["courseid"].ToString()) + "";

            string sqlCourse = "SELECT name FROM CourseList WHERE courseid = '" + dt1.Rows[i]["courseid"].ToString() + "'";
            list += string.Format(str, dt.Rows[0]["nickname"].ToString(), DB.FindString(sqlCourse), Convert.ToInt32(DB.FindString(sql1)));
            // list += "<tr><td><input id='checkit' type='checkbox' /></td><td>" + dt.Rows[i]["newsid"].ToString() + "</td><td>" + dt.Rows[i]["New_newstypeid"].ToString() + "</td><td>" + dt.Rows[i]["title"].ToString() + "</td><td>" + dt.Rows[i]["time"].ToString() + "</td><td><a href='javascript:EditNews(" + dt.Rows[i]["newsid"].ToString() + "," + dt.Rows[i]["New_newstypeid"].ToString() + ",'" + dt.Rows[i]["title"].ToString() + "'," + dt.Rows[i]["Typ_steptid"].ToString() + "," + dt.Rows[i]["content"].ToString() + ")'>编辑</a>||<a href=\"javascript:void(DelNews(" + dt.Rows[i]["newsid"].ToString() + "));\">删除</a></td></tr>";
        }
        list += "</table>";
        Response.Write(list);
    }
    //获得分页代码
    //public string genPager(int page, int pageSize, int count)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    int pageCount = (int)Math.Ceiling((double)count / pageSize);
    //    int start = ((page - 1) / 10) * 10 + 1;

    //    for (int i = start; i <= pageCount && i < start + 10; i++)
    //    {
    //        if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
    //        else sb.Append("<a href='javascript:getPage("+i+")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
    //    }

    //    if (start > 1)
    //    {
    //        sb.Insert(0, "<a href='javascript:getPage(" + (start - 1).ToString() + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
    //        sb.Insert(0, "<a href='javascript:getPage(" + (1).ToString() + ")' title='首页'>|&lt;&lt;</a>");
    //    }

    //    if (start + 10 < pageCount)
    //    {
    //        sb.Append("<a href='javascript:getPage(" + (start + 10).ToString() + ")' title='第" + (start + 10).ToString() + "页'>&gt;&gt;</a>");
    //        sb.Append("<a href='javascript:getPage(" + pageCount.ToString() + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
    //    }

    //    return sb.ToString();
    //}
    //public string GetTeachPager(int page, int pageSize, int count)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    int pageCount = (int)Math.Ceiling((double)count / pageSize);
    //    int start = ((page - 1) / 10) * 10 + 1;

    //    for (int i = start; i <= pageCount && i < start + 10; i++)
    //    {
    //        if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
    //        else sb.Append("<a href='javascript:GetTeachPage(" + i + ")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
    //    }

    //    if (start > 1)
    //    {
    //        sb.Insert(0, "<a href='javascript:GetTeachPage(" + (start - 1).ToString() + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
    //        sb.Insert(0, "<a href='javascript:GetTeachPage(" + (1).ToString() + ")' title='首页'>|&lt;&lt;</a>");
    //    }

    //    if (start + 10 < pageCount)
    //    {
    //        sb.Append("<a href='javascript:GetTeachPage(" + (start + 10).ToString() + ")' title='第" + (start + 10).ToString() + "页'>&gt;&gt;</a>");
    //        sb.Append("<a href='javascript:GetTeachPage(" + pageCount.ToString() + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
    //    }

    //    return sb.ToString();
    //}
    public string GetPager1(int page, int pageSize, int count, int type,int id)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 10) * 10 + 1;

        for (int i = start; i <= pageCount && i < start + 10; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:GetPage1(" + id + "," + i + "," + type + ")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:GetPage1(" + id + "," + (start - 1).ToString() + "," + type + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:GetPage1(" + id + "," + (1).ToString() + "," + type + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 10 < pageCount)
        {
            sb.Append("<a href='javascript:GetPage1(" + id + "," + (start + 10).ToString() + "," + type + ")' title='第" + (start + 10).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:GetPage1(" + id + "," + pageCount.ToString() + "," + type + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    public string GetPager(int page, int pageSize, int count,int type)
    {
        StringBuilder sb = new StringBuilder();
        int pageCount = (int)Math.Ceiling((double)count / pageSize);
        int start = ((page - 1) / 10) * 10 + 1;

        for (int i = start; i <= pageCount && i < start + 10; i++)
        {
            if (i == page) sb.Append("<span title='当前页'>[" + i.ToString() + "]</span>");
            else sb.Append("<a href='javascript:GetPage(" + i + ","+type+")' title='第" + i.ToString() + "页'>[" + i.ToString() + "]&nbsp;&nbsp;</a>");
        }

        if (start > 1)
        {
            sb.Insert(0, "<a href='javascript:GetPage(" + (start - 1).ToString() + "," + type + ")' title='第" + (start - 1).ToString() + "页'>&lt;&lt;&nbsp;&nbsp;</a>");
            sb.Insert(0, "<a href='javascript:GetPage(" + (1).ToString() + "," + type + ")' title='首页'>|&lt;&lt;</a>");
        }

        if (start + 10 < pageCount)
        {
            sb.Append("<a href='javascript:GetPage(" + (start + 10).ToString() + "," + type + ")' title='第" + (start + 10).ToString() + "页'>&gt;&gt;</a>");
            sb.Append("<a href='javascript:GetPage(" + pageCount.ToString() + "," + type + ")' title='第" + pageCount.ToString() + "页（末页）'>&gt;&gt;|</a>");
        }

        return sb.ToString();
    }
    //protected void DelNews()
    //{
    //    string sql = "DELETE FROM NewsList WHERE newsid = "+Convert.ToInt32(Request["id"]);
    //    DB.execnonsql(sql);
    //    Response.Write("删除成功！");
    //}
    //protected void DelTeachPark() //删除教师信息
    //{
    //    string sql = "DELETE FROM TeachPark WHERE teachParkID = " + Convert.ToInt32(Request["id"]);
    //    DB.execnonsql(sql);
    //    Response.Write("删除成功！");
    //}
    protected void Del() //删除信息
    {
        string sql = "";
        switch (Request.QueryString["park"])
        {
            case "0": sql = "DELETE FROM NewsList WHERE newsid = " + Convert.ToInt32(Request["id"]); break;
            case "1": sql = "DELETE FROM TeachPark WHERE teachParkID = " + Convert.ToInt32(Request["id"]); break;
            case "2": sql = "DELETE FROM ResearchList WHERE researchId = " + Convert.ToInt32(Request["id"]); break;
            case "4": sql = "DELETE FROM ResourcesList WHERE resourcesID = " + Convert.ToInt32(Request["id"]); break;
            case "5": sql = "DELETE FROM SubjectList WHERE subjectID = " + Convert.ToInt32(Request["id"]); break;
            case "31": sql = "DELETE FROM studentlist WHERE studentID = " + Convert.ToInt32(Request["id"]); break;
            case "3": sql = "DELETE FROM TeacherUpFileWorkList WHERE TeacherUpWorkID = " + Convert.ToInt32(Request["id"]); break;
            case "6": sql = "DELETE FROM StuUpFIleList WHERE upId = " + Convert.ToInt32(Request["id"]); break;
            case "7": sql = "DELETE FROM CompleteWork WHERE completWorkID = " + Convert.ToInt32(Request["id"]); break;
            case "9": sql = "DELETE FROM NetUser WHERE userid = " + Convert.ToInt32(Request["id"]); break;
            case "11": sql = "DELETE FROM ForumQuestion WHERE questionid = " + Convert.ToInt32(Request["id"]); break;
            case "12": sql = "DELETE FROM ForumAnswer WHERE answerid = " + Convert.ToInt32(Request["id"]); break;
            case "22": sql = "DELETE FROM workNumId WHERE workNumId = " + Convert.ToInt32(Request["id"]); break;
            case "10": sql = "DELETE FROM stuWorkList WHERE upWorkId = " + Convert.ToInt32(Request["id"]); break;
        }

        try
        {
            DB.execnonsql(sql);
            Response.Write("<font color='red'> 删除成功！<font>");
        }
        catch
        {
            Response.Write("<font color='red'> 请先删除与此项关联的信息！(学生上传资料，作业，作业次数或论坛回复)<font>");
        }
    }
    //protected void DelNewsType()
    //{
    //    string sql = "DELETE FROM NewsType WHERE newstypeid = " + Convert.ToInt32(Request["id"]);
    //    DB.execnonsql(sql);
    //    Response.Write("删除成功！");
    //}
    protected void DelType()
    {
        string sql = "";
        switch (Request.QueryString["park"])
        {
            case "0": sql = "DELETE FROM NewsType WHERE newstypeid = " + Convert.ToInt32(Request["id"]); break;
            case "1": sql = "DELETE FROM TeachParkType WHERE teachtypeid = " + Convert.ToInt32(Request["id"]); break;
            case "2": sql = "DELETE FROM researchType WHERE researchTypeId = " + Convert.ToInt32(Request["id"]); break;
            case "4": sql = "DELETE FROM RescourcesType WHERE resourcestypeid = " + Convert.ToInt32(Request["id"]); break;
            case "5": sql = "DELETE FROM SubjectType WHERE subTypeID = " + Convert.ToInt32(Request["id"]); break;
            case "3": sql = "DELETE FROM TeacherUpType WHERE teachUpTypeID = " + Convert.ToInt32(Request["id"]); break;
            case "8": sql = "DELETE FROM pass WHERE passId = " + Convert.ToInt32(Request["id"]); break;
            case "10": sql = "DELETE FROM TypeValueList WHERE steptid = " + Convert.ToInt32(Request["id"]); break;

        }

        try
        {
            DB.execnonsql(sql);
            Response.Write("<font color='red'> 删除成功！<font>");
        }
        catch {
            Response.Write("<font color='red'> 请先删除与此类型关联的信息！<font>");
        }
    }
    //protected void DelNum()
    //{
    //    string sql = "DELETE FROM workNumId WHERE workNumId = " + Convert.ToInt32(Request["id"]);
    //    DB.execnonsql(sql);
    //    Response.Write("<font color='red'> 删除成功！<font>");
    //}
    protected void DelClassList()
    {
        string sql = "DELETE FROM class WHERE classId = " + Convert.ToInt32(Request["id"]);
        try
        {
            DB.execnonsql(sql);
            Response.Write("<font color='red'> 删除成功！<font>");
        }
        catch
        {
            Response.Write("<font color='red'> 请先删除与此班级关联的信息！<font>");
        }
    }
    protected void DelCourseList()
    {
        string sql = "DELETE FROM CourseList WHERE courseid = " + Convert.ToInt32(Request["id"]);
        try
        {
            DB.execnonsql(sql);
            Response.Write("<font color='red'> 删除成功！<font>");
        }
        catch
        {
            Response.Write("<font color='red'> 请先删除与此课程关联的信息！<font>");
        }
    }
    //protected void SubmitNewsType()
    //{
    //    string sql = "UPDATE NewsType SET content = N'" + Request["content"] + "'WHERE newstypeid ='" + Convert.ToInt32(Request["id"]) + "' ";
    //    DB.execnonsql(sql);
    //    Response.Write("提交成功！");
    //} //
    protected void SubmitType()//提交编辑的信息
    {
        string sql = "";
        switch (Request["park"])
        {
            case "0": sql = "UPDATE NewsType SET name = N'" + Request["content"] + "'WHERE newstypeid ='" + Convert.ToInt32(Request["id"]) + "' "; break;
            case "1": sql = "UPDATE TeachParkType SET name = N'" + Request["content"] + "'WHERE teachtypeid ='" + Convert.ToInt32(Request["id"]) + "' ";break;
            case "2": sql = "UPDATE researchType SET name = N'" + Request["content"] + "'WHERE researchTypeId ='" + Convert.ToInt32(Request["id"]) + "' "; break;
            case "4": sql = "UPDATE RescourcesType SET name = N'" + Request["content"] + "'WHERE resourcestypeid ='" + Convert.ToInt32(Request["id"]) + "' "; break;
            case "5": sql = "UPDATE SubjectType SET name = N'" + Request["content"] + "'WHERE subTypeID ='" + Convert.ToInt32(Request["id"]) + "' "; break;
            case "3": sql = "UPDATE TeacherUpType SET name = N'" + Request["content"] + "'WHERE teachUpTypeID ='" + Convert.ToInt32(Request["id"]) + "' "; break;
            case "8": sql = "UPDATE pass SET name = N'" + Request["content"] + "'WHERE passId ='" + Convert.ToInt32(Request["id"]) + "' "; break;
            case "10": sql = "UPDATE TypeValueList SET name = N'" + Request["content"] + "'WHERE steptid ='" + Convert.ToInt32(Request["id"]) + "' "; break;

            default: Response.Write("<font color='red'> park传值错误！<font>"); break;

        }
        
        DB.execnonsql(sql);
        Response.Write("<font color='red'> 提交成功！<font>");
    }

}
