using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)

public partial class images2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        ValidateNumber s = new ValidateNumber();
        string str = s.CreateValidateNumber(4);
        Session["Vnumber2"] = str;
        s.CreateValidateGraphic(this, str);
        //}
    }


}

//5_1_a_s_p_x.c_o_m
