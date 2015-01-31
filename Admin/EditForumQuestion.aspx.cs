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

public partial class EditForumQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DB.hasSession("admin")) Response.Redirect("Default.htm");
        switch (Request.QueryString["park"])
        {


            case "12": this.Panel1.Visible = false; this.Panel2.Visible = false; break;
        }
        string sqlEditNews = "";
        if (!IsPostBack)
        {

            switch (Request.QueryString["park"])
            {

                case "11": sqlEditNews = "SELECT content FROM ForumQuestion WHERE questionid = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
                case "12": sqlEditNews = "SELECT content FROM ForumAnswer WHERE answerid = " + Convert.ToInt32(Request.QueryString["id"].ToString()) + ""; break;
            }

            this.Editor1.Text = DB.FindString(sqlEditNews);
            this.title.Text = Server.UrlDecode(Request.QueryString["title"]);
            this.steptbox1.Text = Server.UrlDecode(Request.QueryString["stept"]);
            this.author.Text = Server.UrlDecode(Request.QueryString["author"]);
        }
           
    }
    protected void submitTeachPark_Click(object sender, EventArgs e)
    {
        if (this.title.Text.Trim() == "" || this.Editor1.Text.Trim() == "" || this.author.Text.Trim() == "")
            Response.Write("<script>alert('标题和内容和作者不能为空！');</script>");
        else
        {
            string sql = "";
            string title = this.title.Text;

            //string sql1 = "SELECT studentID FROM studentlist WHERE name = '" + this.student.Text.Trim().ToString()+ "'";
            //string student = DB.FindString(sql1);

            string stept = this.steptbox.Text;
            string content = this.Editor1.Text;
            string author = this.author.Text;
            try
            {
                switch (Request.QueryString["park"])
                {

                    case "11": sql = "UPDATE ForumQuestion SET title = N'" + title + "', author = N'" + author + "', Typ_steptid = '" + Convert.ToInt32(stept) + "', content = N'" + content + "'WHERE questionid ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                    case "12": sql = "UPDATE ForumAnswer SET title = N'" + title + "', author = N'" + author + "', content = N'" + content + "'WHERE answerid ='" + Convert.ToInt32(Request.QueryString["id"]) + "' "; break;
                }
            }
            catch { }

            try
            {

                DB.execnonsql(sql);
                Response.Write("<script>alert('更新成功！');</script>");
                Response.Write("<script>window.close()</script>");

            }
            catch { Response.Write("<script>alert('未选择权限或输入太长！');</script>"); this.steptbox.Text = ""; }
        }
    }
}
