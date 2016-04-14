using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class BusController : ApiController
    {
        BusService busService = new BusService();
        [HttpPost]
        public Bus SaveOrUpdate(Bus bus)
        {
            return busService.saveOrUpdate(bus);
        }

        [HttpPost]
        public Bus GetBus(Bus bus)
        {
            return busService.getBus(bus);
        }

        [HttpPost]
        public IEnumerable<Bus> GetAllBus()
        {
            return busService.getAllBus();
        }

        [HttpPost]
        public Bus DeleteBus(Bus bus)
        {
            return busService.delete(bus);
        }
    }
}