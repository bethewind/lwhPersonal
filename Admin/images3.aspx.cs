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

public partial class Admin_images3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidateNumber s = new ValidateNumber();
        string str = s.CreateValidateNumber(4);
        Session["Vnumber3"] = str;
        s.CreateValidateGraphic(this, str);
    }
}
