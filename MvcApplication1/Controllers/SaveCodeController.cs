using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proje.Models;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class SaveCodeController : ApiController
    {
        SaveCodeService saveCodeService = new SaveCodeService();
        [HttpPost]
        public SaveCode Save(SaveCode saveCode)
        {
            return saveCodeService.Save(saveCode);
        }
    }
}