using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using proje.Models;
using System.Globalization;

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

    public class LineService
    {
        Line newLine = new Line();
        Object message;

        public Line saveOrUpdate(Line line)
        {
            Line existLine = Database.Session.Load<Line>(line.lineId);
            if (existLine.lineId == 0)
            {
                line.createdAt = System.DateTime.Now;
                line.state = true;
                try
                {
                    Database.Session.Save(line);
                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            else
            {
                newLine = line;
                newLine.createdAt = System.DateTime.Now;
                newLine.state = true;
                try
                {
                    Database.Session.Clear();
                    Database.Session.Flush();
                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            return line;
        }

        public Line getLine(Line line)
        {
            line = Database.Session.QueryOver<Line>().Where(x => x.lineName == line.lineName && x.state == true).SingleOrDefault();
            return line;
        }
        public IEnumerable<Line> getAllLine()
        {

            return Database.Session.QueryOver<Line>().Where(x => x.state == true).List();
        }

        public Line delete(Line line)
        {
            Line existLine = Database.Session.QueryOver<Line>().Where(x => x.lineName == line.lineName).SingleOrDefault();
            if (existLine.lineId == 0)
            {
                return null;
            }
            else
            {
                line.createdAt = existLine.createdAt;
                line.state = false;
                line.lineName = existLine.lineName;
                line.lineId = existLine.lineId;
                Database.Session.Clear();
                Database.Session.Update(line);
                Database.Session.Flush();
                return line;
            }

        }

    }

    public class OnComingBus
    {
        IEnumerable<ShiftTime> s;
      IList<BusLocation> buslist;
        IList<BusLocation> buslists;
        public IList<BusLocation> GetOnComingBus(Station Station)
        {
            buslist = new List<BusLocation>();
            buslists = new List<BusLocation>();
            IEnumerable<StationRanking> Lines;

            Station stationLocation = Database.Session.QueryOver<Station>().Where(x => x.stationId == Station.stationId).SingleOrDefault();
            String[] Location = stationLocation.location.Split(' ');
            float meridyen = float.Parse(Location[0], CultureInfo.InvariantCulture.NumberFormat);
            float paralel = float.Parse(Location[1], CultureInfo.InvariantCulture.NumberFormat);
            Lines = Database.Session.QueryOver<StationRanking>().Where(x => x.stationId.stationId == stationLocation.stationId).List();
            

            foreach (var i in Lines)
            {
                s = Database.Session.QueryOver<ShiftTime>().Where(x => x.lineId.lineId == i.lineId.lineId).List();
            }

           
           
            foreach (var i in s)
            {
                buslist.Add(Database.Session.QueryOver<BusLocation>().Where(x => x.busId.busId == i.plate.busId && x.state == true).SingleOrDefault());
             
            }
            for (int i = 0; i < buslist.Count; i++)
            {
                string[] location1 = buslist[i].busLocation.Split(' ');
                float meridyen1 = float.Parse(location1[0], CultureInfo.InvariantCulture.NumberFormat);
                float paralel1 = float.Parse(location1[1], CultureInfo.InvariantCulture.NumberFormat);

                double uz = distFrom(paralel, meridyen,  paralel1, meridyen1);
                if (uz < 2)
                {

              IList<BusLocation> busloc=Database.Session.QueryOver<BusLocation>().Where(x => x.busId.busId == buslist[i].busId.busId).OrderBy(x => x.createdAt).Desc.List();
                  String[] buslocc=  busloc[1].busLocation.Split(' ');
                    float meridyen2 = float.Parse(buslocc[0], CultureInfo.InvariantCulture.NumberFormat);
                    float paralel2 = float.Parse(buslocc[1], CultureInfo.InvariantCulture.NumberFormat);
                    if(uz<distFrom(paralel, meridyen, paralel2, meridyen2))
                    buslists.Add( buslist[i]);
                }
            }
            return buslists;
        }

        public static double distFrom(double lat1, double lng1, double lat2, double lng2)
        {
            //double earthRadius = 6371.0;//kilometer
            //double dLat = (Math.PI / 180) * (lat2 - lat1);
            //double dLng = (Math.PI / 180) * (lng2 - lng1);
            //double sindLat = Math.Sin(dLat / 2);
            //double sindLng = Math.Sin(dLng / 2);
            //double a = Math.Pow(sindLat, 2) + Math.Pow(sindLng, 2)
            //        * Math.Cos((Math.PI / 180) * (lat1)) * Math.Cos((Math.PI / 180) * (lat2));
            //double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            //double dist = earthRadius * c;

            //return dist;
            double rad = 6371; //Km cinsinden Dünyanın yarı çapı

            double p1X = lng1 / 180 * Math.PI;
            double p1Y = lat1 / 180 * Math.PI;
            double p2X =lng2 / 180 * Math.PI;
            double p2Y = lat2 / 180 * Math.PI;

            return Math.Acos(Math.Sin(p1Y) * Math.Sin(p2Y) +
                Math.Cos(p1Y) * Math.Cos(p2Y) * Math.Cos(p2X - p1X)) * rad;
        }
    }
}

