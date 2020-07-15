using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppVideo.Model;

namespace WpfAppVideo.ViewModel
{
    public class GestionVideo : IDisposable
    {
        private static EF_TP_MVVM dbContext = new EF_TP_MVVM();

        public static int LoggToBase(string log)
        {
            dbContext.traces.Add(new Trace()
            {
                Info = log
            }
            );
            // return < 0--> NOK
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
