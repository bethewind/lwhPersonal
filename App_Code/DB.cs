using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
/// <summary>
/// DB 的摘要说明
/// </summary>
public class DB
{
	public DB()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static SqlConnection Getconn()
    {
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings ["conn"].ConnectionString);
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"].ToString());

        if (conn.State.Equals(ConnectionState.Closed))
        {

            conn.Open();

        }
        return conn;
    
    
    }
    //=================================================
    //功能描述：关闭数据库
    //时间：2007.11.10
    //=================================================
    private static void closeConnection()
    {
        SqlConnection conn = DB.Getconn();
        SqlCommand cmd = new SqlCommand();
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
        }
    }
    //=================================================
    //功能描述：执行SQL语句
    //输入参数：sql，查询的SQL语句
    //时间：2007.11.10
    //=================================================
    public static  void execnonsql(string sql)
    {
        try
        {
            SqlConnection conn = DB.Getconn();
            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection(); 
        }

    }
  
    //功能描述：获取DATASET
    //输入参数：sql，查询的SQL语句
    //返回值：DataSet
    //时间：2007.11.10
    //=================================================
    public static DataSet getdataset(string sql)
    {
        try
        {
            SqlConnection conn = DB.Getconn();
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "ds");
            return ds;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        
        }
        finally
        {
         closeConnection();
        }
    }
    //=================================================
    //功能描述：获取DATASET1
    //输入参数：sql，查询的SQL语句
    //返回值：DataSet
    //时间：2007.11.10
    //=================================================
    public static DataSet select(string sql,string tablename)
    {
        try
        {
            SqlConnection conn = DB.Getconn();
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, tablename);
            return ds;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
        finally
        {
            closeConnection();
        }
    }
    //=================================================
    //功能描述：获取某个字段数据
    //输入参数：sql，查询的SQL语句
    //返回值：hang
    //时间：2007.11.10
    //=================================================
    //public static string FindStrin(string sql, SqlConnection conn)
    //{

    //    SqlCommand com = new SqlCommand(sql, conn);
    //    string hang = Convert.ToString(com.ExecuteScalar());
    //    return hang;
    
    
    
    //}





    public static bool hasSession(string session)
    {
        bool isOK = false;
        if (HttpContext.Current.Session.Count != 0)
        {
            try
            {
                if (!String.IsNullOrEmpty(HttpContext.Current.Session[session].ToString()))
                {
                    isOK = true;
                }
            }
            catch (NullReferenceException ex)
            {
                return false;
            }
        }
        return isOK;
    }
    
    
   
    public static string FindString(string sql)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"].ToString()))
        {

            if (conn.State.Equals(ConnectionState.Closed))
            {

                conn.Open();

            }
            try
            {
                // SqlConnection conn = DB.Getconn();
                SqlCommand com = new SqlCommand(sql, conn);
                string hang = Convert.ToString(com.ExecuteScalar());
                return hang;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            finally
            {
                closeConnection();
            }
        }

    }
    //=================================================
    //功能描述：对DATAGRIG进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dg，需要绑定的DATAGRID控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void binddatagrid(string sql, DataGrid dg)
    {

        try
        {
            DataSet ds = getdataset(sql);
            dg.DataSource = ds.Tables[0].DefaultView;
            dg.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
        finally
        {
            closeConnection();
        }
    }
    //public static void binddatagrid(string sql, GridView dg)
    //{

    //    //try
    //    //{
    //    DataSet ds = getdataset(sql);
    //    dg.DataSource = ds.Tables[0].DefaultView;
    //    dg.DataBind();
    //    //}
    //    //catch (Exception e)
    //    //{
    //    //    throw new Exception(e.Message);
        
    //    //}
    //    //finally
    //    //{
    //    // closeConnection();
    //    //}
    //}
    //=================================================
    //功能描述：对DropDownList进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dg，需要绑定的DATAGRID控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindDropDownList(string sql, DropDownList dl, string class_name, string id)
    {

        try
        {
            DataSet ds = getdataset(sql);
            dl.DataSource = ds.Tables[0].DefaultView;
            dl.DataTextField = class_name;
            dl.DataValueField = id;
            dl.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
        finally
        {
            closeConnection();
        }
    }
    //=================================================
    //功能描述：对RadioButtonList进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dg，需要绑定的DATAGRID控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindRadioButtonList(string sql, RadioButtonList rl, string class_name, string id)
    {

        try
        {
            DataSet ds = getdataset(sql);
            rl.DataSource = ds.Tables[0].DefaultView;
            rl.DataTextField = class_name;
            rl.DataValueField = id;
            rl.SelectedIndex = 0;
            rl.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
        finally
        {
            closeConnection();
        }
    }
    //=================================================
    //功能描述：对GridView进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dg，需要绑定的DATAGRID控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindGridView(string sql, GridView dg)
    {
        try
        {
            SqlConnection conn = DB.Getconn();
            DataSet ds = getdataset(sql);
            dg.DataSource = ds.Tables[0].DefaultView;
            dg.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
        finally
        {
            closeConnection();
        }
    }
    //=================================================
    //功能描述：对datalist进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dl，需要绑定的datalist控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void binddatalist(string sql, DataList dl)
    {
        try
        {
            SqlConnection conn = DB.Getconn();
            DataSet ds = getdataset(sql);
            dl.DataSource = ds.Tables[0].DefaultView;
            dl.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
        finally
        {
            closeConnection();
        }
    }
    //=================================================
    //功能描述：对repeater进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dl，需要绑定的repeater控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindrepeater(string sql, Repeater rp)
    {
        try
        {
            SqlConnection conn = DB.Getconn();
            DataSet ds = getdataset(sql);
            rp.DataSource = ds.Tables[0].DefaultView;
            rp.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
        finally
        {
            closeConnection();
        }
    }
    //=================================================
    //功能描述：对listbox进行数据绑定
    //输入参数：sql，查询的SQL语句；listb，需要绑定的listbox控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindlistbox(string sql, ListBox listb, string class_name, string id)
    {
        try
        {
            SqlConnection conn = DB.Getconn();
            DataSet ds = getdataset(sql);
            listb.DataSource = ds.Tables[0].DefaultView;
            listb.DataTextField = class_name;
            listb.DataValueField = id;
            listb.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
        finally
        {
            closeConnection();
        }
    }
    /// <summary>
    /// 返回 HTML 字符串的编码结果
    /// </summary>
    /// <param name="str">字符串</param>
    /// <returns>编码结果</returns>
    public static string HtmlEncode(string str)
    {
        return HttpUtility.HtmlEncode(str);
    }

    /// <summary>
    /// 返回 HTML 字符串的解码结果
    /// </summary>
    /// <param name="str">字符串</param>
    /// <returns>解码结果</returns>
    public static string HtmlDecode(string str)
    {
        return HttpUtility.HtmlDecode(str);
    }
    /// <summary>
    /// 检测是否有Sql危险字符
    /// </summary>
    /// <param name="str">要判断字符串</param>
    /// <returns>判断结果</returns>
    public static bool IsSafeSqlString(string str)
    {

        return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
    }
    /// <summary>
    /// 检测用户登录。
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public static string UserCheck(string username,string userpass)
    {
        string strsql = "select count(*) from Member where mem_Name='" + username + "' and mem_Password='"+userpass+"'";
        SqlConnection conn = DB.Getconn();
        SqlCommand com = new SqlCommand(strsql, conn);
        string hang = Convert.ToString(com.ExecuteScalar());
        return hang;
    }
    public static string GetStringByControl(System.Web.UI.Control c)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        System.IO.StringWriter writer = new System.IO.StringWriter(sb);
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(writer);
        c.RenderControl(htw);
        return sb.ToString();
    }
    //执行数据查询功能，返回一个数据表
    public static DataTable OpenQuery(string sql)
    {
        System.Data.DataTable dt;
        //SqlConnection conn = DB.Getconn();  
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"].ToString()))
        {

            if (conn.State.Equals(ConnectionState.Closed))
            {

                conn.Open();

            }
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da.Dispose();
                closeConnection();
            }
        }
        return dt;
    }

}
//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)
