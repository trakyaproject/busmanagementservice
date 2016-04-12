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
        if (txtdriverId.Text == "")
        {
            Driver driver = new Driver()
            {
                nameSurname = txtnameSurname.Text,
                tc = txttc.Text,
                birthday = Convert.ToDateTime(txtbirthday.Text),
                bloodGroup = txtbloodGroup.Text,
                phone = txtphone.Text,
                address = txtaddress.Text,
            };
            service.saveOrUpdate(driver);
        }
        else {
            Driver driver = new Driver()
            {
                driverId = Convert.ToInt32(txtdriverId.Text),
                nameSurname = txtnameSurname.Text,
                tc = txttc.Text,
                birthday = Convert.ToDateTime(txtbirthday.Text),
                bloodGroup = txtbloodGroup.Text,
                phone = txtphone.Text,
                address = txtaddress.Text,
            };
            service.saveOrUpdate(driver);
        }
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
        string tc = Convert.ToString(e.ExtraParams["tc"]);
        int driverId = Convert.ToInt32(e.ExtraParams["driverId"]);
        String CommandName = e.ExtraParams["command"];
        // Bus bus = new Bus();

        if (tc == "") return;
        switch (CommandName)
        {
            case "cmdUpdate":
                hdnDriverType.SetValue(driverId);
                txtdriverId.Text = driverId.ToString();
                txttc.Text = tc;
                WindowDriver.Show();
                break;
            case "cmdDel":
                hdnDriverDelete.SetValue(tc);
                wndDeleteConfirm.Show();
                break;
        }
    }
    private void getExtract(int ID)
    {
    }

    protected void btnDelete_DirectClick(object sender, DirectEventArgs e)
    {
        Store str = grdDriver.GetStore();
        Driver driver = new Driver();
        DriverService driverService = new DriverService();

        driver.tc = hdnDriverDelete.Value.ToString();
        driver = driverService.delete(driver);
        btnGet_DirectClick(new object(), new DirectEventArgs(null));
        wndDeleteConfirm.Hide();


    }
    protected void btnCancel_DirectClick(object sender, DirectEventArgs e)
    {
        wndDeleteConfirm.Hide();

    }

}