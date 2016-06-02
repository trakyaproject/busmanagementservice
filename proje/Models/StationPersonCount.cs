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
   public class StationPersonCount
    {
        public virtual int stationPersonCountId { get; set; }
        public virtual int stationPersonCount { get; set; }
        public virtual DateTime stationPersonCountTime { get; set; }
        public virtual Station stationId { get; set; }
    }

    public class StationPersonCountMap : ClassMapping<StationPersonCount>
    {
        public StationPersonCountMap()
        {
            Table("StationPersonCount");
            Id(x => x.stationPersonCountId, x => x.Generator(Generators.Identity));
            Property(x => x.stationPersonCount, x => x.NotNullable(true));
            Property(x => x.stationPersonCountTime, x => x.NotNullable(true));

            ManyToOne(x => x.stationId, x =>
            {
                x.Column("stationId");
                x.NotNullable(true);
                x.Lazy(LazyRelation.NoLazy);
            }); 
        }
    }

    public class StationPersonCountService
    {
        StationPersonCount newCount = new StationPersonCount();

        public StationPersonCount StationPersonCountSave(StationPersonCount Count)
        {
            
            Count.stationPersonCountTime = System.DateTime.Now;
          Count.stationId=  Database.Session.QueryOver<Station>().Where(x => x.stationId == Count.stationId.stationId).SingleOrDefault();
            Database.Session.Save(Count);


            return Count;
        }

        public StationPersonCount StationPersonCountGetByStationId(StationPersonCount Count)
        {
            Count = Database.Session.Query<StationPersonCount>().Where(x => x.stationId == Count.stationId).OrderByDescending(x => x.stationPersonCountId).ToList().First();
            return Count;
        }
        public StationPersonCount littleStationPersonCount()
        {
            
            return Database.Session.QueryOver<StationPersonCount>().OrderBy(x=>x.stationPersonCount).Asc.List().FirstOrDefault();
        }
    }
}
