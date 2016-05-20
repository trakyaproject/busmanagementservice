using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
     public class BusLocation
    {
        public virtual int busLocationId { get; set; }
        public virtual string busLocation { get; set; }
        public virtual Bus busId { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class BusLocationMap : ClassMapping<BusLocation>
    {
        public BusLocationMap()
        {
            Table("BusLocation");
            Id(x => x.busLocationId, x => x.Generator(Generators.Identity));
            Property(x => x.busLocation, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));

            ManyToOne(x => x.busId, x =>
            {
                x.Column("busId");
                x.NotNullable(true);
            }); 


        }
    }
    public class BusLocationService
    {
      
        public BusLocation Save(BusLocation buslocation)
        {
            
            Bus existBus = Database.Session.QueryOver<Bus>().Where(x=>x.plate== buslocation.busId.plate).SingleOrDefault();
            int a = Database.Session.QueryOver<BusLocation>().Where(x => x.busId== existBus).RowCount();
            if (a >= 1)
            {
            IEnumerable <BusLocation> existBusLocation=  Database.Session.QueryOver<BusLocation>().Where(x => x.busId.busId == existBus.busId).OrderBy(x=>x.createdAt).Desc.List();
                BusLocation updateBusLocationState = existBusLocation.FirstOrDefault();
                updateBusLocationState.state = false;
                Database.Session.Clear();
                Database.Session.Update(updateBusLocationState);
                Database.Session.Flush();
                buslocation.createdAt = DateTime.Now;
                buslocation.busId = existBus;
                buslocation.state = true;
                Database.Session.Save(buslocation);
            }
            else
            {
              
                    buslocation.createdAt = DateTime.Now;
                    buslocation.state = true;
                    buslocation.busId = existBus;
                    Database.Session.Clear();
                    Database.Session.Save(buslocation);
                    Database.Session.Flush();
                
             
            }
            return buslocation;
        }


        public BusLocation getBusLocation(Bus bus)
        {
            bus = Database.Session.QueryOver<Bus>().Where(x => x.plate == bus.plate && x.state == true).SingleOrDefault();
            BusLocation busLocation = Database.Session.QueryOver<BusLocation>().Where(x => x.busId == bus && x.state == true).SingleOrDefault();
            return busLocation;
        }


    }
}
