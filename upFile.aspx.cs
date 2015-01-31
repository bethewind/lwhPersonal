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

public partial class upFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DB.hasSession("student"))
        {
            Response.Write("<script>alert('学生请先登录！');</script>"); Response.Write("<script>window.close()</script>");
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (this.boxTitle.Text.Trim() == "" || this.Editor1.Text.Trim() == "")
            Response.Write("<script>alert('标题和内容不能为空！');</script>");
        else
        {
            string title = this.boxTitle.Text;
            string content = this.Editor1.Text;
            string sql = "SELECT studentID FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
            string sql2 = "SELECT sclass FROM studentlist WHERE name = N'" + Session["student1"].ToString() + "'";
            try
            {
                string sql1 = "INSERT INTO StuUpFIleList (stu_studentID,Cou_courseid,content,title,time,classId)VALUES(" + Convert.ToInt32(DB.FindString(sql)) + "," + Convert.ToInt32(this.boxCourse.Text) + ",N'" + content + "',N'" + title + "','" + DateTime.Now + "'," + Convert.ToInt32(DB.FindString(sql2)) + ")";
                DB.execnonsql(sql1); Response.Write("<script>alert('上传成功，待管理员审核！');</script>"); Response.Write("<script>window.close()</script>");
            }
            catch { Response.Write("<script>alert('未选择课程！或输入太长！');</script>"); }
        }
    }
}
