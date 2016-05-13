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
        

    }
    protected void btnGet_DirectClick(object sender, DirectEventArgs e)
    {
        ShiftTime sT = new ShiftTime();
        ShifTimeService stService = new ShifTimeService();
        Store str = grdST.GetStore();
        str.DataBind();
    }
    protected void btnAddNew_DirectClick(object sender, DirectEventArgs e)
    {
        WindowST.Render(this.Form);
        WindowST.Show();
       
    
    }
    protected void btnKaydet_DirectClick(object sender, DirectEventArgs e)
    {
        if (cmbdepartureTime.Text == "")
        {
            X.Msg.Alert("UYARI", "Boş Alan Bırakmayınız.").Show();
            return;
        }

        ShifTimeService stService = new ShifTimeService();

        if (txtshiftTimeId.Text == "")
        {
            ShiftTime sT = new ShiftTime()
            {
                departureTime = Convert.ToDateTime(cmbdepartureTime.Value),
                              

            };
            stService.Save(sT);
        }

        else
        {
            ShiftTime sT = new ShiftTime()
            {
                

            };

            stService.Save(sT);
        }


        X.Msg.Alert("UYARI", "Bilgiler kayıt edilmiştir.").Show();
        WindowST.Hide(this.Form);
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

    protected void btnDelete_DirectClick(object sender, DirectEventArgs e)
    {
        

    }
    protected void btnCancel_DirectClick(object sender, DirectEventArgs e)
    {
       

    }
}