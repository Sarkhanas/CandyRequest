using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    class Holiday : Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string id_sale { get; set; }
    }
}
