using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Data;

namespace TestWebApi.Business
{
    public static class DriverOperations
    {
        public static IEnumerable<driver> GetList()
        {
            using (var ctx = new testEntities())
            {
                return ctx.drivers.ToList();
            }
        }

        public static driver Get(int driverID)
        {
            using (var ctx = new testEntities())
            {
                return ctx.drivers.FirstOrDefault(i=>i.driver_id==driverID);
            }
        }

        private static void Insert(string lastName, string firstname, string passportNo, DateTime bornDate)
        {
            using (var ctx = new testEntities())
            {
                var q= ctx.drivers.AsQueryable();

                if(string.IsNullOrEmpty(passportNo))
                    if(q.Any(i=>i.passport_no_full==passportNo))
                        throw new ApplicationException("Водитель с таким паспортом уже зарегистрирован");

                ctx.drivers.Add(new driver()
                {
                    born_date = bornDate,
                    first_name = firstname,
                    last_name = lastName,
                    passport_no_full = passportNo
                });

                ctx.SaveChanges();


            }
        }

        public static void Update(driver updated)
        {
            using (var ctx = new testEntities())
            {
                var o = ctx.drivers.FirstOrDefault(i=>i.driver_id==updated.driver_id);

                if (o != null)
                {
                    o.passport_no_full = updated.passport_no_full;
                    o.born_date = updated.born_date;
                    o.first_name = updated.first_name;
                    o.last_name = updated.last_name;

                    ctx.SaveChanges();
                }
            }
        }

        public static void Delete(int driverID)
        {
            using (var ctx = new testEntities())
            {
                var o = ctx.drivers.FirstOrDefault(i => i.driver_id == driverID);

                if (o != null)
                {
                    ctx.drivers.Remove(o);

                    ctx.SaveChanges();
                }
            }
        }


        public static void Insert(driver item)
        {
            Insert(item.last_name, item.first_name, item.passport_no_full, item.born_date);
        }
    }
}
