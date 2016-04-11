using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace proje
{
  
    public class Database
    {
        private static ISessionFactory _sessionFactory;
        public static String SessionKey = "proje";
        public static ISession Session
        {
            get
            {
                return (ISession)HttpContext.Current.Items[SessionKey];
            }
        }
        public static void Configure()
        {
            var config = new Configuration();
            var mapper = new ModelMapper();
            mapper.AddMapping<BusMap>();
            mapper.AddMapping<BusLocationMap>();
            mapper.AddMapping<BusPersonCountMap>();
            mapper.AddMapping<DriverMap>();
            mapper.AddMapping<DriverPointMap>();
            mapper.AddMapping<LineMap>();
            mapper.AddMapping<ShiftTimeMap>();
            mapper.AddMapping<StationMap>();
            mapper.AddMapping<StationPersonCountMap>();
            mapper.AddMapping<StationRankingMap>();
            mapper.AddMapping<SaveCodeMap>();




            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            _sessionFactory = config.BuildSessionFactory();

        }

        public static void OpenSession()
        {
            
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }


        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;

            if (session != null)
            {
                session.Close();
            }

            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}
