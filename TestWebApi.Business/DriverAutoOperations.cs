using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Data;

namespace TestWebApi.Business
{
    public static class DriverAutoOperations
    {
        public static void AddAutoToDriver(int driverID, int autoID)
        {
            using (var ctx = new testEntities())
            {
                var o = ctx.driver_auto.FirstOrDefault(i => i.driver_id == driverID && i.auto_id == autoID);

                if (o == null)
                {
                    ctx.driver_auto.Add(new driver_auto()
                    {
                        driver_id = driverID,
                        auto_id = autoID
                    });

                    ctx.SaveChanges();
                }
            }
        }

        public static IEnumerable<auto> GetDriverAutos(int driverID)
        {
            using (var ctx = new testEntities())
            {
                var q = from da in ctx.driver_auto
                    join a in ctx.autoes on da.auto_id equals a.auto_id
                    where da.driver_id == driverID
                    select a;

                return q.ToList();
            }
        }

        public static IEnumerable<driver> GetAutoDrivers(int autoID)
        {
            using (var ctx = new testEntities())
            {
                var q = from da in ctx.driver_auto
                        join d in ctx.drivers on da.driver_id equals d.driver_id
                        where da.auto_id == autoID
                        select d;

                return q.ToList();
            }
        }

        public static void RemoveAutoDriver(int autoID, int driverID)
        {
            using (var ctx = new testEntities())
            {
                var o = ctx.driver_auto.FirstOrDefault(i => i.driver_id == driverID && i.auto_id == autoID);

                if (o != null)
                {
                    ctx.driver_auto.Remove(o);

                    ctx.SaveChanges();
                }
            }
            
        }
    }
}
