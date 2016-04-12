using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class DriverController :ApiController
    {
        DriverService driverService = new DriverService();


        [HttpPost]
        public Driver SaveOrUpdate(Driver driver)
        {
            return driverService.saveOrUpdate(driver);
        }

        [HttpPost]
        public Driver GetDriver(Driver driver)
        {
            return driverService.getDriver(driver);
        }


        [HttpPost]
        public IEnumerable<Driver> getAllDriver()
        {
            return driverService.getAllDriver();
        }
        [HttpPost]
        public Driver DeleteDriver(Driver Driver)
        {
            return driverService.delete(Driver);
        }
    }
}