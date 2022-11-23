using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyServices.Model
{
    public class Company
    {
        public int companycode { get; set; }
        public string companyname { get; set; }
        public string comanyceo { get; set; }
        public int turnover { get; set; }
        public string website { get; set; }
        public string stockexchange { get; set; }
        public bool isdelete { get; set; }
    }
}
