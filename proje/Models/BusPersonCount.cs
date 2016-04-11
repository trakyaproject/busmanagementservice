using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
    public class BusPersonCount
    {
        public virtual int busPersonCountId { get; set; }
        public virtual int busPersonCount { get; set; }
        public virtual DateTime busPersonCountTime { get; set; }
        public virtual Bus busId { get; set; }
    }

    public class BusPersonCountMap : ClassMapping<BusPersonCount>
    {
        public BusPersonCountMap()
        {
            Table("BusPersonCount");
            Id(x => x.busPersonCountId, x => x.Generator(Generators.Identity));
            Property(x => x.busPersonCount, x => x.NotNullable(true));
            Property(x => x.busPersonCountTime, x => x.NotNullable(true));

            ManyToOne(x => x.busId, x =>
            {
                x.Column("busId");
                x.NotNullable(true);
            }); 
        }

    }
}
