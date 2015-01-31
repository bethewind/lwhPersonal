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

public partial class ReplyForum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DB.hasSession("name")) this.Label1.Text = "你当前是匿名发帖，你可以到首页先登录或注册！";
        this.boxtitle.Text =  Request["title"].ToString();
    
        this.boxtitle.ToolTip = Request["title"];
    }
    protected void btnreply_Click(object sender, EventArgs e)
    {
        if (this.boxtitle.Text.Trim() == "" || this.Editor1.Text.Trim() == "")
            Response.Write("<script>alert('内容不能为空！');</script>");
        else
        {
            string name = "";
            string title = this.boxtitle.Text;
            string content = this.Editor1.Text;
            if (DB.hasSession("name"))
                name = Session["name"].ToString();
            else name = "匿名";
            try
            {
                string sql1 = "INSERT INTO ForumAnswer (For_questionid,content,title,time,author)VALUES(" + Convert.ToInt32(Request["questionid"]) + ",N'" + content + "',N'" + title + "','" + DateTime.Now + "',N'" + name + "')";
                DB.execnonsql(sql1); Response.Write("<script>alert('恭喜回复成功！');</script>"); Response.Write("<script>window.close()</script>");
                string sql2 = "UPDATE ForumQuestion SET replynum=replynum+1 WHERE questionid =" + Convert.ToInt32(Request["questionid"]) + "";
                DB.execnonsql(sql2);
            }
            catch { Response.Write("<script>alert('输入太长！');</script>"); }
        }
            
    }
}
