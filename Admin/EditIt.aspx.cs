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

public partial class Admin_EditIt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DB.hasSession("admin")) Response.Redirect("Default.htm");
        string sqlEditNews = "";

        if (!IsPostBack)
        {
            if (Request.QueryString["park"] == "0" || Request.QueryString["park"] == "4" || Request.QueryString["park"] == "5")
            {
                this.Panel1.Visible = false;
            }
            else
            {

                this.course1.Text = Server.UrlDecode(Request.QueryString["course"]);
            }
            switch (Request.QueryString["park"])
            {
                case "0": sqlEditNews = "SELECT content FROM NewsList WHERE newsid = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + "";
                break;
                case "1": sqlEditNews = "SELECT content FROM TeachPark WHERE teachParkID = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
                case "2": sqlEditNews = "SELECT content FROM ResearchList WHERE researchId = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
                case "4": sqlEditNews = "SELECT content FROM ResourcesList WHERE resourcesID = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
                case "5": sqlEditNews = "SELECT content FROM SubjectList WHERE subjectID = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
                case "3": sqlEditNews = "SELECT content FROM TeacherUpFileWorkList WHERE TeacherUpWorkID = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
            }

            this.Editor1.Text = DB.FindString(sqlEditNews);
            this.title.Text = Server.UrlDecode(Request["title"]);
            this.steptbox1.Text = Server.UrlDecode(Request.QueryString["stept"]);
            this.type1.Text = Server.UrlDecode(Request.QueryString["type"]);

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
            string type = this.type.Text;
            string stept = this.steptbox.Text;
            string content = this.Editor1.Text;
            string course = this.course.Text;
            try
            {
                switch (Request.QueryString["park"])
                {
                    case "0": sql = "UPDATE NewsList SET title = N'" + title + "', New_newstypeid = '" + Convert.ToInt32(type) + "', Typ_steptid = '" + Convert.ToInt32(stept) + "', content = N'" + content + "'WHERE newsid ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                    case "1": sql = "UPDATE TeachPark SET title = N'" + title + "', Tea_teachtypeid = '" + Convert.ToInt32(type) + "', Cou_courseid = '" + Convert.ToInt32(course) + "', Typ_steptid = '" + Convert.ToInt32(stept) + "', content = N'" + content + "'WHERE teachParkID ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                    case "2": sql = "UPDATE ResearchList SET title = N'" + title + "', res_researchTypeId = '" + Convert.ToInt32(type) + "', pas_passId = '" + Convert.ToInt32(course) + "', Typ_steptid = '" + Convert.ToInt32(stept) + "', content = N'" + content + "'WHERE researchId ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                    case "4": sql = "UPDATE ResourcesList SET title = N'" + title + "', Res_resourcestypeid = '" + Convert.ToInt32(type) + "', Typ_steptid = '" + Convert.ToInt32(stept) + "', content = N'" + content + "'WHERE resourcesID ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                    case "5": sql = "UPDATE SubjectList SET title = N'" + title + "', Sub_subTypeID = '" + Convert.ToInt32(type) + "', Typ_steptid = '" + Convert.ToInt32(stept) + "', content = N'" + content + "'WHERE subjectID ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                    case "3": sql = "UPDATE TeacherUpFileWorkList SET title = N'" + title + "', Tea_teachUpTypeID = '" + Convert.ToInt32(type) + "', Cou_courseid = '" + Convert.ToInt32(course) + "', Typ_steptid = '" + Convert.ToInt32(stept) + "', content = N'" + content + "'WHERE TeacherUpWorkID ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                }
            }
            catch { }

            try { DB.execnonsql(sql); Response.Write("<script>alert('更新成功！');</script>"); Response.Write("<script>window.close()</script>"); }
            catch
            {
                Response.Write("<script>alert('请选择类别&权限&课程&方向或输入太长！');</script>");
                this.steptbox.Text = "";
                this.type.Text = "";
                this.course.Text = "";
            }
        }
       
    }
}
