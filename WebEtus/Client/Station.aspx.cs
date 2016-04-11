using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Station : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void btnGetList_DirectClick(object sender, Ext.Net.DirectEventArgs e)
    {
        //    Database.OpenSession();
        //    grdStation.BindDataSet(Database.Session.Query<etusLibrary.Station>().ToList());
        //    Database.CloseSession();
    }
    protected void cmdCommand(object sender, Ext.Net.DirectEventArgs e)
    {
    }

    protected void btnAddNew_DirectClick(object sender, DirectEventArgs e)
    {

        //Window1.Render(this.Form);

    }
    private void ResetForm()
    {
    }

    protected void btnSave_DirectClick(object sender, DirectEventArgs e)
    {
    }
    protected void btnKaydet_DirectClick(object sender, DirectEventArgs e)
    {
        Window1.Visible = true;




        Window1.Visible = false;

    }

    protected void btnCancel_DirectClick(object sender, DirectEventArgs e)
    {
        //wndNew.Hide();
    }
}