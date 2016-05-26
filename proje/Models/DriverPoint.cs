﻿using NHibernate.Mapping.ByCode;
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
    public class DriverPointService
    {
        DriverPoint newPoint = new DriverPoint();


        public DriverPoint DriverPointSave(DriverPoint driverpoint)
        {
            Driver driver = new Driver();
            driver = Database.Session.QueryOver<Driver>().Where(x => x.tc == driverpoint.driverId.tc && x.state == true).SingleOrDefault();

            if (driver.driverId != 0)
            {
                driverpoint.createdAt = DateTime.Now;
                driverpoint.pointTime = DateTime.Now;
                driverpoint.state = true;
                driverpoint.driverId = driver;
                Database.Session.Save(driverpoint);
                return driverpoint;

            }
            else

                return null;
        }



        public DriverPoint getPoint(DriverPoint point)
        {
            double totalpoint = 0;
            point.driverId = Database.Session.QueryOver<Driver>().Where(x => x.tc == point.driverId.tc).SingleOrDefault();
            IEnumerable<DriverPoint> driverpoint = Database.Session.QueryOver<DriverPoint>().Where(x => x.driverId.driverId == point.driverId.driverId && x.createdAt.Month==DateTime.Now.AddMonths(-1).Month).List();
            foreach (var i in driverpoint)
            {

                totalpoint += i.driverPoint;
            }
            point.driverPoint = Convert.ToInt32(totalpoint / driverpoint.Count());
           
            return point;


        }
    }

}
