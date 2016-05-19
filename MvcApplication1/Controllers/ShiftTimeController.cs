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
        public class ShiftControllerFilter
        {
            public String plate { get; set; }
            
        }

        ShifTimeService shifTimeService = new ShifTimeService();
               
        [HttpPost]
        public ShiftTime Save(ShiftTime shifTime)
        {
            return shifTimeService.Save(shifTime);
        }

        [HttpPost]
        public ShiftTime Get(ShiftControllerFilter filter)
        {
            return shifTimeService.Get(filter.plate);
        }
        public IEnumerable<ShiftTime> GetAll()
        {
            return shifTimeService.GetAll();
        }
    }
}