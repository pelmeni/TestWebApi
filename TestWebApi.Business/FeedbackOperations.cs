using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Data;

namespace TestWebApi.Business
{
    public static class FeedbackOperations
    {
        public static IEnumerable<feedback> GetDriverFeedbacks(int driverID)
        {
            using (var ctx = new testEntities())
            {
                return ctx.feedbacks.Where(i => i.driver_id == driverID).ToList();
            }
        }

        public static double? GetDriverAverageFeedback(int driverID)
        {
            using (var ctx = new testEntities())
            {
                return ctx.feedbacks.Where(i => i.driver_id == driverID).Average(i => i.points);
            }
        }

        public static void SetDriverFeedback(int driverID, int points)
        {
            using (var ctx = new testEntities())
            {

                ctx.feedbacks.Add(new feedback()
                {
                    driver_id = driverID,
                    points = points,
                    created = DateTime.Now
                });
                ctx.SaveChanges();
            }
        }
    }
}
