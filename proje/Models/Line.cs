using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class Line
    {
        public virtual int lineId { get; set; }
        public virtual string lineName { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class LineMap : ClassMapping<Line>
    {
        public LineMap()
        {
            Table("Line");
            Id(x => x.lineId, x => x.Generator(Generators.Identity));
            Property(x => x.lineName, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));
        }
    }
}
