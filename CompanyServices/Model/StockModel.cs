using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyServices.Model
{
    public class StockModel
    {
        public int id { get; set; }
        public int companycode { get; set; }

        public double stockprice { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
    }
}
