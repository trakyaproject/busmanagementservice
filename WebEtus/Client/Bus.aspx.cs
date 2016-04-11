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

public partial class Client_Bus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGetAccounts_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        Bus bus = new Bus();
        BusService service= new BusService();
        Object message = service.getOrGetAll(bus);
        Store str = grdBus.GetStore();
        
       str.DataSource = message;
       str.DataBind();

    }

    protected void btnAddNew_DirectClick(object sender, DirectEventArgs e)
    {
        Window1.Render(this.Form);

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

        Bus bus = new Bus()
        {
             plate = txtPlate.Text,
             busModel = txtModel.Text,
             maxBusPessenger= Convert.ToInt32(txtMaxPassenger.Value)
            
            
        };
        
      Object message =service.saveOrUpdate(bus);
        
      this.Window1.Hide();
      

    }

    protected void cmdCommand(object sender, Ext.Net.DirectEventArgs e)
    {
        string plate = Convert.ToString(e.ExtraParams["plate"]);
        String CommandName = e.ExtraParams["command"];

        if (plate == "") return;
        switch (CommandName)
        {

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

        

    }
    protected void btnDeleteConfirmCancel_DirectClick(object sender, DirectEventArgs e)
    {
        wndDeleteConfirm.Hide();

    }

}