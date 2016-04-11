using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace proje.Models
{
    public class Bus
    {
        public virtual int busId { get; set; }
        public virtual string plate { get; set; }
        public virtual string busModel { get; set; }
        public virtual int maxBusPessenger { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class BusMap : ClassMapping<Bus>
    {
        public BusMap()
        {
            Table("Bus");
            Id(x => x.busId, x => x.Generator(Generators.Identity));
            Property(x => x.plate, x => x.NotNullable(true));
            Property(x => x.busModel, x => x.NotNullable(true));
            Property(x => x.maxBusPessenger, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(false));
            Property(x => x.createdAt, x => x.NotNullable(true));
        }
    }

    public class BusService
    {
        Bus newBus = new Bus();
        Object message;
        public Bus saveOrUpdate(Bus bus)
        {
            Bus existBus = Database.Session.Load<Bus>(bus.busId);

            if (existBus.busId == 0)
            {
                bus.createdAt = System.DateTime.Now;
                bus.state = true;
                try
                {
                    Database.Session.Save(bus);
                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            else
            {

                newBus = bus;
                newBus.createdAt = System.DateTime.Now;
                newBus.state = true;
                if (bus.busModel == null || bus.maxBusPessenger == 0 || bus.plate == null)
                {

                    if (bus.busModel == null)
                        newBus.busModel = existBus.busModel;
                    if (bus.maxBusPessenger == 0)
                        newBus.maxBusPessenger = existBus.maxBusPessenger;
                    if (bus.plate == null)
                        newBus.plate = existBus.plate;

                }
                try
                {
                    Database.Session.Clear();
                    Database.Session.Update(newBus);
                    Database.Session.Flush();

                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            return bus;
        }

        public Bus getBus(Bus bus)
        {
            bus = Database.Session.QueryOver<Bus>().Where(x => x.plate == bus.plate && x.state == true).SingleOrDefault();
            return bus;
        }

        public IEnumerable<Bus> getAllBus()
        {

            return Database.Session.QueryOver<Bus>().Where(x => x.state == true).List();
        }

        public Bus delete(Bus bus)
        {
            Bus existBus = Database.Session.QueryOver<Bus>().Where(x => x.plate == bus.plate).SingleOrDefault();
            if (existBus.plate == null)
            {
                return null;
            }
            else
            {
                    bus.busId = existBus.busId;
                    existBus.state = false;
                    bus.busModel = existBus.busModel;
                    bus.maxBusPessenger = existBus.maxBusPessenger;
                    bus.plate = existBus.plate;
                    bus.createdAt = existBus.createdAt;

                    Database.Session.Clear();
                    Database.Session.Update(bus);
                    Database.Session.Flush();
                

                return bus;
            }

        }

    }
}
