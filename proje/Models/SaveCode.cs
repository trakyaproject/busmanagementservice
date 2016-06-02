using NHibernate.Mapping.ByCode;
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
        public virtual int codeId { get; set; }
        public virtual Driver driverId { get; set; }
        public virtual string code { get; set; }
        public virtual DateTime dateCode { get; set; }

    }

    public class SaveCodeMap : ClassMapping<SaveCode>
    {
        public SaveCodeMap()
        {
            Table("SaveCode");
            Id(x => x.codeId, x => x.Generator(Generators.Identity));
            Property(x => x.code, x => x.NotNullable(true));
            Property(x => x.dateCode, x => x.NotNullable(true));


            ManyToOne(x => x.driverId, x =>
            {
                x.Column("driverId");
                x.NotNullable(true);
            }); 


        }
    }
    public class SaveCodeService
    {
        public SaveCode Save(SaveCode saveCode)
        {
            saveCode.dateCode = DateTime.Now;
            saveCode.driverId = Database.Session.QueryOver<Driver>().Where(x => x.driverId == saveCode.driverId.driverId && x.state == true).SingleOrDefault();
            Database.Session.Save(saveCode);
            return saveCode;


        }
         public SaveCode GetCode(SaveCode saveCode)
        {
            Driver driver = Database.Session.QueryOver<Driver>().Where(x => x.driverId == saveCode.driverId.driverId).SingleOrDefault();
            saveCode = Database.Session.QueryOver<SaveCode>().Where(x => x.driverId.driverId == driver.driverId).OrderBy(x => x.codeId).Desc.List().FirstOrDefault();
            return saveCode;
        }
    }
}
