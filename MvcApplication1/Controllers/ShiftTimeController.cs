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
        [HttpPost]
        public IEnumerable<ShiftTime> GetAll()
        {
            return shifTimeService.GetAll();
        }
<<<<<<< HEAD
=======
        
>>>>>>> c74b9c25179700fc8fafabed1898184b2ef5a277
    }
}