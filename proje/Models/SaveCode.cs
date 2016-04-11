using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class SaveCode
    {
        public virtual Driver driverId { get; set; }
        public virtual string code { get; set; }
        public virtual DateTime dateCode { get; set; }

    }

    public class SaveCodeMap : ClassMapping<SaveCode>
    {
        public SaveCodeMap()
        {
            Table("SaveCode");
            Property(x => x.code, x => x.NotNullable(true));
            Property(x => x.dateCode, x => x.NotNullable(true));


            ManyToOne(x => x.driverId, x =>
            {
                x.Column("driverId");
                x.NotNullable(true);
            }); 


        }
    }
}
