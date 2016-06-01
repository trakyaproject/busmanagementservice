using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
    
    public class ShiftTime
    {
        public virtual int shiftTimeId { get; set; }
        public virtual DateTime departureTime { get; set; }
      
        public virtual Bus plate { get; set; }
        public virtual Driver driverId { get; set; }
        public virtual Line lineId { get; set; }
        public virtual DateTime stiftStart { get; set; }
        public virtual DateTime shiftEnd { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
      //  public virtual Bus 
    }
  
    public class ShiftTimeMap : ClassMapping<ShiftTime>
    {
        public ShiftTimeMap()
        {
            Table("ShiftTime");
            Id(x => x.shiftTimeId, x => x.Generator(Generators.Identity));
            Property(x => x.departureTime, x => x.NotNullable(true));
            Property(x => x.stiftStart, x => x.NotNullable(true));
            Property(x => x.shiftEnd, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));
         //   Property(x=>x.existPlate, 


            ManyToOne(x => x.driverId, x =>
            {
                x.Column("driverId");
                x.NotNullable(true);
                x.Lazy(LazyRelation.NoLazy);
            });


            ManyToOne(x => x.plate, x =>
            {
                x.Column("plate");
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

  public class ShifTimeService
    {
        ShiftTime message;
        public ShiftTime Get(string shifTime)
        {// burda plaka ile sorgu attgında istegin bilgiler geliyolar stations dişinda onun içde rankinge sorgu atılacak
            Bus existPlate = Database.Session.QueryOver<Bus>().Where(x => x.plate == shifTime).SingleOrDefault();
            IEnumerable<ShiftTime> existShifTime = Database.Session.QueryOver<ShiftTime>().Where(x => x.plate.busId == existPlate.busId && ( x.stiftStart<= DateTime.Now && DateTime.Now<=x.shiftEnd)).OrderBy(y => y.createdAt).Desc.List();
            
            Database.Session.Flush();
            Database.Session.Clear();


            return existShifTime.FirstOrDefault();
        }
        public IEnumerable< ShiftTime> GetAll()
        {
            return Database.Session.QueryOver<ShiftTime>().Where(x=> x.stiftStart <= DateTime.Now && DateTime.Now <= x.shiftEnd).List();
        }
        
        Object mssg;
        
        public ShiftTime Save(ShiftTime shifTime)
        {

            shifTime.plate = Database.Session.QueryOver<Bus>().Where(x => x.plate == shifTime.plate.plate).SingleOrDefault();
        shifTime.lineId=Database.Session.QueryOver<Line>().Where(x => x.lineName == shifTime.lineId.lineName).SingleOrDefault();
            shifTime.driverId = Database.Session.QueryOver<Driver>().Where(x => x.driverId == shifTime.driverId.driverId).SingleOrDefault();
            shifTime.createdAt = DateTime.Now;
        
                shifTime.state = true;
                Database.Session.Save(shifTime);
            
            //catch(Exception e)
            //{
            //    if (e.InnerException.Message != null)
            //        mssg = e.InnerException.Message;
            //    else
            //        mssg = e.Message;


            //}
            return shifTime;
        }
    }
}
