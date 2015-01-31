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

public partial class Admin_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DB.hasSession("admin")) Response.Redirect("Default.htm");
       
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (this.title.Text.Trim() == "" || this.content.Text.Trim() == "")
            Response.Write("<script>alert('标题和内容不能为空！');</script>");
        else
        {
            string title = this.title.Text;
            string content = this.content.Text.ToString();
            string park = this.Select1.Value;
            string stept = this.steptbox.Text;
            string type = this.type.Text;
            string course = this.course.Text;
            DateTime time = DateTime.Now;
            string sql = ""; ;
            try
            {
                switch (park)
                {
                    case "0":
                        sql = "INSERT INTO NewsList(Typ_steptid,title,content,New_newstypeid,time,imgUrl,isProImg)VALUES(" + Convert.ToInt32(stept) + ",N'" + title + "',N'" + content + "', " + Convert.ToInt32(type) + ",'" + time + "',N'" + this.pic.Text.ToString() + "','" + Convert.ToBoolean(this.ispic.Checked) + "')";
                        break;
                    case "1":
                        sql = "INSERT INTO TeachPark(Typ_steptid,title,content,Tea_teachtypeid,Cou_courseid,time)VALUES(" + Convert.ToInt32(stept) + ",N'" + title + "',N'" + content + "', " + Convert.ToInt32(type) + ",  " + Convert.ToInt32(course) + ",'" + time + "')";
                        break;
                    case "2":
                        sql = "INSERT INTO ResearchList(Typ_steptid,title,content,res_researchTypeId,pas_passId,time)VALUES(" + Convert.ToInt32(stept) + ",N'" + title + "',N'" + content + "', " + Convert.ToInt32(type) + ", " + Convert.ToInt32(course) + ",'" + time + "')";
                        break;
                    case "3":
                        sql = "INSERT INTO TeacherUpFileWorkList(Typ_steptid,title,content,Tea_teachUpTypeID,Cou_courseid,time)VALUES(" + Convert.ToInt32(stept) + ",N'" + title + "',N'" + content + "', " + Convert.ToInt32(type) + ", " + Convert.ToInt32(course) + ",'" + time + "')";
                        break;
                    case "4":
                        sql = "INSERT INTO ResourcesList(Typ_steptid,title,content,Res_resourcestypeid,time)VALUES(" + Convert.ToInt32(stept) + ",N'" + title + "',N'" + content + "', " + Convert.ToInt32(type) + ",'" + time + "')";
                        break;
                    case "5":
                        sql = "INSERT INTO SubjectList(Typ_steptid,title,content,Sub_subTypeID,time)VALUES(" + Convert.ToInt32(stept) + ",N'" + title + "',N'" + content + "', " + Convert.ToInt32(type) + ",'" + time + "')";
                        break;
                }
            }
            catch { }
            try
            {
                DB.execnonsql(sql);
                Response.Write("<script>alert('提交成功！');</script>");
                this.title.Text = "";
                this.content.Text = "";
                this.Select1.SelectedIndex = 0;
                this.steptbox.Text = "";
                this.type.Text = "";
                this.course.Text = "";
                this.pic.Text = "";
                this.Label1.Text = "";
                this.ispic.Checked = false;
            }
            catch
            {
                Response.Write("<script>alert('请选择类别&权限&课程&方向或输入太长！');</script>");
                this.Select1.SelectedIndex = 0;
                this.steptbox.Text = "";
                this.type.Text = "";
                this.course.Text = "";
            }
        }
      
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string res;
        upload up = new upload();
        res = up.Up(file2, "../uploads/Images/");
        this.Label1.Visible = true;
        this.Label1.Text = up.Resup[Convert.ToInt32(res)];
        this.pic.Text = up.s;
    }
}
