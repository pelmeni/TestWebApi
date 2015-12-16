using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Data;

namespace TestWebApi.Business
{
    public static class AutoOperations
    {
        public static IEnumerable<auto> GetList()
        {
            using (var ctx = new testEntities())
            {
                return ctx.autoes.ToList();
            }
        }

        public static auto Get(int autoID)
        {
            using (var ctx = new testEntities())
            {
                return ctx.autoes.FirstOrDefault(i => i.auto_id == autoID);
            }
        }

        private static void Insert(string mark, string model, string no, string color)
        {
            using (var ctx = new testEntities())
            {
                var q = ctx.autoes.AsQueryable();

                if (string.IsNullOrEmpty(no))
                    throw new ApplicationException("Не указан номер.");
                
                if (string.IsNullOrEmpty(mark))
                    throw new ApplicationException("Не указана марка.");
                
                if (string.IsNullOrEmpty(model))
                    throw new ApplicationException("Не указана модель.");
                
                if (string.IsNullOrEmpty(color))
                    throw new ApplicationException("Не указан цвет.");

                if (q.ToArray().Any(i => i.no.ToLowerInvariant() == no.ToLowerInvariant() && i.mark.ToLowerInvariant() == mark.ToLowerInvariant() && i.model.ToLowerInvariant() == model.ToLowerInvariant()
                    && i.color.ToLowerInvariant() == color.ToLowerInvariant()))
                        throw new ApplicationException("Авто с таки параметрами уже зарегистрирован");

                ctx.autoes.Add(new auto()
                {
                    no = no,
                    model = model,
                    mark = mark,
                    color = color
                });

                ctx.SaveChanges();


            }
        }

        public static void Update(auto updated)
        {
            using (var ctx = new testEntities())
            {
                var o = ctx.autoes.FirstOrDefault(i => i.auto_id == updated.auto_id);

                if (o != null)
                {
                    o.mark = updated.mark;
                    o.model = updated.model;
                    o.no= updated.no;
                    o.color = updated.color;

                    ctx.SaveChanges();
                }
            }
        }

        public static void Delete(int autoID)
        {
            using (var ctx = new testEntities())
            {
                var o = ctx.autoes.FirstOrDefault(i => i.auto_id == autoID);

                if (o != null)
                {
                    ctx.autoes.Remove(o);

                    ctx.SaveChanges();
                }
            }
        }

        public static void Insert(auto item)
        {
            Insert(item.mark, item.model, item.no, item.color);
        }
    }
}
