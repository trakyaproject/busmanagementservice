using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class DriverPoint
    {
        public virtual int driverPointId { get; set; }
        public virtual DateTime pointTime { get; set; }
        public virtual int driverPoint { get; set; }
        public virtual Driver driverId { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class DriverPointMap : ClassMapping<DriverPoint>
    {
        public DriverPointMap()
        {
            Table("DriverPoint");
            Id(x => x.driverPointId, x => x.Generator(Generators.Identity));
            Property(x => x.pointTime, x => x.NotNullable(true));
            Property(x => x.driverPoint, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));

            ManyToOne(x => x.driverId, x =>
            {
                x.Column("driverId");
                x.NotNullable(true);
            }); 
        }
    }

}
