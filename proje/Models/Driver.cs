using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class Driver
    {
        public virtual int driverId { get; set; }
        public virtual string nameSurname { get; set; }
        public virtual int picture { get; set; }
        public virtual string tc { get; set; }
        public virtual DateTime birthday { get; set; }
        public virtual string bloodGroup { get; set; }
        public virtual string phone { get; set; }
        public virtual string address { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class DriverMap : ClassMapping<Driver>
    {
        public DriverMap()
        {
            Table("Driver");
            Id(x => x.driverId, x => x.Generator(Generators.Identity));
            Property(x => x.nameSurname, x => x.NotNullable(true));
            Property(x => x.picture, x => x.NotNullable(true));
            Property(x => x.tc, x => x.NotNullable(true));
            Property(x => x.birthday, x => x.NotNullable(true));
            Property(x => x.bloodGroup, x => x.NotNullable(true));
            Property(x => x.phone, x => x.NotNullable(true));
            Property(x => x.address, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));

        }
    }
    public class DriverService
    {
        Driver newDriver = new Driver();
        Object message;
        public Driver saveOrUpdate(Driver driver)

        {
            Driver existDriver = Database.Session.Load<Driver>(driver.driverId);

            if (existDriver.driverId == 0)
            {
                driver.createdAt = System.DateTime.Now;
                driver.state = true;
                try
                {
                    Database.Session.Save(driver);
                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            else
            {

                newDriver = driver;
                newDriver.createdAt = System.DateTime.Now;
                newDriver.state = true;
                if (driver.picture == 0 || driver.phone == null || driver.address == null)
                {

                    if (driver.address == null)
                        newDriver.address = existDriver.address;
                    if (driver.phone == null)
                        newDriver.phone = existDriver.phone;
                    if (driver.picture == 0)
                        newDriver.picture = existDriver.picture;

                }
                try
                {
                    Database.Session.Clear();
                    Database.Session.Update(newDriver);
                    Database.Session.Flush();

                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            return driver;
        }


        public Driver getDriver(Driver driver)
        {
            driver = Database.Session.QueryOver<Driver>().Where(x => x.tc == driver.tc && x.state == true).SingleOrDefault();
            return driver;
        }


        public IEnumerable<Driver> getAllDriver()
        {

            return Database.Session.QueryOver<Driver>().Where(x => x.state == true).List();
        }

    }
}
