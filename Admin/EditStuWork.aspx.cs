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

public partial class Admin_EditStuWork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DB.hasSession("admin")) Response.Redirect("Default.htm");
        string sqlEditNews = "";
        if (!IsPostBack)
        {
            
            switch (Request.QueryString["park"])
            {

                case "6": sqlEditNews = "SELECT content FROM StuUpFIleList WHERE upId = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
                case "7": sqlEditNews = "SELECT content FROM CompleteWork WHERE completWorkID = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
            }
           
            this.Editor1.Text = DB.FindString(sqlEditNews);
            this.title.Text = Server.UrlDecode(Request.QueryString["title"]);
            this.steptbox1.Text = Server.UrlDecode(Request.QueryString["stept"]);
            this.course1.Text = Server.UrlDecode(Request.QueryString["course"]);
            this.isPro.Checked = Convert.ToBoolean(Server.UrlDecode(Request.QueryString["isPro"]));
        }
    }
    protected void submitTeachPark_Click(object sender, EventArgs e)
    {
        if (this.title.Text.Trim() == "" || this.Editor1.Text.Trim() == "")
            Response.Write("<script>alert('标题和内容不能为空！');</script>");
        else
        {
            string sql = "";
            string title = this.title.Text;

            //string sql1 = "SELECT studentID FROM studentlist WHERE name = '" + this.student.Text.Trim().ToString()+ "'";
            //string student = DB.FindString(sql1);

            string stept = this.steptbox.Text;
            string content = this.Editor1.Text;
            string course = this.course.Text;
            bool isPro = this.isPro.Checked;
            try
            {
                switch (Request.QueryString["park"])
                {

                    case "6": sql = "UPDATE StuUpFIleList SET title = N'" + title + "', Cou_courseid = '" + Convert.ToInt32(course) + "', Typ_steptid = '" + Convert.ToInt32(stept) + "',isPro = '" + isPro + "', content = N'" + content + "'WHERE upId ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                    case "7": sql = "UPDATE CompleteWork SET title = N'" + title + "', Cou_courseid = '" + Convert.ToInt32(course) + "', Typ_steptid = '" + Convert.ToInt32(stept) + "',isPro = '" + isPro + "', content = N'" + content + "',remarkTime = N'" + DateTime.Now.ToString() + "'WHERE completWorkID ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                }
            }
            catch { }

            try
            {
                DB.execnonsql(sql); string sql1 = "UPDATE workNumId SET num = num + 1 WHERE courseId='" + Convert.ToInt32(course) + "'AND studentId='" + Convert.ToInt32(Request.QueryString["studentId"]) + "'";
                if (Request.QueryString["remarkTime"] == "")
                {
                    switch (Request.QueryString["park"])
                    {
                        case "7": DB.execnonsql(sql1); break;
                    }
                }
                Response.Write("<script>alert('更新成功！');</script>"); Response.Write("<script>window.close()</script>");
            }
            catch
            {
                Response.Write("<script>alert('请选择权限&课程&方向或输入太长！');</script>");
                this.steptbox.Text = "";
                this.course.Text = "";
            }
        }
        
    }
}
