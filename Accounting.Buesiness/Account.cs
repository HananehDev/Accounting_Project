using Accounting.DataLayer.Context;
using Accounting.ViewModels.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Buesiness
{
    public class Account
    {
        public static ReportViewModel ReportForm()
        {
            ReportViewModel rp = new ReportViewModel();
            using (UnitOfWork db = new UnitOfWork())
            {
                DateTime startdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
                DateTime enddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 31);

                var receive = db.AccountingRepository.Get(a => a.TypeId == 1 && a.DateTime >= startdate && a.DateTime<=enddate).Select(a => a.Amount).ToList();
                var pay = db.AccountingRepository.Get(a => a.TypeId == 2 && a.DateTime >= startdate && a.DateTime <= enddate).Select(a => a.Amount).ToList();

                rp.Receive = receive.Sum();
                rp.Pay = pay.Sum(); 
                rp.AccountBalance = (receive.Sum() - pay.Sum());
            }
            return rp;
        }
    }
}
