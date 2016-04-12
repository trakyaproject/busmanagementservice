using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proje.Models;
using proje;
public partial class Client_Station : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void btnGetAccounts_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        Station station = new Station();
        StationService service = new StationService();
        Store str = grdStation.GetStore();
        str.DataSource = Database.Session.QueryOver<Station>().Where(x => x.state == true).List();
        str.DataBind();
    }
   

    protected void btnAddNew_DirectClick(object sender, DirectEventArgs e)
    {

        Window1.Render(this.Form);
        Window1.Show();
    }
    private void ResetForm()
    {
    }

    protected void btnSave_DirectClick(object sender, DirectEventArgs e)
    {
    }
    protected void btnKaydet_DirectClick(object sender, DirectEventArgs e)
    {
        if (txtstationName.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }
        if (txtlocation.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }
        if (txtaddress.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }
       StationService service = new StationService();
       if (txtstationId.Text == "") { 
        Station station = new Station()
        {

            stationName = txtstationName.Text,
            location = txtlocation.Text,
            address = txtaddress.Text,
        };
        service.saveOrUpdate(station);
        }

         else {
             Station station = new Station()
             {
                 stationId =Convert.ToInt32(txtstationId.Text),
                 stationName = txtstationName.Text,
                 location = txtlocation.Text,
                 address = txtaddress.Text,
             };
             service.saveOrUpdate(station);
         }

        X.Msg.Alert("UYARI", "Bilgiler kayıt edilmiştir.").Show();
        Window1.Hide(this.Form);
        btnGetAccounts_DirectClick(new object(), new DirectEventArgs(null));
       
    }
    protected void cmdCommand(object sender, Ext.Net.DirectEventArgs e)
    {
        string stationName = Convert.ToString(e.ExtraParams["stationName"]);
        int stationId = Convert.ToInt32(e.ExtraParams["stationId"]);
        String CommandName = e.ExtraParams["command"];

        if (stationName == null) return;
        switch (CommandName)
        {
            case "cmdUpdate":
                hdnStationType.SetValue(stationId);
                txtstationId.Text = stationId.ToString();
                Window1.Show();
                break;
            case "cmdDel":
                hdnStationType.SetValue(stationName);
                wndDeleteConfirm.Show();
                break;
        }
    }

    protected void btnCancel_DirectClick(object sender, DirectEventArgs e)
    {
    //    wndNew.Hide();
    }
    protected void btnDel_DirectClick(object sender, DirectEventArgs e)
    {
        Store str = grdStation.GetStore();
        Station station = new Station();
        StationService StationService = new StationService();

        station.stationName = hdnStationDelete.Text; ;
        station = StationService.delete(station);
        btnGetAccounts_DirectClick(new object(), new DirectEventArgs(null));
        wndDeleteConfirm.Hide();
    }
    protected void btnExit_DirectClick(object sender, DirectEventArgs e)
    {
        wndDeleteConfirm.Hide();
    }

}