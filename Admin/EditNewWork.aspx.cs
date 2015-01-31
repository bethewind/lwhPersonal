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

public partial class Admin_EditNewWork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!DB.hasSession("admin")) Response.Redirect("Default.htm");
            this.title.Text = Server.UrlDecode(Request["title"]);
            this.year.Text = Request["year"];
            this.month.Text = Request["month"];
            this.day.Text = Request["day"];
            this.txtStept.Text = Server.UrlDecode(Request["stept"]);
            this.txtCourse.Text = Server.UrlDecode(Request["course"]);
            string sql = "SELECT content FROM stuWorkList WHERE upWorkId = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + "";
            this.content.Text = DB.FindString(sql);
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    { 
       
        try {
            string sql = "UPDATE stuWorkList SET title=N'" + this.title.Text.Trim() + "',content=N'" + this.content.Text.Trim() + "',Cou_courseid=" + Convert.ToInt32(this.course.Text.Trim()) + ",Typ_steptid=" + Convert.ToInt32(this.steptbox.Text.Trim()) + ",lastUpYear=" + Convert.ToInt32(this.year.Text.Trim()) + ",lastUpMonth=" + Convert.ToInt32(this.month.Text.Trim()) + ",lastUpDay=" + Convert.ToInt32(this.day.Text.Trim()) + " WHERE upWorkId = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + "";
            string sql1 = "UPDATE CompleteWork SET title=N'" + this.title.Text.Trim() + "',Cou_courseid=" + Convert.ToInt32(this.course.Text.Trim()) + " WHERE noworkID = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + "";
            DB.execnonsql(sql); DB.execnonsql(sql1); Response.Write("<script>alert('更新成功！');</script>"); Response.Write("<script>window.close()</script>");
        }
        catch
        {
            Response.Write("<script>alert('请选择权限&课程或输入太长！');</script>");
            this.steptbox.Text = "";
           
            this.course.Text = "";
        }
    }
}
