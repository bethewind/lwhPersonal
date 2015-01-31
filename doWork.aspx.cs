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

public partial class doWork : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!DB.hasSession("student"))
            {
                Response.Write("<script>alert('学生请先登录！');</script>"); Response.Write("<script>window.close()</script>"); return;
            }
            int year = Convert.ToInt32(Request["year"]);
            int month = Convert.ToInt32(Request["month"]);
            int day = Convert.ToInt32(Request["day"]);
             int year1 = Convert.ToInt32(DateTime.Now.Year);
            int month1 = Convert.ToInt32(DateTime.Now.Month);
            int day1 = Convert.ToInt32(DateTime.Now.Day);
            int time = (year1 - year)*12*31 + (month1 - month)*31 + day1 - day;
            if (time > 0)
            {
                Response.Write("<script>alert('已过上传截至日期！');</script>"); Response.Write("<script>window.close()</script>"); return;
            }
            string sql = "SELECT studentID FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
            //string sql1 = "SELECT COUNT (*) FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(DB.FindString(sql)) + " AND noworkID=" + Convert.ToInt32(Request["noworkid"]) + " ";
            string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(DB.FindString(sql)) + " AND noworkID=" + Convert.ToInt32(Request["noworkid"]) + " ";
            //int count = Convert.ToInt32(DB.FindString(sql1));
            System.Data.DataTable dt = DB.OpenQuery(sql1);
            int count = dt.Rows.Count;
            if (count > 0)
            {
                if (dt.Rows[0]["remarkTime"].ToString() != "")
                {
                    Response.Write("<script>alert('老师已批改，不能再修改！');</script>"); Response.Write("<script>window.close()</script>"); return;
                }
                if (dt.Rows[0]["workContent"].ToString() != "")
                {
                    this.Label1.Visible = true;
                    this.Label1.Text = "你的作业已上传，再次上传会覆盖原来的！";
                }
                if (dt.Rows[0]["workAdd"].ToString() != "")
                {
                    this.Label2.Visible = true;
                    this.Label2.Text = "你的附件已上传，再次上传会覆盖原来的！";
                }
            }

            this.boxtitle.Text = Request["title"].ToString();

            this.boxtitle.ToolTip = Request["title"];
        }
    }
    //protected void Button3_Click(object sender, EventArgs e)
    //{
       
    //        //string title = this.boxtitle.Text;
    //        //string content = this.Editor1.Text;
    //        //string sql = "SELECT studentID FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
    //        //string sql1 = "INSERT INTO CompleteWork (stu_studentID,Cou_courseid,content,title,time,Typ_steptid,noworkID)VALUES(" + Convert.ToInt32(DB.FindString(sql)) + "," + Convert.ToInt32(Request["courseid"]) + ",N'" + content + "',N'" + title + "',N'" + DateTime.Now.ToString() + "'," + 1 + "," + Convert.ToInt32(Request["noworkid"]) + ")";
    //        ////try { 
    //        //    DB.execnonsql(sql1); Response.Write("<script>alert('上交成功！');</script>"); Response.Write("<script>window.close()</script>"); 
    //        ////}
    //        ////catch { Response.Write("<script>alert('输入太长！');</script>"); }
    //    string res;
    //    upload up = new upload();
    //    res = up.Up1(File1, "uploads/studentWork/");
    //    this.Label1.Visible = true;
    //    this.Label1.Text = up.Resup1[Convert.ToInt32(res)];
       
    //    //Response.Write("<script>alert('"+up.Resup1[Convert.ToInt32(res)]+"');</script>");
    //    //this.pic.Text = up.s;
    //    string res1;
    //    upload up1 = new upload();
    //    res1 = up1.Up2(File2, "uploads/studentWork/");
    //    this.Label2.Visible = true;
    //    this.Label2.Text = up1.Resup2[Convert.ToInt32(res1)];
    //    if (up.a1 == 1 && up1.a2 == 1&&a == 0)
    //    {
    //        string title = this.boxtitle.Text;
    //        string sql = "SELECT studentID FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
    //        string sql1 = "SELECT sclass FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
    //        string sql2 = "INSERT INTO CompleteWork (stu_studentID,Cou_courseid,workContent,workAdd,title,time,noworkID,workNum,classId)VALUES(" + Convert.ToInt32(DB.FindString(sql)) + "," + Convert.ToInt32(Request["courseid"]) + ",N'" + up.s1 + "',N'" + up1.s2 + "',N'" + title + "',N'" + DateTime.Now.ToString() + "'," + Convert.ToInt32(Request["noworkid"]) + "," + Convert.ToInt32(Request["workNum"]) + "," + Convert.ToInt32(DB.FindString(sql1)) + ")";
    //        DB.execnonsql(sql2);
    //    }
    //    else
    //    {
    //        if (a == 0)
    //        {
    //            this.Label3.Visible = true;
    //            this.Label3.Text = "作业上传失败，请重新上传！";
    //        }
    //        else
    //        {
    //            if (up.a1 == 1 && up1.a2 == 1)
    //            {
    //                this.Label3.Visible = true;
    //                this.Label3.Text = "再次上传成功！";
    //            }
    //            else
    //            {
    //                this.Label3.Visible = true;
    //                this.Label3.Text = "再次上传失败，请重新上传！";
    //            }
    //        }
    //    }
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        string title = this.boxtitle.Text;
        string sql2="";
    string sql3 = "SELECT sclass FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
        string sql = "SELECT studentID FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
        string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(DB.FindString(sql)) + " AND noworkID=" + Convert.ToInt32(Request["noworkid"]) + " ";
       // int count = Convert.ToInt32(DB.FindString(sql1));
        System.Data.DataTable dt = DB.OpenQuery(sql1);
        int count = dt.Rows.Count;
        string name = Session["student"] + DB.FindString(sql) + "-" + Request["courseid"] +"-"+ Request["workNum"];
        string res;
        upload up = new upload();
        res = up.Up1(File1, "uploads/studentWork/",name);
        this.Label1.Visible = true;
        this.Label1.Text = up.Resup1[Convert.ToInt32(res)];
        if (Convert.ToInt32(res) == 3)
        {
            if (count > 0)
            {
                sql2 = "UPDATE CompleteWork SET workContent=N'" + up.s1 + "'WHERE stu_studentID=" + Convert.ToInt32(DB.FindString(sql)) + " AND noworkID=" + Convert.ToInt32(Request["noworkid"]) + "";
            }
            else sql2 = "INSERT INTO CompleteWork (stu_studentID,Cou_courseid,workContent,title,time,noworkID,workNum,classId)VALUES(" + Convert.ToInt32(DB.FindString(sql)) + "," + Convert.ToInt32(Request["courseid"]) + ",N'" + up.s1 + "',N'" + title + "','" + DateTime.Now + "'," + Convert.ToInt32(Request["noworkid"]) + "," + Convert.ToInt32(Request["workNum"]) + "," + Convert.ToInt32(DB.FindString(sql3)) + ")";
            DB.execnonsql(sql2);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string title = this.boxtitle.Text;
        string sql2 = "";
        string sql3 = "SELECT sclass FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
        string sql = "SELECT studentID FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
        string sql1 = "SELECT * FROM CompleteWork WHERE stu_studentID=" + Convert.ToInt32(DB.FindString(sql)) + " AND noworkID=" + Convert.ToInt32(Request["noworkid"]) + " ";
        //int count = Convert.ToInt32(DB.FindString(sql1));
        System.Data.DataTable dt = DB.OpenQuery(sql1);
        int count = dt.Rows.Count;
        string name = Session["student"] + DB.FindString(sql) + "-" + Request["courseid"] + "-" + Request["workNum"];
        string res;
        upload up = new upload();
        res = up.Up2(File2, "uploads/studentWork/",name);
        this.Label2.Visible = true;
        this.Label2.Text = up.Resup2[Convert.ToInt32(res)];
        if (Convert.ToInt32(res) == 3)
        {
            if (count > 0)
            {
                sql2 = "UPDATE CompleteWork SET workAdd=N'" + up.s2 + "'WHERE stu_studentID=" + Convert.ToInt32(DB.FindString(sql)) + " AND noworkID=" + Convert.ToInt32(Request["noworkid"]) + "";
            }
            else sql2 = "INSERT INTO CompleteWork (stu_studentID,Cou_courseid,workAdd,title,time,noworkID,workNum,classId)VALUES(" + Convert.ToInt32(DB.FindString(sql)) + "," + Convert.ToInt32(Request["courseid"]) + ",N'" + up.s2 + "',N'" + title + "',N'" + DateTime.Now.ToString() + "'," + Convert.ToInt32(Request["noworkid"]) + "," + Convert.ToInt32(Request["workNum"]) + "," + Convert.ToInt32(DB.FindString(sql3)) + ")";
            DB.execnonsql(sql2);
        }
    }
}
