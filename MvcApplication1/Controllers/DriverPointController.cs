using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MvcApplication1.Controllers
{
    public class DriverPointController: ApiController

    {
        //
        // GET: /DriverPoint/
        DriverPointService driverpointservice = new DriverPointService();
       [HttpPost]
       public DriverPoint DriverPointSave(DriverPoint driverpoint)
        {
            return driverpointservice.DriverPointSave(driverpoint);
        }
        public DriverPoint DriverPointGet(DriverPoint driverpoint)
        {

            return driverpointservice.getPoint(driverpoint);
        }
    }
}
