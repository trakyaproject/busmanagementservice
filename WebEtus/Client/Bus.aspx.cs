using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate.Linq;
using NHibernate;
using NHibernate.Mapping.ByCode;
using proje.Models;
using proje;
using proje.Extensions;

public partial class Client_Bus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGetAccounts_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        Bus bus = new Bus();
        BusService service = new BusService();
        Store str = grdBus.GetStore();
        str.DataSource = Database.Session.QueryOver<Bus>().Where(x => x.state == true).List(); 
        str.DataBind();
    }

    protected void btnAddNew_DirectClick(object sender, DirectEventArgs e)
    {
        Window1.Render(this.Form);
        Window1.Show();
    }

    protected void btnKaydet_DirectClick(object sender, DirectEventArgs e)
    {
        if (txtPlate.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }

        if (txtModel.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }

        if (Convert.ToInt32(txtMaxPassenger.Value) <= 0)
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }

        BusService service = new BusService();

        if (TextbusId.Text == "") {
            Bus bus = new Bus()
            {

                
                plate = txtPlate.Text,
                busModel = txtModel.Text,
                maxBusPessenger = Convert.ToInt32(txtMaxPassenger.Value)


            };
            service.saveOrUpdate(bus);
        }

        else { 
        Bus bus = new Bus()
        {
            busId = Convert.ToInt32(TextbusId.Text),
            plate = txtPlate.Text,
            busModel = txtModel.Text,
            maxBusPessenger = Convert.ToInt32(txtMaxPassenger.Value)


        };

        service.saveOrUpdate(bus);
        }
        
        
        X.Msg.Alert("UYARI", "Bilgiler kayıt edilmiştir.").Show();
        Window1.Hide(this.Form);
        btnGetAccounts_DirectClick(new object(), new DirectEventArgs(null));
       
    }

    protected void cmdCommand(object sender, Ext.Net.DirectEventArgs e)
    {
        string plate = Convert.ToString(e.ExtraParams["plate"]);
        int busId = Convert.ToInt32(e.ExtraParams["busId"]);
        String CommandName = e.ExtraParams["command"];
       // Bus bus = new Bus();

        if (plate == "") return;
        switch (CommandName)
        {
            case "cmdUpdate":
                hdnBusType.SetValue(busId);
                TextbusId.Text = busId.ToString();
                txtPlate.Text = plate;
                Window1.Show();
                break;
            case "cmdDel":
                hdnBusDelete.SetValue(plate);
                wndDeleteConfirm.Show();
                break;
        }
    }
    private void getExtract(int ID)
    {
    }
    protected void btnDeleteConfirmSave_DirectClick(object sender, DirectEventArgs e)
    {
        Store str = grdBus.GetStore();
        Bus bus = new Bus();
        BusService busService = new BusService();
        
         
        //service.delete(bus);
        bus.plate = hdnBusDelete.Value.ToString();
        bus=busService.delete(bus);
        btnGetAccounts_DirectClick(new object(), new DirectEventArgs(null));
        wndDeleteConfirm.Hide();
        

    }
    protected void btnDeleteConfirmCancel_DirectClick(object sender, DirectEventArgs e)
    {
        wndDeleteConfirm.Hide();

    }

}