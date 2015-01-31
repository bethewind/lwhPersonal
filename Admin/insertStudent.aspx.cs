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
using System.Data.OleDb;
public partial class Admin_insertStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DB.hasSession("admin")) Response.Redirect("Default.htm");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string res;
        upload up = new upload();
        res = up.Up3(File1, "/lwhPersonal/uploads/excel/", "student");

        if (Convert.ToInt32(res) == 3)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + up.s3 + ";Extended Properties=Excel 8.0";
            //链接Excel
            OleDbConnection cnnxls = new OleDbConnection(strConn);
            //读取Excel里面有 表Sheet1
            OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", cnnxls);
            DataSet ds = new DataSet();
            //将Excel里面有表内容装载到内存表中！
            oda.Fill(ds);
            DataTable dt = ds.Tables[0];
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql1 = "SELECT classId FROM class WHERE name = N'" + dt.Rows[i]["class"].ToString().Trim() + "'";
                    string sql2 = "SELECT COUNT(*) FROM studentlist WHERE name = N'" + dt.Rows[i]["userName"] + "'";
                    string sql3 = "SELECT COUNT(*) FROM studentlist WHERE studyNum = N'" + dt.Rows[i]["studyNum"] + "'";
                    string sql4 = "SELECT COUNT(*) FROM studentlist WHERE sclass = " + Convert.ToInt32(DB.FindString(sql1)) + " AND classNum = " + Convert.ToInt32(dt.Rows[i]["classNum"]) + " ";
                    if (Convert.ToInt32(DB.FindString(sql2)) == 0 && Convert.ToInt32(DB.FindString(sql3)) == 0 && Convert.ToInt32(DB.FindString(sql4)) == 0)
                    {

                       
                        string sql = "INSERT INTO studentlist(name,nickname,password,sclass,studyNum,classNum)VALUES(N'" + dt.Rows[i]["userName"] + "',N'" + dt.Rows[i]["name"] + "',N'" + MD5.Hash(dt.Rows[i]["password"].ToString()) + "'," + Convert.ToInt32(DB.FindString(sql1)) + ",N'" + dt.Rows[i]["studyNum"] + "','" + Convert.ToInt32(dt.Rows[i]["classNum"]) + "')";
                        DB.execnonsql(sql);



                    }
                   
                }
                Response.Write("<script>alert('导入成功!');</script>");
            }
            catch { Response.Write("<script>alert('导入出错,请检查excel表！');</script>"); }
        }
        else
        {
            Response.Write("<script>alert('" + up.Resup3[Convert.ToInt32(res)] + "');</script>");
            //this.Label1.Visible = true;
            //this.Label1.Text = up.Resup3[Convert.ToInt32(res)];
        }
       
    }
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    string res;
    //    upload up = new upload();
    //    res = up.Up3(File1, "../uploads/studentWork/", "student");
    //    this.Label1.Visible = true;
    //    this.Label1.Text = up.Resup3[Convert.ToInt32(res)];
    //    this.TextBox1.Text = up.s3;
    //}
}
