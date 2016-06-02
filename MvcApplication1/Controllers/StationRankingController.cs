using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class StationRankingController : ApiController
    {
        StationRankingService StationRankingService = new StationRankingService();
        [HttpPost]
        public StationRanking Save(StationRanking StationRanking)
        {
            return StationRankingService.StationRankingSave(StationRanking);
        }
        [HttpPost]
        public IEnumerable< StationRanking> Get(Line line)
        {
            return StationRankingService.StationRankingGet(line);
        }
    }
}
