using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MvcApplication1.Controllers
{
   
    public class ShiftTimeController :ApiController
    {
        ShifTimeService shifTimeService = new ShifTimeService();
               
        [HttpPost]
        public ShiftTime Save(ShiftTime shifTime)
        {
            return shifTimeService.Save(shifTime);
        }

        [HttpPost]
        public ShiftTime Get(ShiftTime shifTime)
        {
            return shifTimeService.Get(shifTime);
        }
    }
}