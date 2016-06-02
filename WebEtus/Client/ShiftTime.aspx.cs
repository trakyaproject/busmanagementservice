using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proje.Models;
using proje;
using Ext.Net;
public partial class Client_ShiftTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            btnGet_DirectClick(new object(), new DirectEventArgs(null));
            cmbDriverList = cmbDriver.GetStore();
            cmbDriverList.DataSource = new DriverService().getAllDriver();
            cmbDriverList.DataBind();
            cmbPlateList = cmbplate.GetStore();
            cmbPlateList.DataSource = new BusService().getAllBus();
            cmbPlateList.DataBind();
            cmbLineList = cmblineName.GetStore();
            cmbLineList.DataSource = new LineService().getAllLine();
            cmbLineList.DataBind();
            
    }
    protected void btnGet_DirectClick(object sender, DirectEventArgs e)
    {
        //ShiftTime st = new ShiftTime();
        ShifTimeService stService = new ShifTimeService();
        
        Store str = grdST.GetStore();
        str.DataSource = stService.GetAll();
        str.DataBind();
    }
    protected void btnAddNew_DirectClick(object sender, DirectEventArgs e)
    {
        WindowST.Render(this.Form);
        WindowST.Show();
    }
    protected void btnKaydet_DirectClick(object sender, DirectEventArgs e)
    {       
        ShifTimeService stService = new ShifTimeService();

        if (txtshiftTimeId.Text == "")
        {
            ShiftTime sT = new ShiftTime()
            {
                departureTime = cmbdepartureTime.SelectedItem.Value.ToString(),
                plate = new Bus() { plate = cmbplate.SelectedItem.Text },
                driverId = new Driver() { driverId = Convert.ToInt32(cmbDriver.SelectedItem.Value.ToString()) },
                lineId = new Line() { lineName = cmblineName.SelectedItem.Text },
                stiftStart = Convert.ToDateTime(txtstiftStart.Text),
                shiftEnd = Convert.ToDateTime(txtshiftEnd.Text)
            };
            stService.Save(sT);
        }

        else
        {
            ShiftTime sT = new ShiftTime()
            {
                departureTime = cmbdepartureTime.SelectedItem.Value.ToString(),
                plate = new Bus() { plate = cmbplate.SelectedItem.Text },
                driverId = new Driver() { driverId = Convert.ToInt32(cmbDriver.SelectedItem.Value.ToString()) },
                lineId = new Line() { lineName = cmblineName.SelectedItem.Text },
                stiftStart = Convert.ToDateTime(txtstiftStart.Text),
                shiftEnd = Convert.ToDateTime(txtshiftEnd.Text)
            };
            stService.Save(sT);
        }
        txtshiftEnd.Clear();
        txtshiftTimeId.Clear();
        txtstiftStart.Clear();
        cmbdepartureTime.Clear();
        cmbDriver.Clear();
        cmblineName.Clear();
        cmbplate.Clear();
        X.Msg.Alert("UYARI", "Bilgiler kayıt edilmiştir.").Show();
        WindowST.Hide(this.Form);
        btnGet_DirectClick(new object(), new DirectEventArgs(null));
       
        
    }
  
   
}