using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class BusPersonCountController : ApiController
    {

        BusPersonCountService BPCountService = new BusPersonCountService();

        [HttpPost]
        public BusPersonCount BPCountSave(BusPersonCount Count)
        {
            return BPCountService.BusPersonCountSave(Count);
        }

        [HttpPost]
        public BusPersonCount BPCountGetByStationId(BusPersonCount Count)
        {
            return BPCountService.BusPersonCountGetByBusId(Count);
        }

    }
}
