using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class RevenueService
    {
        RevenueDao revenuedb;

        public RevenueService()
        {
            this.revenuedb = new RevenueDao();
        }

        public Revenue GetRevenue()
        {
            return revenuedb.GetAllRevenues();
        }
    }
}
