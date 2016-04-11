using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class BusLocationController :ApiController
    {
        BusLocationService busLocationService = new BusLocationService();
        [HttpPost]
        public BusLocation Save(BusLocation busLocation)
        {
            return busLocationService.Save(busLocation);
        }

        [HttpPost]
        public BusLocation GetBusLocation(Bus busLocation)
        {
            return busLocationService.getBusLocation(busLocation);
        }
    }
}