using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// upload 的摘要说明
/// </summary>
public class upload
{
	public upload()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public string[] Resup ={ "上传失败或指定的文件不存在", "图片大于100000K，重新传图片！", "格式不对，限制上传（只允许gif/jpg格式文件）！", "上传成功！" };
    public string s = string.Empty;

    public string Up(System.Web.UI.HtmlControls.HtmlInputFile File2, string Pa)
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //

        if (File2.PostedFile.ContentLength.ToString() == "0")
        {
            return "0";
        }
        else
        {
            //获取文件名称
            string ss;
            ss = Path.GetFileName(File2.PostedFile.FileName);
            string ss1 = Path.GetExtension(File2.PostedFile.FileName);
            if (File2.PostedFile.ContentLength / 1024 > 100000)
            { return "1"; }
            else
            {
                string ty = ss1;
                if (ty == ".gif" || ty == ".jpg")
                {
                    File2.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(Pa) + ss);
                    s = "./Uploads/Images/" + ss;
                    return "3";
                    //Up= ss;
                }
                else
                { return "2"; }
            }
        }

    }
    public string[] Resup1 = { "上传失败或指定的文件不存在", "文件大于10000K，重新传！", "格式不对，限制上传（只允许doc格式文件）！", "作业上传成功！" };
    public string s1 = string.Empty;

    public string Up1(System.Web.UI.HtmlControls.HtmlInputFile File2, string Pa,string name)
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //

        if (File2.PostedFile.ContentLength.ToString() == "0")
        {
            return "0";
        }
        else
        {
            //获取文件名称
            string ss;
            ss = name + Path.GetExtension(File2.PostedFile.FileName);
            string ss1 = Path.GetExtension(File2.PostedFile.FileName);
            if (File2.PostedFile.ContentLength / 1024 > 10000)
            { return "1"; }
            else
            {
                string ty = ss1;
                if (ty == ".doc")
                {
                    File2.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(Pa) + ss);
                    s1 = "../Uploads/studentWork/" + ss;
                    return "3";
                 
                    //Up= ss;
                }
                else
                { return "2"; }
            }
        }

    }
    public string[] Resup2 = { "上传失败或指定的文件不存在", "文件大于50000K，重新传！", "格式不对，限制上传（只允许zip/rar格式文件）！", "作业附件上传成功！" };
    public string s2 = string.Empty;
  
    public string Up2(System.Web.UI.HtmlControls.HtmlInputFile File2, string Pa,string name)
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //

        if (File2.PostedFile.ContentLength.ToString() == "0")
        {
            return "0";
        }
        else
        {
            //获取文件名称
            string ss;
            ss = name + Path.GetExtension(File2.PostedFile.FileName);
            string ss1 = Path.GetExtension(File2.PostedFile.FileName);
            if (File2.PostedFile.ContentLength / 1024 > 50000)
            { return "1"; }
            else
            {
                string ty = ss1;
                if (ty == ".zip" || ty == ".rar")
                {
                    File2.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(Pa) + ss);
                    s2 = "../Uploads/studentWork/" + ss;
                    return "3";
            
                    //Up= ss;
                }
                else
                { return "2"; }
            }
        }

    }
    public string[] Resup3 = { "上传失败或指定的文件不存在", "文件大于10000K，重新传！", "格式不对，限制上传（只允许xls格式文件）！", "文件上传成功！" };
    public string s3 = string.Empty;

    public string Up3(System.Web.UI.HtmlControls.HtmlInputFile File2, string Pa, string name)
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //

        if (File2.PostedFile.ContentLength.ToString() == "0")
        {
            return "0";
        }
        else
        {
            //获取文件名称
            string ss;
            ss = name + Path.GetExtension(File2.PostedFile.FileName);
            string ss1 = Path.GetExtension(File2.PostedFile.FileName);
            if (File2.PostedFile.ContentLength / 1024 > 10000)
            { return "1"; }
            else
            {
                string ty = ss1;
                if (ty == ".xls")
                {
                    File2.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(Pa) + ss);
                    s3 = "/lwhPersonal/Uploads/excel/" + ss;
                    return "3";

                    //Up= ss;
                }
                else
                { return "2"; }
            }
        }

    }

    }

