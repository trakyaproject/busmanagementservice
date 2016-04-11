using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.TreePanel1.Listeners.ItemClick.Handler = "addTab(App.pnlTab, record);";
        if (!X.IsAjaxRequest)
        {
            lblUserName.Text = HttpContext.Current.User.Identity.Name;
            try
            {
                //lblFirmName.Text = "Kullanıcı Adı  : " + ((SystemUser)Session["User"]).UserName;

            }
            catch { }
        }
    }
    protected void btnLogOut_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/default.aspx");
    }
}