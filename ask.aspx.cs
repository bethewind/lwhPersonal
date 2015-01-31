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

public partial class ask : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DB.hasSession("name")) this.Label1.Text = "你当前是匿名发帖，你可以到首页先登录或注册！";
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (this.boxTitle.Text.Trim() == "" || this.Editor1.Text.Trim() == "")
            Response.Write("<script>alert('标题和内容不能为空！');</script>");
        else
        {
            string name = "";
            string title = this.boxTitle.Text;
            string content = this.Editor1.Text;
            if (DB.hasSession("name"))
                name = Session["name"].ToString();
            else name = "匿名";
            string sql1 = "INSERT INTO ForumQuestion (clicknum,replynum,content,title,time,author,Typ_steptid)VALUES(" + 0 + "," + 0 + ",N'" + content + "',N'" + title + "','" + DateTime.Now + "',N'" + name + "'," + 1 + ")";
            try { DB.execnonsql(sql1); Response.Write("<script>alert('恭喜发贴成功！');</script>"); Response.Write("<script>window.close()</script>"); }
            catch { Response.Write("<script>alert('输入太长！');</script>"); }
        }
    }
}
