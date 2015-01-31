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

public partial class Admin_AddNewWork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!DB.hasSession("admin")) Response.Redirect("Default.htm");
            this.year.Text = DateTime.Now.Year.ToString();
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (this.title.Text.Trim() == "" || this.content.Text.Trim() == "")
            Response.Write("<script>alert('标题和内容不能为空！');</script>");
        else
        {
            string title = this.title.Text;
            string content = this.content.Text.ToString();
           
            string stept = this.steptbox.Text;
          int workNum=0;
            string course = this.course.Text;
            System.Data.DataTable dt = DB.OpenQuery("SELECT * FROM stuWorkList WHERE Cou_courseid=" + Convert.ToInt32(this.course.Text) + "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["workNum"]) > workNum)
                    workNum = Convert.ToInt32(dt.Rows[i]["workNum"]);
            }
            workNum += 1;
            //for (int i = 1; ; i++)
            //{
            //    System.Data.DataTable dt = DB.OpenQuery("SELECT * FROM stuWorkList WHERE workNum=" + i + " AND Cou_courseid=" + Convert.ToInt32(this.course.Text) + "");
            //    if (dt.Rows.Count > 0) continue;
            //    else { workNum = i; break; }
            //}
            DateTime time = DateTime.Now;
            string month = this.month.Text.Trim();
            string day = this.day.Text.Trim();
            string sql = "INSERT INTO stuWorkList(Typ_steptid,title,content,Cou_courseid,time,lastUpMonth,lastUpDay,workNum,lastUpYear)VALUES(" + Convert.ToInt32(stept) + ",N'" + title + "',N'" + content + "', " + Convert.ToInt32(course) + ",'" + time + "'," + Convert.ToInt32(month) + "," + Convert.ToInt32(day) + "," + workNum + "," + Convert.ToInt32(this.year.Text.Trim()) + ")";
            try
            {
                DB.execnonsql(sql);
                Response.Write("<script>alert('提交成功！');</script>");
                this.title.Text = "";
                this.content.Text = "";

                this.steptbox.Text = "";

                this.course.Text = "";



            }
            catch
            {
                Response.Write("<script>alert('请选择类别&权限&课程&方向或输入太长！');</script>");

                this.steptbox.Text = "";

                this.course.Text = "";
            }
        }
       
    }
}
