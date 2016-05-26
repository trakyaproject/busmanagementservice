using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;


namespace proje.Models
{
     public class StationRanking
    {
        public virtual int Id { get; set; }
        public virtual int rank { get; set; }
        public virtual Line lineId { get; set; }
        public virtual Station stationId { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class StationRankingMap : ClassMapping<StationRanking>
    {
        public StationRankingMap()
        {
            Table("StationRanking");
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.rank, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));

            ManyToOne(x => x.stationId, x =>
            {
                x.Column("stationId");
                x.NotNullable(true);
                x.Lazy(LazyRelation.NoLazy);
            });

            ManyToOne(x => x.lineId, x =>
            {
                x.Column("lineId");
                x.NotNullable(true);
                x.Lazy(LazyRelation.NoLazy);
            }); 
        }

    }
    public class StationRankingService
    {
        public StationRanking StationRankingSave(StationRanking stationRanking)
        {
            stationRanking.lineId = Database.Session.QueryOver<Line>().Where(x => x.lineId == stationRanking.lineId.lineId).SingleOrDefault();
            stationRanking.createdAt = DateTime.Now;
            stationRanking.state = true;
            stationRanking.stationId = Database.Session.QueryOver<Station>().Where(x => x.stationId == stationRanking.stationId.stationId).SingleOrDefault();
            if (Database.Session.QueryOver<StationRanking>().Where(x => x.lineId == stationRanking.lineId && x.rank == stationRanking.rank).RowCount() == 0)
            {
                Database.Session.Save(stationRanking);
                return stationRanking;
            }
            else
                return null;
        }
        public IEnumerable<StationRanking> StationRankingGet(Line line)
        {
            IEnumerable<StationRanking> StationRanking = Database.Session.Query<StationRanking>().Where(x => x.lineId.lineId == line.lineId).OrderBy(x => x.rank).ToList();

            return StationRanking;
        }
    }
   
  
}
