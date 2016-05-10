using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class BusControllerFilter
    {
        public String Pwd { get; set; }
        public Bus bus { get; set; }
    }

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
            //if (filter.Pwd == "") return null;
            //if (filter.Pwd != "123") return null;
            return busService.getBus(bus);
        }

        [HttpPost]
        public IEnumerable<Bus> GetAllBus()
        {
            return busService.getAllBus();
        }

        [HttpPost]
        public Bus DelteBus(Bus bus)
        {
            return busService.delete(bus);
        }

        //[HttpPost]
        //public Object Login(BusControllerFilter filter)
        //{
        //    if (filter.Pwd == "") return null;
        //    if (filter.Pwd != "123") return null;

        //    return busService.Login(filter.Email, filter.Password);
        //    // return new ExcBraUser() { Email = filter.Email, Password = filter.Password }.Login();
        //}
    }
}