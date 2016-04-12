using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class Station
    {
        public virtual int stationId { get; set; }
        public virtual string stationName { get; set; }
        public virtual string location { get; set; }
        public virtual string address { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class StationMap : ClassMapping<Station>
    {
        public StationMap()
        {
            Table("Station");
            Id(x => x.stationId, x => x.Generator(Generators.Identity));
            Property(x => x.stationName, x => x.NotNullable(true));
            Property(x => x.location, x => x.NotNullable(true));
            Property(x => x.address, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));            
        }
    }


    public class StationService
    {
        Station newStation = new Station();
        Object message;
        public Station saveOrUpdate(Station station)
        {
            Station existStation = Database.Session.Load<Station>(station.stationId);
            if (existStation.stationId == 0)
            {
                station.createdAt = System.DateTime.Now;
                station.state = true;
                try
                {
                    Database.Session.Save(station);
                }
                catch(Exception e)
                {
                    message = e.InnerException.Message;           
                }
            }
            else
            {
                newStation = station;
                newStation.createdAt = System.DateTime.Now;
                newStation.state = true;
                if (station.location == null || station.address == null)
                {
                    if (station.location == null)
                        newStation.location = existStation.location;
                    if (station.address == null)
                        newStation.address = existStation.address;
                }
                try
                {
                    Database.Session.Clear();
                    Database.Session.Update(newStation);
                    Database.Session.Flush();
                }
                catch(Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            return station;
        }


        public Station getStation(Station station)
        {
            station = Database.Session.QueryOver<Station>().Where(x => x.stationName == station.stationName && x.state == true).SingleOrDefault();
            return station;
        }


        public IEnumerable<Station> getAllStation()
        {

            return Database.Session.QueryOver<Station>().Where(x => x.state == true).List();
        }

        public Station delete(Station station)
        {
            Station existStation = Database.Session.QueryOver<Station>().Where(x => x.stationName == station.stationName).SingleOrDefault();
            if (existStation.stationId == 0)
            {
                return null;
            }
            else
            {
                station = existStation;
                station.state = false;
                
                Database.Session.Clear();
                Database.Session.Update(station);
                Database.Session.Flush();
                return station;
            }

        }

    }
}
