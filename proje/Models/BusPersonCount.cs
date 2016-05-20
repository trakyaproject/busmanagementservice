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

    public class BusPersonCountService
    {
        BusPersonCount newCount = new BusPersonCount();

        public BusPersonCount BusPersonCountSave(BusPersonCount Count)
        {
                newCount = Count;
                newCount.busId = newCount.busId;
                Count.busPersonCountTime = System.DateTime.Now;
                Count.busPersonCount = newCount.busPersonCount;
                Database.Session.Save(newCount);

                return Count;
        }

        //public String BusPersonCountSave(BusPersonCount Count)
        //{
          
        //    String record = "record is Null";
        //    String unsuccess = "Gerekli Değerleri giriniz";
        //    newCount = Count;

        //    Bus ExistBus = Database.Session.Load<Bus>(Count.busId.busId);
        //    if (ExistBus.busId == 0)
        //    {
        //        return record;
        //    }

        //    if (newCount.busPersonCount == 0)
        //    { 
        //        return unsuccess; 
        //    }

        //    if(newCount.busId == null)
        //    {
        //        return unsuccess;
        //    }
           
           
        //        String success = "Kayıt Başarılı";
        //        newCount = Count;
        //        Count.busId = newCount.busId;
        //        Count.busPersonCountTime = System.DateTime.Now;
        //        Count.busPersonCount = newCount.busPersonCount;
        //        Database.Session.Save(newCount);

        //        return success;
            
        //}

        public BusPersonCount BusPersonCountGetByBusId(BusPersonCount Count)
        {
            Count = Database.Session.Query<BusPersonCount>().Where(x => x.busId.busId == Count.busId.busId).OrderByDescending(x => x.busPersonCountId).ToList().First();
            return Count;
        }
    }
}
