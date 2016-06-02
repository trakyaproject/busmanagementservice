using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class LineController : ApiController
    {
        OnComingBus OnComingBus = new OnComingBus();
        LineService lineService = new LineService();
        [HttpPost]
       public Line SaveOrUpdate(Line line)
        {
            return lineService.saveOrUpdate(line);
        }
        [HttpPost]
        public Line GetLine(Line line)
        {
            return lineService.getLine(line);
        }
        [HttpPost]
        public IEnumerable<Line> getAllLine()
        {
            return lineService.getAllLine();
        }

        [HttpPost]
        public Line DeleteLine(Line line)
        {
            return lineService.delete(line);
        }
        [HttpPost]
        public IList< BusLocation> GetOnComingBus(Station Station)
        {
            return OnComingBus.GetOnComingBus(Station);
        }
    }
}
