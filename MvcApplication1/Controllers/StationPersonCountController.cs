using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class StationPersonCountController : ApiController
    {
        StationPersonCountService SPCountService = new StationPersonCountService();

        [HttpPost]
        public StationPersonCount SPCountSave(StationPersonCount Count)
        {
            return SPCountService.StationPersonCountSave(Count);
        }

        [HttpPost]
        public StationPersonCount SPCountGetByStationId(StationPersonCount Count)
        {
            return SPCountService.StationPersonCountGetByStationId(Count);
        }
        [HttpPost]
        public StationPersonCount littleStationPersonCount()
        {
            return SPCountService.littleStationPersonCount();
        }
        [HttpPost]
        public IEnumerable<StationPersonCount> littleStationPersonCountList()
        {
            return SPCountService.littleStationPersonCountList();
        }
    }
}
