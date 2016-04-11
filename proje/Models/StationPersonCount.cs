using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            }); 
        }
    }
}
