using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using proje.Models;

namespace MvcApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpPost]
        //public Object Get(Bus s)
        //{
        //    BusService se = new BusService();
        //    return se.Save(s);
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

       

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}