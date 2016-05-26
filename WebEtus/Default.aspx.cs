using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, DirectEventArgs e)
    {
       
    }
    protected void btnLogin_DirectClick(object sender, DirectEventArgs e)
    {
        string username = "Ali Duru";
        string psw = "1234";
        if (txtUsername.Text == username && txtPassword.Text == psw)
        {
            Response.Redirect("~/Client/Default.aspx");
        }
        else {
            X.Msg.Alert("UYARI", "Lütfen geçerli bir kullanıcı adı ve şifresi ile giriş yapınız").Show();
           
        }

    }
}