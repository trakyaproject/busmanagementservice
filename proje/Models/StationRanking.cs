using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje.Models
{
     public class StationRanking
    {
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
            Property(x => x.rank, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));

            ManyToOne(x => x.stationId, x =>
            {
                x.Column("stationId");
                x.NotNullable(true);
            });

            ManyToOne(x => x.lineId, x =>
            {
                x.Column("lineId");
                x.NotNullable(true);
            }); 
        }

    }
}
