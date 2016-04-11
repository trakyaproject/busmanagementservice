using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proje.Models;
using proje;

public partial class Client_Driver : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void btnGet_DirectClick(object sender, DirectEventArgs e)
    {
        Driver driver = new Driver();
        DriverService service = new DriverService();
        object message =  Database.Session.QueryOver<Driver>().Where(x => x.state == true).List();
        Store str = grdDriver.GetStore();
        str.DataSource = message;
        str.DataBind();

    }
    protected void btnAddNew_DirectClick(object sender, DirectEventArgs e)
    {
        WindowDriver.Render(this.Form);
        WindowDriver.Show();
    }
    protected void btnKaydet_DirectClick(object sender, DirectEventArgs e)
    {
        if (txtnameSurname.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }

        if (txttc.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }
        if (txtbloodGroup.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }
        if (txtphone.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }
        if (txtaddress.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }
        DriverService service = new DriverService();

        Driver driver = new Driver()
        {
            nameSurname = txtnameSurname.Text,
            tc = txttc.Text,
            bloodGroup = txtbloodGroup.Text,
            phone = txtphone.Text,
            address = txtaddress.Text,
         };
        service.saveOrUpdate(driver);
        X.Msg.Alert("UYARI", "Bilgiler kayıt edilmiştir.").Show();
        WindowDriver.Hide(this.Form);
        btnGet_DirectClick(new object(), new DirectEventArgs(null));
       
    }
    protected void btnDeleteConfirmSave_DirectClick(object sender, DirectEventArgs e)
    {
    }
    protected void btnDeleteConfirmCancel_DirectClick(object sender, DirectEventArgs e)
    {
    }
    protected void cmdCommand(object sender, Ext.Net.DirectEventArgs e)
    {
    }
    private void getExtract(int ID)
    {
    }
}